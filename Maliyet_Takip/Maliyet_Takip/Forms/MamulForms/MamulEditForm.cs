using DevExpress.XtraEditors;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Maliyet_Takip.Forms.MamulForms
{
    public partial class MamulEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlCommand komut;
        SqlDataReader oku;


        public MamulEditForm(int id, bool ac)
        {
            _ac = ac;
            _id = id;
            InitializeComponent();
            txtKod.Text = numara.MamulNumarasi();
            DataLayoutControl = aDataLayoutControl;            
            if (_ac)
            {
                StokGetir(_id);
                txtKod.Enabled = false;
            }
            EventsLoad();
        }

        private void StokGetir(int id)
        {
            _id = id;
            try
            {
                komut = new SqlCommand("Select * from Mamuller where Id = '" + _id + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    txtKod.Text = oku["Kod"].ToString();
                    txtStokAdi.Text = oku["StokAdi"].ToString();
                    txtBarkodu.Text = oku["Barkodu"].ToString();
                    txtBirimi.SelectedItem = oku["Birimi"].ToString();
                    txtAlisKDV.EditValue= oku["AlisKDV"];
                    txtSatisKDV.EditValue = oku["SatisKDV"];
                    txtAltLimit.EditValue = oku["AltLimit"];
                    txtStokGrubu.Id = Convert.ToInt32(oku["GrupId"]);
                    txtAciklama.Text = oku["Aciklama"].ToString();

                    tglDurum.IsOn = (bool)oku["Durum"];
                }
                komut.Dispose();
                baglan.bgl(false);

                string a = txtStokGrubu.Id.ToString();
                if (!string.IsNullOrEmpty(a))
                {
                    komut = new SqlCommand("Select * from MamulGruplar where Id = '" + txtStokGrubu.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtStokGrubu.Text = oku["GrupAdi"].ToString();
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
            if (txtStokAdi.Text != "")
            {
                if (txtBarkodu.Text != "")
                {
                    if (txtAltLimit.Text != "")
                    {
                        var dr = mesajlar.EvetSeciliEvetHayir(txtStokAdi.Text + " Mamul işlemini onaylıyor musunuz?", "Uyarı");
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                if (!_ac)
                                {
                                    int sayac = 0;
                                    komut = new SqlCommand("Select * from Mamuller where StokAdi = '" + txtStokAdi.Text + "'", baglan.bgl());
                                    oku = komut.ExecuteReader();
                                    while (oku.Read())
                                    {
                                        sayac++;
                                    }
                                    komut.Dispose();
                                    baglan.bgl(false);
                                    if (sayac > 0)
                                    {
                                        mesajlar.Hata("Stok Adıyla daha önce bir Mamul oluşturulmuş farklı bir Mamul adı giriniz");
                                        txtStokAdi.Focus();
                                        return false;
                                    }
                                }

                                if (!_ac)
                                {
                                    komut = new SqlCommand("insert into Mamuller (Kod, StokAdi, Barkodu, Birimi, AlisKDV, SatisKDV, AltLimit, Aciklama, GrupId, Durum, SaveDate, SaveUser) values (@Kod, @StokAdi, @Barkodu, @Birimi, @AlisKDV, @SatisKDV, @AltLimit, @Aciklama, @GrupId, @Durum,@SaveDate,@SaveUser)", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@StokAdi", txtStokAdi.Text.ToUpper());
                                    komut.Parameters.AddWithValue("@Barkodu", txtBarkodu.Text);
                                    komut.Parameters.AddWithValue("@Birimi", txtBirimi.SelectedItem);
                                    komut.Parameters.AddWithValue("@AlisKDV", txtAlisKDV.EditValue);
                                    komut.Parameters.AddWithValue("@SatisKDV", txtSatisKDV.EditValue);
                                    komut.Parameters.AddWithValue("@AltLimit", txtAltLimit.EditValue);
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                                    komut.Parameters.AddWithValue("@GrupId", txtStokGrubu.Id);
                                    komut.Parameters.AddWithValue("@Durum", (bool)tglDurum.IsOn);
                                    komut.Parameters.AddWithValue("@SaveDate", DateTime.Now);
                                    komut.Parameters.AddWithValue("@SaveUser", AnaForm._kullaniciId);
                                    komut.ExecuteNonQuery();
                                    komut.Dispose();
                                    baglan.bgl(false);
                                }
                                else
                                {

                                    komut = new SqlCommand("update Mamuller set Kod=@Kod, StokAdi=@StokAdi, Barkodu=@Barkodu, Birimi=@Birimi, AlisKDV=@AlisKDV, SatisKDV=@SatisKDV, AltLimit=@AltLimit, Aciklama=@Aciklama, GrupId=@GrupId, Durum=@Durum, EditDate=@EditDate, EditUser=@EditUser where Id=@Id", baglan.bgl());
                                    komut.Parameters.AddWithValue("@Kod", txtKod.Text);
                                    komut.Parameters.AddWithValue("@StokAdi", txtStokAdi.Text.ToUpper());
                                    komut.Parameters.AddWithValue("@Barkodu", txtBarkodu.Text);
                                    komut.Parameters.AddWithValue("@Birimi", txtBirimi.SelectedItem);
                                    komut.Parameters.AddWithValue("@AlisKDV", txtAlisKDV.EditValue);
                                    komut.Parameters.AddWithValue("@SatisKDV", txtSatisKDV.EditValue);
                                    komut.Parameters.AddWithValue("@AltLimit", txtAltLimit.EditValue);
                                    komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.ToString());
                                    komut.Parameters.AddWithValue("@GrupId", txtStokGrubu.Id);
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

                                    mesajlar.Guncelle(txtStokAdi.Text + " mamülü güncellenmiştir.");
                                    return true;
                                }
                                else
                                {

                                    mesajlar.YeniKayit(txtStokAdi.Text + " mamülü oluşturulmuştur.");
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
                        mesajlar.Hata("Alt Limit Boş Olamaz!");
                        txtAltLimit.Focus();
                        return false;
                    }
                }
                else
                {
                    komut.Dispose();
                    baglan.bgl(false);
                    mesajlar.Hata("Barkodu Boş Olamaz!");
                    txtBarkodu.Focus();
                    return false;
                }
            }
            else
            {
                komut.Dispose();
                baglan.bgl(false);
                mesajlar.Hata("Stok Adı Boş Olamaz!");
                txtStokAdi.Focus();
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

                if (sender == txtStokGrubu)
                {
                    formlar.MamulGruplarListFormu(true);
                    txtStokGrubu.Id = AnaForm._secilenId;
                    komut = new SqlCommand("Select * from MamulGruplar where Id = '" + txtStokGrubu.Id + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        txtStokGrubu.EditValue = (oku["GrupAdi"]);
                    }
                    oku = null;
                    komut.Dispose();
                    baglan.bgl(false);
                    AnaForm._secilenId = -1;
                }
            }

        }

    }
}