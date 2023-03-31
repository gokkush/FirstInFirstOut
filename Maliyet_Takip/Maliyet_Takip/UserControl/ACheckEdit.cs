using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class ACheckEdit : CheckEdit
    {
        public ACheckEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightSkyBlue;
        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }
    }
}
