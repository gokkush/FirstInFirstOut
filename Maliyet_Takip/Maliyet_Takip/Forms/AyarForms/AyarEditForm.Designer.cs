
namespace Maliyet_Takip.Forms.AyarForms
{
    partial class AyarEditForm
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
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition7 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition8 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition9 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition10 = new DevExpress.XtraLayout.RowDefinition();
            this.aDataLayoutControl = new Maliyet_Takip.UserControl.ADataLayoutControl();
            this.txtDonem = new Maliyet_Takip.UserControl.ALookUpEdit();
            this.txtBirimler = new Maliyet_Takip.UserControl.ALookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDataLayoutControl)).BeginInit();
            this.aDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirimler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(418, 109);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // aDataLayoutControl
            // 
            this.aDataLayoutControl.Controls.Add(this.txtDonem);
            this.aDataLayoutControl.Controls.Add(this.txtBirimler);
            this.aDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aDataLayoutControl.Location = new System.Drawing.Point(0, 109);
            this.aDataLayoutControl.Name = "aDataLayoutControl";
            this.aDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.aDataLayoutControl.Root = this.Root;
            this.aDataLayoutControl.Size = new System.Drawing.Size(418, 356);
            this.aDataLayoutControl.TabIndex = 2;
            this.aDataLayoutControl.Text = "aDataLayoutControl1";
            // 
            // txtDonem
            // 
            this.txtDonem.EnterMoveNextControl = true;
            this.txtDonem.Location = new System.Drawing.Point(107, 36);
            this.txtDonem.MenuManager = this.ribbon;
            this.txtDonem.Name = "txtDonem";
            this.txtDonem.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtDonem.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDonem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDonem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DonemAdi", "Dönem"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Açıklama")});
            this.txtDonem.Properties.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            this.txtDonem.Properties.ShowFooter = false;
            this.txtDonem.Size = new System.Drawing.Size(209, 20);
            this.txtDonem.StatusBarAciklama = null;
            this.txtDonem.StatusBarKisayol = "F4 : ";
            this.txtDonem.StatusBarKisayolAciklama = "Seçim Yap";
            this.txtDonem.StyleController = this.aDataLayoutControl;
            this.txtDonem.TabIndex = 5;
            this.txtDonem.EditValueChanged += new System.EventHandler(this.txtDonem_EditValueChanged);
            // 
            // txtBirimler
            // 
            this.txtBirimler.EnterMoveNextControl = true;
            this.txtBirimler.Location = new System.Drawing.Point(107, 12);
            this.txtBirimler.MenuManager = this.ribbon;
            this.txtBirimler.Name = "txtBirimler";
            this.txtBirimler.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtBirimler.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtBirimler.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBirimler.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Birim_Adi", "Birim Adı")});
            this.txtBirimler.Properties.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            this.txtBirimler.Properties.ShowFooter = false;
            this.txtBirimler.Size = new System.Drawing.Size(209, 20);
            this.txtBirimler.StatusBarAciklama = null;
            this.txtBirimler.StatusBarKisayol = "F4 : ";
            this.txtBirimler.StatusBarKisayolAciklama = "Seçim Yap";
            this.txtBirimler.StyleController = this.aDataLayoutControl;
            this.txtBirimler.TabIndex = 4;
            this.txtBirimler.EditValueChanged += new System.EventHandler(this.txtBirimler_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 200D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 100D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition3.Width = 90D;
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
            rowDefinition4.Height = 24D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition5.Height = 24D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition6.Height = 24D;
            rowDefinition6.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition7.Height = 24D;
            rowDefinition7.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition8.Height = 24D;
            rowDefinition8.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition9.Height = 24D;
            rowDefinition9.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition10.Height = 100D;
            rowDefinition10.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4,
            rowDefinition5,
            rowDefinition6,
            rowDefinition7,
            rowDefinition8,
            rowDefinition9,
            rowDefinition10});
            this.Root.Size = new System.Drawing.Size(418, 356);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txtBirimler;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem1.Size = new System.Drawing.Size(308, 24);
            this.layoutControlItem1.Text = "İlk Stok Giriş Birimi: ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(92, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtDonem;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 2;
            this.layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(308, 24);
            this.layoutControlItem2.Text = "Aktif Mali Dönem: ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(92, 13);
            // 
            // AyarEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 489);
            this.Controls.Add(this.aDataLayoutControl);
            this.IconOptions.ShowIcon = false;
            this.Name = "AyarEditForm";
            this.Text = "AyarEditForm";
            this.Load += new System.EventHandler(this.AyarEditForm_Load);
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.aDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDataLayoutControl)).EndInit();
            this.aDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDonem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirimler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControl.ADataLayoutControl aDataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControl.ALookUpEdit txtBirimler;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private UserControl.ALookUpEdit txtDonem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}