using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCompare
{
    public partial class Form1 : Form
    {
        private string _project_compair;    // XXX_Kunde
        private string _project_project;    // XXX
        private string _version;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Version
            //-----------------------------------------------------------------------
            // Mi.01.04.2014 18:20:00 -op- Cr.
            //-----------------------------------------------------------------------
            _version = "20161205_125738_Mo";
            // Old: "20160720_173725_Mi"
        }

        private void SetContextMenue()
        {
        }
    }
}
