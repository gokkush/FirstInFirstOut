using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Maliyet_Takip.Enums;
using Maliyet_Takip.Functions;
using Maliyet_Takip.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maliyet_Takip.Forms.BaseForms
{
    public partial class BaseListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected internal bool _secim = false;
        //private long _filtreId;
        private bool _formSablonKayitEdilecek;
        private bool _tabloSablonKayitedilecek;
        protected IBaseFormshow FormShow;
        protected KartTuru BaseKartTuru;
        protected internal GridView Tablo;
        protected bool AktifKartlariGoster = true;
        protected internal bool AktifPasifButonGoster = false;
        protected internal bool MultiSelect;
        protected internal bool EklenebilecekEntityVar = false;
        protected ControlNavigator Navigator;
        protected internal int SeciliGelecekId;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        protected internal IList<long> ListeDisiTutulacakKayitlar;
        //protected internal SelectRowFunctions RowSelect;
        //protected internal IList<BaseEntity> SecilenEntities;

        Formlar frm = new Formlar();
        public BaseListForm()
        {
            InitializeComponent();
            //   EventsLoad();
        }

        private void EventsLoad()
        {
            //Buton Events
            foreach (BarItem button in ribbon.Items)
            {
                button.ItemClick += Button_ItemClick;

            }

            //Tablo Events
            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.RowClick += Tablo_Click;
            //Tablo.Click += Tablo_Click;
            Tablo.KeyDown += Tablo_KeyDown;
            Tablo.MouseUp += Tablo_MouseUp;
            Tablo.ColumnWidthChanged += Tablo_ColumnWidthChanged;
            Tablo.ColumnPositionChanged += Tablo_ColumnPositionChanged;
            Tablo.EndSorting += Tablo_EndSorting;
            Tablo.ColumnFilterChanged += Tablo_ColumnFilterChanged;

            //Form Events
            Shown += BaseListForm_Shown;
            Load += BaseListForm_Load;
            FormClosing += BaseListForm_FormClosing;
            LocationChanged += BaseListForm_LocationChanged;
            SizeChanged += BaseListForm_SizeChanged;
        }

        private void Tablo_RowClick(object sender, RowClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void Tablo_Click(object sender, EventArgs e)
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                SeciliGelecekId = int.Parse(Tablo.GetFocusedRowCellValue("Id").ToString());
                if (!string.IsNullOrEmpty(Tablo.GetFocusedRowCellValue("SaveUser").ToString()))
                    AnaForm._saveUser = int.Parse(Tablo.GetFocusedRowCellValue("SaveUser").ToString());
                else
                    AnaForm._saveUser = -1;
                if (!string.IsNullOrEmpty(Tablo.GetFocusedRowCellValue("EditUser").ToString()))
                    AnaForm._editUser = int.Parse(Tablo.GetFocusedRowCellValue("EditUser").ToString());
                else
                    AnaForm._editUser = -1;
                if (!string.IsNullOrEmpty(Tablo.GetFocusedRowCellValue("SaveDate").ToString()))
                    AnaForm._saveDate = DateTime.Parse(Tablo.GetFocusedRowCellValue("SaveDate").ToString());
                else
                    AnaForm._saveDate = null;
                if (!string.IsNullOrEmpty(Tablo.GetFocusedRowCellValue("EditDate").ToString()))
                    AnaForm._editDate = DateTime.Parse(Tablo.GetFocusedRowCellValue("EditDate").ToString());
                else
                    AnaForm._editDate = null;
            }
        }

        private void Tablo_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tablo.ActiveFilterString)) { }
            // _filtreId = 0;
        }



        private void BaseListForm_SizeChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }

        private void BaseListForm_LocationChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }

        private void Tablo_EndSorting(object sender, EventArgs e)
        {
            _tabloSablonKayitedilecek = true;
        }

        private void Tablo_ColumnPositionChanged(object sender, EventArgs e)
        {
            _tabloSablonKayitedilecek = true;
        }

        private void Tablo_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            _tabloSablonKayitedilecek = true;
        }

        private void BaseListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {
            SablonYukle();
        }

        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.SagMenuGoster(sagMenu);
        }

        protected virtual void BaseListForm_Shown(object sender, EventArgs e)
        {
            Tablo.Focus();
            ButtonGizleGoster();
            Listele();
            //  SutunGizleGoster();
            if (IsMdiChild || SeciliGelecekId == -1) return;
            Tablo.RowFocus("Id", SeciliGelecekId);
        }

        private void ButtonGizleGoster()
        {

            btnSec.Visibility = AktifPasifButonGoster ? BarItemVisibility.Never : IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnter.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnterAciklama.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            btnAktifPasifKartlar.Visibility = AktifPasifButonGoster ? BarItemVisibility.Always : !IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;

            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
            /* Yukarıdaki kodun aynısı foreach (BarItem item in ShowItems)
            {
                item.Visibility = BarItemVisibility.Always;
            }*/
        }

        private void SutunGizleGoster()
        {
            // throw new NotImplementedException();
        }

        private void SablonKaydet()
        {
            if (_formSablonKayitEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);

            if (_tabloSablonKayitedilecek)
                Tablo.TabloSablonKaydet(IsMdiChild ? Name + " Tablosu" : Name + " TablosuMDI");
        }

        private void SablonYukle()
        {
            if (IsMdiChild)
                Tablo.TabloSablonYukle(Name + " Tablosu");
            else
            {
                Name.FormSablonYukle(this);
                Tablo.TabloSablonYukle(Name + " TablosuMDI");
            }

        }

        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            // Tablo.OptionsSelection.MultiSelect = MultiSelect;
            //Navigator.NavigatableControl = Tablo.GridControl;
            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = DefaultCursor;

            //Güncellenecek
        }

        protected virtual void DegiskenleriDoldur()
        {

        }

        protected virtual void ShowEditForm(long id)
        {
            try
            {
                var result = FormShow.ShowDialogeditForm(BaseKartTuru, id);
                ShowEditFormDefault(result);
            }
            catch (Exception)
            {

            }
        }

        protected virtual void ShowEditFormDefault(long id)
        {
            if (id <= 0) return;
            AktifKartlariGoster = true;
            FormCaptionAyarla();
            Tablo.RowFocus("Id", id);
        }


        protected virtual void EntityDelete()
        {


            Tablo.DeleteSelectedRows();
            Tablo.RowFocus(Tablo.FocusedRowHandle);
        }

        protected virtual void SelectEntity()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                SeciliGelecekId = int.Parse(Tablo.GetFocusedRowCellValue("Id").ToString());
            }

        }

        protected virtual void Listele()
        {
            Tablo.GridControl.DataSource = null;
        }


        protected virtual void Yazdir()
        {
            TablePrintingFunctions.Yazdir(Tablo, Tablo.ViewCaption, "");
        }

        private void FormCaptionAyarla()
        {
            if (btnAktifPasifKartlar == null)
            {

                return;
            }

            if (AktifKartlariGoster == true)
            {
                btnAktifPasifKartlar.Caption = "Pasif Kartlar";
                Tablo.ViewCaption = Text;

            }
            else
            {
                btnAktifPasifKartlar.Caption = "Aktif Kartlar";
                Tablo.ViewCaption = Text + " - Pasif Kartlar";
                return;

            }
            Listele();
        }


        private void IslemTuruSec()
        {
            if (!IsMdiChild)
            {
                SelectEntity();
                AnaForm._secilenId = SeciliGelecekId;
                Close();
            }
            else
            {
                btnDuzelt.PerformClick();
                AnaForm._secilenId = -1;
            }

        }
        protected virtual void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnGonder)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnExcelStandart)
                Tablo.TabloDisariAktar(DosyaTuru.ExcelStandart, e.Item.Caption, Text);
            else if (e.Item == btnExcelFormatli)
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormat, e.Item.Caption, Text);
            else if (e.Item == btnExcelFormatsiz)
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormatsiz, e.Item.Caption, Text);
            else if (e.Item == btnWord)
                Tablo.TabloDisariAktar(DosyaTuru.WordDosyasi, e.Item.Caption, Text);
            else if (e.Item == btnPdf)
                Tablo.TabloDisariAktar(DosyaTuru.PdfDosyasi, e.Item.Caption, Text);
            else if (e.Item == btnTxt)
                Tablo.TabloDisariAktar(DosyaTuru.TxtDosyasi, e.Item.Caption, Text);
            else if (e.Item == btnYeni)
            {
                Yeni();
                Listele();
            }
            else if (e.Item == btnDuzelt)
            {
                Duzelt();
                Listele();
            }
            else if (e.Item == btnSil)
            {
                //Yetki Kontrolü
                EntityDelete();
            }

            else if (e.Item == btnSec)
            {
                SelectEntity();
                Close();
            }

            else if (e.Item == btnYenile)
            {
                Listele();
            }

            else if (e.Item == btnRaporDok)
            {
                RaporDok();
            }

            else if (e.Item == btnKolonlar)
            {
                if (Tablo.CustomizationForm == null)
                {
                    Tablo.ShowCustomization();
                }
                else Tablo.HideCustomization();
            }

            else if (e.Item == btnYazdir)
            {
                Yazdir();
            }
            else if (e.Item == btnBaskiOnizleme)
            {
                BaskiOnizleme();
            }
            else if (e.Item == btnKullaniciSorgu)
            {
                KullaniciSorgula();
            }
            else if (e.Item == btnCikis)
            {
                Close();
            }

            else if (e.Item == btnAktifPasifKartlar)
            {
                AktifKartlariGoster = !AktifKartlariGoster;
                FormCaptionAyarla();
                Listele();
            }

            Cursor.Current = DefaultCursor;
        }

        protected virtual void KullaniciSorgula()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm.KullaniciSorguFormu();
                Cursor.Current = DefaultCursor;
            }
        }



        protected virtual void Tablo_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Tablo.FocusedRowHandle > -1)
            {
                IslemTuruSec();
            }
            Cursor.Current = DefaultCursor;
        }

        protected virtual void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    IslemTuruSec();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }
        protected virtual void Yeni()
        {

        }
        protected virtual void RaporDok()
        {

        }
        protected virtual void Duzelt()
        {

        }
        protected virtual void BaskiOnizleme()
        {

        }

    }
}