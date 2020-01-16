namespace up_gps_241284
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
            this.mySplitCont = new System.Windows.Forms.SplitContainer();
            this.latitiudeText = new System.Windows.Forms.Label();
            this.latitiudeLabel = new System.Windows.Forms.Label();
            this.longitiudeText = new System.Windows.Forms.Label();
            this.logitiudeLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mySplitCont)).BeginInit();
            this.mySplitCont.Panel1.SuspendLayout();
            this.mySplitCont.SuspendLayout();
            this.SuspendLayout();
            // 
            // mySplitCont
            // 
            this.mySplitCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySplitCont.Location = new System.Drawing.Point(0, 0);
            this.mySplitCont.Name = "mySplitCont";
            // 
            // mySplitCont.Panel1
            // 
            this.mySplitCont.Panel1.Controls.Add(this.logitiudeLabel1);
            this.mySplitCont.Panel1.Controls.Add(this.longitiudeText);
            this.mySplitCont.Panel1.Controls.Add(this.latitiudeLabel);
            this.mySplitCont.Panel1.Controls.Add(this.latitiudeText);
            this.mySplitCont.Size = new System.Drawing.Size(800, 450);
            this.mySplitCont.SplitterDistance = 266;
            this.mySplitCont.TabIndex = 0;
            // 
            // latitiudeText
            // 
            this.latitiudeText.AutoSize = true;
            this.latitiudeText.Location = new System.Drawing.Point(103, 58);
            this.latitiudeText.Name = "latitiudeText";
            this.latitiudeText.Size = new System.Drawing.Size(67, 20);
            this.latitiudeText.TabIndex = 0;
            this.latitiudeText.Text = "Latitude";
            // 
            // latitiudeLabel
            // 
            this.latitiudeLabel.AutoSize = true;
            this.latitiudeLabel.Location = new System.Drawing.Point(103, 93);
            this.latitiudeLabel.Name = "latitiudeLabel";
            this.latitiudeLabel.Size = new System.Drawing.Size(14, 20);
            this.latitiudeLabel.TabIndex = 1;
            this.latitiudeLabel.Text = "-";
            // 
            // longitiudeText
            // 
            this.longitiudeText.AutoSize = true;
            this.longitiudeText.Location = new System.Drawing.Point(103, 212);
            this.longitiudeText.Name = "longitiudeText";
            this.longitiudeText.Size = new System.Drawing.Size(83, 20);
            this.longitiudeText.TabIndex = 2;
            this.longitiudeText.Text = "Longitiude";
            // 
            // logitiudeLabel1
            // 
            this.logitiudeLabel1.AutoSize = true;
            this.logitiudeLabel1.Location = new System.Drawing.Point(103, 249);
            this.logitiudeLabel1.Name = "logitiudeLabel1";
            this.logitiudeLabel1.Size = new System.Drawing.Size(14, 20);
            this.logitiudeLabel1.TabIndex = 3;
            this.logitiudeLabel1.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mySplitCont);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mySplitCont.Panel1.ResumeLayout(false);
            this.mySplitCont.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mySplitCont)).EndInit();
            this.mySplitCont.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mySplitCont;
        private System.Windows.Forms.Label logitiudeLabel1;
        private System.Windows.Forms.Label longitiudeText;
        private System.Windows.Forms.Label latitiudeLabel;
        private System.Windows.Forms.Label latitiudeText;
    }
}

