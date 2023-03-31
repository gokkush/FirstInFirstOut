using DevExpress.XtraEditors;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Maliyet_Takip.Forms.HareketForms.HammaddeHareketForms
{
    public partial class DepolarArasiSevkEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlKomut komutlar = new SqlKomut();
        SqlCommand komut;
        SqlDataReader oku;
        private decimal _kalan;


        public DepolarArasiSevkEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            txtKod.Text = numara.SevkNumarasi();
            DataLayoutControl = aDataLayoutControl;
            if (_ac)
            {
                HareketGetir(_id);
                txtKod.Enabled = false;
            }
            txtMiktar.Enabled = false;
            EventsLoad();
        }

        private void HareketGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Evraklar where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    txtKod.Text = oku["Kod"].ToString();
                    txtDepo.Id = Convert.ToInt32(oku["BirimId"].ToString());
                    txtAciklama.Text = oku["Aciklama"].ToString();
                    //txtAraToplam.Text = oku["AraToplam"].ToString();
                    //txtKDV.Text = oku["KDV"].ToString();
                    //txtToplam.Text = oku["Toplam"].ToString();
                    txtTarih.EditValue = (DateTime)oku["EvrakTarihi"];
                }
                komut.Dispose();
                baglan.bgl(false);

                string a = txtDepo.Id.ToString();
                if (!string.IsNullOrEmpty(a))
                {
                    komut = new SqlCommand("Select * from Birimler where Id = '" + txtDepo.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtDepo.Text = oku["Birim_Adi"].ToString();
                    }
                    komut.Dispose();
                    baglan.bgl(false);
                }

                DataSet ds = komutlar.Dataset("Select * from VW_HammaddeHareketleri where EvrakId = '" + _id + "' and GCKodu='Sevk'", baglan.bgl());
                var lst = ds.Tables[0];

                grid.DataSource = lst;
                grid.EndUpdate();
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
                if (txtDepo.Text != "")
                {
                    if (txtTarih.Text != "")
                    {
                        var dr = mesajlar.EvetSeciliEvetHayir(txtDepo.Text + " deposundan sevk işlemini onaylıyor musunuz?", "Uyarı");
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                if (!_ac)
                                {
                                    komut = new SqlCommand("insert into Evraklar (Kod, EvrakTuru, DonemId, BirimId, EvrakTarihi, AraToplam, KDV, Toplam, Aciklama, SaveDate, SaveUser, GCKodu) values (@Kod, @EvrakTuru, @DonemId, @BirimId, @EvrakTarihi, @AraToplam, @KDV, @Toplam, @Aciklama, @SaveDate, @SaveUser, @GCKodu)", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@EvrakTuru", "Depolar Arası Sevk");
                                    komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                                    komut.Parameters.AddWithValue("@BirimId", txtDepo.Id);
                                    komut.Parameters.AddWithValue("@EvrakTarihi", txtTarih.EditValue);
                                    komut.Parameters.AddWithValue("@AraToplam", Convert.ToDecimal(txtAraToplam.Text));
                                    komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(txtKDV.Text));
                                    komut.Parameters.AddWithValue("@Toplam", Convert.ToDecimal(txtToplam.Text));
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                                    komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                                    komut.Parameters.AddWithValue("@GCKodu", "Sevk");
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    komut = new SqlCommand("Select * from Evraklar order by Id desc", baglan.bgl());
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

                                    komut = new SqlCommand("update Evraklar set Kod=@Kod, EvrakTuru=@EvrakTuru, DonemId=@DonemId, BirimId=@BirimId, EvrakTarihi=@EvrakTarihi, AraToplam=@AraToplam, KDV=@KDV, Toplam=@Toplam, Aciklama=@Aciklama, EditDate=@EditDate, EditUser=@EditUser, GCKodu=@GCKodu where Id=@Id", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@EvrakTuru", "Depolar Arası Sevk");
                                    komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                                    komut.Parameters.AddWithValue("@BirimId", txtDepo.Id);
                                    komut.Parameters.AddWithValue("@EvrakTarihi", txtTarih.EditValue);
                                    komut.Parameters.AddWithValue("@AraToplam", Convert.ToDecimal(txtAraToplam.Text));
                                    komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(txtKDV.Text));
                                    komut.Parameters.AddWithValue("@Toplam", Convert.ToDecimal(txtToplam.Text));
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                                    komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                                    komut.Parameters.AddWithValue("@GCKodu", "Sevk");
                                    komut.Parameters.AddWithValue("@Id", _id);
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    komut = new SqlCommand("Delete from HammaddeHareketleri where EvrakId = '" + _id + "'", baglan.bgl());
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    TabloKaydet(_id);

                                }
                                _kayitSonrasiFormuKapat = true;
                                if (_ac)
                                {

                                    mesajlar.Guncelle(txtDepo.Text + " deposuna sevk güncellenmiştir.");
                                    AnaForm._evrakId = -1;
                                    return true;
                                }
                                else
                                {

                                    mesajlar.YeniKayit(txtDepo.Text + " deposuna sevk oluşturulmuştur.");
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
                    mesajlar.Hata("Depo Boş Olamaz!");
                    txtDepo.Focus();
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
                komut = new SqlCommand("insert into HammaddeHareketleri (EvrakId, HammaddeId, GirisYerId, CikisYerId, CikisMiktar, GirisMiktar, GirisTarihi, BirimFiyat, AlisKDV, AraToplam, KDV, Toplam, HareketId, DonemId, SaveDate, SaveUser, GCKodu) values (@EvrakId, @HammaddeId, @GirisYerId, @CikisYerId, @CikisMiktar, @GirisMiktar, @GirisTarihi, @BirimFiyat, @AlisKDV, @AraToplam, @KDV, @Toplam, @HareketId, @DonemId, @SaveDate, @SaveUser, @GCKodu)", baglan.bgl());
                komut.Parameters.AddWithValue("@EvrakId", id);
                komut.Parameters.AddWithValue("@HammaddeId", Convert.ToInt32(tablo.GetRowCellValue(i, "HammaddeId")));
                komut.Parameters.AddWithValue("@GirisYerId", AnaForm._birimId);
                komut.Parameters.AddWithValue("@CikisYerId", txtDepo.Id);
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
                komut.Parameters.AddWithValue("@GCKodu", "Sevk");
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.bgl(false);
            }
            for (int i = 0; i < tablo.RowCount; i++)
            {
                komut = new SqlCommand("Select IDENT_CURRENT('HammaddeHareketleri') + 1", baglan.bgl());
                int sonId = Convert.ToInt32(komut.ExecuteScalar());
                komut.Dispose();
                baglan.bgl(false);
                komut = new SqlCommand("insert into HammaddeHareketleri (EvrakId, HammaddeId, GirisYerId, CikisYerId, CikisMiktar, GirisMiktar, GirisTarihi, BirimFiyat, AlisKDV, AraToplam, KDV, Toplam, HareketId, DonemId, SaveDate, SaveUser, GCKodu) values (@EvrakId, @HammaddeId, @GirisYerId, @CikisYerId, @CikisMiktar, @GirisMiktar, @GirisTarihi, @BirimFiyat, @AlisKDV, @AraToplam, @KDV, @Toplam, @HareketId, @DonemId, @SaveDate, @SaveUser, @GCKodu)", baglan.bgl());
                komut.Parameters.AddWithValue("@EvrakId", id);
                komut.Parameters.AddWithValue("@HammaddeId", Convert.ToInt32(tablo.GetRowCellValue(i, "HammaddeId")));
                komut.Parameters.AddWithValue("@GirisYerId", txtDepo.Id);
                komut.Parameters.AddWithValue("@CikisYerId", 0);
                komut.Parameters.AddWithValue("@CikisMiktar", 0);
                komut.Parameters.AddWithValue("@GirisMiktar", Convert.ToDecimal(tablo.GetRowCellValue(i, "CikisMiktar")));
                komut.Parameters.AddWithValue("@GirisTarihi", Convert.ToDateTime(tablo.GetRowCellValue(i, "GirisTarihi")).Date);
                komut.Parameters.AddWithValue("@BirimFiyat", Convert.ToDecimal(tablo.GetRowCellValue(i, "BirimFiyat")));
                komut.Parameters.AddWithValue("@AlisKDV", Convert.ToDecimal(tablo.GetRowCellValue(i, "AlisKDV")));
                komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(tablo.GetRowCellValue(i, "KDV")));
                komut.Parameters.AddWithValue("@AraToplam", Convert.ToDecimal(tablo.GetRowCellValue(i, "AraToplam")));
                komut.Parameters.AddWithValue("@Toplam", Convert.ToDecimal(tablo.GetRowCellValue(i, "Toplam")));
                komut.Parameters.AddWithValue("@HareketId", sonId);
                komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                komut.Parameters.AddWithValue("@GCKodu", "DepoyaGiris");
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.bgl(false);
            }
        }
        protected override void EntityDelete()
        {
            if (tablo.FocusedRowHandle > -1)
            {
                DialogResult dr = MessageBox.Show("Seçili satırı silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    int rowHandle = tablo.FocusedRowHandle;
                    tablo.DeleteRow(rowHandle);
                }
            }
            else
                mesajlar.Hata("Lütfen listeden silinecek kaydı seçiniz!");
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

                    if (sender == txtDepo)
                    {
                        formlar.BirimlerListFormu(true);
                        txtDepo.Id = AnaForm._secilenId;
                        komut = new SqlCommand("Select * from Birimler where Id = '" + txtDepo.Id + "'", baglan.bgl());
                        oku = komut.ExecuteReader();
                        while (oku.Read())
                        {
                            txtDepo.EditValue = (oku["Birim_Adi"]);
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
                decimal birimFiyat = 0, kdv = 0, araToplam = 0, miktar = 0, geneltoplam = 0;
                for (int i = 0; i < tablo.RowCount; i++)
                {

                    miktar = decimal.Parse(tablo.GetRowCellValue(i, "CikisMiktar").ToString());
                    birimFiyat = decimal.Parse(tablo.GetRowCellValue(i, "BirimFiyat").ToString());
                    araToplam += miktar * birimFiyat;
                    kdv = decimal.Parse(tablo.GetRowCellValue(i, "KDV").ToString()) / 100 + 1;
                    geneltoplam += decimal.Parse(tablo.GetRowCellValue(i, "Toplam").ToString());
                }
                txtAraToplam.Text = araToplam.ToString("0.00");
                txtKDV.Text = (geneltoplam - araToplam).ToString("0.00");
                txtToplam.Text = geneltoplam.ToString("0.00");
            }
            catch (System.Exception ex)
            {
                mesajlar.Hata(ex.Message);
            }
        }





        private void btnStokSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Formlar formlar = new Formlar();
            formlar.SayimYerListFormu(true);
            int id = AnaForm._secilenId;

            bool var = false;
            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                if (Convert.ToInt32(tablo.GetRowCellValue(i, "HammaddeId")) == id)
                {
                    var = true;
                }
            }
            if (id > 0 && var == false)
            {
                tablo.AddNewRow();
                tablo.SetFocusedRowCellValue("CikisMiktar", "0.00");
                komut = new SqlCommand("Select * from Hammaddeler where Id = '" + id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    tablo.SetFocusedRowCellValue("HammaddeId", (oku["Id"].ToString()));
                    tablo.SetFocusedRowCellValue("Barkodu", (oku["Barkodu"].ToString()));
                    tablo.SetFocusedRowCellValue("StokAdi", (oku["StokAdi"].ToString()));
                    tablo.SetFocusedRowCellValue("Birimi", (oku["Birimi"].ToString()));
                    tablo.SetFocusedRowCellValue("AlisKDV", (oku["AlisKDV"].ToString()));

                }
                komut.Dispose();
                baglan.bgl(false);
            }
            else
            {
                mesajlar.Hata("Daha önce bu hammadde eklenmiş");
            }

            AnaForm._secilenId = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtMiktar.EditValue) <= _kalan)
            {
                if (txtStok.Id != null && txtStok.Id > 0)
                {
                    int? id = txtStok.Id;
                    List<KalanHammadde> kalanHammadde = new List<KalanHammadde>();

                    komut = new SqlCommand("Select * from VW_KalanListesiTarihli where HammaddeId = '" + id + "' and KALAN >0 and GirisYerId = '" + AnaForm._birimId + "' Order By GirisTarihi", baglan.bgl()); // eklenecek
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        kalanHammadde.Add(new KalanHammadde
                        {
                            _kalanMiktar = Convert.ToDecimal(oku["KALAN"]),
                            _hammaddeId = Convert.ToInt32(oku["HammaddeId"]),
                            _hareketId = Convert.ToInt32(oku["HareketId"])
                        });
                    }
                    komut.Dispose();
                    baglan.bgl(false);
                    decimal kalan = Convert.ToDecimal(txtMiktar.Text);
                    foreach (var data in kalanHammadde)
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

        private void SatirEkle(int hammaddeId, int hareketId, decimal miktar)
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
    }
}