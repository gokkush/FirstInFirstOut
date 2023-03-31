using DevExpress.XtraSplashScreen;
using Maliyet_Takip.Enums;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace Maliyet_Takip
{
    public partial class GirisForm : SplashScreen
    {
        string _sicili;
        string _adi;
        string _sifre;
        string _gorevi;
        string _birim;
        int _birimId;
        int _kullaniciId;
        int _deger;
        int _unvanId;
        string _unvan;
        Sifrele sifre = new Sifrele();
        Random rastgele = new Random();
        Baglanti baglan = Baglanti.NesneVer();
        SqlCommand komut;
        SqlDataReader oku;

        public GirisForm()
        {
            InitializeComponent();
            this.labelCopyright.Text = "© -Gokkush 2020-" + DateTime.Now.Year.ToString();
            labelStatus.Text= $"Versiyon: {Assembly.GetExecutingAssembly().GetName().Version}";
            txtKullanici.GotFocus += TxtKullanici_GotFocus;
        }

        private void TxtKullanici_GotFocus(object sender, EventArgs e)
        {
            txtKullanici.Focus();
        }

        void yenile()
        {

            txtKullanici.Text = "";
            txtSifre.Text = "";
            txtGuvenlik.Text = "";
            _deger = rastgele.Next(1000, 9999);
            txtSecure.Text = _deger.ToString();
            txtKullanici.Select();
            txtKullanici.Focus();

        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
        void giris()
        {
            int sayac = 0;
            try
            {
                komut = new SqlCommand("Select * from Kullanicilar", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    sayac++;
                }
                komut.Dispose();
                baglan.bgl(false);
            }
            catch (Exception e)
            {
                //komut.Dispose();
                baglan.bgl(false);
                ALC.Show(this, "UYARI", e.Message);
                yenile();
                return;
            }
            if (sayac > 0)
            {
                try
                {
                    komut = new SqlCommand("Select * from Kullanicilar where Sicili = '" + txtKullanici.Text + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        _sicili = oku["Sicili"].ToString();
                        _kullaniciId = Convert.ToInt32(oku["Id"]);
                        _adi = oku["Adi"].ToString() + " " + oku["Soyadi"].ToString();
                        _sifre = sifre.TextSifreCoz(oku["Sifre"].ToString());
                        _gorevi = oku["Gorevi"].ToString();
                        _unvanId = Convert.ToInt32(oku["Unvan_Id"]);
                        _birimId = Convert.ToInt32(oku["Birim_Id"]);
                    }
                    oku = null;
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("Select * from Unvanlar where Id = '" + _unvanId+ "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        _unvan = oku["Unvan_Adi"].ToString();
                    }
                    oku = null;
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("Select * from Birimler where Id = '" + _birimId + "'", baglan.bgl());
                    oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        _birim = oku["Birim_Adi"].ToString();
                    }
                    oku = null;
                    komut.Dispose();
                    baglan.bgl(false);
                    if (_sicili == txtKullanici.Text.Trim() && _sifre == txtSifre.Text.Trim() && txtGuvenlik.Text == _deger.ToString())
                    {
                        ALC.Show(this, "Hoşgeldiniz " + _adi, "");
                        this.Hide();
                        AnaForm frm = new AnaForm(_kullaniciId, _birimId, _adi, _sicili, _gorevi, _unvan, _birim);
                        frm.Show();
                    }
                    else
                    {
                        ALC.Show(this, "UYARI", "Giriş Başarısız");
                        yenile();
                    }
                    baglan.bgl(false);
                    //    Functions.Kullanicilar Kullanici = db.Kullanicilar.First(s => s.Sicili == txtKullanici.Text.Trim() && s.Sifre == txtSifre.Text.Trim() && txtGuvenlik.Text.Trim() == txtSecure.Text.Trim() && s.Durum.ToString() == "True");
                    //Kullanici.Last_Login = DateTime.Now;
                    //db.SubmitChanges();
                    //ALC.Show(this, "Hoşgeldiniz " + Kullanici.Adi + " " + Kullanici.Soyadi, "");
                    //this.Hide();
                    //AnaForm frm = new AnaForm(Kullanici);
                    //frm.Show();


                }
                catch (Exception e)
                {
                    komut.Dispose();
                    baglan.bgl(false);
                    ALC.Show(this, "UYARI", e.Message);
                    yenile();
                    return;
                }
            }
            else
            {
                komut.Dispose();
                baglan.bgl(false);
                _sicili = "admin";
                _sifre = "admin";
                if (_sicili == txtKullanici.Text.Trim() && _sifre == txtSifre.Text.Trim() && txtGuvenlik.Text == _deger.ToString())
                {
                    this.Hide();
                    AnaForm frm = new AnaForm();
                    frm.Show();

                }
                else ALC.Show(this, "UYARI", "İlk kullanım için sicil: 'admin' şifre: 'admin'dir.");

            }


            // Baglanti.Close();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "")
            {
                ALC.Show(this, "Kullanıcı Adı Boş Olamaz", "UYARI");
                //MessageBox.Show("Kullanıcı Adı Boş Olamaz");
                txtKullanici.Focus();
                return;
            }
            else if (txtSifre.Text == "")
            {
                ALC.Show(this, "Şifre Boş Olamaz", "UYARI");
                txtSifre.Focus();
                return;
            }
            else if (txtGuvenlik.Text == "")
            {
                ALC.Show(this, "Güvenlik Kodunu Girmediniz", "UYARI");
                txtGuvenlik.Focus();
                return;
            }
            giris();
        }

        private void txtKullanici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtGuvenlik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnBaglantiAyari_Click(object sender, EventArgs e)
        {
            AyarForm frm = new AyarForm();
            frm.ShowDialog();
            // this.Hide();
            //SqlCommand komut = new SqlCommand("delete from sqlite_sequence where name='Birimlers';", baglan.bgl());
            //komut.ExecuteNonQuery();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2010 Blue";
            yenile();
        }

        private void GirisForm_Shown(object sender, EventArgs e)
        {
            yenile();
        }

        private void GirisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult x = MessageBox.Show("Programdan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo);
            //if (x == DialogResult.Yes)
            //{
            //Evet tıklandığında Yapılacak İşlemler
            this.Dispose();
            Environment.Exit(0); // Evet tıklandığında uygulama kapanacak

            //}
            //else if (x == DialogResult.No)
            //{
            //    // Hayır tıklandığında yapılacak işlemler
            //    e.Cancel = true; // Hayır tıklandığında iptal edilecek
            //}
        }

    }
}