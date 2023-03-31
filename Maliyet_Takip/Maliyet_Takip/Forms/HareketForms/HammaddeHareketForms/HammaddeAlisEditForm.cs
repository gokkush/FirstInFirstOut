using DevExpress.XtraEditors;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Maliyet_Takip.Forms.HareketForms.HammaddeHareketForms
{
    public partial class HammaddeAlisEditForm : BaseEditForm
    {

        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlKomut komutlar = new SqlKomut();
        SqlCommand komut;
        SqlDataReader oku;
        int sayac = 0;


        public HammaddeAlisEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            txtKod.Text = numara.StokNumarasi();
            DataLayoutControl = aDataLayoutControl;
            if (_ac)
            {
                HareketGetir(_id);
                txtKod.Enabled = false;
            }
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
                    txtCari.Id = Convert.ToInt32(oku["CariId"].ToString());
                    txtAciklama.Text= oku["Aciklama"].ToString();
                    txtAraToplam.Text= oku["AraToplam"].ToString();
                    txtKDV.Text= oku["KDV"].ToString();
                    txtToplam.Text = oku["Toplam"].ToString();
                    txtEvrakTarihi.EditValue = (DateTime)oku["EvrakTarihi"];
                }
                komut.Dispose();
                baglan.bgl(false);

                string a = txtCari.Id.ToString();
                if (!string.IsNullOrEmpty(a))
                {
                    komut = new SqlCommand("Select * from Cariler where Id = '" + txtCari.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtCari.Text = oku["CariAdi"].ToString();
                    }
                    komut.Dispose();
                    baglan.bgl(false);
                }

                DataSet ds = komutlar.Dataset("Select * from VW_HammaddeHareketleri where EvrakId = '" + _id + "'", baglan.bgl());
                var lst = ds.Tables[0];

                gridControl1.DataSource = lst;
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
                if (txtCari.Text != "")
                {
                    if (txtEvrakTarihi.Text != "")
                    {
                        var dr = mesajlar.EvetSeciliEvetHayir(txtCari.Text + "den hammadde alım işlemini onaylıyor musunuz?", "Uyarı");
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                               
                                if (!_ac)
                                {
                                    komut = new SqlCommand("insert into Evraklar (Kod, EvrakTuru, DonemId, CariId, EvrakTarihi, AraToplam, KDV, Toplam, Aciklama, SaveDate, SaveUser, GCKodu) values (@Kod, @EvrakTuru, @DonemId, @CariId, @EvrakTarihi, @AraToplam, @KDV, @Toplam, @Aciklama, @SaveDate, @SaveUser, @GCKodu)", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@EvrakTuru", "Hammadde Alışları");
                                    komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                                    komut.Parameters.AddWithValue("@CariId", txtCari.Id );
                                    komut.Parameters.AddWithValue("@EvrakTarihi", txtEvrakTarihi.EditValue);
                                    komut.Parameters.AddWithValue("@AraToplam",Convert.ToDecimal(txtAraToplam.Text));
                                    komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(txtKDV.Text));
                                    komut.Parameters.AddWithValue("@Toplam", Convert.ToDecimal(txtToplam.Text));
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                                    komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                                    komut.Parameters.AddWithValue("@GCKodu", "Alis");
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
                                    TabloKaydet();
                                    
                                }
                                else
                                {

                                    komut = new SqlCommand("update Evraklar set Kod=@Kod, EvrakTuru=@EvrakTuru, DonemId=@DonemId, CariId=@CariId, EvrakTarihi=@EvrakTarihi, AraToplam=@AraToplam, KDV=@KDV, Toplam=@Toplam, Aciklama=@Aciklama, EditDate=@EditDate, EditUser=@EditUser, GCKOdu=@GCKodu where Id=@Id", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@EvrakTuru", "Hammadde Alışları");
                                    komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                                    komut.Parameters.AddWithValue("@CariId", txtCari.Id);
                                    komut.Parameters.AddWithValue("@EvrakTarihi", txtEvrakTarihi.EditValue);
                                    komut.Parameters.AddWithValue("@AraToplam", Convert.ToDecimal(txtAraToplam.Text));
                                    komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(txtKDV.Text));
                                    komut.Parameters.AddWithValue("@Toplam", Convert.ToDecimal(txtToplam.Text));
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                                    komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                                    komut.Parameters.AddWithValue("@GCKodu", "Alis");
                                    komut.Parameters.AddWithValue("@Id", _id);
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    komut = new SqlCommand("Delete from HammaddeHareketleri where EvrakId = '" + _id + "'", baglan.bgl());
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    TabloKaydet();

                                }
                                _kayitSonrasiFormuKapat = true;
                                if (_ac)
                                {

                                    mesajlar.Guncelle(txtCari.Text + " carisinden giriş güncellenmiştir.");
                                    AnaForm._evrakId = -1;
                                    return true;
                                }
                                else
                                {

                                    mesajlar.YeniKayit(txtCari.Text + " carisinden giriş oluşturulmuştur.");
                                    AnaForm._evrakId = -1;
                                    return true;
                                }

                            }
                            catch (System.Exception ex)
                            {
                                mesajlar.Hata("İşlem görmüş kayıtda düzeltme yapamazsınız.\n" + ex.Message);
                                komut.Dispose();
                                baglan.bgl(false);
                            }
                        }
                    }
                    else
                    {
                        komut.Dispose();
                        baglan.bgl(false);
                        mesajlar.Hata("Evrak Tarihi Boş Olamaz!");
                        txtEvrakTarihi.Focus();
                        return false;
                    }
                }
                else
                {
                    komut.Dispose();
                    baglan.bgl(false);
                    mesajlar.Hata("Cari Boş Olamaz!");
                    txtCari.Focus();
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

        private void TabloKaydet()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                komut = new SqlCommand("Select IDENT_CURRENT('HammaddeHareketleri') + 1", baglan.bgl());
                int sonId = Convert.ToInt32(komut.ExecuteScalar());
                komut.Dispose();
                baglan.bgl(false);
                komut = new SqlCommand("insert into HammaddeHareketleri (EvrakId, HammaddeId, GirisMiktar, CikisMiktar, GirisTarihi, BirimFiyat, AlisKDV, KDV, AraToplam, Toplam, DonemId, GirisYerId, CikisYerId, SaveDate, SaveUser, GCKodu, HareketId) values (@EvrakId, @HammaddeId, @GirisMiktar, @CikisMiktar, @GirisTarihi, @BirimFiyat, @AlisKDV, @KDV, @AraToplam, @Toplam, @DonemId, @GirisYerId, @CikisYerId, @SaveDate, @SaveUser, @GCKodu, @HareketId)", baglan.bgl());
                komut.Parameters.AddWithValue("@EvrakId", AnaForm._evrakId);
                komut.Parameters.AddWithValue("@HammaddeId", Convert.ToInt32(gridView1.GetRowCellValue(i, "HammaddeId")));
                komut.Parameters.AddWithValue("@GirisMiktar", Convert.ToDecimal(gridView1.GetRowCellValue(i, "GirisMiktar")));
                komut.Parameters.AddWithValue("@CikisMiktar", 0);
                komut.Parameters.AddWithValue("@GirisTarihi", txtEvrakTarihi.EditValue);
                komut.Parameters.AddWithValue("@BirimFiyat", Convert.ToDecimal(gridView1.GetRowCellValue(i, "BirimFiyat")));
                komut.Parameters.AddWithValue("@AlisKDV", Convert.ToDecimal(gridView1.GetRowCellValue(i, "AlisKDV")));
                komut.Parameters.AddWithValue("@KDV", Convert.ToDecimal(gridView1.GetRowCellValue(i, "KDV")));
                komut.Parameters.AddWithValue("@AraToplam", Convert.ToDecimal(gridView1.GetRowCellValue(i, "AraToplam")));
                komut.Parameters.AddWithValue("@Toplam", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Toplam")));
                komut.Parameters.AddWithValue("@DonemId", AnaForm._donemId);
                komut.Parameters.AddWithValue("@GirisYerId", AnaForm._birimId);
                komut.Parameters.AddWithValue("@CikisYerId", 0);
                komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                komut.Parameters.AddWithValue("@GCKodu", "Alis");
                komut.Parameters.AddWithValue("@HareketId", sonId);
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.bgl(false);
            }
        }
        protected override void EntityDelete()
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DialogResult dr = MessageBox.Show("Seçili satırı silmek istediğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    int rowHandle = gridView1.FocusedRowHandle;
                    gridView1.DeleteRow(rowHandle);
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

                    if (sender == txtCari)
                    {
                        formlar.CariListFormu(true);
                        txtCari.Id = AnaForm._secilenId;
                        komut = new SqlCommand("Select * from Cariler where Id = '" + txtCari.Id + "'", baglan.bgl());
                        oku = komut.ExecuteReader();
                        while (oku.Read())
                        {
                            txtCari.EditValue = (oku["CariAdi"]);
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
                for (int i = 0; i < gridView1.RowCount; i++)
                {

                    miktar = decimal.Parse(gridView1.GetRowCellValue(i,"GirisMiktar").ToString());
                    birimFiyat = decimal.Parse(gridView1.GetRowCellValue(i,"BirimFiyat").ToString());
                    araToplam += miktar * birimFiyat;
                    kdv=decimal.Parse(gridView1.GetRowCellValue(i,"AlisKDV").ToString())/100+1;
                    geneltoplam += decimal.Parse(gridView1.GetRowCellValue(i, "AraToplam").ToString()) * kdv;
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
            formlar.StoklarListFormu(true);
            int id = AnaForm._secilenId;
            bool var = false;
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (Convert.ToInt32(gridView1.GetRowCellValue(i, "HammaddeId")) == id)
                {
                    var = true;
                }
            }
            if (id > 0 && var==false)
            {
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("BirimFiyat", "0.00");
                gridView1.SetFocusedRowCellValue("GirisMiktar", "0.00");


                sayac++;
                komut = new SqlCommand("Select * from Hammaddeler where Id = '" + id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    gridView1.SetFocusedRowCellValue("HammaddeId", (oku["Id"].ToString()));
                    gridView1.SetFocusedRowCellValue("Barkodu", (oku["Barkodu"].ToString()));
                    gridView1.SetFocusedRowCellValue("StokAdi", (oku["StokAdi"].ToString()));
                    gridView1.SetFocusedRowCellValue("Birimi", (oku["Birimi"].ToString()));
                    gridView1.SetFocusedRowCellValue("AlisKDV", (oku["AlisKDV"].ToString()));

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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal miktar = 0, birimFiyat = 0, tutar = 0, kdv=0, kdvtutar=0, toplam=0;
                if (e.Column.Name != "colToplam" && e.Column.Name != "colKDV" && e.Column.Name != "colAraToplam"&& gridView1.GetFocusedRowCellValue("GirisMiktar").ToString()!=""&& e.Column.Name != "colAraToplam" && gridView1.GetFocusedRowCellValue("AlisKDV").ToString() != "")
                {
                    miktar = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("GirisMiktar").ToString());
                    birimFiyat = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("BirimFiyat").ToString());
                    kdv = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("AlisKDV").ToString());
                    tutar = miktar * birimFiyat;
                    if (tutar>0&&kdv>0)
                    {
                        kdvtutar = tutar * kdv / 100; 
                    }
                    toplam = tutar + kdvtutar;
                    gridView1.SetFocusedRowCellValue("AraToplam", tutar.ToString());
                    gridView1.SetFocusedRowCellValue("KDV", kdvtutar.ToString());
                    gridView1.SetFocusedRowCellValue("Toplam", toplam.ToString());
                }
                if (tutar > 0)
                    Hesapla();
            }
            catch (System.Exception ex)
            {
                mesajlar.Hata("hata"+ex.Message);
            }
        }

        private void gridView1_RowCountChanged(object sender, System.EventArgs e)
        {
            Hesapla();
        }
    }
}