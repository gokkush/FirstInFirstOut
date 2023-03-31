using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maliyet_Takip.Forms.HareketForms.HammaddeHareketForms
{
    public class HammaddeHareketleri
    {
        public int id,
            EvrakId,
            HammaddeId,
            GirisYerId,
            CikisYerId,
            DonemId,
            HareketId;

        public decimal GirisMiktar,
            CikisMiktar,
            BirimFiyat,
            AlisKDV,
            AlisKDVTutar,
            Tutar,
            KDVliToplam;

        public DateTime GirisTarihi, CikisTarihi;

        public string GCKodu;

    }
}
