﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCompare
{
    public partial class Form1 : Form
    {
        private string _project_compair;    // TEST_Kunde
        private string _project_project;    // TEST
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

            _project_compair = "TEST";
            _project_project = GetFirstToken(_project_compair, "_");
            SetProject();
            DisplayHeader();

            this.radioButtonSrcSQL.Checked = true;
            this.radioButtonTarSQL.Checked = true;

            contextMenuStripProject.Items.Clear();
            contextMenuStripProject.Items.Add("TEST");
            //...
            //contextMenuStripProject.Items.Add( "" );
            SetContextMenue();  // .BackColor = Color.Cyan

            try
            {
                this.textBoxSrcConnStr.SelectionLength = -1;
                this.buttonCompare.Focus();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void SetContextMenue()
        {
            // Reset Color
            for (int i = 0; i < contextMenuStripProject.Items.Count; i++)
            {
                contextMenuStripProject.Items[i].BackColor = System.Drawing.SystemColors.Control;

                if (contextMenuStripProject.Items[i].Text == _project_compair)
                {
                    contextMenuStripProject.Items[i].BackColor = Color.Cyan;
                }
            }
        }

        private void DisplayHeader()
        {
            string DR = "R";
#if DEBUG
            DR = "D";
#endif
            this.Text = "SQLCompare Ver.:" + _version + "." + DR + " - " + _project_compair + " - " + _project_project;
        }

        private void SrcTarSwap()
        {
            string Src = this.textBoxSrcConnStr.Text;
            string Tar = this.textBoxTarConnStr.Text;
            this.textBoxSrcConnStr.Text = Tar;
            this.textBoxTarConnStr.Text = Src;
        }

        private string GetFileName(string type, bool mitColId, bool mit_SP_View)
        {
            string fullFileName = "";

            //...

            return fullFileName;
        }

        private void SetProject()
        {
            //...

            DisplayFileInfo();
        }

        private void DisplayFileInfo()
        {
            // Check Files
            //...
        }

        private void SetGUI()
        {
            // Src
            //...
            // Tar
            //...
        }

        private void DisplayAction(string txt)
        {
            this.toolStripStatusLabelAction.Text = txt;
            Application.DoEvents();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            // Exit
            this.Close();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            // Info

            int cntSrc = -1;
            int cntTar = -1;

            DisplayAction("Info...");
            
            //...
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            // Compare

            DateTime startZeit;
            DateTime endZeit;
            TimeSpan dauer;
            string dauerDisp;

            startZeit = DateTime.Now;
            endZeit = DateTime.Now;

            dauer = endZeit.Subtract(startZeit);
            dauer = TimeSpan.Zero;
            //string dauerDisp = dauer.ToString("HH:mm:ss");
            dauerDisp = new DateTime(dauer.Ticks).ToString("HH:mm:ss.ff");

            int cntSrc = -1;
            int cntTar = -1;

            DisplayAction("Compare...");
            
            //...
        }

        private string[] GetSQL_SP_Views_List(string connStr, bool checkWithColId)
        {
            string[] ret = new string[0];
            List<string> list = new List<string>();
            List<SQLList> SQLlist = new List<SQLList>();

            //...

            ret = list.ToArray();

            return ret;
        }

        private bool CheckConnection(string connStr)
        {
            bool ret = false;

            //...

            return ret;
        }

        private string[] GetSQLInfo(string connStr)
        {
            string[] ret = new string[0];
            List<string> list = new List<string>();

            //...

            ret = list.ToArray();

            return ret;
        }

        private string GetSQLHeader(string connStr)
        {
            string ret = "";
            StringBuilder sb = new StringBuilder();

            //...

            ret = sb.ToString();

            return ret;
        }

        private string[] GetSQLColList(string connStr, bool checkWithColId, bool checkWith_SP_View)
        {
            string[] ret = new string[0];
            List<string> list = new List<string>();

            //...

            ret = list.ToArray();

            return ret;
        }

        private void contextMenuStripProject_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedText = e.ClickedItem.Text;

            //...
        }

        private string GetFirstToken(string txt, string splitString)
        {
            string ret = txt;

            string[] split = txt.Split(new string[] { splitString }, StringSplitOptions.None);
            if (split.Length > 1)
            {
                ret = split[0];
            }

            return ret;
        }

        private void contextMenuStripProject_Opening(object sender, CancelEventArgs e)
        {
            //
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            SrcTarSwap();
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            SrcTarSwap();
        }

        private void radioButtonSrcSQL_CheckedChanged(object sender, EventArgs e)
        {
            SetGUI();
        }

        private void radioButtonSrcFile_CheckedChanged(object sender, EventArgs e)
        {
            SetGUI();
        }

        private void radioButtonTarSQL_CheckedChanged(object sender, EventArgs e)
        {
            SetGUI();
        }

        private void radioButtonTarFile_CheckedChanged(object sender, EventArgs e)
        {
            SetGUI();
        }

        private void labelFileSrc_DoubleClick(object sender, EventArgs e)
        {
            // Open Src-File
            string fullFileNameSrc = GetFileName("Src", this.checkBoxColId.Checked, this.checkBox_SP_View.Checked);
            Process.Start("notepad.exe", fullFileNameSrc);
        }

        private void labelFileTar_DoubleClick(object sender, EventArgs e)
        {
            // Open Tar-File
            string fullFileNameTar = GetFileName("Tar", this.checkBoxColId.Checked, this.checkBox_SP_View.Checked);
            Process.Start("notepad.exe", fullFileNameTar);
        }

        private void checkBoxColId_Click(object sender, EventArgs e)
        {
            SetProject();
        }

        private void checkBox_SP_View_Click(object sender, EventArgs e)
        {
            SetProject();
        }
    }

    public class SQLList
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
