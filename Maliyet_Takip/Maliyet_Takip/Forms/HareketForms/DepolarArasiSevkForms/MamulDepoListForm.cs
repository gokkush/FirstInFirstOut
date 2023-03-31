using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System.Data;
using DevExpress.XtraBars;

namespace Maliyet_Takip.Forms.HareketForms.DepolarArasiSevkForms
{
    public partial class MamulDepoListForm : BaseListForm
    {
        Formlar formlar = new Formlar();
        SqlKomut komutlar = new SqlKomut();
        Baglanti baglan = Baglanti.NesneVer();

        public MamulDepoListForm()
        {
            InitializeComponent();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            HideItems = new BarItem[] { btnKullaniciSorgu,btnYeni,btnDuzelt,btnSil};
        }

        protected override void Listele()
        {
            base.Listele();

            if (AktifKartlariGoster)
            {
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset("Select * from VW_MamulSayimListesiYer where DONEM_ID ='" + AnaForm._donemId + "'and YER_ID='" + AnaForm._birimId + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
            else
            {
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset("Select * from VW_MamulSayimListesiYer where DONEM_ID ='" + AnaForm._donemId + "'and YER_ID='" + AnaForm._birimId + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
        }

       
      
    }
}