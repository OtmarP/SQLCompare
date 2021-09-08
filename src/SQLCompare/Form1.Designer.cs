namespace SQLCompare
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.checkBox_SP_View = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonTarSQL = new System.Windows.Forms.RadioButton();
            this.radioButtonTarFile = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonSrcFile = new System.Windows.Forms.RadioButton();
            this.radioButtonSrcSQL = new System.Windows.Forms.RadioButton();
            this.labelFileTar = new System.Windows.Forms.Label();
            this.labelFileSrc = new System.Windows.Forms.Label();
            this.checkBoxSaveTar = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveSrc = new System.Windows.Forms.CheckBox();
            this.checkBoxColId = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxTarConnStr = new System.Windows.Forms.TextBox();
            this.contextMenuStripProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxSrcConnStr = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonInfo);
            this.panel1.Controls.Add(this.checkBox_SP_View);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelFileTar);
            this.panel1.Controls.Add(this.labelFileSrc);
            this.panel1.Controls.Add(this.checkBoxSaveTar);
            this.panel1.Controls.Add(this.checkBoxSaveSrc);
            this.panel1.Controls.Add(this.checkBoxColId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonCompare);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.textBoxTarConnStr);
            this.panel1.Controls.Add(this.textBoxSrcConnStr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 87);
            this.panel1.TabIndex = 0;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(134, 21);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(35, 23);
            this.buttonInfo.TabIndex = 18;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // checkBox_SP_View
            // 
            this.checkBox_SP_View.AutoSize = true;
            this.checkBox_SP_View.Location = new System.Drawing.Point(53, 51);
            this.checkBox_SP_View.Name = "checkBox_SP_View";
            this.checkBox_SP_View.Size = new System.Drawing.Size(75, 17);
            this.checkBox_SP_View.TabIndex = 17;
            this.checkBox_SP_View.Text = "+SP+View";
            this.checkBox_SP_View.UseVisualStyleBackColor = true;
            this.checkBox_SP_View.Click += new System.EventHandler(this.checkBox_SP_View_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonTarSQL);
            this.panel3.Controls.Add(this.radioButtonTarFile);
            this.panel3.Location = new System.Drawing.Point(179, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 37);
            this.panel3.TabIndex = 16;
            // 
            // radioButtonTarSQL
            // 
            this.radioButtonTarSQL.AutoSize = true;
            this.radioButtonTarSQL.Location = new System.Drawing.Point(3, 4);
            this.radioButtonTarSQL.Name = "radioButtonTarSQL";
            this.radioButtonTarSQL.Size = new System.Drawing.Size(14, 13);
            this.radioButtonTarSQL.TabIndex = 14;
            this.radioButtonTarSQL.TabStop = true;
            this.radioButtonTarSQL.UseVisualStyleBackColor = true;
            this.radioButtonTarSQL.CheckedChanged += new System.EventHandler(this.radioButtonTarSQL_CheckedChanged);
            // 
            // radioButtonTarFile
            // 
            this.radioButtonTarFile.AutoSize = true;
            this.radioButtonTarFile.Location = new System.Drawing.Point(3, 22);
            this.radioButtonTarFile.Name = "radioButtonTarFile";
            this.radioButtonTarFile.Size = new System.Drawing.Size(14, 13);
            this.radioButtonTarFile.TabIndex = 14;
            this.radioButtonTarFile.TabStop = true;
            this.radioButtonTarFile.UseVisualStyleBackColor = true;
            this.radioButtonTarFile.CheckedChanged += new System.EventHandler(this.radioButtonTarFile_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonSrcFile);
            this.panel2.Controls.Add(this.radioButtonSrcSQL);
            this.panel2.Location = new System.Drawing.Point(179, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(18, 46);
            this.panel2.TabIndex = 15;
            // 
            // radioButtonSrcFile
            // 
            this.radioButtonSrcFile.AutoSize = true;
            this.radioButtonSrcFile.Location = new System.Drawing.Point(3, 27);
            this.radioButtonSrcFile.Name = "radioButtonSrcFile";
            this.radioButtonSrcFile.Size = new System.Drawing.Size(14, 13);
            this.radioButtonSrcFile.TabIndex = 13;
            this.radioButtonSrcFile.TabStop = true;
            this.radioButtonSrcFile.UseVisualStyleBackColor = true;
            this.radioButtonSrcFile.CheckedChanged += new System.EventHandler(this.radioButtonSrcFile_CheckedChanged);
            // 
            // radioButtonSrcSQL
            // 
            this.radioButtonSrcSQL.AutoSize = true;
            this.radioButtonSrcSQL.Location = new System.Drawing.Point(3, 4);
            this.radioButtonSrcSQL.Name = "radioButtonSrcSQL";
            this.radioButtonSrcSQL.Size = new System.Drawing.Size(14, 13);
            this.radioButtonSrcSQL.TabIndex = 13;
            this.radioButtonSrcSQL.TabStop = true;
            this.radioButtonSrcSQL.UseVisualStyleBackColor = true;
            this.radioButtonSrcSQL.CheckedChanged += new System.EventHandler(this.radioButtonSrcSQL_CheckedChanged);
            // 
            // labelFileTar
            // 
            this.labelFileTar.AutoSize = true;
            this.labelFileTar.Location = new System.Drawing.Point(203, 69);
            this.labelFileTar.Name = "labelFileTar";
            this.labelFileTar.Size = new System.Drawing.Size(61, 13);
            this.labelFileTar.TabIndex = 12;
            this.labelFileTar.Text = "labelFileTar";
            this.labelFileTar.DoubleClick += new System.EventHandler(this.labelFileTar_DoubleClick);
            // 
            // labelFileSrc
            // 
            this.labelFileSrc.AutoSize = true;
            this.labelFileSrc.Location = new System.Drawing.Point(203, 26);
            this.labelFileSrc.Name = "labelFileSrc";
            this.labelFileSrc.Size = new System.Drawing.Size(61, 13);
            this.labelFileSrc.TabIndex = 11;
            this.labelFileSrc.Text = "labelFileSrc";
            this.labelFileSrc.DoubleClick += new System.EventHandler(this.labelFileSrc_DoubleClick);
            // 
            // checkBoxSaveTar
            // 
            this.checkBoxSaveTar.AutoSize = true;
            this.checkBoxSaveTar.Location = new System.Drawing.Point(769, 46);
            this.checkBoxSaveTar.Name = "checkBoxSaveTar";
            this.checkBoxSaveTar.Size = new System.Drawing.Size(51, 17);
            this.checkBoxSaveTar.TabIndex = 10;
            this.checkBoxSaveTar.Text = "Save";
            this.checkBoxSaveTar.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveSrc
            // 
            this.checkBoxSaveSrc.AutoSize = true;
            this.checkBoxSaveSrc.Location = new System.Drawing.Point(769, 6);
            this.checkBoxSaveSrc.Name = "checkBoxSaveSrc";
            this.checkBoxSaveSrc.Size = new System.Drawing.Size(51, 17);
            this.checkBoxSaveSrc.TabIndex = 9;
            this.checkBoxSaveSrc.Text = "Save";
            this.checkBoxSaveSrc.UseVisualStyleBackColor = true;
            // 
            // checkBoxColId
            // 
            this.checkBoxColId.AutoSize = true;
            this.checkBoxColId.Location = new System.Drawing.Point(53, 32);
            this.checkBoxColId.Name = "checkBoxColId";
            this.checkBoxColId.Size = new System.Drawing.Size(69, 17);
            this.checkBoxColId.TabIndex = 7;
            this.checkBoxColId.Text = "mit Col-Id";
            this.checkBoxColId.UseVisualStyleBackColor = true;
            this.checkBoxColId.Click += new System.EventHandler(this.checkBoxColId_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target";
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(53, 4);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 3;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(43, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxTarConnStr
            // 
            this.textBoxTarConnStr.ContextMenuStrip = this.contextMenuStripProject;
            this.textBoxTarConnStr.Location = new System.Drawing.Point(203, 46);
            this.textBoxTarConnStr.Name = "textBoxTarConnStr";
            this.textBoxTarConnStr.Size = new System.Drawing.Size(560, 20);
            this.textBoxTarConnStr.TabIndex = 1;
            // 
            // contextMenuStripProject
            // 
            this.contextMenuStripProject.Name = "contextMenuStripProject";
            this.contextMenuStripProject.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripProject.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripProject_Opening);
            this.contextMenuStripProject.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripProject_ItemClicked);
            // 
            // textBoxSrcConnStr
            // 
            this.textBoxSrcConnStr.ContextMenuStrip = this.contextMenuStripProject;
            this.textBoxSrcConnStr.Location = new System.Drawing.Point(203, 3);
            this.textBoxSrcConnStr.Name = "textBoxSrcConnStr";
            this.textBoxSrcConnStr.Size = new System.Drawing.Size(560, 20);
            this.textBoxSrcConnStr.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(373, 276);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 14);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(390, 276);
            this.textBox2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(13, 111);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Size = new System.Drawing.Size(890, 357);
            this.splitContainer1.SplitterDistance = 427;
            this.splitContainer1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(915, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelAction
            // 
            this.toolStripStatusLabelAction.Name = "toolStripStatusLabelAction";
            this.toolStripStatusLabelAction.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabelAction.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 499);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "SQLCompare";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxTarConnStr;
        private System.Windows.Forms.TextBox textBoxSrcConnStr;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBoxColId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProject;
        private System.Windows.Forms.CheckBox checkBoxSaveTar;
        private System.Windows.Forms.CheckBox checkBoxSaveSrc;
        private System.Windows.Forms.Label labelFileTar;
        private System.Windows.Forms.Label labelFileSrc;
        private System.Windows.Forms.RadioButton radioButtonSrcFile;
        private System.Windows.Forms.RadioButton radioButtonSrcSQL;
        private System.Windows.Forms.RadioButton radioButtonTarFile;
        private System.Windows.Forms.RadioButton radioButtonTarSQL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAction;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.CheckBox checkBox_SP_View;
    }
}