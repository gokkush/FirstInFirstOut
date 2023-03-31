using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using Maliyet_Takip.Entities;
using Maliyet_Takip.Enums;
using Maliyet_Takip.Functions;
using Maliyet_Takip.Interfaces;
using Maliyet_Takip.UserControl;
using System;
using System.Windows.Forms;

namespace Maliyet_Takip.Forms.BaseForms
{
    public partial class BaseEditForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected internal bool _kayitSonrasiFormuKapat = true;
        protected internal bool _ac = false;
        private bool _formSablonKayitedilecek;
        protected internal bool _kaydet;
        protected internal int _id = -1;
        protected internal int _kullanici_Id;
        protected internal int _birim_Id;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        protected ADataLayoutControl DataLayoutControl;
        protected ADataLayoutControl[] DataLayoutControls;
        protected internal IslemTuru BaseIslemTuru;
        protected internal bool RefreshYapilacak;
        protected bool IsLoaded;
        //Mesajlar mesajlar = new Mesajlar();
        public BaseEditForm()
        {
            InitializeComponent();
        }
        public virtual void Yukle()
        {

        }
        protected virtual void BagliTabloYukle()
        {

        }

        protected virtual bool BagliTabloKaydet()
        {
            return false;
        }
        protected virtual void Giris()
        {

        }

        protected internal virtual IBaseEntity ReturnEntity()
        {
            return null;
        }
        protected void EventsLoad()
        {
            //button events
            foreach (BarItem item in ribbon.Items)
            {
                item.ItemClick += Buttom_ItemClick;
            }



            //form Events
            LocationChanged += BaseEditForm_LocationChanged;
            SizeChanged += BaseEditForm_SizeChanged;
            Load += BaseEditForm_Load;
            FormClosing += BaseEditForm_FormClosing;
            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                control.GotFocus += Control_GotFocus;
                control.Leave += Control_Leave;
                control.Enter += Control_Enter;

                switch (control)
                {
                    case FilterControl edt:
                        edt.FilterChanged += Control_EditValueChanged;
                        break;
                    case ComboBoxEdit edt:
                        edt.SelectedValueChanged += Control_SelectedValueChanged;
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                    case AButtonEdit edt:
                        edt.IdChanged += Control_IdChanged;
                        edt.EnabledChange += Control_EnabledChange;
                        edt.ButtonClick += Control_ButtonClick;
                        edt.DoubleClick += Control_DoubleClick;
                        break;
                    case SpinEdit edt:
                        edt.ButtonClick += Control_ButtonClick;
                        edt.DoubleClick += Control_DoubleClick;
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                    case AMoneyEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                    case BaseEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                    case TabPane tab:
                        tab.SelectedPageChanged += Control_SelectedPageChanged;
                        break;
                        //case AGridControl grd:
                        //    grd.MainView.GotFocus += Control_GotFocus;
                        //    break;
                }

            }
            if (DataLayoutControls == null)
            {
                if (DataLayoutControl == null) return;
                foreach (Control ctrl in DataLayoutControl.Controls)
                    ControlEvents(ctrl);
            }
            else
                foreach (var layout in DataLayoutControls)
                    foreach (Control ctrl in layout.Controls)
                        ControlEvents(ctrl);
        }

        protected virtual void Control_Enter(object sender, EventArgs e)
        {

        }

        protected virtual void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {

        }

        protected virtual void Control_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void Control_Leave(object sender, EventArgs e)
        {
            statusBarKisayol.Visibility = BarItemVisibility.Never;
            statusBarKisayolAciklama.Visibility = BarItemVisibility.Never;
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            var type = sender.GetType();

            if (type == typeof(AButtonEdit) || type == typeof(APictureEdit) || type == typeof(AComboBoxEdit) || type == typeof(ADateedit)) //|| type == typeof(AGridView) 
            {
                statusBarKisayol.Visibility = BarItemVisibility.Always;
                statusBarKisayolAciklama.Visibility = BarItemVisibility.Always;

                statusBarAciklama.Caption = ((IStatusBarAciklama)sender).StatusBarAciklama;
                statusBarKisayol.Caption = ((IStatusBarKisayol)sender).StatusBarKisayol;
                statusBarKisayolAciklama.Caption = ((IStatusBarKisayol)sender).StatusBarKisayolAciklama;

            }
            else if (sender is IStatusBarAciklama ctrl)
                statusBarAciklama.Caption = ctrl.StatusBarAciklama;
        }

        private void BaseEditForm_SizeChanged(object sender, EventArgs e)
        {
            _formSablonKayitedilecek = true;
        }

        private void BaseEditForm_LocationChanged(object sender, EventArgs e)
        {
            _formSablonKayitedilecek = true;
        }

        protected virtual void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();

        }

        protected virtual void FiltreUygula()
        {

        }

        protected void SablonKaydet()
        {
            if (_formSablonKayitedilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);

        }

        private void SablonYukle()
        {
            Name.FormSablonYukle(this);
        }

        protected virtual void Control_EnabledChange(object sender, EventArgs e)
        {

        }

        protected virtual void Control_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            SecimYap(sender);
        }

        private void Control_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SecimYap(sender);
        }

        private void Control_IdChanged(object sender, IdChangedEventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
        }

        protected virtual void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (sender is AButtonEdit edt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control || e.Shift:
                        edt.Id = null;
                        edt.EditValue = null;
                        break;

                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SecimYap(edt);
                        break;

                }
            }
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            GuncelNesneOlustur();
            SablonYukle();
            ButtonGizleGoster();

        }

        protected virtual void Buttom_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item == btnYeni)
            {
                //Yetki Kontrolü
                BaseIslemTuru = IslemTuru.EntityInsert;
                Yukle();
            }
            else if (e.Item == btnKaydet)
            {

                if (Kaydet() && _kayitSonrasiFormuKapat)
                {
                    Close();
                }
            }

            else if (e.Item == btnSil)
            {
                //Yetki Kontrolü
                EntityDelete();
            }

            else if (e.Item == btnSifreSifirla)
            {
                SifreSifirla();

            }

            else if (e.Item == btnYazdir)
            {
                Yazdir();
            }
            else if (e.Item == btnBaskiOnizleme)
            {
                BaskiOnizleme();
            }
            else if (e.Item == btnCikis)
            {
                Close();
            }

            Cursor.Current = DefaultCursor;
        }

        protected virtual void ExcelAl()
        {

        }

        protected virtual void SifreSifirla()
        {

        }

        protected virtual void BaskiOnizleme()
        {

        }

        protected virtual void Yazdir()
        {

        }

        private void FarkliKaydet()
        {
            //if (mesajlar.EvetSeciliEvetHayir("Bu filtre referans alınarak yeni bir filtre oluşturulacaktır. Onaylıyor musunuz?", "Kayıt Onayı") != DialogResult.Yes) return;
            //BaseIslemTuru = IslemTuru.EntityInsert;
            //Yukle();
            //if (Kaydet()) Close();
        }

        protected virtual void SecimYap(object sender)
        {
        }
        protected virtual void EntityDelete()
        {

        }

        protected virtual void ButtonGizleGoster()
        {


            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
            /* Yukarıdaki kodun aynısı foreach (BarItem item in ShowItems)
            {
                item.Visibility = BarItemVisibility.Always;
            }*/
        }


        private void GeriAl()
        {

        }

        protected virtual bool Kaydet()
        {
            return false;
        }



        protected virtual bool EntityInsert()
        {
            return false;
        }

        protected virtual bool EntityUpdate()
        {
            return false;
        }
        protected virtual void NesneyiKontrollereBagla()
        {

        }

        protected virtual void GuncelNesneOlustur()
        {

        }

        protected internal virtual void ButtonEnabledDurumu()
        {
            if (!IsLoaded) return;
            //GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGeriAl, btnSil, OldEntity, CurrentEntity);

        }


    }
}