
namespace Maliyet_Takip.Forms.MamulForms
{
    partial class MamulListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MamulListForm));
            this.grid = new Maliyet_Takip.UserControl.AGridControl();
            this.tablo = new Maliyet_Takip.UserControl.AGridView();
            this.colId = new Maliyet_Takip.UserControl.AGridColumn();
            this.colKod = new Maliyet_Takip.UserControl.AGridColumn();
            this.colStokAdi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBarkodu = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAlisKDV = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSatisKDV = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAltLimit = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveUser = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditUser = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAciklama = new Maliyet_Takip.UserControl.AGridColumn();
            this.colGrupAdi = new Maliyet_Takip.UserControl.AGridColumn();
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
            this.colKod,
            this.colStokAdi,
            this.colBarkodu,
            this.colAlisKDV,
            this.colSatisKDV,
            this.colAltLimit,
            this.colSaveDate,
            this.colSaveUser,
            this.colEditDate,
            this.colEditUser,
            this.colAciklama,
            this.colGrupAdi});
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
            this.tablo.ViewCaption = "Mamüller";
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
            this.colStokAdi.VisibleIndex = 1;
            this.colStokAdi.Width = 176;
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
            this.colBarkodu.VisibleIndex = 2;
            this.colBarkodu.Width = 131;
            // 
            // colAlisKDV
            // 
            this.colAlisKDV.Caption = "Alış KDV";
            this.colAlisKDV.FieldName = "AlisKDV";
            this.colAlisKDV.Name = "colAlisKDV";
            this.colAlisKDV.OptionsColumn.AllowEdit = false;
            this.colAlisKDV.StatusBarAciklama = null;
            this.colAlisKDV.StatusBarKisayol = null;
            this.colAlisKDV.StatusBarKisayolAciklama = null;
            this.colAlisKDV.Visible = true;
            this.colAlisKDV.VisibleIndex = 3;
            // 
            // colSatisKDV
            // 
            this.colSatisKDV.Caption = "Satış KDV";
            this.colSatisKDV.FieldName = "SatisKDV";
            this.colSatisKDV.Name = "colSatisKDV";
            this.colSatisKDV.OptionsColumn.AllowEdit = false;
            this.colSatisKDV.StatusBarAciklama = null;
            this.colSatisKDV.StatusBarKisayol = null;
            this.colSatisKDV.StatusBarKisayolAciklama = null;
            this.colSatisKDV.Visible = true;
            this.colSatisKDV.VisibleIndex = 4;
            // 
            // colAltLimit
            // 
            this.colAltLimit.Caption = "Alt Limiti";
            this.colAltLimit.FieldName = "AltLimit";
            this.colAltLimit.Name = "colAltLimit";
            this.colAltLimit.OptionsColumn.AllowEdit = false;
            this.colAltLimit.StatusBarAciklama = null;
            this.colAltLimit.StatusBarKisayol = null;
            this.colAltLimit.StatusBarKisayolAciklama = null;
            this.colAltLimit.Visible = true;
            this.colAltLimit.VisibleIndex = 5;
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
            this.colAciklama.VisibleIndex = 8;
            this.colAciklama.Width = 287;
            // 
            // colGrupAdi
            // 
            this.colGrupAdi.Caption = "Stok Grubu";
            this.colGrupAdi.FieldName = "GrupAdi";
            this.colGrupAdi.Name = "colGrupAdi";
            this.colGrupAdi.OptionsColumn.AllowEdit = false;
            this.colGrupAdi.StatusBarAciklama = null;
            this.colGrupAdi.StatusBarKisayol = null;
            this.colGrupAdi.StatusBarKisayolAciklama = null;
            this.colGrupAdi.Visible = true;
            this.colGrupAdi.VisibleIndex = 6;
            this.colGrupAdi.Width = 151;
            // 
            // MamulListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 528);
            this.Controls.Add(this.grid);
            this.IconOptions.ShowIcon = false;
            this.Name = "MamulListForm";
            this.Text = "Mamul Listesi";
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
        private UserControl.AGridColumn colStokAdi;
        private UserControl.AGridColumn colBarkodu;
        private UserControl.AGridColumn colAlisKDV;
        private UserControl.AGridColumn colSatisKDV;
        private UserControl.AGridColumn colAltLimit;
        private UserControl.AGridColumn colSaveDate;
        private UserControl.AGridColumn colSaveUser;
        private UserControl.AGridColumn colEditDate;
        private UserControl.AGridColumn colEditUser;
        private UserControl.AGridColumn colAciklama;
        private UserControl.AGridColumn colGrupAdi;
    }
}