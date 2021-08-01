using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private string _project_compair;    // TEST_TestKunde
        private string _project_project;    // TEST
        private string _version;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Version - History - letzter unten
            //-----------------------------------------------------------------------
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

            string ColId = "ohneColId";
            if (mitColId)
            {
                ColId = "mitColId";
            }
            string SP_View = "";
            if (mit_SP_View)
            {
                SP_View = "mit_SP_View";
            }

            type = type.ToUpper();
            if (type == "SRC")
            {
                fullFileName = System.IO.Path.Combine(Application.StartupPath, _project_project + "_Src_" + ColId + SP_View + ".txt");
            }
            else if (type == "TAR")
            {
                fullFileName = System.IO.Path.Combine(Application.StartupPath, _project_project + "_Tar_" + ColId + SP_View + ".txt");
            }

            return fullFileName;
        }

        private void SetProject()
        {
            if (_project_compair == "TEST")
            {
                this.textBoxSrcConnStr.Text = "Data Source=localhost;Initial Catalog=Test;Persist Security Info=True;User ID=test;Password=test!";
                //192.168.0.1
                this.textBoxTarConnStr.Text = this.textBoxSrcConnStr.Text.Replace("localhost", "192.168.0.1");
            }
            
            //...

            DisplayFileInfo();
        }

        private void DisplayFileInfo()
        {
            // Check Files
            this.labelFileSrc.Text = "";
            string fullFileNameSrc = GetFileName("Src", this.checkBoxColId.Checked, this.checkBox_SP_View.Checked);
            if (System.IO.File.Exists(fullFileNameSrc))
            {
                System.IO.FileInfo fiSrc = new System.IO.FileInfo(fullFileNameSrc);
                this.labelFileSrc.Text = string.Format("{0} - {1} - {2}", fiSrc.Name, fiSrc.Length, fiSrc.LastWriteTime);
                this.radioButtonSrcFile.Enabled = true;
            }
            else
            {
                this.radioButtonSrcFile.Enabled = false;
                if (this.radioButtonSrcFile.Checked)
                {
                    this.radioButtonSrcSQL.Checked = true;
                }
            }
            this.labelFileTar.Text = "";
            string fullFileNameTar = GetFileName("Tar", this.checkBoxColId.Checked, this.checkBox_SP_View.Checked);
            if (System.IO.File.Exists(fullFileNameTar))
            {
                System.IO.FileInfo fiTar = new System.IO.FileInfo(fullFileNameTar);
                this.labelFileTar.Text = string.Format("{0} - {1} - {2}", fiTar.Name, fiTar.Length, fiTar.LastWriteTime);
                this.radioButtonTarFile.Enabled = true;
            }
            else
            {
                this.radioButtonTarFile.Enabled = false;
                if (this.radioButtonTarFile.Checked)
                {
                    this.radioButtonTarSQL.Checked = true;
                }
            }
        }

        private void SetGUI()
        {
            // Src
            if (this.radioButtonSrcSQL.Checked)
            {
                this.checkBoxSaveSrc.Enabled = true;
                this.textBoxSrcConnStr.BackColor = Color.Cyan;
                this.labelFileSrc.BackColor = SystemColors.Control;
            }
            else
            {
                this.checkBoxSaveSrc.Enabled = false;
                this.textBoxSrcConnStr.BackColor = SystemColors.Window;
                this.labelFileSrc.BackColor = Color.Cyan;
            }
            // Tar
            if (this.radioButtonTarSQL.Checked)
            {
                this.checkBoxSaveTar.Enabled = true;
                this.textBoxTarConnStr.BackColor = Color.Cyan;
                this.labelFileTar.BackColor = SystemColors.Control;
            }
            else
            {
                this.checkBoxSaveTar.Enabled = false;
                this.textBoxTarConnStr.BackColor = SystemColors.Window;
                this.labelFileTar.BackColor = Color.Cyan;
            }
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

            string[] listSrcInfo = new string[0];
            string[] listTarInfo = new string[0];

            // Src
            string conStrSrc = this.textBoxSrcConnStr.Text;
            if (conStrSrc != "")
            {
                DisplayAction("Info, CheckConnection Src...");
                bool connectionOK = CheckConnection(conStrSrc);
                if (connectionOK)
                {
                    DisplayAction("Info, GetInfo Src...");
                    listSrcInfo = GetSQLInfo(conStrSrc);

                    cntSrc = listSrcInfo.Length;
                }
            }
            // Tar
            string conStrTar = this.textBoxTarConnStr.Text;
            if (conStrTar != "")
            {
                DisplayAction("Info, CheckConnection Tar...");
                bool connectionOK = CheckConnection(conStrTar);
                if (connectionOK)
                {
                    DisplayAction("Info, GetInfoTar...");
                    listTarInfo = GetSQLInfo(conStrTar);

                    cntTar = listTarInfo.Length;
                }
            }

            DisplayAction("Info, Display...");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listSrcInfo.Length; i++)
            {
                string valSrc = listSrcInfo[i];
                sb.Append(valSrc);
                sb.AppendLine();
            }
            textBox1.Text = sb.ToString();
            sb.Length = 0;
            for (int i = 0; i < listTarInfo.Length; i++)
            {
                string valTar = listTarInfo[i];
                sb.Append(valTar);
                sb.AppendLine();
            }
            textBox2.Text = sb.ToString();

            DisplayAction(string.Format("Compare. Src:{0}, Tar:{1}", cntSrc, cntTar));
            //DisplayAction( "Info." );
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

            bool checkWithColId = false;
            if (checkBoxColId.Checked)
            {
                checkWithColId = true;
            }
            bool checkWith_SP_View = false;
            if (checkBox_SP_View.Checked)
            {
                checkWith_SP_View = true;
            }

            string[] listSrc = new string[0];
            string[] listSrcMit = new string[0];
            string[] listSrcOhne = new string[0];
            string[] listSrcSPVOhne = new string[0];
            string[] listSrcSPVMit = new string[0];
            string[] listTar = new string[0];
            string[] listTarMit = new string[0];
            string[] listTarOhne = new string[0];
            string[] listTarSPVOhne = new string[0];
            string[] listTarSPVMit = new string[0];
            // Src
            if (this.radioButtonSrcSQL.Enabled && this.radioButtonSrcSQL.Checked)
            {
                if (this.textBoxSrcConnStr.Text != "")
                {
                    DisplayAction("Compare, CheckConnection Src...");
                    bool connectionOK = CheckConnection(this.textBoxSrcConnStr.Text);
                    if (connectionOK)
                    {
                        DisplayAction("Compare, GetSQLColList Src...");
                        listSrcMit = GetSQLColList(this.textBoxSrcConnStr.Text, true, checkWith_SP_View);
                        listSrcOhne = GetSQLColList(this.textBoxSrcConnStr.Text, false, checkWith_SP_View);
                        if (checkWith_SP_View)
                        {
                            // SP, Views
                            DisplayAction("Compare, GetSQL_SP_Views_List Src...");
                            listSrcSPVMit = GetSQL_SP_Views_List(this.textBoxSrcConnStr.Text, true);
                            listSrcSPVOhne = GetSQL_SP_Views_List(this.textBoxSrcConnStr.Text, false);

                            // Concat
                            string[] listSrcXM = listSrcMit.Concat(listSrcSPVMit).ToArray();
                            string[] listSrcXO = listSrcOhne.Concat(listSrcSPVOhne).ToArray();
                            //
                            listSrcMit = listSrcXM.ToArray();
                            listSrcOhne = listSrcXO.ToArray();
                        }

                        if (checkWithColId)
                        {
                            listSrc = listSrcMit;
                        }
                        else
                        {
                            listSrc = listSrcOhne;
                        }
                        cntSrc = listSrc.Length;
                    }
                }
            }
            else if (this.radioButtonSrcFile.Enabled && this.radioButtonSrcFile.Checked)
            {
                DisplayAction("Compare, ReadFromFile Src...");
                string fullFileNameSrc = GetFileName("Src", checkWithColId, checkWith_SP_View);
                listSrc = System.IO.File.ReadAllLines(fullFileNameSrc);
                cntSrc = listSrc.Length;
            }
            // Tar
            if (this.radioButtonTarSQL.Enabled && this.radioButtonTarSQL.Checked)
            {
                if (this.textBoxTarConnStr.Text != "")
                {
                    DisplayAction("Compare, CheckConnection Tar...");
                    bool connectionOK = CheckConnection(this.textBoxTarConnStr.Text);
                    if (connectionOK)
                    {
                        DisplayAction("Compare, GetSQLColList Tar...");
                        listTarMit = GetSQLColList(this.textBoxTarConnStr.Text, true, checkWith_SP_View);
                        listTarOhne = GetSQLColList(this.textBoxTarConnStr.Text, false, checkWith_SP_View);
                        if (checkWith_SP_View)
                        {
                            // SP, Views
                            DisplayAction("Compare, GetSQL_SP_Views_List Tar...");
                            listTarSPVMit = GetSQL_SP_Views_List(this.textBoxTarConnStr.Text, true);
                            listTarSPVOhne = GetSQL_SP_Views_List(this.textBoxTarConnStr.Text, false);

                            // Concat
                            string[] listTarXM = listTarMit.Concat(listTarSPVMit).ToArray();
                            string[] listTarXO = listTarOhne.Concat(listTarSPVOhne).ToArray();
                            //
                            listTarMit = listTarXM.ToArray();
                            listTarOhne = listTarXO.ToArray();
                        }

                        if (checkWithColId)
                        {
                            listTar = listTarMit;
                        }
                        else
                        {
                            listTar = listTarOhne;
                        }
                        cntTar = listTar.Length;
                    }
                }
            }
            else if (this.radioButtonTarFile.Enabled && this.radioButtonTarFile.Checked)
            {
                DisplayAction("Compare, ReadFromFile Tar...");
                string fullFileNameTar = GetFileName("Tar", checkWithColId, checkWith_SP_View);
                listTar = System.IO.File.ReadAllLines(fullFileNameTar);
                cntTar = listTar.Length;
            }


            DisplayAction("Save: PROJ_Src.txt, PROJ_Tar.txt...");
            // Save: VRREH_Src.txt, VRREH_Tar.txt
            if (checkBoxSaveSrc.Enabled && checkBoxSaveSrc.Checked)
            {
                if (checkWith_SP_View)
                {
                    // mit SP_View
                    string fullFileNameSrcMit_SPView = GetFileName("Src", true, true);
                    System.IO.File.WriteAllLines(fullFileNameSrcMit_SPView, listSrcMit);

                    string fullFileNameSrcOhne_SPView = GetFileName("Src", false, true);
                    System.IO.File.WriteAllLines(fullFileNameSrcOhne_SPView, listSrcOhne);
                }
                else
                {
                    // ohne SP_View
                    string fullFileNameSrcMit = GetFileName("Src", true, false);
                    System.IO.File.WriteAllLines(fullFileNameSrcMit, listSrcMit);

                    string fullFileNameSrcOhne = GetFileName("Src", false, false);
                    System.IO.File.WriteAllLines(fullFileNameSrcOhne, listSrcOhne);
                }
            }
            if (checkBoxSaveTar.Enabled && checkBoxSaveTar.Checked)
            {
                if (checkWith_SP_View)
                {
                    // mit SP_View
                    string fullFileNameTarMit_SPView = GetFileName("Tar", true, true);
                    System.IO.File.WriteAllLines(fullFileNameTarMit_SPView, listTarMit);

                    string fullFileNameTarOhne_SPView = GetFileName("Tar", false, true);
                    System.IO.File.WriteAllLines(fullFileNameTarOhne_SPView, listTarOhne);
                }
                else
                {
                    // ohne SP_View
                    string fullFileNameTarMit = GetFileName("Tar", true, false);
                    System.IO.File.WriteAllLines(fullFileNameTarMit, listTarMit);

                    string fullFileNameTarOhne = GetFileName("Tar", false, false);
                    System.IO.File.WriteAllLines(fullFileNameTarOhne, listTarOhne);
                }
            }
            DisplayFileInfo();

            DisplayAction("Compare, Src - Tar...");
            // Src mit Tar
            for (int i = 0; i < listSrc.Length; i++)
            {
                string valSrc = listSrc[i];

                // search in Target
                for (int j = 0; j < listTar.Length; j++)
                {
                    string valTar = listTar[j];

                    if (valTar == valSrc)
                    {
                        listSrc[i] = "";
                        listTar[j] = "";
                        // =================>
                        break;
                    }
                }
            }
            // Tag mit Src
            for (int j = 0; j < listTar.Length; j++)
            {
                string valTar = listTar[j];

                for (int i = 0; i < listSrc.Length; i++)
                {
                    string valSrc = listSrc[i];

                    if (valTar == "" && valSrc == "") { }
                    else
                    {
                        if (valTar == valSrc)
                        {
                            listSrc[i] = "";
                            listTar[j] = "";
                            // =================>
                            break;
                        }
                    }
                }
            }

            //
            // Src
            List<string> list = new List<string>();
            for (int i = 0; i < listSrc.Length; i++)
            {
                string valSrc = listSrc[i];
                if (valSrc != "")
                {
                    list.Add(valSrc);
                }
            }
            listSrc = list.ToArray();
            // Tar
            list = new List<string>();
            for (int i = 0; i < listTar.Length; i++)
            {
                string valTar = listTar[i];
                if (valTar != "")
                {
                    list.Add(valTar);
                }
            }
            listTar = list.ToArray();

            DisplayAction("Compare, Display...");
            // Textbox
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listSrc.Length; i++)
            {
                string valSrc = listSrc[i];
                sb.Append(valSrc);
                sb.AppendLine();
            }
            textBox1.Text = sb.ToString();
            sb.Length = 0;
            for (int i = 0; i < listTar.Length; i++)
            {
                string valTar = listTar[i];
                sb.Append(valTar);
                sb.AppendLine();
            }
            textBox2.Text = sb.ToString();

            endZeit = DateTime.Now;
            dauer = endZeit.Subtract(startZeit);
            //dauerDisp = dauer.ToString( @"HH\:mm\:ss" );
            dauerDisp = new DateTime(dauer.Ticks).ToString("HH:mm:ss.ff");

            DisplayAction(string.Format("Compare. Src:{0}, Tar:{1}, Dauer: {2}", cntSrc, cntTar, dauerDisp));
        }

        private string[] GetSQL_SP_Views_List(string connStr, bool checkWithColId)
        {
            string[] ret = new string[0];
            List<string> list = new List<string>();
            List<SQLList> SQLlist = new List<SQLList>();

            string conString = connStr;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    // select _Cnt=count(1), type from sysobjects group by type order by type
                    //-- _Cnt	type
                    //-- 33	    D 
                    //-- 104	F 
                    //-- 1	    FN ++++++++++
                    //-- 1	    IF ++++++++++
                    //-- 5	    IT
                    //-- 110	K 
                    //-- 13	    P #####################
                    //-- 45	    S 
                    //-- 3	    SQ
                    //-- 1	    TF ++++++++++
                    //-- 1	    TR ++++++++++
                    //-- 1	    TT
                    //-- 114	U *******************
                    //-- 3	    V #####################

                    // select _Cnt=count(1), type, type_desc from sys.objects group by type, type_desc order by type, type_desc
                    //-- _Cnt	type	type_desc
                    //-- 33	    D 	DEFAULT_CONSTRAINT
                    //-- 104	F 	FOREIGN_KEY_CONSTRAINT
                    //-- 1	    FN	SQL_SCALAR_FUNCTION ++++++++++++++++++++++++++++++++++++++++
                    //-- 1	    IF	SQL_INLINE_TABLE_VALUED_FUNCTION +++++++++++++++++++++++++++
                    //-- 5	    IT	INTERNAL_TABLE
                    //-- 13	    P 	SQL_STORED_PROCEDURE =======================================
                    //-- 109	PK	PRIMARY_KEY_CONSTRAINT
                    //-- 45	    S 	SYSTEM_TABLE
                    //-- 3	    SQ	SERVICE_QUEUE
                    //-- 1	    TF	SQL_TABLE_VALUED_FUNCTION ++++++++++++++++++++++++++++++++++
                    //-- 1	    TR	SQL_TRIGGER ++++++++++++++++++++++++++++++++++++++++++++++++
                    //-- 1	    TT	TYPE_TABLE
                    //-- 114	U 	USER_TABLE *******************
                    //-- 1	    UQ	UNIQUE_CONSTRAINT
                    //-- 3	    V 	VIEW =======================================================

                    string sql = "select name, type from sysobjects where type = 'P' or type = 'V' or type = 'FN' or type = 'IF' or type = 'TF' or type ='TR' order by type";
                    // IF
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string valname = reader.GetValue(0).ToString();   //name
                                string valtype = reader.GetValue(1).ToString();   //type
                                SQLList sqlList = new SQLList();
                                sqlList.Name = valname;
                                sqlList.Type = valtype;
                                SQLlist.Add(sqlList);
                            }
                        }
                    }

                    foreach (var item in SQLlist)
                    {
                        string SQLName = item.Name;
                        string SQLType = item.Type;
                        // sp_helptext sp_SepaAuftrag
                        string sqlHelp = "sp_helptext " + SQLName;
                        using (SqlCommand command = new SqlCommand(sqlHelp, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int line = 0;
                                while (reader.Read())
                                {
                                    line++;
                                    string val = reader.GetValue(0).ToString();

                                    // val = "xxx\r\n" -> speicher -> einlesen -> wird "xxx<CR><LF>" !!!
                                    val = val.Replace("\r\n", "");

                                    // Type_Table_Col_Type_Length_Nullable
                                    //string oneRow = SQLType + ",	" + SQLName + ",	" + line.ToString() + ",	" + val;
                                    string oneRow = SQLType + ",\t" + SQLName + ",\t" + line.ToString() + ",\t" + val;
                                    list.Add(oneRow);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.InnerException, "Error");
                }
            }

            ret = list.ToArray();

            return ret;
        }

        private bool CheckConnection(string connStr)
        {
            bool ret = false;

            string conString = connStr;
            //conString = conString + ";Connection Timeout=5;";
            // Connection Timeout=2;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    //connection.ConnectionTimeout = 1;
                    connection.Open();

                    ret = true;

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.InnerException, "Error");
                }
            }

            return ret;
        }

        private string[] GetSQLInfo(string connStr)
        {
            string[] ret = new string[0];
            List<string> list = new List<string>();

            string conString = connStr;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    // connection
                    // {System.Data.SqlClient.SqlConnection}
                    //     base {System.Data.Common.DbConnection}: {System.Data.SqlClient.SqlConnection}
                    //     ClientConnectionId: {f5f5612e-65d2-47bc-99ad-30423f836032}
                    //     ConnectionString: "Data Source=localhost;     Initial Catalog=AtriumVRREH; Persist Security Info=True;User ID=jaha;Password=jaha"
                    //     ConnectionTimeout: 15
                    //     Credential: null
                    //     Database: "AtriumVRREH"
                    //     DataSource: "localhost"
                    //     FireInfoMessageEventOnUserErrors: false
                    //     PacketSize: 8000
                    //     ServerVersion: "10.50.2550"
                    //     State: Open
                    //     StatisticsEnabled: false
                    //     WorkstationId: "VIE-DEV007"

                    var ClientConnectionId = connection.ClientConnectionId;
                    var ConnectionString = connection.ConnectionString;
                    var ConnectionTimeout = connection.ConnectionTimeout;
                    var Container = connection.Container;
                    var Credential = connection.Credential;
                    var Database = connection.Database;
                    var DataSource = connection.DataSource;
                    var PacketSize = connection.PacketSize;
                    var ServerVersion = connection.ServerVersion;
                    var Site = connection.Site;
                    var State = connection.State;
                    var StatisticsEnabled = connection.StatisticsEnabled;
                    var WorkstationId = connection.WorkstationId;

                    string val = "";
                    val = string.Format("ClientConnectionId: {0}", connection.ClientConnectionId);
                    list.Add(val);
                    val = string.Format("ConnectionTimeout: {0}", connection.ConnectionTimeout);
                    list.Add(val);
                    val = string.Format("Database: {0}", connection.Database);
                    list.Add(val);
                    val = string.Format("DataSource: {0}", connection.DataSource);
                    list.Add(val);
                    val = string.Format("PacketSize: {0}", connection.PacketSize);
                    list.Add(val);
                    val = string.Format("ServerVersion: {0}", connection.ServerVersion);
                    list.Add(val);
                    val = string.Format("StatisticsEnabled: {0}", connection.StatisticsEnabled);
                    list.Add(val);
                    val = string.Format("WorkstationId: {0}", connection.WorkstationId);
                    list.Add(val);

                    string sql = @"";

                    list.Add("");

                    sql = string.Format("sp_helpdb '{0}'", connection.Database);
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var valname = reader.GetValue(0).ToString();      // name
                                var valdb_size = reader.GetValue(1).ToString();   // db_size
                                var valowner = reader.GetValue(2).ToString();     // owner
                                var valcreated = reader.GetValue(3).ToString();   // created
                                var valstatus = reader.GetValue(4).ToString();    // status
                                var valcompatibility_level = reader.GetValue(5).ToString();    // compatibility_level

                                list.Add(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", valname, valdb_size, valowner, valcreated, valstatus, valcompatibility_level));
                            }
                            //NextResult
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    var valname = reader.GetValue(0).ToString();      // name
                                    var valfileid = reader.GetValue(1).ToString();    // fileid
                                    var valfilename = reader.GetValue(2).ToString();  // filename
                                    var valfilegroup = reader.GetValue(3).ToString(); // filegroup
                                    var valsize = reader.GetValue(4).ToString();      // size
                                    var valmaxsize = reader.GetValue(5).ToString();   // maxsize
                                    var valgrowth = reader.GetValue(6).ToString();    // growth
                                    var valusage = reader.GetValue(7).ToString();     // usage

                                    list.Add(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", valname, valfileid, valfilename, valsize, valmaxsize, valgrowth, valusage));
                                }
                            }
                        }
                    }

                    list.Add("");

                    sql = string.Format("select getdate(), @@VERSION, @@SERVERNAME, @@SERVICENAME, db_name(), SERVERPROPERTY('productversion'), SERVERPROPERTY ('productlevel'), SERVERPROPERTY ('edition'), @@LANGUAGE");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //for( int i = 0; i < reader.FieldCount; i++ ) {
                                //    string val = reader.GetValue( i ).ToString();
                                //    list.Add( val );
                                //}
                                string valgetdate = reader.GetValue(0).ToString();    // getdate
                                string valVERSION = reader.GetValue(1).ToString();    // VERSION
                                string valSERVERNAME = reader.GetValue(2).ToString(); // SERVERNAME
                                string valSERVICENAME = reader.GetValue(3).ToString(); // SERVICENAME
                                string valdb_name = reader.GetValue(4).ToString(); // db_name
                                string valproductversion = reader.GetValue(5).ToString(); // productversion
                                string valproductlevel = reader.GetValue(6).ToString(); // productlevel
                                string valedition = reader.GetValue(7).ToString(); // edition
                                string valLANGUAGE = reader.GetValue(8).ToString(); // LANGUAGE

                                list.Add(string.Format("getdate(): {0}", valgetdate));
                                list.Add(string.Format("VERSION: {0}", valVERSION));
                                list.Add(string.Format("SERVERNAME: {0}", valSERVERNAME));
                                list.Add(string.Format("SERVICENAME: {0}", valSERVICENAME));
                                list.Add(string.Format("db_name(): {0}", valdb_name));
                                list.Add(string.Format("productversion: {0}", valproductversion));
                                list.Add(string.Format("productlevel: {0}", valproductlevel));
                                list.Add(string.Format("edition: {0}", valedition));
                                list.Add(string.Format("LANGUAGE: {0}", valLANGUAGE));
                            }
                        }
                    }

                    list.Add("");

                    int cntTypeU = 0;
                    int cntTypeV = 0;
                    int cntTypeK = 0;
                    int cntTypeP = 0;
                    int cntTypeD = 0;
                    int cntTypeF = 0;
                    int cntTypeIT = 0;
                    int cntTypeSQ = 0;
                    int cntTypeTR = 0;
                    int cntTypeTT = 0;
                    int cntTypeFN = 0;
                    int cntTypeIF = 0;
                    int cntTypeTF = 0;
                    int cntTypeXXXX = 0;
                    string whatTypeXXXX = "";
                    int cntType_SUM = 0;

                    // Info: https://msdn.microsoft.com/en-us/library/ms177596.aspx?f=255&MSPPError=-2147217396
                    sql = @"select * from sysobjects
    where type in ('U', 'V', 'K', 'P', 'D', 'F', 'IT', 'SQ', 'TR', 'TT', 'FN', 'IF', 'TF')
    order by type, name";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //for( int i = 0; i < reader.FieldCount; i++ ) {
                                //    string val = reader.GetValue( i ).ToString();
                                //    list.Add( val );
                                //}
                                string valName = reader.GetValue(0).ToString();   // name
                                string valCD = reader.GetValue(9).ToString();     // crdate
                                string valType = reader.GetValue(13).ToString();  // type

                                if (valType == "U ") { cntTypeU++; }
                                else if (valType == "V ") { cntTypeV++; }
                                else if (valType == "K ") { cntTypeK++; }
                                else if (valType == "P ") { cntTypeP++; }
                                else if (valType == "D ") { cntTypeD++; }
                                else if (valType == "F ") { cntTypeF++; }
                                else if (valType == "IT") { cntTypeIT++; }
                                else if (valType == "SQ") { cntTypeSQ++; }
                                else if (valType == "TR") { cntTypeTR++; }
                                else if (valType == "TT") { cntTypeTT++; }
                                else if (valType == "FN") { cntTypeFN++; }
                                else if (valType == "IF") { cntTypeIF++; }
                                else if (valType == "TF") { cntTypeTF++; }
                                else
                                {
                                    cntTypeXXXX++;
                                    whatTypeXXXX = whatTypeXXXX + ", " + valType;
                                }
                                cntType_SUM++;

                                list.Add(string.Format("{0}, {1}, {2}", valType, valCD, valName));
                            }
                        }
                    }

                    list.Add(string.Format("U:{0}, V:{1}, P:{2}, TR:{3}, K:{4}, D:{5}, F:{6}, IT:{7}, SQ:{8}, TT:{9}, FN:{10}, IF:{11}, TF:{12}, ?({13}):{14}, SUM={15}",
                        cntTypeU, cntTypeV, cntTypeP, cntTypeTR, cntTypeK, cntTypeD, cntTypeF, cntTypeIT, cntTypeSQ, cntTypeTT
                        , cntTypeFN, cntTypeIF, cntTypeTF
                        , whatTypeXXXX, cntTypeXXXX, cntType_SUM));

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.InnerException, "Error");
                }
            }

            ret = list.ToArray();

            return ret;
        }

        private string GetSQLHeader(string connStr)
        {
            string ret = "";
            StringBuilder sb = new StringBuilder();

            string conString = connStr;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    var ConnectionString = connection.ConnectionString; // ConnectionString: "Data Source=localhost;     Initial Catalog=AtriumVRREH; Persist Security Info=True;User ID=jaha;Password=jaha"
                    var Database = connection.Database; // Database: "AtriumVRREH"
                    var DataSource = connection.DataSource; // DataSource: "localhost"
                    var ServerVersion = connection.ServerVersion;   //ServerVersion: "10.50.2550"

                    string sql = @"";
                    sql = string.Format("select getdate(), @@VERSION, @@SERVERNAME, @@SERVICENAME, db_name(), SERVERPROPERTY('productversion'), SERVERPROPERTY ('productlevel'), SERVERPROPERTY ('edition'), @@LANGUAGE");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string valgetdate = reader.GetValue(0).ToString();    // getdate
                                string valVERSION = reader.GetValue(1).ToString();    // VERSION
                                string valSERVERNAME = reader.GetValue(2).ToString(); // SERVERNAME
                                string valSERVICENAME = reader.GetValue(3).ToString(); // SERVICENAME
                                string valdb_name = reader.GetValue(4).ToString(); // db_name
                                string valproductversion = reader.GetValue(5).ToString(); // productversion
                                string valproductlevel = reader.GetValue(6).ToString(); // productlevel
                                string valedition = reader.GetValue(7).ToString(); // edition
                                string valLANGUAGE = reader.GetValue(8).ToString(); // LANGUAGE

                                sb.AppendFormat("getdate(): {0}", valgetdate);
                                sb.AppendFormat(", VERSION: {0}", valVERSION);
                                sb.AppendFormat(", SERVERNAME: {0}", valSERVERNAME);
                                sb.AppendFormat(", SERVICENAME: {0}", valSERVICENAME);
                                sb.AppendFormat(", db_name(): {0}", valdb_name);
                                sb.AppendFormat(", productversion: {0}", valproductversion);
                                sb.AppendFormat(", productlevel: {0}", valproductlevel);
                                sb.AppendFormat(", edition: {0}", valedition);
                                sb.AppendFormat(", LANGUAGE: {0}", valLANGUAGE);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.InnerException, "Error");
                }
            }

            ret = sb.ToString();

            return ret;
        }

        private string[] GetSQLColList(string connStr, bool checkWithColId, bool checkWith_SP_View)
        {
            string[] ret = new string[0];
            List<string> list = new List<string>();

            string conString = connStr;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                try
                {
                    connection.Open();

                    // 
                    string SQLInfo = "";
                    SQLInfo = "SQL-Info: " + GetSQLHeader(connStr);
                    SQLInfo = SQLInfo.Replace("\r\n", "");
                    SQLInfo = SQLInfo.Replace("\n", "");
                    SQLInfo = SQLInfo.Replace("\r", "");
                    list.Add(SQLInfo);

                    char _TAB = (char)9;
                    string TAB = _TAB.ToString();

                    string withSP_View = "";
                    if (checkWith_SP_View)
                    {
                        //withSP_View = "Type_Table_Col_Type_Length_Nullable='U,	' + ";
                        withSP_View = "Type_Table_Col_Type_Length_Nullable='U," + TAB + "' + ";
                    }

                    // alle User-Tables
                    // ohne column_id
                    string sql = @"select 
    " + withSP_View + @" sys.objects.name + '," + TAB + @"' 
    + sys.columns.name + '," + TAB + @"' + sys.types.name + '," + TAB + @"' + convert(nvarchar(50), sys.columns.max_length) + '," + TAB + @"' + convert(nvarchar(50), sys.columns.is_nullable)
    from sys.columns
        left join sys.objects on (sys.objects.object_id=sys.columns.object_id)
        left join sys.types on (sys.types.user_type_id=sys.columns.system_type_id)
    where sys.objects.type='U'
    order by sys.objects.name, sys.columns.name";
                    // mit column_id
                    if (checkWithColId)
                    {
                        sql = @"select 
    " + withSP_View + @" sys.objects.name + '," + TAB + @"' + convert(nvarchar(50), sys.columns.column_id) + '," + TAB + @"' 
    + sys.columns.name + '," + TAB + @"' + sys.types.name + '," + TAB + @"' + convert(nvarchar(50), sys.columns.max_length) + '," + TAB + @"' + convert(nvarchar(50), sys.columns.is_nullable)
    from sys.columns
        left join sys.objects on (sys.objects.object_id=sys.columns.object_id)
        left join sys.types on (sys.types.user_type_id=sys.columns.system_type_id)
    where sys.objects.type='U'
    order by sys.objects.name, sys.columns.column_id, sys.columns.name";
                    }

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string val = reader.GetValue(i).ToString();
                                    list.Add(val);
                                }
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.InnerException, "Error");
                }
            }

            ret = list.ToArray();

            return ret;
        }

        private void contextMenuStripProject_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedText = e.ClickedItem.Text;

            _project_compair = clickedText;
            _project_project = GetFirstToken(_project_compair, "_"); // SWK, SWK_153, SWK_137_153 ==> "SWK"

            SetProject();
            DisplayHeader();

            // Reset Color
            for (int i = 0; i < contextMenuStripProject.Items.Count; i++)
            {
                contextMenuStripProject.Items[i].BackColor = System.Drawing.SystemColors.Control;
            }
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
