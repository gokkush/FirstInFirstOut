using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Functions;
using System.Data.SqlClient;

namespace Maliyet_Takip.Forms.HareketForms.MamulHareketForms
{
    public partial class MamulSevkListForm : BaseListForm
    {
        Mesajlar mesajlar = new Mesajlar();
        Formlar formlar = new Formlar();
        SqlKomut komutlar = new SqlKomut();
        Baglanti baglan = Baglanti.NesneVer();

        public MamulSevkListForm()
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
                DataSet ds = komutlar.Dataset("Select * from VW_EVRAKLAR where GCKodu='MamulSevk' and DonemId='" + AnaForm._donemId + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
            else
            {
                grid.DataSource = null;
                DataSet ds = komutlar.Dataset("Select * from VW_EVRAKLAR where GCKodu='MamulSevk' and DonemId='" + AnaForm._donemId + "'", baglan.bgl());
                var lst = ds.Tables[0];
                grid.DataSource = lst;
                baglan.bgl(false);
            }
        }

        protected override void Yeni()
        {
            formlar.MamulSevkEditFormu();
        }
        protected override void Duzelt()
        {
            if (Tablo.FocusedRowHandle > -1)
            {
                SeciliGelecekId = int.Parse(tablo.GetFocusedRowCellValue("Id").ToString());
                formlar.MamulSevkEditFormu(SeciliGelecekId, true);
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
                    SqlCommand komut = new SqlCommand("Delete from MamulHareketleri where EvrakId='" + SeciliGelecekId + "'", baglan.bgl());
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.bgl(false);
                    komut = new SqlCommand("Delete from Evraklar where Id='" + SeciliGelecekId + "'", baglan.bgl());
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
    }
}