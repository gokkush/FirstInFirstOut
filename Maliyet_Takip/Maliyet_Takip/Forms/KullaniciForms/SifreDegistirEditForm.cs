using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Maliyet_Takip.Forms.KullaniciForms
{
    public partial class SifreDegistirEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Sifrele sifre = new Sifrele();
        string _eskisifre = "";
        SqlCommand komut;
        SqlDataReader oku;


        public SifreDegistirEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            if (_ac)
            {
                SifreGetir(_id);
            }
            // ShowItems = new BarItem[] { btnYeni, };
            EventsLoad();
        }

        private void SifreGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Kullanicilar where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    _eskisifre =sifre.TextSifreCoz(oku["Sifre"].ToString());
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
            var m = Regex.Match(txtYeniSifre.Text, @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,})");
            if (!m.Success)
                mesajlar.Hata("Şifreniz en az 6 karakter, \nEn az Bir Büyük\nEn az Bir Küçük \n ve rakamlar içermelidir!");
            else
            {
                if (txtEskiSifre.Text == _eskisifre)
                {
                    if (txtYeniSifre.Text != "" && txtYeniSifre.Text.Trim() == txtYeniSifreTekrar.Text.Trim())
                    {
                        try
                        {
                            if (_ac)
                            {
                                komut = new SqlCommand("update Kullanicilar set Sifre=@Sifre, EditUser=@EditUser, EditDate=@EditDate where Id=@Id", baglan.bgl());
                                komut.Parameters.AddWithValue("@Sifre", sifre.TextSifrele(txtYeniSifre.Text));
                                komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                                komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                                komut.Parameters.AddWithValue("@Id", _id);
                                komut.ExecuteNonQuery();
                                mesajlar.Guncelle("Şifreniz güncellenmiştir.");
                                komut.Dispose();
                                baglan.bgl(false);
                                return true;
                            }
                        }
                        catch (Exception e)
                        {
                            komut.Dispose();
                            baglan.bgl(false);
                            mesajlar.Hata(e);
                        }
                    }
                    else
                    {
                        komut.Dispose();
                        baglan.bgl(false);
                        mesajlar.Hata("Yeni Şifre Alanı Boş Olamaz veya Girdiğiniz yeni şifreler uyuşmamaktadır!");
                        txtEskiSifre.Focus();
                        return false;
                    }
                }
                else
                {
                    komut.Dispose();
                    baglan.bgl(false);
                    mesajlar.Hata("Eski Şifreniz Eşleşmiyor");
                    txtEskiSifre.Focus();
                    return false;
                } 
            }
            komut.Dispose();
            baglan.bgl(false);
            return false;
        }



    }
}