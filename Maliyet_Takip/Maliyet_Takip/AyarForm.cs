using DevExpress.XtraBars;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System.Configuration;
using System.Windows.Forms;

namespace Maliyet_Takip
{
    public partial class AyarForm : BaseEditForm
    {

        Configuration config;
        string _baglantiCumle = "";
        //"Data Source=LENOVO-CTE;Initial Catalog=Maliyet-Data;User ID=sa;Password=190500"

        public AyarForm()
        {
            InitializeComponent();
            DataLayoutControl = aDataLayoutControl;
            HideItems = new BarItem[] { btnYeni,btnSifreSifirla,btnSil};
            EventsLoad();
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            tglDurum.IsOn = false;
            txtDatabase.Enabled = false;
            txtPassword.Enabled = false;
            txtServer.Enabled = false;
            txtUserId.Enabled = false;
            string conStr = GeneralFunctions.Decrypt(ConfigurationManager.ConnectionStrings["Isyurdu_Connection"].ToString(),"CTE");
            int sonuc;
            sonuc = conStr.IndexOf("User", 0, conStr.Length - 1);
            _baglantiCumle = conStr.Substring(0,sonuc);
            label1.Text = _baglantiCumle;

        }

       

        protected override bool Kaydet()
        {
            string cnn = "Data Source=" + txtServer.Text.Trim() + ";Initial Catalog=" + txtDatabase.Text.Trim() + ";User ID=" + txtUserId.Text.Trim() + ";Password=" + txtPassword.Text.Trim()+";";
            cnn = GeneralFunctions.Encrypt(cnn,"CTE");
            MessageBox.Show(cnn);
            config.ConnectionStrings.ConnectionStrings["Isyurdu_Connection"].ConnectionString = cnn;
            config.ConnectionStrings.ConnectionStrings["Isyurdu_Connection"].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
            _kayitSonrasiFormuKapat = true;
            return true;
        }


        protected override void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.BaseEditForm_FormClosing(sender, e);
            Application.Restart();
        }
        private void AyarForm_Load(object sender, System.EventArgs e)
        {
            
        }

        private void tglDurum_Toggled(object sender, System.EventArgs e)
        {
            if (tglDurum.IsOn == false)
            {
                tglDurum.IsOn = false;
                txtDatabase.Enabled = false;
                txtPassword.Enabled = false;
                txtServer.Enabled = false;
                txtUserId.Enabled = false;
            }
            else
            {
                tglDurum.IsOn = true;
                txtDatabase.Enabled = true;
                txtPassword.Enabled = true;
                txtServer.Enabled = true;
                txtUserId.Enabled = true;
            }
        }

        private void tglDurum_EditValueChanged(object sender, System.EventArgs e)
        {
            if (tglDurum.IsOn == false)
            {
                tglDurum.IsOn = false;
                txtDatabase.Enabled = false;
                txtPassword.Enabled = false;
                txtServer.Enabled = false;
                txtUserId.Enabled = false;
            }
            else
            {
                tglDurum.IsOn = true;
                txtDatabase.Enabled = true;
                txtPassword.Enabled = true;
                txtServer.Enabled = true;
                txtUserId.Enabled = true;
            }
        }
    }
}