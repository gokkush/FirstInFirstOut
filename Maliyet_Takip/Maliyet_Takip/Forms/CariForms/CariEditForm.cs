using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.CariForms
{
    public partial class CariEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlCommand komut;
        SqlDataReader oku;

        public CariEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            txtKod.Text = numara.CariNumarasi();
            DataLayoutControl = aDataLayoutControl;
            if (_ac)
            {
                CariGetir(_id);
                txtKod.Enabled = false;
            }

            // ShowItems = new BarItem[] {btnYeni, };
            EventsLoad();
        }

        private void CariGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Cariler where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    txtKod.Text = oku["Kod"].ToString();
                    txtCariAdi.Text = oku["CariAdi"].ToString();
                    txtVergiDairesi.Text = oku["VergiDairesi"].ToString();
                    txtVergiNo.Text = oku["VergiNo"].ToString();
                    txtAdresi.Text = oku["Adres"].ToString();
                    txtTelefonu.Text = oku["Telefon"].ToString();
                    txtFaks.Text = oku["Faks"].ToString();
                    txtYetkili.Text = oku["Yetkili"].ToString();
                    txtYetkiliTel.Text = oku["YetkiliTel"].ToString();
                    txtMail.Text = oku["Mail"].ToString();
                    txtAciklama.Text = oku["Aciklama"].ToString();
                    tglDurum.IsOn = (bool)oku["Durum"];
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
            if (txtCariAdi.Text != "")
            {

                var dr = mesajlar.EvetSeciliEvetHayir(txtCariAdi.Text + " cari kaydını onaylıyor musunuz?", "Uyarı");
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (!_ac)
                        {
                            int sayac = 0;
                            komut = new SqlCommand("Select * from Cariler where CariAdi = '" + txtCariAdi.Text + "'", baglan.bgl());
                            oku = komut.ExecuteReader();
                            while (oku.Read())
                            {
                                sayac++;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                            if (sayac > 0)
                            {
                                mesajlar.Hata("cari adıyla daha önce bir cari oluşturulmuş farklı bir cari adı giriniz");
                                txtCariAdi.Focus();
                                return false;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                        }

                        if (!_ac)
                        {
                            komut = new SqlCommand("insert into Cariler (Kod, CariAdi, VergiDairesi, VergiNo, Adres, Telefon, Faks, Yetkili, YetkiliTel, Mail, Durum, SaveDate, SaveUser, Aciklama) values (@Kod, @CariAdi, @VergiDairesi, @VergiNo, @Adres, @Telefon, @Faks, @Yetkili, @YetkiliTel, @Mail, @Durum, @SaveDate, @SaveUser, @Aciklama)", baglan.bgl());
                            komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                            komut.Parameters.AddWithValue("@CariAdi", txtCariAdi.Text.ToUpper());
                            komut.Parameters.AddWithValue("@VergiDairesi", txtVergiDairesi.Text);
                            komut.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text);
                            komut.Parameters.AddWithValue("@Adres", txtAdresi.Text);
                            komut.Parameters.AddWithValue("@Telefon", txtTelefonu.Text);
                            komut.Parameters.AddWithValue("@Faks", txtFaks.Text);
                            komut.Parameters.AddWithValue("@Yetkili", txtYetkili.Text);
                            komut.Parameters.AddWithValue("@YetkiliTel", txtYetkiliTel.Text);
                            komut.Parameters.AddWithValue("@Mail", txtMail.Text);
                            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                            komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglan.bgl(false);
                        }
                        else
                        {

                            komut = new SqlCommand("update Cariler set Kod=@Kod, CariAdi=@CariAdi, VergiDairesi=@VergiDairesi, VergiNo=@VergiNo, Adres=@Adres, Telefon=@Telefon, Faks=@Faks, Yetkili=@Yetkili, YetkiliTel=@YetkiliTel, Mail=@Mail, Durum=@Durum,EditDate=@EditDate, EditUser=@EditUser, Aciklama=@Aciklama where Id=@Id", baglan.bgl());
                            komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                            komut.Parameters.AddWithValue("@CariAdi", txtCariAdi.Text.ToUpper());
                            komut.Parameters.AddWithValue("@VergiDairesi", txtVergiDairesi.Text);
                            komut.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text);
                            komut.Parameters.AddWithValue("@Adres", txtAdresi.Text);
                            komut.Parameters.AddWithValue("@Telefon", txtTelefonu.Text);
                            komut.Parameters.AddWithValue("@Faks", txtFaks.Text);
                            komut.Parameters.AddWithValue("@Yetkili", txtYetkili.Text);
                            komut.Parameters.AddWithValue("@YetkiliTel", txtYetkiliTel.Text);
                            komut.Parameters.AddWithValue("@Mail", txtMail.Text);
                            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                            komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                            komut.Parameters.AddWithValue("@Id", _id);
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglan.bgl(false);
                        }
                        _kayitSonrasiFormuKapat = true;
                        if (_ac)
                        {
                            baglan.bgl(false);
                            mesajlar.Guncelle(txtCariAdi.Text + " carisi güncellenmiştir.");
                            return true;
                        }
                        else
                        {
                            baglan.bgl(false);
                            mesajlar.YeniKayit(txtCariAdi.Text + " carisi oluşturulmuştur.");
                            return true;
                        }

                    }
                    catch (System.Exception ex)
                    {
                        baglan.bgl(false);
                        mesajlar.Hata(ex);
                    }
                }
            }
            else
            {
                baglan.bgl(false);
                mesajlar.Hata("Cari Adı Boş Olamaz!");
                txtCariAdi.Focus();
                return false;
            }
            baglan.bgl(false);
            return false;
        }
    }
}