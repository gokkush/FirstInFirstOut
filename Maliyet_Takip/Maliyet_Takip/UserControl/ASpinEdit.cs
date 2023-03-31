using DevExpress.Utils;
using DevExpress.XtraEditors;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class ASpinEdit : SpinEdit, IStatusBarAciklama
    {

        public ASpinEdit()
        {
            Properties.Appearance.BackColor = Color.LightSkyBlue;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.EditMask = "d";
        }
        public override bool EnterMoveNextControl { get; set; }

        public string StatusBarAciklama { get; set; }
    }
}
