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
    public partial class PayanarTableDesignTimeForm : Form
    {
        public PayanarTableDesignTimeForm()
        {
            InitializeComponent();
        }
        public PayanarTableDesignTimeForm(PayanarTableDesign tableDesign, IPayanarTableDesignRepository payanarTableDesignRepository) : this()
        {
            payanarTableDesignView1.TableDesign = tableDesign;
            payanarTableDesignView1.PayanarTableDesignRepository = payanarTableDesignRepository;
        }
    }
}
