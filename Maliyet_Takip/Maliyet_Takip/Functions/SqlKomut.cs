using System.Data;
using System.Data.SqlClient;

namespace Maliyet_Takip.Functions
{
    public class SqlKomut
    {
        private DataSet ds { get; set; }

        public DataSet DataSet
        {
            get { return ds; }

        }

        public DataSet Dataset(string komutlar, SqlConnection connection)
        {
            SqlCommand komut = new SqlCommand(komutlar, connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
