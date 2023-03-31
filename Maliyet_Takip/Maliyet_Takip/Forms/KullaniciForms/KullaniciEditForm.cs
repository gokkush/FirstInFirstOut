using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Maliyet_Takip.Enums;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Maliyet_Takip.Forms.Kullanici
{
    public partial class KullaniciEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Sifrele sifre = new Sifrele();
        string _otoSifre;
        SqlCommand komut;
        SqlDataReader oku;


        public KullaniciEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            DataLayoutControl = aDataLayoutControl;
            //txtGorev.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<Gorevler>());
            if (_ac)
            {
                KullaniciGetir(_id);
                ShowItems = new BarItem[] { btnSifreSifirla };
            }
            _otoSifre = sifre.OtomatikSifre();            
            EventsLoad();
        }

        private void KullaniciGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Kullanicilar where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    txtSicil.Text = oku["Sicili"].ToString();
                    txtAdi.Text = oku["Adi"].ToString();
                    txtSoyadi.Text = oku["Soyadi"].ToString();
                    txtTelefon.Text = oku["Telefon"].ToString();
                    txtAdres.Text = oku["Adres"].ToString();
                    txtMail.Text = oku["Mail"].ToString();
                    txtUnvan.Id = Convert.ToInt32(oku["Unvan_Id"]);
                    //txtGorev.SelectedItem = ((Gorevler)oku["Gorev_Id"]).ToName();
                    txtGorev.SelectedItem = oku["Gorevi"].ToString();
                    txtBirimi.Id = Convert.ToInt32(oku["Birim_Id"]);
                   // txtDepo.Id = Convert.ToInt32(oku["Depo_Id"]);
                    txtAciklama.Text = oku["Aciklama"].ToString();
                    tglDurum.IsOn = (bool)oku["Durum"];
                }
                komut.Dispose();
                baglan.bgl(false);

                string a = txtBirimi.Id.ToString();
                if (!string.IsNullOrEmpty(a))
                {
                    komut = new SqlCommand("Select * from Birimler where Id = '" + txtBirimi.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtBirimi.Text = oku["Birim_Adi"].ToString();
                    }
                    komut.Dispose();
                    baglan.bgl(false);
                }


                //a = txtDepo.Id.ToString();
                //if (!string.IsNullOrEmpty(a))
                //{
                //    komut = new SqlCommand("Select * from Depolar where Id = '" + txtDepo.Id + "'", baglan.bgl());
                //    oku = komut.ExecuteReader();
                //    while (oku.Read())
                //    {
                //        txtDepo.Text = oku["Depo_Adi"].ToString();
                //    }
                //    komut.Dispose();
                //    baglan.bgl(false);
                //}


                a = txtUnvan.Id.ToString();
                if (!string.IsNullOrEmpty(a))
                {
                    komut = new SqlCommand("Select * from Unvanlar where Id = '" + txtUnvan.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtUnvan.Text = oku["Unvan_Adi"].ToString();
                    }
                    komut.Dispose();
                    baglan.bgl(false);
                }


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
            if (txtSicil.Text != "")
            {
                if (txtAdi.Text != "")
                {
                    if (txtSoyadi.Text != "")
                    {
                        var dr = mesajlar.EvetSeciliEvetHayir(txtSicil.Text + " kullanıcı işlemini onaylıyor musunuz?", "Uyarı");
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                if (!_ac)
                                {
                                    int sayac = 0;
                                    komut = new SqlCommand("Select * from Kullanicilar where Sicili = '" + txtSicil.Text + "'", baglan.bgl());
                                    oku = komut.ExecuteReader();
                                    while (oku.Read())
                                    {
                                        sayac++;
                                    }
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    if (sayac > 0)
                                    {
                                        mesajlar.Hata("Kullanıcı Adıyla daha önce bir kullanıcı açılmış farklı bir kullanıcı adı giriniz");
                                        txtSicil.Focus();
                                        return false;
                                    }
                                }

                                if (!_ac)
                                {
                                    komut = new SqlCommand("insert into Kullanicilar (Sicili, Adi, Soyadi, Adres, Telefon, Mail,Birim_Id, Unvan_Id, Gorev_Id, Sifre, Durum, SaveDate, SaveUser, Aciklama) values (@Sicili, @Adi, @Soyadi, @Adres,@Telefon, @Mail, @Birim_Id,@Unvan_Id, @Gorev_Id, @Sifre, @Durum,@SaveDate,@SaveUser,@Aciklama)", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Sicili", txtSicil.Text);
                                    komut.Parameters.AddWithValue("@Adi", txtAdi.Text.ToUpper());
                                    komut.Parameters.AddWithValue("@Soyadi", txtSoyadi.Text.ToUpper());
                                    komut.Parameters.AddWithValue("@Adres", txtAdres.Text);
                                    komut.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                                    komut.Parameters.AddWithValue("@Mail", txtMail.Text);
                                    komut.Parameters.AddWithValue("@Birim_Id", txtBirimi.Id);
                                    komut.Parameters.AddWithValue("@Unvan_Id", txtUnvan.Id);
                                    //komut.Parameters.AddWithValue("@Gorev_Id", txtGorev.Text.GetEnum<Gorevler>());
                                    komut.Parameters.AddWithValue("@Gorevi", txtGorev.SelectedItem.ToString());
                                    komut.Parameters.AddWithValue("@Sifre", sifre.TextSifrele(_otoSifre));
                                    komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                                    komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    MessageBox.Show("Kullanıcının Şifresi: "+_otoSifre);
                                }
                                else
                                {

                                    komut = new SqlCommand("update Kullanicilar set Sicili=@Sicili, Adi=@Adi, Soyadi=@Soyadi, Adres=@Adres, Telefon=@Telefon, Mail=@Mail, Birim_Id=@Birim_Id, Unvan_Id=@Unvan_Id, Gorev_Id=@Gorev_Id, Durum=@Durum, EditDate=@EditDate, EditUser=@EditUser, Aciklama=@Aciklama where Id=@Id", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Sicili", txtSicil.Text);
                                    komut.Parameters.AddWithValue("@Adi", txtAdi.Text.ToUpper());
                                    komut.Parameters.AddWithValue("@Soyadi", txtSoyadi.Text.ToUpper());
                                    komut.Parameters.AddWithValue("@Adres", txtAdres.Text);
                                    komut.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                                    komut.Parameters.AddWithValue("@Mail", txtMail.Text);
                                    komut.Parameters.AddWithValue("@Birim_Id", txtBirimi.Id);
                                    komut.Parameters.AddWithValue("@Unvan_Id", txtUnvan.Id);
                                    komut.Parameters.AddWithValue("@Gorevi", txtGorev.SelectedItem.ToString());
                                    //komut.Parameters.AddWithValue("@Gorev_Id", txtGorev.Text.GetEnum<Gorevler>());
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
                                   
                                    mesajlar.Guncelle(txtSicil.Text + " kullanıcısı güncellenmiştir.");
                                    return true;
                                }
                                else
                                {
                                   
                                    mesajlar.YeniKayit(txtSicil.Text + " kullanıcısı oluşturulmuştur.");
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
                        mesajlar.Hata("Soyadı Boş Olamaz!");
                        txtSoyadi.Focus();
                        return false;
                    }
                }
                else
                {
                    komut.Dispose();
                    baglan.bgl(false);
                    mesajlar.Hata("Adı Boş Olamaz!");
                    txtAdi.Focus();
                    return false;
                }
            }
            else
            {
                komut.Dispose();
                baglan.bgl(false);
                mesajlar.Hata("Kullanıcı Adı Boş Olamaz!");
                txtSicil.Focus();
                return false;
            }
            return false;
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit))
                return;
            else
            {
                Formlar formlar = new Formlar();

                if (sender == txtBirimi)
                {
                    formlar.BirimlerListFormu(true);
                    txtBirimi.Id = AnaForm._secilenId;
                    komut = new SqlCommand("Select * from Birimler where Id = '" + txtBirimi.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtBirimi.EditValue = (oku["Birim_Adi"]);
                    }
                    oku = null;
                    komut.Dispose();
                    baglan.bgl(false);
                    AnaForm._secilenId = -1;
                }

                if (sender == txtUnvan)
                {
                    formlar.UnvanlarListFormu(true);
                    txtUnvan.Id = AnaForm._secilenId;
                    komut = new SqlCommand("Select * from Unvanlar where Id = '" + txtUnvan.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtUnvan.EditValue = (oku["Unvan_Adi"]);
                    }
                    oku = null;
                    komut.Dispose();
                    baglan.bgl(false);
                    AnaForm._secilenId = -1;
                }

                //if (sender == txtDepo)
                //{
                //    formlar.DepolarListFormu(true);
                //    txtDepo.Id = AnaForm._secilenId;
                //    komut = new SqlCommand("Select * from Depolar where Id = '" + txtDepo.Id + "'", baglan.bgl());
                //    oku = komut.ExecuteReader();
                //    while (oku.Read())
                //    {
                //        txtUnvan.EditValue = (oku["Depo_Adi"]);
                //    }
                //    oku = null;
                //    komut.Dispose();
                //    baglan.bgl(false);
                //    AnaForm._secilenId = -1;
                //}
            }

        }

        protected override void SifreSifirla()
        {
            try
            {
                DialogResult dr = mesajlar.EvetSeciliEvetHayir("Kullanıcı Şifresi sıfırlanacaktır, Onaylıyor musunuz?","Uyarı");

                if (dr==DialogResult.Yes &&_ac)
                {
                    komut = new SqlCommand("update Kullanicilar set Sifre=@Sifre, EditUser=@EditUser, EditDate=@EditDate where Id=@Id", baglan.bgl());
                    komut.Parameters.AddWithValue("@Sifre", sifre.TextSifrele(_otoSifre));
                    komut.Parameters.AddWithValue("@EditUser", AnaForm._kullaniciId);
                    komut.Parameters.AddWithValue("@EditDate", DateTime.Now);
                    komut.Parameters.AddWithValue("@Id", _id);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcının Şifresi: "+_otoSifre);
                    mesajlar.Guncelle("Kullanıcı Şifresi Sıfırlanmıştır.");
                    komut.Dispose();
                    baglan.bgl(false);
                }

            }
            catch (Exception e)
            {
              
                baglan.bgl(false);
                mesajlar.Hata(e.Message);
            }
        }
    }
}