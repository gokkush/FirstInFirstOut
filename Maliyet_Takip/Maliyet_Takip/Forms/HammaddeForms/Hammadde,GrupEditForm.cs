using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.StokForms
{
    public partial class StokGrupEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlCommand komut;
        SqlDataReader oku;

        public StokGrupEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            DataLayoutControl = aDataLayoutControl;
            txtKod.Text = numara.StokGrupNumarasi();
            if (_ac)
            {
                GorevGetir(_id);
            }

            // ShowItems = new BarItem[] {btnYeni, };
            EventsLoad();
        }

        private void GorevGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from HammaddeGruplar where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    txtKod.Text= oku["Kod"].ToString();
                    txtGrupAdi.Text = oku["GrupAdi"].ToString();
                    txtAciklama.Text = oku["Aciklama"].ToString();
                    tglDurum.IsOn = (bool)oku["Durum"];
                }
                komut.Dispose();
                baglan.bgl(false);
            }
            catch (System.Exception ex)
            {
                baglan.bgl(false);
                mesajlar.Hata(ex);
            }
        }

        protected override bool Kaydet()
        {
            if (txtGrupAdi.Text != "")
            {

                var dr = mesajlar.EvetSeciliEvetHayir(txtGrupAdi.Text + " grup kaydını onaylıyor musunuz?", "Uyarı");
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (!_ac)
                        {
                            int sayac = 0;
                            komut = new SqlCommand("Select * from HammaddeGruplar where GrupAdi = '" + txtGrupAdi.Text + "'", baglan.bgl());
                            oku = komut.ExecuteReader();
                            while (oku.Read())
                            {
                                sayac++;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                            if (sayac > 0)
                            {
                                mesajlar.Hata("unvan adıyla daha önce bir grup oluşturulmuş farklı bir unvan adı giriniz");
                                txtGrupAdi.Focus();
                                return false;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                        }

                        if (!_ac)
                        {
                            komut = new SqlCommand("insert into HammaddeGruplar (Kod, GrupAdi, Durum, SaveDate, SaveUser, Aciklama) values (@Kod, @GrupAdi, @Durum, @SaveDate, @SaveUser, @Aciklama)", baglan.bgl());
                            komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                            komut.Parameters.AddWithValue("@GrupAdi", txtGrupAdi.Text.ToUpper());
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                            komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglan.bgl(false);
                        }
                        else
                        {

                            komut = new SqlCommand("update HammaddeGruplar set Kod=@Kod, GrupAdi=@GrupAdi, Durum=@Durum,EditDate=@EditDate, EditUser=@EditUser, Aciklama=@Aciklama where Id=@Id", baglan.bgl());
                            komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                            komut.Parameters.AddWithValue("@GrupAdi", txtGrupAdi.Text.ToUpper());
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                            komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
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
                            mesajlar.Guncelle(txtGrupAdi.Text + " grubu güncellenmiştir.");
                            return true;
                        }
                        else
                        {
                            komut.Dispose();
                            baglan.bgl(false);
                            mesajlar.YeniKayit(txtGrupAdi.Text + " grubu oluşturulmuştur.");
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
                komut.Dispose();
                baglan.bgl(false);
                mesajlar.Hata("Grub Adı Boş Olamaz!");
                txtGrupAdi.Focus();
                return false;
            }
            baglan.bgl(false);
            return false;
        }
    }
}