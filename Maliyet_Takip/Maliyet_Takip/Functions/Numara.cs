using System;
using System.Data.SqlClient;

namespace Maliyet_Takip.Functions
{
    public class Numara
    {
        Baglanti baglan = Baglanti.NesneVer();
        public string DonemNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from Donemler order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = numara.ToString();
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "2022";
                throw;
            }

        }
        public string GiderNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from Giderler order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = "GID" + numara.ToString().PadLeft(6, '0');
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "GID000001";
                throw;
            }

        }

        public string MaliyetNumarasi()
        {
            try
            {
                int ay = DateTime.Now.Month-1;

                int? numara = null;
                SqlCommand komut = new SqlCommand("Select Count(*) from Maliyetler where CiltId='"+ay+"' and DonemId='"+AnaForm._donemId+ "' and BirimId='"+ AnaForm._birimId+"'", baglan.bgl());
                numara = Convert.ToInt32(komut.ExecuteScalar())+1;
                komut.Dispose();
                baglan.bgl(false);
                string Num = "" + numara.ToString().PadLeft(2, '0');
                return Num;

            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "01";
                throw;
            }

        }

        public string StokGrupNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from HammaddeGruplar order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = "HGR" + numara.ToString().PadLeft(6, '0');
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "HGR000001";
                throw;
            }

        }
        public string MamulGrupNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from MamulGruplar order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = "MGR" + numara.ToString().PadLeft(6, '0');
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "MGR000001";
                throw;
            }

        }
        public string CariNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from Cariler order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = "CARİ" + numara.ToString().PadLeft(6, '0');
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "CARİ000001";
                throw;
            }

        }

        public string StokNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from Hammaddeler order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = "HMD" + numara.ToString().PadLeft(6, '0');
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "HMD000001";
                throw;
            }

        }
        public string MamulNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from Mamuller order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = "MAM" + numara.ToString().PadLeft(6, '0');
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "MAM000001";
                throw;
            }

        }
        public string SevkNumarasi()
        {
            try
            {
                int? numara = null;
                SqlCommand komut = new SqlCommand("Select * from Hammaddeler order by Id desc", baglan.bgl());
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                numara = Convert.ToInt32(oku["Id"]);
                numara++;
                string Num = "SVK" + numara.ToString().PadLeft(6, '0');
                komut.Dispose();
                baglan.bgl(false);
                return Num;
            }
            catch (Exception)
            {
                baglan.bgl(false);
                return "SVK000001";
                throw;
            }

        }
    }
}
