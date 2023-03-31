using DevExpress.XtraEditors;
using Maliyet_Takip.Interfaces;

namespace Maliyet_Takip.UserControl
{
    public class AFilterControl : FilterControl, IStatusBarAciklama
    {
        public AFilterControl()
        {
            ShowGroupCommandsIcon = true;
        }

        public string StatusBarAciklama { get; set; }
    }
}
