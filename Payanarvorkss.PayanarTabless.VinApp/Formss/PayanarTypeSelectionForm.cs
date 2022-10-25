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

namespace WinFormsApp1.Formss
{
    public partial class PayanarTypeSelectionForm : Form
    {
        public PayanarTypeSelectionForm()
        {
            InitializeComponent();
        }
        public PayanarTypeSelectionForm(IEnumerable<PayanarTypeSelection> selections) : this()
        {
            payanarTypeSelectionView.Selections = selections;
            payanarTypeSelectionView.OnCellMouseDoubleClickHandler += PayanarTypeSelectionView__OnCellMouseDoubleClickHandler;
        }
        public PayanarTypeSelection SelectedPayanarTypeSelection { get { return payanarTypeSelectionView.SelectedPayanarTypeSelection; } }
        private void PayanarTypeSelectionView__OnCellMouseDoubleClickHandler()
        {
            this.Close();
        }
    }
}
