using DevExpress.XtraEditors;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class ATextEdit : TextEdit, IStatusBarAciklama
    {

        public ATextEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightSkyBlue;
            Properties.MaxLength = 50;

        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }
    }
}
