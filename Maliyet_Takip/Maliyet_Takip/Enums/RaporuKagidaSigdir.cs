using System.ComponentModel;

namespace Maliyet_Takip.Enums
{
    public enum RaporuKagidaSigdir : byte
    {
        [Description("Sütunları Daraltarak Sığdır")]
        SutunlariDaraltarakSigdir = 1,
        [Description("Yazı Boyutunu Küçülterek Sığdır")]
        YaziBoyutunuKücülterekSigdir = 2,
        [Description("İŞlem Yapma")]
        IslemYapma = 3
    }
}
