using DevExpress.XtraBars;
using DevExpress.XtraTabbedMdi;
using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon.Gallery;

namespace Maliyet_Takip
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        Baglanti baglan = Baglanti.NesneVer();
        Formlar frm = new Formlar();
        public static int _evrakId = -1;
        public static int _kullaniciId = -1;
        public static int _birimId = -1;
        public static string _kullaniciAdi = "";
        public static string _gorevi = "";
        public static int _secilenId = -1;
        public static int _raporId = -1;
        public static int _markaId = -1;
        public static string _isimler = "";
        public static string _sicili = "";
        public static string _unvan = "";
        public static string _birim = "";
        public static int _donemId;
        public static string _ilceAdi = "Kütahya/Merkez";
        public static string _kurumAdi = "T Tipi Ceza İnfaz Kurumu Müdürlüğü";
        public static string _sorgu = "Select * from VW_DonanimTanimlars where Durum like '" + 1 + "'";
        public static int _saveUser = -1;
        public static int? _editUser = -1;
        public static DateTime? _saveDate;
        public static DateTime? _editDate;
        SqlCommand komut;
        SqlDataReader oku;

        public AnaForm()
        {
            InitializeComponent();
            EventsLoad(this);
        }

        public AnaForm(int kullniciId, int birimId, string kullaniciAdi, string sicili, string gorevi, string unvan, string birim)
        {
            InitializeComponent();
            _kullaniciId = kullniciId;
            _birimId = birimId;
            _kullaniciAdi = kullaniciAdi;
            _gorevi = gorevi;
            _sicili = sicili;
            _unvan = unvan;
            _birim = birim;
            brKullanici.Caption = _kullaniciAdi;
            brGorev.Caption = _gorevi;
            brUnvan.Caption = _unvan;
            brBirim.Caption = _birim;
            komut = new SqlCommand("Select * from Kurum where Id = '" + 2021 + "'", baglan.bgl());
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                _kurumAdi = oku["KurumAdi"].ToString();
                _ilceAdi = oku["Il_Adi"].ToString() +"/"+oku["Ilce_Adi"].ToString();

            }
            komut.Dispose();
            baglan.bgl(false);
           // brKurum.Caption = _kurumAdi;
            EventsLoad(this);
            if (_gorevi == "Personel")
            {
               // rpTanimlar.Visible = false;
            }
        }

        private void EventsLoad(object sender)
        {
            this.Load += AnaForm_Load;
            foreach (var item in ribbon.Items)
            {
                switch (item)
                {
                    case SkinRibbonGalleryBarItem btn:
                        btn.GalleryItemClick += GaleryItem_GalleryItemClick;
                        break;
                    case SkinPaletteRibbonGalleryBarItem btn:
                        btn.GalleryItemClick += GaleryItem_GalleryItemClick;
                        break;
                    case BarButtonItem btn:
                        btn.ItemClick += Butonlar_ItemClick;
                        break;

                }


            }
            foreach (Control control in Controls)
            {
                control.KeyDown += Control_KeyDown;
            }
            KeyDown += Control_KeyDown;
            FormClosing += AnaForm_FormClosing;
            xtraTabbedMdiManager.PageAdded += XtraTabbedMdiManager_PageAdded;
            xtraTabbedMdiManager.PageRemoved += XtraTabbedMdiManager_PageRemoved;
        }



        private void XtraTabbedMdiManager_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            imgArkaResim.Visible = false;
        }

        private void XtraTabbedMdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (((XtraTabbedMdiManager)sender).Pages.Count == 0)
            {
                imgArkaResim.Visible = true;
            }
        }
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }
        private void Butonlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item == btnKullaniciTanim)
            {
                frm.KullaniciListFormu();
            }
            if (e.Item == btnBirimTanim)
            {

                frm.BirimlerListFormu();
            }
            if (e.Item == btnUnvanTanim)
            {

                frm.UnvanlarListFormu();
            }
            if (e.Item == btnSifreDegistir)
            {

                frm.SifreDegistir(AnaForm._kullaniciId,true);
            }
            if (e.Item == btnGrupTanim)
            {

                frm.StokGruplarListFormu();
            }

            if (e.Item == btnStokTanimlama)
            {

                frm.StoklarListFormu();
            }
            if (e.Item == btnBaslangicAyarlari)
            {

                frm.BaslangicAyarFormu();
            }
            if (e.Item == btnDonemTanimlari)
            {

                frm.DonemlerListFormu();
            }
            if (e.Item == btnCariTinimlama)
            {

                frm.CariListFormu();
            }
            if (e.Item == btnHammaddeAlis)
            {

                frm.HammaddealisListFormu();
            }
            if (e.Item == btnDepoSayim)
            {

                frm.DepoListFormu();
            }
            if (e.Item == btnMamulSayim)
            {

                frm.MamulSayimYerListFormu();
            }
            if (e.Item == btnDepolarArasiSevk)
            {

                frm.DepolarArasiSevkListFormu();
            }
            if (e.Item == btnMamulTanimlama)
            {

                frm.MamullerListFormu();
            }
            if (e.Item == btnMamulGruplari)
            {

                frm.MamulGruplarListFormu();
            }
            if (e.Item == btnGiderTanimlari)
            {

                frm.GiderlerListFormu();
            }
            if (e.Item == btnMaliyetler)
            {

                frm.MaliyetOlusturmaListFormu();
            }
            if (e.Item == btnMamulSatisi)
            {

                frm.MamulSatisListFormu();
            }
            if (e.Item == btnMamulSevk)
            {

                frm.MamulSevkListFormu();
            }
            Cursor.Current = Cursors.Default;
        }

        private void GaleryItem_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            var galery = sender as InRibbonGallery;
            if (galery.OwnerItem.GetType() == typeof(SkinRibbonGalleryBarItem))
                GeneralFunctions.AppSettingsWrite("Skin", e.Item.Caption);
            else if (galery.OwnerItem.GetType() == typeof(SkinPaletteRibbonGalleryBarItem))
                GeneralFunctions.AppSettingsWrite("Palette", e.Item.Caption);
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult x = MessageBox.Show("Sistemden Çıkmak İstediğinizden Emin Misiniz?", "UYARI!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                //Evet tıklandığında Yapılacak İşlemler
                this.Dispose(); // Evet tıklandığında uygulama kapanacak
                GirisForm frm = new GirisForm();
                frm.Show();
            }
            else if (x == DialogResult.No)
            {
                // Hayır tıklandığında yapılacak işlemler
                e.Cancel = true; // Hayır tıklandığında iptal edilecek
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            timer.Start();
            komut = new SqlCommand("Select * from Donemler where Aktif=1",baglan.bgl());
            oku = komut.ExecuteReader();
            oku.Read();
            _donemId = Convert.ToInt32(oku["Id"]);
            brDonem.Caption = _donemId.ToString();
            baglan.bgl(false);
            if (Convert.ToInt32(DateTime.Now.Year)!=_donemId)
            {
                MessageBox.Show("Çalıştığınız dönem bu yıl içerisinde değildir.\nKayıtlarınıza dikkat ediniz!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
 
        }


        public void Mesaj(string Baslik, string Mesaj)
        {
            ALC.Show(this, Baslik, Mesaj);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            brSaat.Caption = DateTime.Now.ToLongTimeString();
            brTarih.Caption = DateTime.Now.ToLongDateString();
        }
    }
}