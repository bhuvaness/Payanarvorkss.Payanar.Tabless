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
using WinFormsApp1.Viewss;

namespace WinFormsApp1.Formss
{
    public partial class PayanarTableRunTimeForm : Form
    {
        public PayanarTableRunTimeForm()
        {
            InitializeComponent();
        }
        public PayanarTableRunTimeForm(
            PayanarTableDesign tableDesign,
            IBaseRepositoryEx baseRepositoryEx,
            PayanarTableRunTimeViewMode viewMode) : this()
        {
            payanarTableRunTimeView.BaseRepositoryEx = baseRepositoryEx;
            payanarTableRunTimeView.TableDesign = tableDesign;
            payanarTableRunTimeView.ViewMode = viewMode;
            payanarTableRunTimeView.OnCellDoubleClickHandler += PayanarTableRunTimeView_OnCellDoubleClickHandler;
        }
        public PayanarTableRow SelectedRow { get; set; }
        private void PayanarTableRunTimeView_OnCellDoubleClickHandler(PayanarTableRow selectedRow)
        {
            SelectedRow = selectedRow;
            this.Close();
        }
    }
}
