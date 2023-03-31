using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.BirimForms
{
    public partial class BirimEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        SqlCommand komut;
        SqlDataReader oku;

        public BirimEditForm(int id, bool ac)
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
                komut = new SqlCommand("Select * from Birimler where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    txtBirimAdi.Text = oku["Birim_Adi"].ToString();
                    tglFormDoldurma.IsOn= (bool)oku["Form_Doldurma"];
                    txtAciklama.Text = oku["Aciklama"].ToString();
                    tglDurum.IsOn = (bool)oku["Durum"];
                }
                komut.Dispose();
                baglan.bgl(false);
            }
            catch (System.Exception ex)
            {
                mesajlar.Hata(ex);
            }
        }

        protected override bool Kaydet()
        {
            if (txtBirimAdi.Text != "")
            {

                var dr = mesajlar.EvetSeciliEvetHayir(txtBirimAdi.Text + " birim kaydını onaylıyor musunuz?", "Uyarı");
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (!_ac)
                        {
                            int sayac = 0;
                            komut = new SqlCommand("Select * from Birimler where Birim_Adi = '" + txtBirimAdi.Text + "'", baglan.bgl());
                            oku = komut.ExecuteReader();
                            while (oku.Read())
                            {
                                sayac++;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                            if (sayac > 0)
                            {
                                mesajlar.Hata("birim adıyla daha önce bir birim oluşturulmuş farklı bir birim adı giriniz");
                                txtBirimAdi.Focus();
                                return false;
                            }
                            komut.Dispose();
                            baglan.bgl(false);
                        }

                        if (!_ac)
                        {
                            komut = new SqlCommand("insert into Birimler (Birim_Adi, Durum, Form_Doldurma, SaveDate, SaveUser, Aciklama) values (@Birim_Adi, @Durum, @Form_Doldurma, @SaveDate, @SaveUser, @Aciklama)", baglan.bgl());
                            komut.Parameters.AddWithValue("@Birim_Adi", txtBirimAdi.Text.ToUpper());
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@Form_Doldurma", (bool)tglFormDoldurma.IsOn);
                            komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                            komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                            komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                            komut.ExecuteNonQuery();
                            komut.Dispose();
                            baglan.bgl(false);
                        }
                        else
                        {

                            komut = new SqlCommand("update Birimler set Birim_Adi=@Birim_Adi, Durum=@Durum, Form_Doldurma=@Form_Doldurma, EditDate=@EditDate, EditUser=@EditUser, Aciklama=@Aciklama where Id=@Id", baglan.bgl());
                            komut.Parameters.AddWithValue("@Birim_Adi", txtBirimAdi.Text.ToUpper());
                            komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                            komut.Parameters.AddWithValue("@Form_Doldurma", (bool)tglFormDoldurma.IsOn);
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
                            mesajlar.Guncelle(txtBirimAdi.Text + " birimi güncellenmiştir.");
                            return true;
                        }
                        else
                        {
                            mesajlar.YeniKayit(txtBirimAdi.Text + " birimi oluşturulmuştur.");
                            return true;
                        }

                    }
                    catch (System.Exception ex)
                    {
                        mesajlar.Hata(ex);
                    }
                }
            }
            else
            {
                mesajlar.Hata("Adı Boş Olamaz!");
                txtBirimAdi.Focus();
                return false;
            }

            return false;
        }
    }
}