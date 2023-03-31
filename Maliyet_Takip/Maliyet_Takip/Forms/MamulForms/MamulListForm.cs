using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System.Data;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.MamulForms
{
    public partial class MamulListForm : BaseListForm
    {
        Mesajlar mesajlar = new Mesajlar();
        Formlar formlar = new Formlar();
        SqlKomut komutlar = new SqlKomut();
        Baglanti baglan = Baglanti.NesneVer();
        string sorgu = "";

        public MamulListForm()
        {
            InitializeComponent();

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
        }

        protected override void Listele()
        {
            base.Listele();

            if (AnaForm._birim == "MUHASEBE")
            {
                if (AktifKartlariGoster)
                {
                    sorgu = "Select * from VW_Mamuller where Durum like '" + 1 + "'";
                }
                else
                    sorgu = "Select * from VW_Mamuller where Durum like '" + 0 + "'";

            }
            else
            {
                if (AktifKartlariGoster)
                {
                    sorgu = "Select * from VW_Mamuller where BirimId = '" + AnaForm._birimId + "' and Durum like '" + 1 + "'";
                }
                else
                    sorgu = "Select * from VW_Mamuller where BirimId = '" + AnaForm._birimId + "' and Durum like '" + 0 + "'";
            }
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset(sorgu, baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
        }

        protected override void Yeni()
        {
            formlar.MamullerrEditFormu();
        }
        protected override void Duzelt()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                SeciliGelecekId = int.Parse(tablo.GetFocusedRowCellValue("Id").ToString());
                formlar.MamullerrEditFormu(SeciliGelecekId, true);
            }
        }
        protected override void EntityDelete()
        {
            try
            {
                if (mesajlar.Sil() == System.Windows.Forms.DialogResult.Yes)
                {
                    //db.Kullanicilars.DeleteOnSubmit(db.Kullanicilars.First(s => s.Id == SeciliGelecekId));
                    //db.SubmitChanges();
                    SqlCommand komut = new SqlCommand("Delete from Mamuller where Id='" + SeciliGelecekId + "'", baglan.bgl());
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                    mesajlar.Sil(true);
                    Tablo.DeleteSelectedRows();
                    Tablo.RowFocus(Tablo.FocusedRowHandle);
                    Listele();
                }
            }
            catch (System.Exception ex)
            {
                mesajlar.Hata("Hareket Görmüş Kayıt Silinemez. " + ex.Message);
                return;
            }
        }
    }
}