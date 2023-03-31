
namespace Maliyet_Takip.Forms.HareketForms.DepolarArasiSevkForms
{
    partial class MamulDepoListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MamulDepoListForm));
            this.grid = new Maliyet_Takip.UserControl.AGridControl();
            this.tablo = new Maliyet_Takip.UserControl.AGridView();
            this.colId = new Maliyet_Takip.UserControl.AGridColumn();
            this.colYER_ID = new Maliyet_Takip.UserControl.AGridColumn();
            this.colURUN_ADI = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBirimi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colBarkodu = new Maliyet_Takip.UserControl.AGridColumn();
            this.colGIRIS_MIKTARI = new Maliyet_Takip.UserControl.AGridColumn();
            this.colCIKIS_MIKTARI = new Maliyet_Takip.UserControl.AGridColumn();
            this.colKALAN_MIKTAR = new Maliyet_Takip.UserControl.AGridColumn();
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
            this.colYER_ID,
            this.colURUN_ADI,
            this.colBirimi,
            this.colBarkodu,
            this.colGIRIS_MIKTARI,
            this.colCIKIS_MIKTARI,
            this.colKALAN_MIKTAR,
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
            this.tablo.ViewCaption = "Mamül Depo Kalan Listesi";
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
            // colYER_ID
            // 
            this.colYER_ID.Caption = "YER_ID";
            this.colYER_ID.FieldName = "YER_ID";
            this.colYER_ID.Name = "colYER_ID";
            this.colYER_ID.OptionsColumn.AllowEdit = false;
            this.colYER_ID.OptionsColumn.ShowInCustomizationForm = false;
            this.colYER_ID.StatusBarAciklama = null;
            this.colYER_ID.StatusBarKisayol = null;
            this.colYER_ID.StatusBarKisayolAciklama = null;
            // 
            // colURUN_ADI
            // 
            this.colURUN_ADI.Caption = "Stok Adı";
            this.colURUN_ADI.FieldName = "URUN_ADI";
            this.colURUN_ADI.Name = "colURUN_ADI";
            this.colURUN_ADI.OptionsColumn.AllowEdit = false;
            this.colURUN_ADI.StatusBarAciklama = null;
            this.colURUN_ADI.StatusBarKisayol = null;
            this.colURUN_ADI.StatusBarKisayolAciklama = null;
            this.colURUN_ADI.Visible = true;
            this.colURUN_ADI.VisibleIndex = 1;
            this.colURUN_ADI.Width = 183;
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
            this.colBirimi.VisibleIndex = 2;
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
            this.colBarkodu.VisibleIndex = 0;
            this.colBarkodu.Width = 106;
            // 
            // colGIRIS_MIKTARI
            // 
            this.colGIRIS_MIKTARI.Caption = "Giriş Miktarı";
            this.colGIRIS_MIKTARI.FieldName = "GIRIS_MIKTARI";
            this.colGIRIS_MIKTARI.Name = "colGIRIS_MIKTARI";
            this.colGIRIS_MIKTARI.OptionsColumn.AllowEdit = false;
            this.colGIRIS_MIKTARI.StatusBarAciklama = null;
            this.colGIRIS_MIKTARI.StatusBarKisayol = null;
            this.colGIRIS_MIKTARI.StatusBarKisayolAciklama = null;
            this.colGIRIS_MIKTARI.Visible = true;
            this.colGIRIS_MIKTARI.VisibleIndex = 3;
            // 
            // colCIKIS_MIKTARI
            // 
            this.colCIKIS_MIKTARI.Caption = "Çıkış Miktarı";
            this.colCIKIS_MIKTARI.FieldName = "CIKIS_MIKTARI";
            this.colCIKIS_MIKTARI.Name = "colCIKIS_MIKTARI";
            this.colCIKIS_MIKTARI.OptionsColumn.AllowEdit = false;
            this.colCIKIS_MIKTARI.StatusBarAciklama = null;
            this.colCIKIS_MIKTARI.StatusBarKisayol = null;
            this.colCIKIS_MIKTARI.StatusBarKisayolAciklama = null;
            this.colCIKIS_MIKTARI.Visible = true;
            this.colCIKIS_MIKTARI.VisibleIndex = 4;
            // 
            // colKALAN_MIKTAR
            // 
            this.colKALAN_MIKTAR.Caption = "Kalan";
            this.colKALAN_MIKTAR.FieldName = "KALAN_MIKTAR";
            this.colKALAN_MIKTAR.Name = "colKALAN_MIKTAR";
            this.colKALAN_MIKTAR.OptionsColumn.AllowEdit = false;
            this.colKALAN_MIKTAR.StatusBarAciklama = null;
            this.colKALAN_MIKTAR.StatusBarKisayol = null;
            this.colKALAN_MIKTAR.StatusBarKisayolAciklama = null;
            this.colKALAN_MIKTAR.Visible = true;
            this.colKALAN_MIKTAR.VisibleIndex = 5;
            this.colKALAN_MIKTAR.Width = 90;
            // 
            // colSaveDate
            // 
            this.colSaveDate.Caption = "SaveDate";
            this.colSaveDate.FieldName = "SaveDate";
            this.colSaveDate.Name = "colSaveDate";
            this.colSaveDate.OptionsColumn.AllowEdit = false;
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
            this.colSaveUser.StatusBarAciklama = null;
            this.colSaveUser.StatusBarKisayol = null;
            this.colSaveUser.StatusBarKisayolAciklama = null;
            // 
            // MamulDepoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 528);
            this.Controls.Add(this.grid);
            this.IconOptions.ShowIcon = false;
            this.Name = "MamulDepoListForm";
            this.Text = "Depo Ürün Listesi";
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
        private UserControl.AGridColumn colYER_ID;
        private UserControl.AGridColumn colURUN_ADI;
        private UserControl.AGridColumn colBirimi;
        private UserControl.AGridColumn colBarkodu;
        private UserControl.AGridColumn colGIRIS_MIKTARI;
        private UserControl.AGridColumn colCIKIS_MIKTARI;
        private UserControl.AGridColumn colKALAN_MIKTAR;
        private UserControl.AGridColumn colSaveDate;
        private UserControl.AGridColumn colEditDate;
        private UserControl.AGridColumn colEditUser;
        private UserControl.AGridColumn colSaveUser;
    }
}