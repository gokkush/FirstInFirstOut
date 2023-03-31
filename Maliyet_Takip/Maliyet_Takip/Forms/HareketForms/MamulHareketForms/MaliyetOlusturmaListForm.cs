using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraBars;
using Maliyet_Takip.Forms.Rapors;
using DevExpress.XtraReports.UI;

namespace Maliyet_Takip.Forms.HareketForms.MamulHareketForms
{
    public partial class MaliyetOlusturmaListForm : BaseListForm
    {
        Mesajlar mesajlar = new Mesajlar();
        Formlar formlar = new Formlar();
        SqlKomut komutlar = new SqlKomut();
        Baglanti baglan = Baglanti.NesneVer();

        public MaliyetOlusturmaListForm()
        {
            InitializeComponent();
            ShowItems = new BarItem[] { btnRaporDok};
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
                DataSet ds = komutlar.Dataset("Select * from VW_MALIYETLER where GCKodu='Maliyet' and DonemId='" + AnaForm._donemId + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
            else
            {
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset("Select * from VW_MALIYETLER where GCKodu='Maliyet' and DonemId='" + AnaForm._donemId + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
        }

        protected override void Yeni()
        {
            formlar.MaliyetOlusturmaEditFormu();
        }
        protected override void Duzelt()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                SeciliGelecekId = int.Parse(tablo.GetFocusedRowCellValue("Id").ToString());
                formlar.MaliyetOlusturmaEditFormu(SeciliGelecekId, true);
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
                    SqlCommand komut = new SqlCommand("Delete from Maliyetler where Id='" + SeciliGelecekId + "'", baglan.bgl());
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("Delete from HammaddeHareketleri where MaliyetId = '" + SeciliGelecekId + "'", baglan.bgl());
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("Delete from MamulHareketleri where EvrakId = '" + SeciliGelecekId + "'", baglan.bgl());
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("Delete from GiderHareketleri where EvrakId = '" + SeciliGelecekId + "'", baglan.bgl());
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
                mesajlar.Hata("İşlem Görmüş Evrak Silinemez. Önce evrak içeriğini siliniz.\n" + ex.Message);
                baglan.bgl(false);
                return;
            }
        }

        protected override void RaporDok()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                DataSet ds1 = komutlar.Dataset("Select * from VW_MALIYETLER where Id=" + SeciliGelecekId + "", baglan.bgl());
                baglan.bgl(false);
                DataSet ds2 = komutlar.Dataset("Select * from VW_HammaddeHareketleri where MaliyetId = '" + SeciliGelecekId + "' and Endirekmi='False'", baglan.bgl());
                baglan.bgl(false);
                DataSet ds3 = komutlar.Dataset("Select * from VW_HammaddeHareketleri where MaliyetId = '" + SeciliGelecekId + "' and Endirekmi='True'", baglan.bgl());
                baglan.bgl(false);
                DataSet ds4 = komutlar.Dataset("Select * from VW_GiderHareketleri where EvrakId = '" + SeciliGelecekId + "'", baglan.bgl());
                baglan.bgl(false);
                MaliyetRapor rapor = new MaliyetRapor(ds1,ds2,ds3,ds4);
                rapor.ShowPreviewDialog();
            }
            
        }
    }
}