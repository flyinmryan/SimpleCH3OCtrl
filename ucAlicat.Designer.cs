namespace BurnerControl
{
    partial class ucAlicat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBurner = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.nudBurner = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBurner)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogo
            // 
            this.imgLogo.Image = global::BurnerControl.Properties.Resources.logo;
            this.imgLogo.Location = new System.Drawing.Point(3, 3);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(47, 74);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(168, 206);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "SET";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // lblBurner
            // 
            this.lblBurner.AutoSize = true;
            this.lblBurner.Location = new System.Drawing.Point(111, 23);
            this.lblBurner.Name = "lblBurner";
            this.lblBurner.Size = new System.Drawing.Size(38, 13);
            this.lblBurner.TabIndex = 2;
            this.lblBurner.Text = "Burner";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(212, 250);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open Valve";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(131, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close Valve";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // nudBurner
            // 
            this.nudBurner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBurner.Location = new System.Drawing.Point(114, 48);
            this.nudBurner.Name = "nudBurner";
            this.nudBurner.Size = new System.Drawing.Size(68, 29);
            this.nudBurner.TabIndex = 4;
            this.nudBurner.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ucAlicat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudBurner);
            this.Controls.Add(this.lblBurner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.imgLogo);
            this.Name = "ucAlicat";
            this.Size = new System.Drawing.Size(423, 315);
            this.Load += new System.EventHandler(this.ucAlicat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBurner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBurner;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.NumericUpDown nudBurner;
    }
}
