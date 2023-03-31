using DevExpress.XtraEditors;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;

namespace Maliyet_Takip.Forms.HareketForms.MamulHareketForms
{
    public partial class MaliyetOlusturmaEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlKomut komutlar = new SqlKomut();
        SqlCommand komut;
        SqlDataReader oku;
        private decimal _kalan;
        private int _durum = 0, _cilt;


        public MaliyetOlusturmaEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            txtKod.Text = numara.MaliyetNumarasi();
            DataLayoutControl = aDataLayoutControl;
            if (_ac)
            {
                HareketGetir(_id);
                CiltNumarasi();
            }
            else
            {
                _cilt = DateTime.Now.Month - 1;
                CiltNumarasi();
            }
            txtMiktar.Enabled = false;
            tglHammaddeDurum.IsOn = false;
            EventsLoad();
        }

        private void CiltNumarasi()
        {
            try
            {
                
                SqlCommand komut = new SqlCommand("Select * from Cilt where Id='"+_cilt+"'", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                txtCilt.Text = oku["CiltAdi"].ToString();
                komut.Dispose();
                baglan.bgl(false);
            }
            catch (Exception)
            {
                baglan.bgl(false);
            }

        }

        private void HareketGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Maliyetler where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    _cilt = Convert.ToInt32(oku["CiltId"]);
                    txtKod.Text = oku["Kod"].ToString();
                    txtMamul.Id = Convert.ToInt32(oku["MamulId"].ToString());
                    txtUretilenMiktar.EditValue= oku["Miktar"].ToString();
                    txtAciklama.Text = oku["Aciklama"].ToString();
                    txtTarih.EditValue = (DateTime)oku["EvrakTarihi"];
                }
                komut.Dispose();
                baglan.bgl(false);
                CiltNumarasi();
                string a = txtMamul.Id.ToString();
                if (!string.IsNullOrEmpty(a))
                {
                    komut = new SqlCommand("Select * from Mamuller where Id = '" + txtMamul.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtMamul.Text = oku["StokAdi"].ToString();
                    }
                    komut.Dispose();
                    baglan.bgl(false);
                }

                DataSet ds = komutlar.Dataset("Select * from VW_HammaddeHareketleri where MaliyetId = '" + _id + "' and GCKodu='Maliyet'", baglan.bgl());
                var lst = ds.Tables[0];

                grid.DataSource = lst;
                grid.EndUpdate();
                baglan.bgl(false);

                DataSet ds2 = komutlar.Dataset("Select * from VW_GiderHareketleri where EvrakId = '" + _id + "'", baglan.bgl());
                var lst2 = ds2.Tables[0];

                gridControl1.DataSource = lst2;
                gridControl1.EndUpdate();
                baglan.bgl(false);

            }
            catch (System.Exception ex)
            {
                komut.Dispose();
                baglan.bgl(false);
                mesajlar.Hata(ex);
            }
        }

        protected override bool Kaydet()
        {
            if (txtKod.Text != "")
            {
                if (txtMamul.Text != "")
                {
                    if (txtTarih.Text != "")
                    {
                        var dr = mesajlar.EvetSeciliEvetHayir(txtMamul.Text + " için maliyet işlemini onaylıyor musunuz?", "Uyarı");
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                if (!_ac)
                                {
                                    komut = new SqlCommand("insert into Maliyetler (Kod, EvrakTuru, DonemId, BirimId, MamulId, EvrakTarihi, Miktar, DirekMalzemeGider, EndirekMalzemeGider, MaliyetToplami, BirimMaliyetTutari, Aciklama, SaveDate, SaveUser, GCKodu, CiltId, Sayi) values (@Kod, @EvrakTuru, @DonemId, @BirimId, @MamulId, @EvrakTarihi, @Miktar, @DirekMalzemeGider, @EndirekMalzemeGider, @MaliyetToplami, @BirimMaliyetTutari, @Aciklama, @SaveDate, @SaveUser, @GCKodu, @CiltId, @Sayi)", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@EvrakTuru", "Maliyet Oluşturma");
                                    komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                                    komut.Parameters.AddWithValue("@BirimId", AnaForm._birimId);
                                    komut.Parameters.AddWithValue("@MamulId", txtMamul.Id);
                                    komut.Parameters.AddWithValue("@EvrakTarihi", txtTarih.EditValue);
                                    komut.Parameters.AddWithValue("@Miktar", Convert.ToDecimal(txtUretilenMiktar.Text));
                                    komut.Parameters.AddWithValue("@DirekMalzemeGider", Convert.ToDecimal(txtIlkMaddeveMalzemeGiderleri.Text));
                                    komut.Parameters.AddWithValue("@EndirekMalzemeGider", Convert.ToDecimal(txtEndirekIlkMaddeveMalzemeGiderleri.Text));
                                    komut.Parameters.AddWithValue("@MaliyetToplami", Convert.ToDecimal(txtToplam.Text));
                                    komut.Parameters.AddWithValue("@BirimMaliyetTutari", Convert.ToDecimal(txtBirimMaliyet.Text));
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                                    komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                                    komut.Parameters.AddWithValue("@GCKodu", "Maliyet");
                                    komut.Parameters.AddWithValue("@CiltId", _cilt);
                                    komut.Parameters.AddWithValue("@Sayi", txtKod.Text);
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    komut = new SqlCommand("Select * from Maliyetler order by Id desc", baglan.bgl());
                                    oku = komut.ExecuteReader();
                                    oku.Read();
                                    AnaForm._evrakId = Convert.ToInt32(oku["Id"]);
                                    oku.Dispose();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    TabloKaydet(AnaForm._evrakId);
                                }
                                else
                                {

                                    komut = new SqlCommand("update Maliyetler set Kod=@Kod, EvrakTuru=@EvrakTuru, DonemId=@DonemId, BirimId=@BirimId, MamulId=@MamulId, EvrakTarihi=@EvrakTarihi, Miktar=@Miktar, DirekMalzemeGider=@DirekMalzemeGider, EndirekMalzemeGider=@EndirekMalzemeGider, MaliyetToplami=@MaliyetToplami, BirimMaliyetTutari=@BirimMaliyetTutari, Aciklama=@Aciklama, EditDate=@EditDate, EditUser=@EditUser, GCKodu=@GCKodu, CiltId=@CiltId, Sayi=@Sayi where Id=@Id", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@EvrakTuru", "Maliyet Oluşturma");
                                    komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                                    komut.Parameters.AddWithValue("@BirimId", AnaForm._birimId);
                                    komut.Parameters.AddWithValue("@MamulId", txtMamul.Id);
                                    komut.Parameters.AddWithValue("@EvrakTarihi", txtTarih.EditValue);
                                    komut.Parameters.AddWithValue("@Miktar", Convert.ToDecimal(txtUretilenMiktar.Text));
                                    komut.Parameters.AddWithValue("@DirekMalzemeGider", Convert.ToDecimal(txtIlkMaddeveMalzemeGiderleri.Text));
                                    komut.Parameters.AddWithValue("@EndirekMalzemeGider", Convert.ToDecimal(txtEndirekIlkMaddeveMalzemeGiderleri.Text));
                                    komut.Parameters.AddWithValue("@MaliyetToplami", Convert.ToDecimal(txtToplam.Text));
                                    komut.Parameters.AddWithValue("@BirimMaliyetTutari", Convert.ToDecimal(txtBirimMaliyet.Text));
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                                    komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                                    komut.Parameters.AddWithValue("@GCKodu", "Maliyet");
                                    komut.Parameters.AddWithValue("@CiltId", _cilt);
                                    komut.Parameters.AddWithValue("@Sayi", txtKod.Text);
                                    komut.Parameters.AddWithValue("@Id", _id);
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    komut = new SqlCommand("Delete from HammaddeHareketleri where MaliyetId = '" + _id + "'", baglan.bgl());
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    komut = new SqlCommand("Delete from MamulHareketleri where EvrakId = '" + _id + "'", baglan.bgl());
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    komut = new SqlCommand("Delete from GiderHareketleri where EvrakId = '" + _id + "'", baglan.bgl());
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    TabloKaydet(_id);

                                }
                                _kayitSonrasiFormuKapat = true;
                                if (_ac)
                                {

                                    mesajlar.Guncelle(txtMamul.Text + " maliyet kaydı güncellenmiştir.");
                                    AnaForm._evrakId = -1;
                                    return true;
                                }
                                else
                                {

                                    mesajlar.YeniKayit(txtMamul.Text + " maliyet kaydı oluşturulmuştur.");
                                    AnaForm._evrakId = -1;
                                    return true;
                                }

                            }
                            catch (System.Exception ex)
                            {
                                mesajlar.Hata(ex);
                                komut.Dispose();
                                baglan.bgl(false);
                            }
                        }
                    }
                    else
                    {
                        komut.Dispose();
                        baglan.bgl(false);
                        mesajlar.Hata("Sevk Tarihi Boş Olamaz!");
                        txtTarih.Focus();
                        return false;
                    }
                }
                else
                {
                    komut.Dispose();
                    baglan.bgl(false);
                    mesajlar.Hata("Maliyet oluşturulacak mamül boş olamaz!");
                    txtMamul.Focus();
                    return false;
                }
            }
            else
            {
                komut.Dispose();
                baglan.bgl(false);
                mesajlar.Hata("Kod Boş Olamaz!");
                txtKod.Focus();
                return false;
            }
            return false;
        }

        private void TabloKaydet(int id)
        {
            for (int i = 0; i < tablo.RowCount; i++)
            {
                komut = new SqlCommand("insert into HammaddeHareketleri (MaliyetId, EvrakId, HammaddeId, GirisYerId, CikisYerId, CikisMiktar, GirisMiktar, GirisTarihi, BirimFiyat, AlisKDV, AraToplam, KDV, Toplam, HareketId, DonemId, SaveDate, SaveUser, GCKodu, Endirekmi) values (@MaliyetId, @EvrakId, @HammaddeId, @GirisYerId, @CikisYerId, @CikisMiktar, @GirisMiktar, @GirisTarihi, @BirimFiyat, @AlisKDV, @AraToplam, @KDV, @Toplam, @HareketId, @DonemId, @SaveDate, @SaveUser, @GCKodu, @Endirekmi)", baglan.bgl());
                komut.Parameters.AddWithValue("@MaliyetId", id);
                komut.Parameters.AddWithValue("@EvrakId", 0);
                komut.Parameters.AddWithValue("@HammaddeId", Convert.ToInt32(tablo.GetRowCellValue(i, "HammaddeId")));
                komut.Parameters.AddWithValue("@GirisYerId", AnaForm._birimId);
                komut.Parameters.AddWithValue("@CikisYerId", AnaForm._birimId);
                komut.Parameters.AddWithValue("@CikisMiktar", Convert.ToDecimal(tablo.GetRowCellValue(i, "CikisMiktar")));
                komut.Parameters.AddWithValue("@GirisMiktar", 0);
                komut.Parameters.AddWithValue("@GirisTarihi", Convert.ToDateTime(tablo.GetRowCellValue(i, "GirisTarihi")).Date);
                komut.Parameters.AddWithValue("@CikisTarihi", txtTarih.EditValue);
                komut.Parameters.AddWithValue("@BirimFiyat", Convert.ToDecimal(tablo.GetRowCellValue(i, "BirimFiyat")));
                komut.Parameters.AddWithValue("@AlisKDV", Convert.ToDecimal(tablo.GetRowCellValue(i, "AlisKDV")));
                komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(tablo.GetRowCellValue(i, "KDV")));
                komut.Parameters.AddWithValue("@AraToplam", Convert.ToDecimal(tablo.GetRowCellValue(i, "AraToplam")));
                komut.Parameters.AddWithValue("@Toplam", Convert.ToDecimal(tablo.GetRowCellValue(i, "Toplam")));
                komut.Parameters.AddWithValue("@HareketId", Convert.ToInt32(tablo.GetRowCellValue(i, "HareketId")));
                komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                komut.Parameters.AddWithValue("@GCKodu", "Maliyet");
                komut.Parameters.AddWithValue("@Endirekmi", bool.Parse(tablo.GetRowCellValue(i, "Endirekmi").ToString()));
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.bgl(false);
            }
            komut = new SqlCommand("Select IDENT_CURRENT('MamulHareketleri') + 1", baglan.bgl());
            int sonId = Convert.ToInt32(komut.ExecuteScalar());
            komut.Dispose();
            baglan.bgl(false);
            komut = new SqlCommand("insert into MamulHareketleri (EvrakId, MamulId, GirisYerId, CikisYerId, CikisMiktar, GirisMiktar, GirisTarihi, BirimFiyat, HareketId, DonemId, SaveDate, SaveUser, GCKodu) values (@EvrakId, @MamulId, @GirisYerId, @CikisYerId, @CikisMiktar, @GirisMiktar, @GirisTarihi, @BirimFiyat, @HareketId, @DonemId, @SaveDate, @SaveUser, @GCKodu)", baglan.bgl());
            komut.Parameters.AddWithValue("@EvrakId", id);
            komut.Parameters.AddWithValue("@MamulId", Convert.ToInt32(txtMamul.Id));
            komut.Parameters.AddWithValue("@GirisYerId", AnaForm._birimId);
            komut.Parameters.AddWithValue("@CikisYerId", 0);
            komut.Parameters.AddWithValue("@CikisMiktar", 0);
            komut.Parameters.AddWithValue("@GirisMiktar", Convert.ToDecimal(txtUretilenMiktar.Text));
            komut.Parameters.AddWithValue("@GirisTarihi", txtTarih.EditValue);
            komut.Parameters.AddWithValue("@BirimFiyat", Convert.ToDecimal(txtBirimMaliyet.Text));
            komut.Parameters.AddWithValue("@HareketId", sonId);
            komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
            komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
            komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
            komut.Parameters.AddWithValue("@GCKodu", "Maliyet");
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglan.bgl(false);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                komut = new SqlCommand("insert into GiderHareketleri (GiderId, Tutar, EvrakId, Aciklama, SaveDate, SaveUser) values (@GiderId, @Tutar, @EvrakId, @Aciklama, @SaveDate, @SaveUser)", baglan.bgl());
                komut.Parameters.AddWithValue("@GiderId", Convert.ToInt32(gridView1.GetRowCellValue(i, "GiderId"))); ;
                komut.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Tutar")));
                komut.Parameters.AddWithValue("@EvrakId", id);
                komut.Parameters.AddWithValue("@Aciklama", Convert.ToString(gridView1.GetRowCellValue(i, "Aciklama")));
                komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.bgl(false);
            }
        }
        protected override void EntityDelete()
        {
            if (_durum==1)
            {
                if (tablo.FocusedRowHandle > -1)
                {
                    DialogResult dr = MessageBox.Show("Hammadde Tablosundan\nSeçili satırı silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {

                        int rowHandle = tablo.FocusedRowHandle;
                        tablo.DeleteRow(rowHandle);
                    }
                }
            }
            else if (_durum==2)
            {
                if (gridView1.FocusedRowHandle > -1)
                {
                    DialogResult dr = MessageBox.Show("Giderler Tabloasundan\nSeçili satırı silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {

                        int rowHandle = gridView1.FocusedRowHandle;
                        gridView1.DeleteRow(rowHandle);
                    }
                }
            }
            else
                mesajlar.Hata("Lütfen ilgili tabloların birinden silinecek kaydı seçiniz!");

            _durum = 0;
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit))
                return;
            else
            {
                try
                {
                    Formlar formlar = new Formlar();

                    if (sender == txtMamul)
                    {
                        formlar.MamullerListFormu(true);
                        txtMamul.Id = AnaForm._secilenId;
                        komut = new SqlCommand("Select * from Mamuller where Id = '" + txtMamul.Id + "'", baglan.bgl());
                        oku = komut.ExecuteReader();
                        while (oku.Read())
                        {
                            txtMamul.EditValue = (oku["StokAdi"]);
                        }
                        oku = null;
                        komut.Dispose();
                        baglan.bgl(false);
                        AnaForm._secilenId = -1;
                    }

                    if (sender == txtStok)
                    {
                        formlar.SayimYerListFormu(true);
                        txtStok.Id = AnaForm._secilenId;
                        komut = new SqlCommand("Select * from VW_SayimListesiYer where Id = '" + txtStok.Id + "' and YER_ID= '" + AnaForm._birimId + "'", baglan.bgl());
                        oku = komut.ExecuteReader();
                        while (oku.Read())
                        {
                            txtStok.EditValue = (oku["URUN_ADI"]);
                            _kalan = Convert.ToDecimal(oku["KALAN_MIKTAR"]);
                            txtMiktar.EditValue = _kalan;
                            
                        }
                        oku = null;
                        komut.Dispose();
                        baglan.bgl(false);
                        AnaForm._secilenId = -1;
                    }
                }
                catch (System.Exception ex)
                {
                    baglan.bgl(false);
                    mesajlar.Hata(ex.Message);
                }

            }

        }




        private void Hesapla()
        {
            try
            {
                decimal direkIlkMaddeAraToplam = 0, enDirekIlkMaddeAraToplam = 0, digerMaliyet=0;
                for (int i = 0; i < tablo.RowCount; i++)
                {
                    if (!string.IsNullOrEmpty(tablo.GetRowCellValue(i, "Endirekmi").ToString()))
                    {
                        if (tablo.GetRowCellValue(i, "Endirekmi").ToString()=="False")
                        {
                            direkIlkMaddeAraToplam += decimal.Parse(tablo.GetRowCellValue(i, "AraToplam").ToString());
                        }
                        else
                        {
                            enDirekIlkMaddeAraToplam += decimal.Parse(tablo.GetRowCellValue(i, "AraToplam").ToString());
                        } 
                    }
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    digerMaliyet += decimal.Parse(gridView1.GetRowCellValue(i, "Tutar").ToString());
                }
                txtIlkMaddeveMalzemeGiderleri.Text = direkIlkMaddeAraToplam.ToString("0.00");
                txtEndirekIlkMaddeveMalzemeGiderleri.Text = enDirekIlkMaddeAraToplam.ToString("0.00");
                txtToplam.Text = (digerMaliyet+direkIlkMaddeAraToplam+enDirekIlkMaddeAraToplam).ToString("0.00");
                txtBirimMaliyet.Text = (Convert.ToDecimal(txtToplam.Text) / Convert.ToDecimal(txtUretilenMiktar.Text)).ToString("0.00");
            }
            catch (System.Exception ex)
            {
                mesajlar.Hata(ex.Message);
            }
        }







        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtMiktar.EditValue) <= _kalan)
            {
                if (txtStok.Id != null && txtStok.Id > 0)
                {
                    int? id = txtStok.Id;
                    List<KullanilacakHammadde> kalanMamul = new List<KullanilacakHammadde>();

                    komut = new SqlCommand("Select * from VW_KalanListesiTarihli where HammaddeId = '" + id + "' and KALAN >0 and GirisYerId = '" + AnaForm._birimId + "' Order By GirisTarihi", baglan.bgl()); // eklenecek
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        kalanMamul.Add(new KullanilacakHammadde
                        {
                            _kalanMiktar = Convert.ToDecimal(oku["KALAN"]),
                            _hammaddeId = Convert.ToInt32(oku["HammaddeId"]),
                            _hareketId = Convert.ToInt32(oku["HareketId"])
                        });
                    }
                    komut.Dispose();
                    baglan.bgl(false);
                    decimal kalan = Convert.ToDecimal(txtMiktar.Text);
                    foreach (var data in kalanMamul)
                    {
                        if (kalan > 0 && data._kalanMiktar >= kalan)
                        {
                            SatirEkle(data._hammaddeId, data._hareketId, kalan);
                            kalan = 0;
                        }
                        else if (kalan > 0 && data._kalanMiktar < kalan)
                        {
                            SatirEkle(data._hammaddeId, data._hareketId, data._kalanMiktar);
                            kalan = kalan - data._kalanMiktar;
                        }
                        else if (kalan == 0)
                        {
                            break;
                        }
                    }
                    txtStok.Id = -1;
                    txtStok.EditValue = "";
                    txtMiktar.EditValue = "0,00";
                    tglHammaddeDurum.IsOn = false;

                }
                else
                {
                    mesajlar.Hata("Hammadde seçimi yapılmamış");
                } 
            }
            else
            {
                mesajlar.Hata("Girdiğiniz "+txtMiktar.Text+ " miktar stoğu aşmaktadır.\nEn fazla: "+_kalan+" sevk edebilirsiniz.");
                txtMiktar.EditValue = _kalan;
            }
        }

        private void SatirEkle(int MamulId, int hareketId, decimal miktar)
        {
            try
            {
                decimal kdvOrani=0, birimFiyat=0, araToplam=0, kdv=0, toplam=0;
                tablo.AddNewRow();
                komut = new SqlCommand("Select * from VW_HammaddeHareketleri where Id = '" + hareketId + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    tablo.SetFocusedRowCellValue("HammaddeId", (oku["HammaddeId"].ToString()));
                    tablo.SetFocusedRowCellValue("Kod", (oku["Kod"].ToString()));
                    tablo.SetFocusedRowCellValue("StokAdi", (oku["StokAdi"].ToString()));
                    tablo.SetFocusedRowCellValue("Birimi", (oku["Birimi"].ToString()));
                    tablo.SetFocusedRowCellValue("Barkodu", (oku["Barkodu"].ToString()));
                    tablo.SetFocusedRowCellValue("BirimFiyat", (oku["BirimFiyat"].ToString()));
                    tablo.SetFocusedRowCellValue("GirisTarihi", ((DateTime)oku["GirisTarihi"]).ToShortDateString());
                    tablo.SetFocusedRowCellValue("HareketId", (oku["HareketId"]).ToString());
                    tablo.SetFocusedRowCellValue("Endirekmi", tglHammaddeDurum.IsOn);
                    //MessageBox.Show((oku["HareketId"]).ToString());
                    birimFiyat = Convert.ToDecimal(oku["BirimFiyat"]);
                    tablo.SetFocusedRowCellValue("AlisKDV", (oku["AlisKDV"].ToString()));
                    kdvOrani = Convert.ToDecimal(oku["AlisKDV"]);
                }
                komut.Dispose();
                baglan.bgl(false);
                araToplam = miktar * birimFiyat;
                kdv = araToplam * kdvOrani / 100;
                toplam = araToplam + kdv;
                tablo.SetFocusedRowCellValue("CikisMiktar", miktar.ToString("0.00"));
                tablo.SetFocusedRowCellValue("AraToplam", araToplam.ToString("0.00"));
                tablo.SetFocusedRowCellValue("KDV", kdv.ToString("0.00"));
                tablo.SetFocusedRowCellValue("Toplam", toplam.ToString("0.00"));
                grid.RefreshDataSource();
                tablo.AddNewRow();
                tablo.DeleteRow(tablo.FocusedRowHandle);

            }
            catch (Exception e)
            {
                baglan.bgl(false);
                mesajlar.Hata(e);
            }

            
        }




        private void txtStok_EditValueChanged(object sender, EventArgs e)
        {
            if (txtStok.Id>0)
            {
                txtMiktar.Enabled = true;
            }
            else
            {
                txtMiktar.Enabled = false;
            }
        }

        private void txtMiktar_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void tablo_RowCountChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void btnGiderSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Formlar formlar = new Formlar();
            formlar.GiderlerListFormu(true);
            int id = AnaForm._secilenId;
            bool var = false;
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, "Id")) == id)
                {
                    var = true;
                }
            }
            if (id > 0 && var == false)
            {
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("Tutar", "0.00");
                
                komut = new SqlCommand("Select * from Giderler where Id = '" + id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    gridView1.SetFocusedRowCellValue("GiderId", (oku["Id"].ToString()));
                    gridView1.SetFocusedRowCellValue("Kod", (oku["Kod"].ToString()));
                    gridView1.SetFocusedRowCellValue("GiderAdi", (oku["GiderAdi"].ToString()));

                }
                komut.Dispose();
                baglan.bgl(false);
            }
            else
            {
                mesajlar.Hata("Daha önce bu gider eklenmiş");
            }

            AnaForm._secilenId = -1;
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void txtUretilenMiktar_EditValueChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void tablo_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
               
                string gidervarmi = tablo.GetRowCellDisplayText(e.RowHandle, "Endirekmi");

                if (gidervarmi =="True")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;

                }

            }
        }

        private void tablo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle>=0)
            {
                _durum = 1;
            }
        }


        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                _durum = 2;
            }
        }
    }
}