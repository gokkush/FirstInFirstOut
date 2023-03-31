using DevExpress.XtraEditors;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Windows.Forms;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AHyperLinkLabelControl : HyperlinkLabelControl, IStatusBarAciklama
    {
        public AHyperLinkLabelControl()
        {
            Cursor = Cursors.Hand;
            LinkBehavior = LinkBehavior.NeverUnderline;

        }
        public string StatusBarAciklama { get; set; }
    }
}
