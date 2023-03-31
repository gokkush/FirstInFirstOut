using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System.Data;

namespace Maliyet_Takip.Forms.DonemForms
{
    public partial class DonemListForm : BaseListForm
    {
        Mesajlar mesajlar = new Mesajlar();
        Formlar formlar = new Formlar();
        SqlKomut komutlar = new SqlKomut();
        Baglanti baglan = Baglanti.NesneVer();

        public DonemListForm()
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
                DataSet ds = komutlar.Dataset("Select * from Donemler where Durum like '" + 1 + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
            else
            {
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset("Select * from Donemler where Durum like'" + 0 + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
        }

        protected override void Yeni()
        {
            formlar.DonemlerEditFormu();
        }
        protected override void Duzelt()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                SeciliGelecekId = int.Parse(tablo.GetFocusedRowCellValue("Id").ToString());
                formlar.DonemlerEditFormu(SeciliGelecekId, true);
            }
        }
        protected override void EntityDelete()
        {
            mesajlar.Hata("Dönemlerden silme yapılamaz!");
        }
    }
}