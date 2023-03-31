using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.UnvanForms
{
    public partial class UnvanEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        SqlCommand komut;
        SqlDataReader oku;

        public UnvanEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            DataLayoutControl = aDataLayoutControl;
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
                komut = new SqlCommand("Select * from Unvanlar where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    txtUnvanAdi.Text = oku["Unvan_Adi"].ToString();
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
            if (txtUnvanAdi.Text != "")
            {

                var dr = mesajlar.EvetSeciliEvetHayir(txtUnvanAdi.Text + " unvan kaydını onaylıyor musunuz?", "Uyarı");
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (!_ac)
                        {
                            int sayac = 0;
                            komut = new SqlCommand("Select * from Unvanlar where Unvan_Adi = '" + txtUnvanAdi.Text + "'", baglan.bgl());
                            oku = komut.ExecuteReader();
                            while (oku.Read())
                            {
                                sayac++;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                            if (sayac > 0)
                            {
                                mesajlar.Hata("unvan adıyla daha önce bir unvan oluşturulmuş farklı bir unvan adı giriniz");
                                txtUnvanAdi.Focus();
                                return false;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                        }

                        if (!_ac)
                        {
                            komut = new SqlCommand("insert into Unvanlar (Unvan_Adi, Durum, SaveDate, SaveUser, Aciklama) values (@Unvan_Adi, @Durum, @SaveDate, @SaveUser, @Aciklama)", baglan.bgl());
                            komut.Parameters.AddWithValue("@Unvan_Adi", txtUnvanAdi.Text.ToUpper());
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

                            komut = new SqlCommand("update Unvanlar set Unvan_Adi=@Unvan_Adi, Durum=@Durum,EditDate=@EditDate, EditUser=@EditUser, Aciklama=@Aciklama where Id=@Id", baglan.bgl());
                            komut.Parameters.AddWithValue("@Unvan_Adi", txtUnvanAdi.Text.ToUpper());
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
                            mesajlar.Guncelle(txtUnvanAdi.Text + " unvanı güncellenmiştir.");
                            return true;
                        }
                        else
                        {
                            komut.Dispose();
                            baglan.bgl(false);
                            mesajlar.YeniKayit(txtUnvanAdi.Text + " unvanı oluşturulmuştur.");
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
                mesajlar.Hata("Adı Boş Olamaz!");
                txtUnvanAdi.Focus();
                return false;
            }
            komut.Dispose();
            baglan.bgl(false);
            return false;
        }
    }
}