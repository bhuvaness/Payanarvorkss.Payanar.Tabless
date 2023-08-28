using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Formss;
using WinFormsApp1.Modelss;

namespace WinFormsApp1.Viewss
{
    public enum PayanarTableRunTimeViewMode
    {
        Design,
        Selection,
        Readonly
    }
    public partial class PayanarTableRunTimeView : BaseTableView
    {
        public delegate void OnCellDoubleClick(PayanarTableRow selectedRow);
        public event OnCellDoubleClick OnCellDoubleClickHandler;
        public PayanarTableRunTimeView()
        {
            InitializeComponent();
        }
        private PayanarTable Table { get; set; }
        private DataTable DataTable { get; set; }
        private PayanarTableDesign _tableDesign = null;
        public PayanarTableDesign TableDesign
        {
            get { return _tableDesign; }
            set
            {
                _tableDesign = value;
            }
        }
        private PayanarTableRunTimeViewMode _viewMode = PayanarTableRunTimeViewMode.Design;
        public PayanarTableRunTimeViewMode ViewMode
        {
            get { return _viewMode; }
            set
            {
                _viewMode = value;
                if (_viewMode == PayanarTableRunTimeViewMode.Selection)
                {
                    tableNameRichTextBox.Enabled = false;
                    columnToolBasePanel.Enabled = false;
                    rowsDataGridView.ReadOnly = true;
                    rowsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }
        private IBaseRepositoryEx _baseRepositoryEx = null;
        public IBaseRepositoryEx BaseRepositoryEx { private get { return _baseRepositoryEx; } set { _baseRepositoryEx = value; } }
        public PayanarTableRow SelectedRow { get; set; }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tableNameRichTextBox.DataBindings.Clear();
            tableNameRichTextBox.DataBindings.Add(new Binding("Text", payanarTableDesignBindingSource, "OriginalName"));
            payanarTableDesignBindingSource.DataSource = _tableDesign;
            this.DataTable = ConvertToDataTable(_tableDesign);
            rowsBindingSource.DataSource = this.DataTable;
            rowsDataGridView.DataSource = rowsBindingSource;
            Table = await _baseRepositoryEx.Read<PayanarTable, PayanarTableDesign>("https://localhost:7288/vtree/api/PayanarTable/", TableDesign);
            Table.TableDesign = TableDesign;
            ConvertToDataTableRow(Table, this.DataTable);
        }
        private void addColumnLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TableDesign.AddColumn();
            rowsDataGridView.AutoGenerateColumns = false;
            this.DataTable = ConvertToDataTable(_tableDesign);
            rowsBindingSource.DataSource = this.DataTable;
            rowsBindingSource.ResetBindings(false);
            rowsDataGridView.DataSource = rowsBindingSource;
        }
        private DataTable ConvertToDataTable(PayanarTableDesign tableDesign)
        {
            if (tableDesign != null)
            {
                DataTable dt = new DataTable(tableDesign.Name);
                dt.Columns.Add(new DataColumn() { ColumnName = "Tag", DataType = typeof(object), ColumnMapping = MappingType.Hidden });
                dt.Columns.Add(new DataColumn() { ColumnName = "UniqueId", DataType = typeof(String), ColumnMapping = MappingType.Hidden });
                tableDesign.Columns.ToList().ForEach(x =>
                {
                    dt.Columns.Add(new DataColumn() { ColumnName = x.Name, DataType = x.ColumnType.GetType() });
                    if (x.PayanarTypeSelection.TableDesign.IsSystemType)
                        rowsDataGridView.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = x.Name, Name = x.Name, DataPropertyName = x.Name, Tag = x });
                    else
                        rowsDataGridView.Columns.Add(new DataGridViewButtonColumn() { HeaderText = x.Name, Name = x.Name, DataPropertyName = x.Name, Tag = x });
                });
                return dt;
            }
            return null;
        }
        private void ConvertToDataTableRow(PayanarTable table, DataTable dataTable)
        {
            DataRow dataRow = null;
            IList<string> values = new List<string>();
            if (table != null && table.Rows != null && table.Rows.Count() > 0)
            {
                foreach (var row in table.Rows)
                {
                    values.Clear();
                    dataRow = dataTable.NewRow();
                    dataRow["Tag"] = row;
                    dataRow["UniqueId"] = row.UniqueId.ToString();
                    foreach (var cell in row.Cells)
                    {
                        dataRow[cell.Key] = cell.Value.Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
        }
        private void rowsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.ColumnIndex < rowsDataGridView.Columns.Count)
            {
                if (!(rowsDataGridView.Columns[e.ColumnIndex].Tag as PayanarTableColumnDesign).PayanarTypeSelection.TableDesign.IsSystemType)
                {
                    PayanarTableRunTimeForm form = new PayanarTableRunTimeForm(
                        (rowsDataGridView.Columns[e.ColumnIndex].Tag as PayanarTableColumnDesign).PayanarTypeSelection.TableDesign,
                        _baseRepositoryEx,
                        PayanarTableRunTimeViewMode.Selection);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog(this);
                    var selectedRow = form.SelectedRow;

                    var row = ((rowsBindingSource.Current as DataRowView).Row["Tag"] as PayanarTableRow);
                    (rowsBindingSource.Current as DataRowView).Row[(rowsDataGridView.Columns[e.ColumnIndex].Tag as PayanarTableColumnDesign).Name] = selectedRow.GetValue((rowsDataGridView.Columns[e.ColumnIndex].Tag as PayanarTableColumnDesign).PayanarTypeSelection.ColumnName);
                }
            }
        }
        private void saveLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int rowIndex = 0; rowIndex < this.DataTable.Rows.Count; rowIndex++)
            {
                var dataRow = this.DataTable.Rows[rowIndex];

                var payanarRow = Table.GetRow(dataRow["UniqueId"]?.ToString());

                if (payanarRow != null)
                {
                    foreach (var eachColumn in TableDesign.Columns)
                        payanarRow.SetValue(eachColumn.Name, dataRow[eachColumn.Name]?.ToString());
                }
                else
                {
                    var newRow = Table.AddRow();
                    foreach (var eachColumn in TableDesign.Columns)
                    {
                        newRow.SetValue(eachColumn.Name, dataRow[eachColumn.Name]?.ToString());
                    }
                }
            }

            _baseRepositoryEx.Create<PayanarTable>("https://localhost:7288/vtree/api/PayanarTable", Table);
        }

        private void rowsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rowsBindingSource.Current == null) return;

            if (ViewMode == PayanarTableRunTimeViewMode.Selection)
            {
                SelectedRow = (rowsBindingSource.Current as DataRowView).Row["Tag"] as PayanarTableRow;
                if (SelectedRow != null && OnCellDoubleClickHandler != null)
                {
                    OnCellDoubleClickHandler(SelectedRow);
                }
            }
        }
    }
}
