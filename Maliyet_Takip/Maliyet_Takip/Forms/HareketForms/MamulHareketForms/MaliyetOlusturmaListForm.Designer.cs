
namespace Maliyet_Takip.Forms.HareketForms.MamulHareketForms
{
    partial class MaliyetOlusturmaListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaliyetOlusturmaListForm));
            this.grid = new Maliyet_Takip.UserControl.AGridControl();
            this.tablo = new Maliyet_Takip.UserControl.AGridView();
            this.colId = new Maliyet_Takip.UserControl.AGridColumn();
            this.colKod = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEvrakTuru = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAciklama = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBirim_Adi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveUser = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditUser = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEvrakTarihi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colDirekMalzemeGider = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEndirekMalzemeGider = new Maliyet_Takip.UserControl.AGridColumn();
            this.colMaliyetToplami = new Maliyet_Takip.UserControl.AGridColumn();
            this.colStokAdi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colMamulKodu = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBirimi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBarkodu = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBirimMaliyetTutari = new Maliyet_Takip.UserControl.AGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbon.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbon.SearchEditItem.EditWidth = 150;
            this.ribbon.SearchEditItem.Id = -5000;
            this.ribbon.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(946, 109);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnGonder
            // 
            this.btnGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.Image")));
            this.btnGonder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.LargeImage")));
            // 
            // barSubItem2
            // 
            this.barSubItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.Image")));
            this.barSubItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.LargeImage")));
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 109);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbon;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(946, 395);
            this.grid.TabIndex = 3;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colKod,
            this.colEvrakTuru,
            this.colAciklama,
            this.colBirim_Adi,
            this.colSaveDate,
            this.colSaveUser,
            this.colEditDate,
            this.colEditUser,
            this.colEvrakTarihi,
            this.colDirekMalzemeGider,
            this.colEndirekMalzemeGider,
            this.colMaliyetToplami,
            this.colStokAdi,
            this.colMamulKodu,
            this.colBirimi,
            this.colBarkodu,
            this.colBirimMaliyetTutari});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisayol = null;
            this.tablo.StatusBarKisayolAciklama = null;
            this.tablo.ViewCaption = "Maliyetler";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.StatusBarAciklama = null;
            this.colId.StatusBarKisayol = null;
            this.colId.StatusBarKisayolAciklama = null;
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.StatusBarAciklama = null;
            this.colKod.StatusBarKisayol = null;
            this.colKod.StatusBarKisayolAciklama = null;
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 87;
            // 
            // colEvrakTuru
            // 
            this.colEvrakTuru.Caption = "Evrak Türü";
            this.colEvrakTuru.FieldName = "EvrakTuru";
            this.colEvrakTuru.Name = "colEvrakTuru";
            this.colEvrakTuru.OptionsColumn.AllowEdit = false;
            this.colEvrakTuru.StatusBarAciklama = null;
            this.colEvrakTuru.StatusBarKisayol = null;
            this.colEvrakTuru.StatusBarKisayolAciklama = null;
            this.colEvrakTuru.Visible = true;
            this.colEvrakTuru.VisibleIndex = 2;
            this.colEvrakTuru.Width = 110;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.StatusBarAciklama = null;
            this.colAciklama.StatusBarKisayol = null;
            this.colAciklama.StatusBarKisayolAciklama = null;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 12;
            this.colAciklama.Width = 355;
            // 
            // colBirim_Adi
            // 
            this.colBirim_Adi.Caption = "Maliyet Birimi";
            this.colBirim_Adi.FieldName = "Birim_Adi";
            this.colBirim_Adi.Name = "colBirim_Adi";
            this.colBirim_Adi.OptionsColumn.AllowEdit = false;
            this.colBirim_Adi.StatusBarAciklama = null;
            this.colBirim_Adi.StatusBarKisayol = null;
            this.colBirim_Adi.StatusBarKisayolAciklama = null;
            this.colBirim_Adi.Visible = true;
            this.colBirim_Adi.VisibleIndex = 3;
            this.colBirim_Adi.Width = 178;
            // 
            // colSaveDate
            // 
            this.colSaveDate.Caption = "SaveDate";
            this.colSaveDate.FieldName = "SaveDate";
            this.colSaveDate.Name = "colSaveDate";
            this.colSaveDate.OptionsColumn.AllowEdit = false;
            this.colSaveDate.OptionsColumn.ShowInCustomizationForm = false;
            this.colSaveDate.StatusBarAciklama = null;
            this.colSaveDate.StatusBarKisayol = null;
            this.colSaveDate.StatusBarKisayolAciklama = null;
            // 
            // colSaveUser
            // 
            this.colSaveUser.Caption = "SaveUser";
            this.colSaveUser.FieldName = "SaveUser";
            this.colSaveUser.Name = "colSaveUser";
            this.colSaveUser.OptionsColumn.AllowEdit = false;
            this.colSaveUser.OptionsColumn.ShowInCustomizationForm = false;
            this.colSaveUser.StatusBarAciklama = null;
            this.colSaveUser.StatusBarKisayol = null;
            this.colSaveUser.StatusBarKisayolAciklama = null;
            // 
            // colEditDate
            // 
            this.colEditDate.Caption = "EditDate";
            this.colEditDate.FieldName = "EditDate";
            this.colEditDate.Name = "colEditDate";
            this.colEditDate.OptionsColumn.AllowEdit = false;
            this.colEditDate.OptionsColumn.ShowInCustomizationForm = false;
            this.colEditDate.StatusBarAciklama = null;
            this.colEditDate.StatusBarKisayol = null;
            this.colEditDate.StatusBarKisayolAciklama = null;
            // 
            // colEditUser
            // 
            this.colEditUser.Caption = "EditUser";
            this.colEditUser.FieldName = "EditUser";
            this.colEditUser.Name = "colEditUser";
            this.colEditUser.OptionsColumn.AllowEdit = false;
            this.colEditUser.OptionsColumn.ShowInCustomizationForm = false;
            this.colEditUser.StatusBarAciklama = null;
            this.colEditUser.StatusBarKisayol = null;
            this.colEditUser.StatusBarKisayolAciklama = null;
            // 
            // colEvrakTarihi
            // 
            this.colEvrakTarihi.Caption = "İşlem Tarihi";
            this.colEvrakTarihi.FieldName = "EvrakTarihi";
            this.colEvrakTarihi.Name = "colEvrakTarihi";
            this.colEvrakTarihi.OptionsColumn.AllowEdit = false;
            this.colEvrakTarihi.StatusBarAciklama = null;
            this.colEvrakTarihi.StatusBarKisayol = null;
            this.colEvrakTarihi.StatusBarKisayolAciklama = null;
            this.colEvrakTarihi.Visible = true;
            this.colEvrakTarihi.VisibleIndex = 1;
            this.colEvrakTarihi.Width = 110;
            // 
            // colDirekMalzemeGider
            // 
            this.colDirekMalzemeGider.Caption = "Direk İlk Malzeme Gideri";
            this.colDirekMalzemeGider.FieldName = "DirekMalzemeGider";
            this.colDirekMalzemeGider.Name = "colDirekMalzemeGider";
            this.colDirekMalzemeGider.OptionsColumn.AllowEdit = false;
            this.colDirekMalzemeGider.StatusBarAciklama = null;
            this.colDirekMalzemeGider.StatusBarKisayol = null;
            this.colDirekMalzemeGider.StatusBarKisayolAciklama = null;
            this.colDirekMalzemeGider.Visible = true;
            this.colDirekMalzemeGider.VisibleIndex = 8;
            this.colDirekMalzemeGider.Width = 133;
            // 
            // colEndirekMalzemeGider
            // 
            this.colEndirekMalzemeGider.Caption = "Endirek İlk Malzeme Gider";
            this.colEndirekMalzemeGider.FieldName = "EndirekMalzemeGider";
            this.colEndirekMalzemeGider.Name = "colEndirekMalzemeGider";
            this.colEndirekMalzemeGider.OptionsColumn.AllowEdit = false;
            this.colEndirekMalzemeGider.StatusBarAciklama = null;
            this.colEndirekMalzemeGider.StatusBarKisayol = null;
            this.colEndirekMalzemeGider.StatusBarKisayolAciklama = null;
            this.colEndirekMalzemeGider.Visible = true;
            this.colEndirekMalzemeGider.VisibleIndex = 9;
            this.colEndirekMalzemeGider.Width = 143;
            // 
            // colMaliyetToplami
            // 
            this.colMaliyetToplami.Caption = "Maliyet Toplam";
            this.colMaliyetToplami.FieldName = "MaliyetToplami";
            this.colMaliyetToplami.Name = "colMaliyetToplami";
            this.colMaliyetToplami.OptionsColumn.AllowEdit = false;
            this.colMaliyetToplami.StatusBarAciklama = null;
            this.colMaliyetToplami.StatusBarKisayol = null;
            this.colMaliyetToplami.StatusBarKisayolAciklama = null;
            this.colMaliyetToplami.Visible = true;
            this.colMaliyetToplami.VisibleIndex = 10;
            this.colMaliyetToplami.Width = 113;
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "Mamül Adı";
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.OptionsColumn.AllowEdit = false;
            this.colStokAdi.StatusBarAciklama = null;
            this.colStokAdi.StatusBarKisayol = null;
            this.colStokAdi.StatusBarKisayolAciklama = null;
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 5;
            // 
            // colMamulKodu
            // 
            this.colMamulKodu.Caption = "Mamul Kodu";
            this.colMamulKodu.FieldName = "MamulKodu";
            this.colMamulKodu.Name = "colMamulKodu";
            this.colMamulKodu.OptionsColumn.AllowEdit = false;
            this.colMamulKodu.StatusBarAciklama = null;
            this.colMamulKodu.StatusBarKisayol = null;
            this.colMamulKodu.StatusBarKisayolAciklama = null;
            this.colMamulKodu.Visible = true;
            this.colMamulKodu.VisibleIndex = 4;
            // 
            // colBirimi
            // 
            this.colBirimi.Caption = "Birimi";
            this.colBirimi.FieldName = "Birimi";
            this.colBirimi.Name = "colBirimi";
            this.colBirimi.OptionsColumn.AllowEdit = false;
            this.colBirimi.StatusBarAciklama = null;
            this.colBirimi.StatusBarKisayol = null;
            this.colBirimi.StatusBarKisayolAciklama = null;
            this.colBirimi.Visible = true;
            this.colBirimi.VisibleIndex = 6;
            // 
            // colBarkodu
            // 
            this.colBarkodu.Caption = "Barkodu";
            this.colBarkodu.FieldName = "Barkodu";
            this.colBarkodu.Name = "colBarkodu";
            this.colBarkodu.OptionsColumn.AllowEdit = false;
            this.colBarkodu.StatusBarAciklama = null;
            this.colBarkodu.StatusBarKisayol = null;
            this.colBarkodu.StatusBarKisayolAciklama = null;
            this.colBarkodu.Visible = true;
            this.colBarkodu.VisibleIndex = 7;
            // 
            // colBirimMaliyetTutari
            // 
            this.colBirimMaliyetTutari.Caption = "Birim Maliyeti";
            this.colBirimMaliyetTutari.FieldName = "BirimMaliyetTutari";
            this.colBirimMaliyetTutari.Name = "colBirimMaliyetTutari";
            this.colBirimMaliyetTutari.OptionsColumn.AllowEdit = false;
            this.colBirimMaliyetTutari.StatusBarAciklama = null;
            this.colBirimMaliyetTutari.StatusBarKisayol = null;
            this.colBirimMaliyetTutari.StatusBarKisayolAciklama = null;
            this.colBirimMaliyetTutari.Visible = true;
            this.colBirimMaliyetTutari.VisibleIndex = 11;
            this.colBirimMaliyetTutari.Width = 100;
            // 
            // MaliyetOlusturmaListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 528);
            this.Controls.Add(this.grid);
            this.IconOptions.ShowIcon = false;
            this.Name = "MaliyetOlusturmaListForm";
            this.Text = "Maliyetler Listesi";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControl.AGridControl grid;
        private UserControl.AGridView tablo;
        private UserControl.AGridColumn colId;
        private UserControl.AGridColumn colKod;
        private UserControl.AGridColumn colEvrakTuru;
        private UserControl.AGridColumn colAciklama;
        private UserControl.AGridColumn colBirim_Adi;
        private UserControl.AGridColumn colSaveDate;
        private UserControl.AGridColumn colSaveUser;
        private UserControl.AGridColumn colEditDate;
        private UserControl.AGridColumn colEditUser;
        private UserControl.AGridColumn colEvrakTarihi;
        private UserControl.AGridColumn colDirekMalzemeGider;
        private UserControl.AGridColumn colEndirekMalzemeGider;
        private UserControl.AGridColumn colMaliyetToplami;
        private UserControl.AGridColumn colStokAdi;
        private UserControl.AGridColumn colMamulKodu;
        private UserControl.AGridColumn colBirimi;
        private UserControl.AGridColumn colBarkodu;
        private UserControl.AGridColumn colBirimMaliyetTutari;
    }
}