using DevExpress.Utils;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class ACodeTextEdit : ATextEdit, IStatusBarAciklama
    {
        public ACodeTextEdit()
        {
            Properties.Appearance.BackColor = Color.Moccasin;
            Properties.AppearanceFocused.BackColor = Color.LightSkyBlue;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaxLength = 20;
            StatusBarAciklama = "Kod Giriniz.";
        }
    }
}
