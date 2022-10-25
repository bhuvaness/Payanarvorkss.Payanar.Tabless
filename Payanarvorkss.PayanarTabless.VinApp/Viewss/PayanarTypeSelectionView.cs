using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Modelss;

namespace WinFormsApp1.Viewss
{
    public partial class PayanarTypeSelectionView : BaseTableView
    {
        public delegate void OnCellMouseDoubleClick();
        public event OnCellMouseDoubleClick OnCellMouseDoubleClickHandler;
        public PayanarTypeSelectionView()
        {
            InitializeComponent();
        }
        private IEnumerable<PayanarTypeSelection> _selections = null;
        public IEnumerable<PayanarTypeSelection> Selections
        {
            set
            {
                _selections = value;
                payanarTypeSelectionBindingSource.DataSource = _selections;
            }
        }
        public PayanarTypeSelection SelectedPayanarTypeSelection { get; private set; }
        private void payanarTypessDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectedPayanarTypeSelection = payanarTypeSelectionBindingSource.Current as PayanarTypeSelection;

            if (OnCellMouseDoubleClickHandler != null)
            {
                OnCellMouseDoubleClickHandler();
            }
        }
    }
}
