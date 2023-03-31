
namespace Maliyet_Takip.Forms.Kullanici
{
    partial class KullaniciSorguForm
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblEditDate = new DevExpress.XtraEditors.LabelControl();
            this.lblEditUser = new DevExpress.XtraEditors.LabelControl();
            this.lblSaveDate = new DevExpress.XtraEditors.LabelControl();
            this.lblSaveUser = new DevExpress.XtraEditors.LabelControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 13);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Düzenleme Tarihi: ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(126, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Düzenleyen Kullanıcı: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(99, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Kaydetme Tarihi: ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Kaydeden Kullanıcı: ";
            // 
            // lblEditDate
            // 
            this.lblEditDate.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblEditDate.Appearance.Options.UseForeColor = true;
            this.lblEditDate.Location = new System.Drawing.Point(144, 81);
            this.lblEditDate.Name = "lblEditDate";
            this.lblEditDate.Size = new System.Drawing.Size(63, 13);
            this.lblEditDate.TabIndex = 13;
            this.lblEditDate.Text = "labelControl1";
            this.lblEditDate.Visible = false;
            // 
            // lblEditUser
            // 
            this.lblEditUser.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblEditUser.Appearance.Options.UseForeColor = true;
            this.lblEditUser.Location = new System.Drawing.Point(144, 58);
            this.lblEditUser.Name = "lblEditUser";
            this.lblEditUser.Size = new System.Drawing.Size(63, 13);
            this.lblEditUser.TabIndex = 12;
            this.lblEditUser.Text = "labelControl1";
            this.lblEditUser.Visible = false;
            // 
            // lblSaveDate
            // 
            this.lblSaveDate.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblSaveDate.Appearance.Options.UseForeColor = true;
            this.lblSaveDate.Location = new System.Drawing.Point(144, 35);
            this.lblSaveDate.Name = "lblSaveDate";
            this.lblSaveDate.Size = new System.Drawing.Size(63, 13);
            this.lblSaveDate.TabIndex = 11;
            this.lblSaveDate.Text = "labelControl1";
            // 
            // lblSaveUser
            // 
            this.lblSaveUser.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblSaveUser.Appearance.Options.UseForeColor = true;
            this.lblSaveUser.Location = new System.Drawing.Point(144, 12);
            this.lblSaveUser.Name = "lblSaveUser";
            this.lblSaveUser.Size = new System.Drawing.Size(63, 13);
            this.lblSaveUser.TabIndex = 10;
            this.lblSaveUser.Text = "labelControl1";
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(121, 118);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(118, 43);
            this.btnKapat.TabIndex = 9;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // KullaniciSorguForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 173);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblEditDate);
            this.Controls.Add(this.lblEditUser);
            this.Controls.Add(this.lblSaveDate);
            this.Controls.Add(this.lblSaveUser);
            this.Controls.Add(this.btnKapat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.ShowIcon = false;
            this.Name = "KullaniciSorguForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KullaniciSorguForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblEditDate;
        private DevExpress.XtraEditors.LabelControl lblEditUser;
        private DevExpress.XtraEditors.LabelControl lblSaveDate;
        private DevExpress.XtraEditors.LabelControl lblSaveUser;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
    }
}