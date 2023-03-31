using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Maliyet_Takip.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Maliyet_Takip.UserControl
{
    [ToolboxItem(true)]
    public class AGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (GridView)CreateView("AGridView");
            view.Appearance.ViewCaption.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);

            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true;

            view.OptionsPrint.AutoWidth = false;
            view.OptionsPrint.PrintFooter = true;
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.RowAutoHeight = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            var idColumn = new AGridColumn
            {
                Caption = "Id",
                FieldName = "Id"
            };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(idColumn);
            var kodColumn = new AGridColumn
            {
                Caption = "Kod",
                FieldName = "Kod"
            };
            kodColumn.OptionsColumn.AllowEdit = false;
            kodColumn.Visible = true;
            kodColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            kodColumn.AppearanceCell.Options.UseTextOptions = true;
            view.Columns.Add(kodColumn);

            var SaveDateColumn = new AGridColumn
            {
                Caption = "SaveDate",
                FieldName = "SaveDate"
            };
            SaveDateColumn.OptionsColumn.AllowEdit = false;
            SaveDateColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(SaveDateColumn);

            var SaveUserColumn = new AGridColumn
            {
                Caption = "SaveUser",
                FieldName = "SaveUser"
            };
            SaveUserColumn.OptionsColumn.AllowEdit = false;
            SaveUserColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(SaveUserColumn);

            var EditDateColumn = new AGridColumn
            {
                Caption = "EditDate",
                FieldName = "EditDate"
            };
            EditDateColumn.OptionsColumn.AllowEdit = false;
            EditDateColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(EditDateColumn);

            var EditUserColumn = new AGridColumn
            {
                Caption = "EditUser",
                FieldName = "EditUser"
            };
            EditUserColumn.OptionsColumn.AllowEdit = false;
            EditUserColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(EditUserColumn);

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new AGridInfoRegistrator());
        }

        private class AGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName
            {
                get
                {
                    return "AGridView";
                }
            }
            public override BaseView CreateView(GridControl grid)
            {
                return new AGridView(grid);
            }
        }
    }

    public class AGridView : GridView, IStatusBarKisayol
    {

        #region Properties
        public string StatusBarAciklama { get; set; }

        public string StatusBarKisayol { get; set; }

        public string StatusBarKisayolAciklama { get; set; }
        #endregion

        public AGridView() { }
        public AGridView(GridControl ownerGrid) : base(ownerGrid) { }

        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);
            if (column.ColumnEdit == null) return;
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            }
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            return new AGridColumnCollection(this);
        }

        private class AGridColumnCollection : GridColumnCollection
        {
            public AGridColumnCollection(ColumnView view) : base(view)
            {
            }
            protected override GridColumn CreateColumn()
            {
                var column = new AGridColumn();
                column.OptionsColumn.AllowEdit = false;
                return column;
            }
        }
    }

    public class AGridColumn : GridColumn, IStatusBarKisayol
    {
        #region Properties
        public string StatusBarAciklama { get; set; }

        public string StatusBarKisayol { get; set; }

        public string StatusBarKisayolAciklama { get; set; }
        #endregion
    }
}