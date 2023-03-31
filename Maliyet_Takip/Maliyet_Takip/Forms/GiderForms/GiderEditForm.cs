using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.GiderForms
{
    public partial class GiderEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlCommand komut; 
        SqlDataReader oku;

        public GiderEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            DataLayoutControl = aDataLayoutControl;
            txtKod.Text = numara.GiderNumarasi();
            if (_ac)
            {
                GiderGetir(_id);
            }

            // ShowItems = new BarItem[] {btnYeni, };
            EventsLoad();
        }

        private void GiderGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Giderler where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    txtKod.Text = oku["Kod"].ToString();
                    txtGider.Text = oku["GiderAdi"].ToString();
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
            if (txtKod.Text!="")
            {
                if (txtGider.Text != "")
                {

                    var dr = mesajlar.EvetSeciliEvetHayir(txtGider.Text + " gider hesap kaydını onaylıyor musunuz?", "Uyarı");
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            if (!_ac)
                            {
                                int sayac = 0;
                                komut = new SqlCommand("Select * from Giderler where GiderAdi = '" + txtGider.Text + "'", baglan.bgl());
                                oku = komut.ExecuteReader();
                                while (oku.Read())
                                {
                                    sayac++;
                                }
                                if (sayac > 0)
                                {
                                    mesajlar.Hata("Gider adıyla daha önce bir hesap oluşturulmuş farklı bir gider adı giriniz");
                                    txtGider.Focus();
                                    return false;
                                }
                                komut.Dispose();
                                baglan.bgl(false);
                            }

                            if (!_ac)
                            {
                                komut = new SqlCommand("insert into Giderler (Kod, GiderAdi, Durum, SaveDate, SaveUser, Aciklama) values (@Kod, @GiderAdi, @Durum, @SaveDate, @SaveUser, @Aciklama)", baglan.bgl());
                                komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                komut.Parameters.AddWithValue("@GiderAdi", txtGider.Text.ToUpper());
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

                                komut = new SqlCommand("update Giderler set GiderAdi=@GiderAdi, Durum=@Durum,EditDate=@EditDate, EditUser=@EditUser, Aciklama=@Aciklama where Id=@Id", baglan.bgl());
                                komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                komut.Parameters.AddWithValue("@GiderAdi", txtGider.Text.ToUpper());
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
                                mesajlar.Guncelle(txtGider.Text + " gider hesabı güncellenmiştir.");
                                return true;
                            }
                            else
                            {
                                komut.Dispose();
                                baglan.bgl(false);
                                mesajlar.YeniKayit(txtGider.Text + " gider hesabı oluşturulmuştur.");
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
                    mesajlar.Hata("Gider Adı Boş Olamaz!");
                    txtGider.Focus();
                    return false;
                } 
            }
            else
            {
                mesajlar.Hata("Kod Boş Olamaz!");
                txtKod.Focus();
                return false;
            }
            komut.Dispose();
            baglan.bgl(false);
            return false;
        }
    }
}