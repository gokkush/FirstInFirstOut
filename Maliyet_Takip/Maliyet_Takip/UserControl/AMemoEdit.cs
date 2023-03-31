using DevExpress.XtraEditors;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AMemoEdit : MemoEdit, IStatusBarAciklama
    {

        public AMemoEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightSkyBlue;
            Properties.MaxLength = 500;
        }
        public override bool EnterMoveNextControl { get; set; } = true;

        public string StatusBarAciklama { get; set; } = "Açıklama Giriniz.";

    }
}
