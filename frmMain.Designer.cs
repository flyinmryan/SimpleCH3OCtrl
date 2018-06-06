namespace BurnerControl
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.nudBurner = new System.Windows.Forms.NumericUpDown();
            this.lblBurner = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.ucDataLView1 = new SIGIntranetShell.ucDataLView();
            ((System.ComponentModel.ISupportInitialize)(this.nudBurner)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 19200;
            this.serialPort.PortName = "COM4";
            this.serialPort.ReadTimeout = 5000;
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // nudBurner
            // 
            this.nudBurner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBurner.Location = new System.Drawing.Point(147, 61);
            this.nudBurner.Name = "nudBurner";
            this.nudBurner.Size = new System.Drawing.Size(68, 29);
            this.nudBurner.TabIndex = 10;
            this.nudBurner.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblBurner
            // 
            this.lblBurner.AutoSize = true;
            this.lblBurner.Location = new System.Drawing.Point(144, 36);
            this.lblBurner.Name = "lblBurner";
            this.lblBurner.Size = new System.Drawing.Size(38, 13);
            this.lblBurner.TabIndex = 8;
            this.lblBurner.Text = "Burner";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(164, 263);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close Valve";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(245, 263);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Open Valve";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(201, 219);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 7;
            this.btnSet.Text = "SET";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // ucDataLView1
            // 
            this.ucDataLView1.AllowColumnReorder = true;
            this.ucDataLView1.AllowColumnSorting = true;
            this.ucDataLView1.BackColor = System.Drawing.SystemColors.Control;
            this.ucDataLView1.BorderFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ucDataLView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucDataLView1.CaptionGrid = "Results:";
            this.ucDataLView1.CheckBoxes = false;
            this.ucDataLView1.ColumnHeadersVisible = true;
            this.ucDataLView1.ColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataLView1.ColumnNames")));
            this.ucDataLView1.ColumnWidth = ((System.Collections.Generic.List<int>)(resources.GetObject("ucDataLView1.ColumnWidth")));
            this.ucDataLView1.GridDT = null;
            this.ucDataLView1.GridLines = true;
            this.ucDataLView1.GroupBackColor = System.Drawing.SystemColors.Control;
            this.ucDataLView1.HideSelection = false;
            this.ucDataLView1.HoverSelection = false;
            this.ucDataLView1.LabelEdit = false;
            this.ucDataLView1.ListBackColor = System.Drawing.SystemColors.Window;
            this.ucDataLView1.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.ucDataLView1.ListShowItemToolTips = true;
            this.ucDataLView1.ListViewContextMenu = null;
            this.ucDataLView1.Location = new System.Drawing.Point(-2, 325);
            this.ucDataLView1.MultiSelect = false;
            this.ucDataLView1.Name = "ucDataLView1";
            this.ucDataLView1.Scrollable = true;
            this.ucDataLView1.ShowItemAddButton = false;
            this.ucDataLView1.ShowItemRemoveButton = false;
            this.ucDataLView1.ShowPrintPreviewButton = false;
            this.ucDataLView1.ShowRefreshButton = false;
            this.ucDataLView1.Size = new System.Drawing.Size(500, 114);
            this.ucDataLView1.SmallImageList = null;
            this.ucDataLView1.TabIndex = 1;
            this.ucDataLView1.ToolTipAdd = "Add new record";
            this.ucDataLView1.ToolTipPreview = "View a print preview in IE";
            this.ucDataLView1.ToolTipRefresh = "Refresh the data in the List";
            this.ucDataLView1.ToolTipRemove = "Remove selected record";
            this.ucDataLView1.ToolTipTitle = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 451);
            this.Controls.Add(this.nudBurner);
            this.Controls.Add(this.lblBurner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.ucDataLView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Burner Control";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBurner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private SIGIntranetShell.ucDataLView ucDataLView1;
        private System.Windows.Forms.NumericUpDown nudBurner;
        private System.Windows.Forms.Label lblBurner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSet;
    }
}

