using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace Maliyet_Takip.UserControl
{
    public class AMoneyEdit : ATextEdit
    {
        [ToolboxItem(true)]
        public AMoneyEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            Properties.Mask.MaskType = MaskType.Numeric;
            Properties.Mask.EditMask = "d2";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Tutar Giriniz";
        }
    }
}