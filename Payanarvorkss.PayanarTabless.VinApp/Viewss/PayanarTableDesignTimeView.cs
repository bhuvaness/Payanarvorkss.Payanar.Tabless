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
    public partial class PayanarTableDesignTimeView : BaseTableView
    {
        public PayanarTableDesignTimeView()
        {
            InitializeComponent();
        }
        private PayanarTableDesign _tableDesign = null;
        public PayanarTableDesign TableDesign
        {
            get { return _tableDesign; }
            set
            {
                _tableDesign = value;
                payanarTableDesignBindingSource.DataSource = _tableDesign;
                payanarTableColumnDesignBindingSource.DataSource = _tableDesign.Columns;
            }
        }
        private IPayanarTableDesignRepository _payanarTableDesignRepository = null;
        public IPayanarTableDesignRepository PayanarTableDesignRepository { private get { return _payanarTableDesignRepository; } set { _payanarTableDesignRepository = value; } }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tableNameRichTextBox.DataBindings.Clear();
            tableNameRichTextBox.DataBindings.Add(new Binding("Text", payanarTableDesignBindingSource, "OriginalName"));
        }
        private void columnsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PayanarTableColumnDesign columnDesign = null;
            if (e.ColumnIndex == columnTypeDataGridViewTextBoxColumn.Index)
            {
                PayanarTypeSelectionForm selectionForm = new PayanarTypeSelectionForm(PayanarApplication.Instance.TypeSelections);
                selectionForm.ShowDialog(this);
                columnDesign = payanarTableColumnDesignBindingSource.Current as PayanarTableColumnDesign;
                columnDesign.PayanarTypeSelection = selectionForm.SelectedPayanarTypeSelection;
            }
        }

        private void addColumnLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TableDesign.AddColumn();
            payanarTableColumnDesignBindingSource.DataSource = TableDesign.Columns;
            payanarTableColumnDesignBindingSource.ResetBindings(false);
        }

        private void saveLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _payanarTableDesignRepository.Insert("https://localhost:7288/vtree/api/PayanarTableDesign", _tableDesign);
        }
    }
}
