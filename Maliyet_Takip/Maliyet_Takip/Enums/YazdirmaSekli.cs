using System.ComponentModel;

namespace Maliyet_Takip.Enums
{
    public enum YazdirmaSekli : byte
    {
        [Description("Tek Tek Yazdır")]
        TekTekYazdir = 1,
        [Description("Tümünü Yazdır")]
        TopluYazdir = 2
    }
}
