using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AMailTextEdit : ATextEdit, IStatusBarAciklama
    {
        public AMailTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.RegEx;
            Properties.Mask.EditMask = @"((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+";
            Properties.Mask.AutoComplete = AutoCompleteType.Strong;
            StatusBarAciklama = "E-Mail Giriniz";
        }
    }
}