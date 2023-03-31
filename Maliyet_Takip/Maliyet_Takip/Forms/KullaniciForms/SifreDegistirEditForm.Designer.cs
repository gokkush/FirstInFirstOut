
namespace Maliyet_Takip.Forms.KullaniciForms
{
    partial class SifreDegistirEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            this.aDataLayoutControl = new Maliyet_Takip.UserControl.ADataLayoutControl();
            this.txtYeniSifreTekrar = new Maliyet_Takip.UserControl.ATextEdit();
            this.txtYeniSifre = new Maliyet_Takip.UserControl.ATextEdit();
            this.txtEskiSifre = new Maliyet_Takip.UserControl.ATextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDataLayoutControl)).BeginInit();
            this.aDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(323, 109);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // aDataLayoutControl
            // 
            this.aDataLayoutControl.Controls.Add(this.txtYeniSifreTekrar);
            this.aDataLayoutControl.Controls.Add(this.txtYeniSifre);
            this.aDataLayoutControl.Controls.Add(this.txtEskiSifre);
            this.aDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aDataLayoutControl.Location = new System.Drawing.Point(0, 109);
            this.aDataLayoutControl.Name = "aDataLayoutControl";
            this.aDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.aDataLayoutControl.Root = this.Root;
            this.aDataLayoutControl.Size = new System.Drawing.Size(323, 111);
            this.aDataLayoutControl.TabIndex = 2;
            this.aDataLayoutControl.Text = "aDataLayoutControl1";
            // 
            // txtYeniSifreTekrar
            // 
            this.txtYeniSifreTekrar.EnterMoveNextControl = true;
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(159, 60);
            this.txtYeniSifreTekrar.MenuManager = this.ribbon;
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtYeniSifreTekrar.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtYeniSifreTekrar.Properties.MaxLength = 50;
            this.txtYeniSifreTekrar.Properties.UseSystemPasswordChar = true;
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(99, 20);
            this.txtYeniSifreTekrar.StatusBarAciklama = null;
            this.txtYeniSifreTekrar.StyleController = this.aDataLayoutControl;
            this.txtYeniSifreTekrar.TabIndex = 6;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.EnterMoveNextControl = true;
            this.txtYeniSifre.Location = new System.Drawing.Point(159, 36);
            this.txtYeniSifre.MenuManager = this.ribbon;
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtYeniSifre.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtYeniSifre.Properties.MaxLength = 50;
            this.txtYeniSifre.Properties.UseSystemPasswordChar = true;
            this.txtYeniSifre.Size = new System.Drawing.Size(99, 20);
            this.txtYeniSifre.StatusBarAciklama = null;
            this.txtYeniSifre.StyleController = this.aDataLayoutControl;
            this.txtYeniSifre.TabIndex = 5;
            // 
            // txtEskiSifre
            // 
            this.txtEskiSifre.EnterMoveNextControl = true;
            this.txtEskiSifre.Location = new System.Drawing.Point(159, 12);
            this.txtEskiSifre.MenuManager = this.ribbon;
            this.txtEskiSifre.Name = "txtEskiSifre";
            this.txtEskiSifre.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtEskiSifre.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtEskiSifre.Properties.MaxLength = 50;
            this.txtEskiSifre.Properties.UseSystemPasswordChar = true;
            this.txtEskiSifre.Size = new System.Drawing.Size(99, 20);
            this.txtEskiSifre.StatusBarAciklama = null;
            this.txtEskiSifre.StyleController = this.aDataLayoutControl;
            this.txtEskiSifre.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 50D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition2.Width = 200D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
            rowDefinition1.Height = 24D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition2.Height = 24D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition3.Height = 24D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition4.Height = 100D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4});
            this.Root.Size = new System.Drawing.Size(323, 111);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txtEskiSifre;
            this.layoutControlItem1.Location = new System.Drawing.Point(50, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem1.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem1.Text = "Eski Şifre: ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtYeniSifre;
            this.layoutControlItem2.Location = new System.Drawing.Point(50, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem2.Text = "Yeni Şifre :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem3.Control = this.txtYeniSifreTekrar;
            this.layoutControlItem3.Location = new System.Drawing.Point(50, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem3.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem3.Text = "Yeni Şifre : (Tekrar)";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // SifreDegistirEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 244);
            this.Controls.Add(this.aDataLayoutControl);
            this.IconOptions.ShowIcon = false;
            this.MaximumSize = new System.Drawing.Size(325, 245);
            this.MinimumSize = new System.Drawing.Size(325, 245);
            this.Name = "SifreDegistirEditForm";
            this.Text = "Şifre Değiştir";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.aDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDataLayoutControl)).EndInit();
            this.aDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEskiSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControl.ADataLayoutControl aDataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControl.ATextEdit txtYeniSifreTekrar;
        private UserControl.ATextEdit txtYeniSifre;
        private UserControl.ATextEdit txtEskiSifre;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}