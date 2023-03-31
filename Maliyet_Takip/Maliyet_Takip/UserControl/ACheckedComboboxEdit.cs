using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class ACheckedComboboxEdit : CheckedComboBoxEdit
    {
        public ACheckedComboboxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightSkyBlue;
        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }

        public string StatusBarKisayol { get; set; } = "F4 : ";

        public string StatusBarKisayolAciklama { get; set; }
    }
}