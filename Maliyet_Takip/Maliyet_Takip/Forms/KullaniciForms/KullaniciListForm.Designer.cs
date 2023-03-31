
namespace Maliyet_Takip.Forms.Kullanici
{
    partial class KullaniciListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciListForm));
            this.grid = new Maliyet_Takip.UserControl.AGridControl();
            this.tablo = new Maliyet_Takip.UserControl.AGridView();
            this.colId = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSicil = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAdi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSoyadi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colTelefon = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAdres = new Maliyet_Takip.UserControl.AGridColumn();
            this.colMail = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAciklama = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBirim_Adi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colGorevi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colUnvan_Adi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditUser = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveUser = new Maliyet_Takip.UserControl.AGridColumn();
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
            this.grid.Size = new System.Drawing.Size(1063, 395);
            this.grid.TabIndex = 2;
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
            this.colSicil,
            this.colAdi,
            this.colSoyadi,
            this.colTelefon,
            this.colAdres,
            this.colMail,
            this.colAciklama,
            this.colBirim_Adi,
            this.colGorevi,
            this.colUnvan_Adi,
            this.colSaveDate,
            this.colEditDate,
            this.colEditUser,
            this.colSaveUser});
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
            this.tablo.ViewCaption = "Kullanıcılar";
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
            // colSicil
            // 
            this.colSicil.AppearanceCell.Options.UseTextOptions = true;
            this.colSicil.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSicil.Caption = "Sicil";
            this.colSicil.FieldName = "Sicili";
            this.colSicil.Name = "colSicil";
            this.colSicil.OptionsColumn.AllowEdit = false;
            this.colSicil.StatusBarAciklama = null;
            this.colSicil.StatusBarKisayol = null;
            this.colSicil.StatusBarKisayolAciklama = null;
            this.colSicil.Visible = true;
            this.colSicil.VisibleIndex = 0;
            // 
            // colAdi
            // 
            this.colAdi.Caption = "Adı";
            this.colAdi.FieldName = "Adi";
            this.colAdi.Name = "colAdi";
            this.colAdi.OptionsColumn.AllowEdit = false;
            this.colAdi.StatusBarAciklama = null;
            this.colAdi.StatusBarKisayol = null;
            this.colAdi.StatusBarKisayolAciklama = null;
            this.colAdi.Visible = true;
            this.colAdi.VisibleIndex = 1;
            // 
            // colSoyadi
            // 
            this.colSoyadi.Caption = "Soyadı";
            this.colSoyadi.FieldName = "Soyadi";
            this.colSoyadi.Name = "colSoyadi";
            this.colSoyadi.OptionsColumn.AllowEdit = false;
            this.colSoyadi.StatusBarAciklama = null;
            this.colSoyadi.StatusBarKisayol = null;
            this.colSoyadi.StatusBarKisayolAciklama = null;
            this.colSoyadi.Visible = true;
            this.colSoyadi.VisibleIndex = 2;
            // 
            // colTelefon
            // 
            this.colTelefon.Caption = "Telefonu";
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.OptionsColumn.AllowEdit = false;
            this.colTelefon.StatusBarAciklama = null;
            this.colTelefon.StatusBarKisayol = null;
            this.colTelefon.StatusBarKisayolAciklama = null;
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 6;
            this.colTelefon.Width = 87;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adresi";
            this.colAdres.FieldName = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.OptionsColumn.AllowEdit = false;
            this.colAdres.StatusBarAciklama = null;
            this.colAdres.StatusBarKisayol = null;
            this.colAdres.StatusBarKisayolAciklama = null;
            this.colAdres.Visible = true;
            this.colAdres.VisibleIndex = 8;
            this.colAdres.Width = 141;
            // 
            // colMail
            // 
            this.colMail.Caption = "E-Maili";
            this.colMail.FieldName = "Mail";
            this.colMail.Name = "colMail";
            this.colMail.OptionsColumn.AllowEdit = false;
            this.colMail.StatusBarAciklama = null;
            this.colMail.StatusBarKisayol = null;
            this.colMail.StatusBarKisayolAciklama = null;
            this.colMail.Visible = true;
            this.colMail.VisibleIndex = 7;
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
            this.colAciklama.VisibleIndex = 9;
            this.colAciklama.Width = 266;
            // 
            // colBirim_Adi
            // 
            this.colBirim_Adi.Caption = "Birimi";
            this.colBirim_Adi.FieldName = "Birim_Adi";
            this.colBirim_Adi.Name = "colBirim_Adi";
            this.colBirim_Adi.OptionsColumn.AllowEdit = false;
            this.colBirim_Adi.StatusBarAciklama = null;
            this.colBirim_Adi.StatusBarKisayol = null;
            this.colBirim_Adi.StatusBarKisayolAciklama = null;
            this.colBirim_Adi.Visible = true;
            this.colBirim_Adi.VisibleIndex = 5;
            this.colBirim_Adi.Width = 152;
            // 
            // colGorevi
            // 
            this.colGorevi.Caption = "Görevi";
            this.colGorevi.FieldName = "Gorevi";
            this.colGorevi.Name = "colGorevi";
            this.colGorevi.OptionsColumn.AllowEdit = false;
            this.colGorevi.StatusBarAciklama = null;
            this.colGorevi.StatusBarKisayol = null;
            this.colGorevi.StatusBarKisayolAciklama = null;
            this.colGorevi.Visible = true;
            this.colGorevi.VisibleIndex = 4;
            // 
            // colUnvan_Adi
            // 
            this.colUnvan_Adi.Caption = "Ünvanı";
            this.colUnvan_Adi.FieldName = "Unvan_Adi";
            this.colUnvan_Adi.Name = "colUnvan_Adi";
            this.colUnvan_Adi.OptionsColumn.AllowEdit = false;
            this.colUnvan_Adi.StatusBarAciklama = null;
            this.colUnvan_Adi.StatusBarKisayol = null;
            this.colUnvan_Adi.StatusBarKisayolAciklama = null;
            this.colUnvan_Adi.Visible = true;
            this.colUnvan_Adi.VisibleIndex = 3;
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
            // KullaniciListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 528);
            this.Controls.Add(this.grid);
            this.IconOptions.ShowIcon = false;
            this.Name = "KullaniciListForm";
            this.Text = "Kullanıcı Listesi";
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
        private UserControl.AGridColumn colSicil;
        private UserControl.AGridColumn colAdi;
        private UserControl.AGridColumn colSoyadi;
        private UserControl.AGridColumn colTelefon;
        private UserControl.AGridColumn colAdres;
        private UserControl.AGridColumn colMail;
        private UserControl.AGridColumn colAciklama;
        private UserControl.AGridColumn colBirim_Adi;
        private UserControl.AGridColumn colGorevi;
        private UserControl.AGridColumn colUnvan_Adi;
        private UserControl.AGridColumn colSaveDate;
        private UserControl.AGridColumn colEditDate;
        private UserControl.AGridColumn colEditUser;
        private UserControl.AGridColumn colSaveUser;
    }
}