using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.DonemForms
{
    public partial class DonemEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlCommand komut; 
        SqlDataReader oku;

        public DonemEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            DataLayoutControl = aDataLayoutControl;
            txtKod.Enabled = false;
            txtKod.Text = numara.DonemNumarasi();
            txtDonem.EditValue= numara.DonemNumarasi();
            if (_ac)
            {
                DonemGetir(_id);
            }

            // ShowItems = new BarItem[] {btnYeni, };
            EventsLoad();
        }

        private void DonemGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Donemler where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    txtKod.Text = oku["Kod"].ToString();
                    txtDonem.Text = oku["DonemAdi"].ToString();
                    txtAciklama.Text = oku["Aciklama"].ToString();
                }
                komut.Dispose();
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
            if (txtDonem.Text != "")
            {

                var dr = mesajlar.EvetSeciliEvetHayir(txtDonem.Text + " dönem kaydını onaylıyor musunuz?", "Uyarı");
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (!_ac)
                        {
                            int sayac = 0;
                            komut = new SqlCommand("Select * from Donemler where DonemAdi = '" + txtDonem.Text + "'", baglan.bgl());
                            oku = komut.ExecuteReader();
                            while (oku.Read())
                            {
                                sayac++;
                            }
                            if (sayac > 0)
                            {
                                mesajlar.Hata("Dönem adıyla daha önce bir görev oluşturulmuş farklı bir görev adı giriniz");
                                txtDonem.Focus();
                                return false;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                        }

                        if (!_ac)
                        {
                            komut = new SqlCommand("insert into Donemler (DonemAdi, Durum, SaveDate, SaveUser, Aciklama) values (@DonemAdi, @Durum, @SaveDate, @SaveUser, @Aciklama)", baglan.bgl());
                            komut.Parameters.AddWithValue("@DonemAdi", txtDonem.Text.ToUpper());
                            komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                            komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglan.bgl(false);
                        }
                        else
                        {

                            komut = new SqlCommand("update Donemler set DonemAdi=@DonemAdi, Durum=@Durum,EditDate=@EditDate, EditUser=@EditUser, Aciklama=@Aciklama where Id=@Id", baglan.bgl());
                            komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                            komut.Parameters.AddWithValue("@DonemAdi", txtDonem.Text.ToUpper());
                            komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                            komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@Id", _id);
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglan.bgl(false);
                        }
                        _kayitSonrasiFormuKapat = true;
                        if (_ac)
                        {
                            komut.Dispose();
                            baglan.bgl(false);
                            mesajlar.Guncelle(txtDonem.Text + " dönemi güncellenmiştir.");
                            return true;
                        }
                        else
                        {
                            komut.Dispose();
                            baglan.bgl(false);
                            mesajlar.YeniKayit(txtDonem.Text + " dönemi oluşturulmuştur.");
                            return true;
                        }

                    }
                    catch (System.Exception ex)
                    {
                        komut.Dispose();
                        baglan.bgl(false);
                        mesajlar.Hata(ex);
                    }
                }
            }
            else
            {
                komut.Dispose();
                baglan.bgl(false);
                mesajlar.Hata("Dönem Boş Olamaz!");
                txtDonem.Focus();
                return false;
            }
            komut.Dispose();
            baglan.bgl(false);
            return false;
        }
    }
}