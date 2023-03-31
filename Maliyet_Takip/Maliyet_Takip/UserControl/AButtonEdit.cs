using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Maliyet_Takip.Interfaces;
using System;
using System.ComponentModel;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AButtonEdit : ButtonEdit, IStatusBarKisayol
    {
        public AButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSkyBlue;
        }
        public override bool EnterMoveNextControl { get; set; }
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisayol { get; set; } = "F4: ";
        public string StatusBarKisayolAciklama { get; set; }

        #region EventDef

        private int? _id;

        [Browsable(false)]
        public int? Id
        {
            get { return _id; }
            set
            {
                var oldValue = _id;
                var newValue = value;
                if (newValue.HasValue && oldValue.HasValue && newValue == oldValue)
                    return;
                _id = value;
                IdChanged(this, new IdChangedEventArgs(oldValue, newValue));
                EnabledChange(this, EventArgs.Empty);

            }
        }

        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { };

        public event EventHandler EnabledChange = delegate { };
        #endregion

    }
    public class IdChangedEventArgs : EventArgs
    {
        public IdChangedEventArgs(long? OldValue, long? NewValue)
        {
            oldValue = OldValue;
            newValue = NewValue;
        }
        public long? oldValue { get; }
        public long? newValue { get; set; }

    }
}