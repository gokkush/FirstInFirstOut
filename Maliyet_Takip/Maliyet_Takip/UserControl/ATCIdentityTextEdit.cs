using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class ATCIdentityTextEdit : ATextEdit
    {
        public ATCIdentityTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d? \d?\d?\d? \d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "T.C. Kimlik No Giriniz";
        }

    }
}
