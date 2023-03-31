using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class APhoneNoTextEdit : ATextEdit, IStatusBarAciklama
    {
        public APhoneNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"0(\d?\d?\d?) \d?\d?\d? \d?\d? \d?\d";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            StatusBarAciklama = "Telefon No Giriniz";
        }
    }
}
