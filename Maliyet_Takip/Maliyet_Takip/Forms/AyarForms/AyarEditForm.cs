using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Maliyet_Takip.Forms.AyarForms
{
    public partial class AyarEditForm : BaseEditForm
    {
        Baglanti baglan = Baglanti.NesneVer();
        Mesajlar mesajlar = new Mesajlar();
        Numara numara = new Numara();
        SqlKomut komutlar= new SqlKomut();
        SqlCommand komut;
        SqlDataReader oku;
        bool birimler = false;
        bool donemler = false;

        public AyarEditForm()
        {
            InitializeComponent();
            DataLayoutControl = aDataLayoutControl;
            Doldur();
            EventsLoad();
        }


        private void Doldur()
        {
            try
            {
                DataSet dsBirim= komutlar.Dataset("Select * from Birimler where Durum like '" + 1 + "'", baglan.bgl());
                var lstBirim = dsBirim.Tables[0];
                txtBirimler.Properties.DataSource = lstBirim;
                baglan.bgl(false);
                txtBirimler.Properties.DisplayMember = "Birim_Adi";
                txtBirimler.Properties.ValueMember= "Id";
                DataSet dsDonem = komutlar.Dataset("Select * from Donemler where Durum like '" + 1 + "'", baglan.bgl());
                var lstDonem = dsDonem.Tables[0];
                txtDonem.Properties.DataSource = lstDonem;
                baglan.bgl(false);
                txtDonem.Properties.DisplayMember = "DonemAdi";
                txtDonem.Properties.ValueMember = "Id";

            }
            catch (System.Exception ex)
            {
                baglan.bgl(false);
                mesajlar.Hata(ex);
            }
        }


        protected override bool Kaydet()
        {
            try
            {
                if (birimler && Convert.ToInt32(txtBirimler.GetColumnValue("Id")) > 0)
                {
                    komut = new SqlCommand("update Birimler set Aktif=@Aktif", baglan.bgl());
                    komut.Parameters.AddWithValue("@Aktif", 0);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("update Birimler set Aktif=@Aktif where Id=@Id", baglan.bgl());
                    komut.Parameters.AddWithValue("@Aktif", 1);
                    komut.Parameters.AddWithValue("@Id", Convert.ToInt32(txtBirimler.GetColumnValue("Id")));
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                }

                if (donemler && Convert.ToInt32(txtDonem.GetColumnValue("Id")) > 0)
                {
                    komut = new SqlCommand("update Donemler set Aktif=@Aktif", baglan.bgl());
                    komut.Parameters.AddWithValue("@Aktif", 0);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("update Donemler set Aktif=@Aktif where Id=@Id", baglan.bgl());
                    komut.Parameters.AddWithValue("@Aktif", 1);
                    komut.Parameters.AddWithValue("@Id", Convert.ToInt32(txtDonem.GetColumnValue("Id")));
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                }
            }
            catch (Exception ex)
            {
                baglan.bgl(false);
                mesajlar.Hata(ex.Message);
            }

            return false;
        }

        private void txtBirimler_EditValueChanged(object sender, System.EventArgs e)
        {
            birimler = true;
        }

        private void AyarEditForm_Load(object sender, EventArgs e)
        {
            komut = new SqlCommand("Select * from Birimler where Aktif=1", baglan.bgl());
            oku = komut.ExecuteReader();
            oku.Read();
            txtBirimler.EditValue = Convert.ToInt32(oku["Id"]);
            komut.Dispose();
            baglan.bgl(false);
            komut = new SqlCommand("Select * from Donemler where Aktif=1", baglan.bgl());
            oku = komut.ExecuteReader();
            oku.Read();
            txtDonem.EditValue = Convert.ToInt32(oku["Id"]);
            komut.Dispose();
            baglan.bgl(false);
        }

        private void txtDonem_EditValueChanged(object sender, EventArgs e)
        {
            donemler = true;
        }
    }
}