using DevExpress.Utils;
using DevExpress.XtraEditors;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AToogleSwitch : ToggleSwitch, IStatusBarAciklama
    {
        public AToogleSwitch()
        {
            Name = "tglDurum";
            Properties.OffText = "Pasif";
            Properties.OnText = "Aktif";
            Properties.AutoHeight = false;
            Properties.AutoWidth = true;
            Properties.GlyphAlignment = HorzAlignment.Far;
            Properties.Appearance.ForeColor = Color.Maroon;
            IsOn = true;
        }
        public override bool EnterMoveNextControl { get; set; }

        public string StatusBarAciklama { get; set; } = "Kayıt Aktif mi, Pasif mi?";
    }
}

