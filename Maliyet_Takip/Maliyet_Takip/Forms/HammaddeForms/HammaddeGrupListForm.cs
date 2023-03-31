using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System.Data;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.StokForms
{
    public partial class StokGrupListForm : BaseListForm
    {
        Mesajlar mesajlar = new Mesajlar();
        Formlar formlar = new Formlar();
        SqlKomut komutlar = new SqlKomut();
        Baglanti baglan = Baglanti.NesneVer();

        public StokGrupListForm()
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

            if (AktifKartlariGoster)
            {
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset("Select * from HammaddeGruplar where Durum like '" + 1 + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
            else
            {
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset("Select * from HammaddeGruplar where Durum like'" + 0 + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
        }

        protected override void Yeni()
        {
            formlar.StokGrupEditFormu();
        }
        protected override void Duzelt()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                SeciliGelecekId = int.Parse(tablo.GetFocusedRowCellValue("Id").ToString());
                formlar.StokGrupEditFormu(SeciliGelecekId, true);
            }
        }
        protected override void EntityDelete()
        {
            if (mesajlar.Sil() == System.Windows.Forms.DialogResult.Yes)
            {
                //db.Kullanicilars.DeleteOnSubmit(db.Kullanicilars.First(s => s.Id == SeciliGelecekId));
                //db.SubmitChanges();
                SqlCommand komut = new SqlCommand("Delete from HammaddeGruplar where Id='" + SeciliGelecekId + "'", baglan.bgl());
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.bgl(false);
                mesajlar.Sil(true);
                Tablo.DeleteSelectedRows();
                Tablo.RowFocus(Tablo.FocusedRowHandle);
                Listele();
            }
        }
    }
}