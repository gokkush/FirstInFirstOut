using Maliyet_Takip.Functions;
using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.Kullanici
{
    public partial class KullaniciSorguForm : DevExpress.XtraEditors.XtraForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        SqlCommand komut;
        SqlDataReader oku;
        public KullaniciSorguForm()
        {
            InitializeComponent();
            if (AnaForm._saveUser > -1)
            {
                lblSaveDate.Visible = true;
                lblSaveUser.Visible = true;
                komut = new SqlCommand("Select * from Kullanicilar where Id = '" + AnaForm._saveUser + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    lblSaveUser.Text = oku["Adi"].ToString() + " " + oku["Soyadi"].ToString();
                    lblSaveDate.Text = AnaForm._saveDate.ToString();
                }
                komut.Dispose();
                baglan.bgl(false);
            }
            else
            {
                lblSaveDate.Visible = false;
                lblSaveUser.Visible = false;
            }
            if (AnaForm._editUser > -1)
            {
                lblEditDate.Visible = true;
                lblEditUser.Visible = true;
                komut = new SqlCommand("Select * from Kullanicilar where Id = '" + AnaForm._editUser + "'", baglan.bgl());
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    lblEditUser.Text = oku["Adi"].ToString() + " " + oku["Soyadi"].ToString();
                    lblEditDate.Text = AnaForm._editDate.ToString();
                }
                komut.Dispose();
                baglan.bgl(false);
            }
            else
            {
                lblEditDate.Visible = false;
                lblEditUser.Visible = false;
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}