
namespace Maliyet_Takip.Forms.CariForms
{
    partial class CariListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CariListForm));
            this.grid = new Maliyet_Takip.UserControl.AGridControl();
            this.tablo = new Maliyet_Takip.UserControl.AGridView();
            this.colId = new Maliyet_Takip.UserControl.AGridColumn();
            this.colKod = new Maliyet_Takip.UserControl.AGridColumn();
            this.colACariAdi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colVergiDairesi = new Maliyet_Takip.UserControl.AGridColumn();
            this.colVergiNo = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAdres = new Maliyet_Takip.UserControl.AGridColumn();
            this.colTelefon = new Maliyet_Takip.UserControl.AGridColumn();
            this.colFaks = new Maliyet_Takip.UserControl.AGridColumn();
            this.colMail = new Maliyet_Takip.UserControl.AGridColumn();
            this.colAciklama = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colSaveUser = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditDate = new Maliyet_Takip.UserControl.AGridColumn();
            this.colEditUser = new Maliyet_Takip.UserControl.AGridColumn();
            this.colYetkiliTel = new Maliyet_Takip.UserControl.AGridColumn();
            this.colYetkili = new Maliyet_Takip.UserControl.AGridColumn();
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
            this.colACariAdi,
            this.colVergiDairesi,
            this.colVergiNo,
            this.colAdres,
            this.colTelefon,
            this.colFaks,
            this.colYetkili,
            this.colYetkiliTel,
            this.colMail,
            this.colAciklama,
            this.colSaveDate,
            this.colSaveUser,
            this.colEditDate,
            this.colEditUser});
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
            // 
            // colACariAdi
            // 
            this.colACariAdi.Caption = "Cari Adı";
            this.colACariAdi.FieldName = "CariAdi";
            this.colACariAdi.Name = "colACariAdi";
            this.colACariAdi.OptionsColumn.AllowEdit = false;
            this.colACariAdi.StatusBarAciklama = null;
            this.colACariAdi.StatusBarKisayol = null;
            this.colACariAdi.StatusBarKisayolAciklama = null;
            this.colACariAdi.Visible = true;
            this.colACariAdi.VisibleIndex = 1;
            this.colACariAdi.Width = 158;
            // 
            // colVergiDairesi
            // 
            this.colVergiDairesi.Caption = "Vergi Dairesi";
            this.colVergiDairesi.FieldName = "VergiDairesi";
            this.colVergiDairesi.Name = "colVergiDairesi";
            this.colVergiDairesi.OptionsColumn.AllowEdit = false;
            this.colVergiDairesi.StatusBarAciklama = null;
            this.colVergiDairesi.StatusBarKisayol = null;
            this.colVergiDairesi.StatusBarKisayolAciklama = null;
            this.colVergiDairesi.Visible = true;
            this.colVergiDairesi.VisibleIndex = 2;
            // 
            // colVergiNo
            // 
            this.colVergiNo.Caption = "Vergi Numarası";
            this.colVergiNo.FieldName = "VergiNo";
            this.colVergiNo.Name = "colVergiNo";
            this.colVergiNo.OptionsColumn.AllowEdit = false;
            this.colVergiNo.StatusBarAciklama = null;
            this.colVergiNo.StatusBarKisayol = null;
            this.colVergiNo.StatusBarKisayolAciklama = null;
            this.colVergiNo.Visible = true;
            this.colVergiNo.VisibleIndex = 3;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adres";
            this.colAdres.FieldName = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.OptionsColumn.AllowEdit = false;
            this.colAdres.StatusBarAciklama = null;
            this.colAdres.StatusBarKisayol = null;
            this.colAdres.StatusBarKisayolAciklama = null;
            this.colAdres.Visible = true;
            this.colAdres.VisibleIndex = 4;
            this.colAdres.Width = 168;
            // 
            // colTelefon
            // 
            this.colTelefon.Caption = "Telefon";
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.OptionsColumn.AllowEdit = false;
            this.colTelefon.StatusBarAciklama = null;
            this.colTelefon.StatusBarKisayol = null;
            this.colTelefon.StatusBarKisayolAciklama = null;
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 5;
            // 
            // colFaks
            // 
            this.colFaks.Caption = "Faks";
            this.colFaks.FieldName = "Faks";
            this.colFaks.Name = "colFaks";
            this.colFaks.OptionsColumn.AllowEdit = false;
            this.colFaks.StatusBarAciklama = null;
            this.colFaks.StatusBarKisayol = null;
            this.colFaks.StatusBarKisayolAciklama = null;
            this.colFaks.Visible = true;
            this.colFaks.VisibleIndex = 6;
            // 
            // colMail
            // 
            this.colMail.Caption = "E-Mail";
            this.colMail.FieldName = "Mail";
            this.colMail.Name = "colMail";
            this.colMail.OptionsColumn.AllowEdit = false;
            this.colMail.StatusBarAciklama = null;
            this.colMail.StatusBarKisayol = null;
            this.colMail.StatusBarKisayolAciklama = null;
            this.colMail.Visible = true;
            this.colMail.VisibleIndex = 7;
            this.colMail.Width = 126;
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
            this.colAciklama.VisibleIndex = 10;
            this.colAciklama.Width = 182;
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
            // colYetkiliTel
            // 
            this.colYetkiliTel.Caption = "Yetkili Telefonu";
            this.colYetkiliTel.FieldName = "YetkiliTel";
            this.colYetkiliTel.Name = "colYetkiliTel";
            this.colYetkiliTel.OptionsColumn.AllowEdit = false;
            this.colYetkiliTel.StatusBarAciklama = null;
            this.colYetkiliTel.StatusBarKisayol = null;
            this.colYetkiliTel.StatusBarKisayolAciklama = null;
            this.colYetkiliTel.Visible = true;
            this.colYetkiliTel.VisibleIndex = 9;
            this.colYetkiliTel.Width = 97;
            // 
            // colYetkili
            // 
            this.colYetkili.Caption = "Yetkili Kişi";
            this.colYetkili.FieldName = "Yetkili";
            this.colYetkili.Name = "colYetkili";
            this.colYetkili.OptionsColumn.AllowEdit = false;
            this.colYetkili.StatusBarAciklama = null;
            this.colYetkili.StatusBarKisayol = null;
            this.colYetkili.StatusBarKisayolAciklama = null;
            this.colYetkili.Visible = true;
            this.colYetkili.VisibleIndex = 8;
            this.colYetkili.Width = 116;
            // 
            // CariListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 528);
            this.Controls.Add(this.grid);
            this.IconOptions.ShowIcon = false;
            this.Name = "CariListForm";
            this.Text = "CariListForm";
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
        private UserControl.AGridColumn colSaveDate;
        private UserControl.AGridColumn colSaveUser;
        private UserControl.AGridColumn colEditDate;
        private UserControl.AGridColumn colEditUser;
        private UserControl.AGridColumn colACariAdi;
        private UserControl.AGridColumn colVergiDairesi;
        private UserControl.AGridColumn colVergiNo;
        private UserControl.AGridColumn colAdres;
        private UserControl.AGridColumn colTelefon;
        private UserControl.AGridColumn colFaks;
        private UserControl.AGridColumn colMail;
        private UserControl.AGridColumn colAciklama;
        private UserControl.AGridColumn colYetkili;
        private UserControl.AGridColumn colYetkiliTel;
    }
}