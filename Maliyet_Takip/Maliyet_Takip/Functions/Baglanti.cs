using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Maliyet_Takip.Functions
{
    public class Baglanti
    {
        static Sifrele sifre = new Sifrele();
        static SqlConnection baglan;
        static string conStr = ConfigurationManager.ConnectionStrings["Isyurdu_Connection"].ToString();
        
        private Baglanti()
        {
            
        }
        private static Baglanti _nesne;

        public static Baglanti NesneVer()
        {
            if (_nesne == null)
            {
                conStr = GeneralFunctions.Decrypt(conStr, "CTE");
                _nesne = new Baglanti();
                baglan = new SqlConnection(conStr);
            }
            return _nesne;
        }
        public SqlConnection bgl(bool sonuc = true)
        {
            
            
            //string conStr = ConfigurationManager.ConnectionStrings["Isyurdu_Connection"].ToString();
            if (sonuc)
                baglan.Open();
            else
                baglan.Close();
            return baglan;
        }
    }
}
