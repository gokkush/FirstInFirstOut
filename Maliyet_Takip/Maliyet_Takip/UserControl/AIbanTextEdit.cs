using DevExpress.XtraEditors.Mask;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AIbanTextEdit : ATextEdit, IStatusBarAciklama
    {
        public AIbanTextEdit()
        {
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"TR\d?\d \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Iban No Giriniz";
        }

    }
}
