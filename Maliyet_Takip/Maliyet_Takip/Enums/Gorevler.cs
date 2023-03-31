using System.ComponentModel;

namespace Maliyet_Takip.Enums
{
    public enum Gorevler : byte
    {
        
        [Description("Personel")]
        Personel = 1,
        [Description("Kurum Müdürü")]
        Mudur = 2,
        [Description("Muhasebe Yetkilisi")]
        Sayman = 3,
        [Description("Admin")]
        Admin = 4

    }
}