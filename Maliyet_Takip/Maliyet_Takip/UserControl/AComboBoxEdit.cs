using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AComboBoxEdit : ComboBoxEdit, IStatusBarKisayol
    {
        public AComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightSkyBlue;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; }

        public string StatusBarKisayol { get; set; } = "F4 : ";

        public string StatusBarKisayolAciklama { get; set; }
    }
}
