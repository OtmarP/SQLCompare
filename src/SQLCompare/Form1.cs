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
            //----------------------------------------------------------------------- History - letzter unten
            // Mi.01.04.2014 18:20:00 -op- Cr.
            // Do.01.04.2014 09:30:00 -op- ...
            // Mi.08.04.2014 11:00:00 -op- mit Save to File, compare mit File
            // Do.09.04.2015 13:08:18 -op- .
            // Fr.03.07.2015 11:34:13 -op- mit SP und Views (V2)
            // Mi.08.07.2015 13:58:57 -op- SWK_Kunde, V1,V2 CheckConnection, SQLInfo
            // Do.09.07.2015 13:44:12 -op- mehr Info
            // Fr.10.07.2015 15:04:12 -op- #
            // Mo.13.07.2015 20:27:21 -op- Problem mit CR+LF // val = "xxx\r\n" -> speicher -> einlesen -> wird "xxx<CR><LF>" !!!
            //                             mit SQL-Info-Zeile
            // Mi.22.07.2015 10:19:17 -op- mit Functions (type = 'FN' or type = 'IF' or type = 'TF') , auch bei Info
            // Di.29.09.2015 10:09:55 -op- WL
            // Do.12.11.2015 17:27:47 -op- SWK.153
            // Mo.16.11.2015 11:38:47 -op- SWK_Kunde
            // Di.17.11.2015 11:21:51 -op- mit _project_compair und _project_project
            // Di.24.11.2015 09:31:21 -op- Goch-Daten
            // Fr.29.04.2016 13:25:03 -op- KVG
            // Mi.20.07.2016 17:36:38 -op- mit 'TR' Trigger
            // Mo.05.12.2016 12:57:02 -op- VRRABO
            //-----------------------------------------------------------------------
            _version = "20161205_125738_Mo";
            // Old: "20160720_173725_Mi"

            this.Top = 50;
            this.Left = 50;

            this.splitContainer1.Dock = DockStyle.Fill;
            this.textBox1.Dock = DockStyle.Fill;
            this.textBox2.Dock = DockStyle.Fill;
            this.toolStripStatusLabelAction.Text = "";
            this.labelFileSrc.Text = "";
            this.labelFileTar.Text = "";

            _project_compair = "XXX";
            //_project_project = GetFirstToken(_project_compair, "_");
            //SetProject();
            //DisplayHeader();

            //...
        }

        private void SetContextMenue()
        {
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Exit
            this.Close();
        }

        private void contextMenuStripProject_Opening(object sender, CancelEventArgs e)
        {
            //
        }

        private void contextMenuStripProject_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            //
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            //
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            //
        }

        //private void checkBoxColId_CheckedChanged(object sender, EventArgs e)
        //{
        //    //
        //}

        private void checkBoxColId_Click(object sender, EventArgs e)
        {
            //
        }

        private void labelFileSrc_DoubleClick(object sender, EventArgs e)
        {
            //
        }

        private void labelFileTar_DoubleClick(object sender, EventArgs e)
        {
            //
        }
    }
}
