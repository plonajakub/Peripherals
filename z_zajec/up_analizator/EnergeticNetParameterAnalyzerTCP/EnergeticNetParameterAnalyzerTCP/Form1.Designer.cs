namespace EnergeticNetParameterAnalyzerTCP
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
            this.VoltageL1LNLabel = new System.Windows.Forms.Label();
            this.VoltageL1TextBox = new System.Windows.Forms.TextBox();
            this.VoltageUnitLabel = new System.Windows.Forms.Label();
            this.startLoggingButton = new System.Windows.Forms.Button();
            this.CL1Label = new System.Windows.Forms.Label();
            this.cosPhiL1Label = new System.Windows.Forms.Label();
            this.activePowerL1Label = new System.Windows.Forms.Label();
            this.currentL1TextBox = new System.Windows.Forms.TextBox();
            this.amperLabel = new System.Windows.Forms.Label();
            this.cosPhiL1TextBox = new System.Windows.Forms.TextBox();
            this.activePowerL1TexBox = new System.Windows.Forms.TextBox();
            this.cosPhiUnitLabel = new System.Windows.Forms.Label();
            this.powerUnitLabel = new System.Windows.Forms.Label();
            this.calculatedActivePowerL1Label = new System.Windows.Forms.Label();
            this.calculatedActivePowerL1TextBox = new System.Windows.Forms.TextBox();
            this.calculatedActivePowerUnit = new System.Windows.Forms.Label();
            this.logLabel = new System.Windows.Forms.Label();
            this.stopLoggingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VoltageL1LNLabel
            // 
            this.VoltageL1LNLabel.AutoSize = true;
            this.VoltageL1LNLabel.Location = new System.Drawing.Point(203, 182);
            this.VoltageL1LNLabel.Name = "VoltageL1LNLabel";
            this.VoltageL1LNLabel.Size = new System.Drawing.Size(123, 20);
            this.VoltageL1LNLabel.TabIndex = 0;
            this.VoltageL1LNLabel.Text = "Voltage L1 [L-N]";
            // 
            // VoltageL1TextBox
            // 
            this.VoltageL1TextBox.Location = new System.Drawing.Point(336, 182);
            this.VoltageL1TextBox.Name = "VoltageL1TextBox";
            this.VoltageL1TextBox.ReadOnly = true;
            this.VoltageL1TextBox.Size = new System.Drawing.Size(100, 26);
            this.VoltageL1TextBox.TabIndex = 1;
            this.VoltageL1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VoltageUnitLabel
            // 
            this.VoltageUnitLabel.AutoSize = true;
            this.VoltageUnitLabel.Location = new System.Drawing.Point(455, 179);
            this.VoltageUnitLabel.Name = "VoltageUnitLabel";
            this.VoltageUnitLabel.Size = new System.Drawing.Size(20, 20);
            this.VoltageUnitLabel.TabIndex = 2;
            this.VoltageUnitLabel.Text = "V";
            // 
            // startLoggingButton
            // 
            this.startLoggingButton.Location = new System.Drawing.Point(267, 479);
            this.startLoggingButton.Name = "startLoggingButton";
            this.startLoggingButton.Size = new System.Drawing.Size(105, 36);
            this.startLoggingButton.TabIndex = 3;
            this.startLoggingButton.Text = "Start";
            this.startLoggingButton.UseVisualStyleBackColor = true;
            this.startLoggingButton.Click += new System.EventHandler(this.startLoggingButton_Click);
            // 
            // CL1Label
            // 
            this.CL1Label.AutoSize = true;
            this.CL1Label.Location = new System.Drawing.Point(203, 227);
            this.CL1Label.Name = "CL1Label";
            this.CL1Label.Size = new System.Drawing.Size(84, 20);
            this.CL1Label.TabIndex = 4;
            this.CL1Label.Text = "Current L1";
            // 
            // cosPhiL1Label
            // 
            this.cosPhiL1Label.AutoSize = true;
            this.cosPhiL1Label.Location = new System.Drawing.Point(203, 273);
            this.cosPhiL1Label.Name = "cosPhiL1Label";
            this.cosPhiL1Label.Size = new System.Drawing.Size(85, 20);
            this.cosPhiL1Label.TabIndex = 5;
            this.cosPhiL1Label.Text = "Cos Phi L1";
            // 
            // activePowerL1Label
            // 
            this.activePowerL1Label.AutoSize = true;
            this.activePowerL1Label.Location = new System.Drawing.Point(203, 319);
            this.activePowerL1Label.Name = "activePowerL1Label";
            this.activePowerL1Label.Size = new System.Drawing.Size(122, 20);
            this.activePowerL1Label.TabIndex = 6;
            this.activePowerL1Label.Text = "Active Power L1";
            // 
            // currentL1TextBox
            // 
            this.currentL1TextBox.Location = new System.Drawing.Point(336, 227);
            this.currentL1TextBox.Name = "currentL1TextBox";
            this.currentL1TextBox.ReadOnly = true;
            this.currentL1TextBox.Size = new System.Drawing.Size(100, 26);
            this.currentL1TextBox.TabIndex = 7;
            this.currentL1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amperLabel
            // 
            this.amperLabel.AutoSize = true;
            this.amperLabel.Location = new System.Drawing.Point(455, 230);
            this.amperLabel.Name = "amperLabel";
            this.amperLabel.Size = new System.Drawing.Size(20, 20);
            this.amperLabel.TabIndex = 8;
            this.amperLabel.Text = "A";
            // 
            // cosPhiL1TextBox
            // 
            this.cosPhiL1TextBox.Location = new System.Drawing.Point(336, 267);
            this.cosPhiL1TextBox.Name = "cosPhiL1TextBox";
            this.cosPhiL1TextBox.ReadOnly = true;
            this.cosPhiL1TextBox.Size = new System.Drawing.Size(100, 26);
            this.cosPhiL1TextBox.TabIndex = 9;
            this.cosPhiL1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // activePowerL1TexBox
            // 
            this.activePowerL1TexBox.Location = new System.Drawing.Point(336, 313);
            this.activePowerL1TexBox.Name = "activePowerL1TexBox";
            this.activePowerL1TexBox.ReadOnly = true;
            this.activePowerL1TexBox.Size = new System.Drawing.Size(100, 26);
            this.activePowerL1TexBox.TabIndex = 10;
            this.activePowerL1TexBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cosPhiUnitLabel
            // 
            this.cosPhiUnitLabel.AutoSize = true;
            this.cosPhiUnitLabel.Location = new System.Drawing.Point(455, 273);
            this.cosPhiUnitLabel.Name = "cosPhiUnitLabel";
            this.cosPhiUnitLabel.Size = new System.Drawing.Size(14, 20);
            this.cosPhiUnitLabel.TabIndex = 11;
            this.cosPhiUnitLabel.Text = "-";
            // 
            // powerUnitLabel
            // 
            this.powerUnitLabel.AutoSize = true;
            this.powerUnitLabel.Location = new System.Drawing.Point(455, 313);
            this.powerUnitLabel.Name = "powerUnitLabel";
            this.powerUnitLabel.Size = new System.Drawing.Size(24, 20);
            this.powerUnitLabel.TabIndex = 12;
            this.powerUnitLabel.Text = "W";
            // 
            // calculatedActivePowerL1Label
            // 
            this.calculatedActivePowerL1Label.AutoSize = true;
            this.calculatedActivePowerL1Label.Location = new System.Drawing.Point(203, 389);
            this.calculatedActivePowerL1Label.Name = "calculatedActivePowerL1Label";
            this.calculatedActivePowerL1Label.Size = new System.Drawing.Size(145, 20);
            this.calculatedActivePowerL1Label.TabIndex = 13;
            this.calculatedActivePowerL1Label.Text = "Active Power L1 [C]";
            // 
            // calculatedActivePowerL1TextBox
            // 
            this.calculatedActivePowerL1TextBox.Location = new System.Drawing.Point(354, 389);
            this.calculatedActivePowerL1TextBox.Name = "calculatedActivePowerL1TextBox";
            this.calculatedActivePowerL1TextBox.ReadOnly = true;
            this.calculatedActivePowerL1TextBox.Size = new System.Drawing.Size(100, 26);
            this.calculatedActivePowerL1TextBox.TabIndex = 14;
            this.calculatedActivePowerL1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // calculatedActivePowerUnit
            // 
            this.calculatedActivePowerUnit.AutoSize = true;
            this.calculatedActivePowerUnit.Location = new System.Drawing.Point(472, 389);
            this.calculatedActivePowerUnit.Name = "calculatedActivePowerUnit";
            this.calculatedActivePowerUnit.Size = new System.Drawing.Size(24, 20);
            this.calculatedActivePowerUnit.TabIndex = 15;
            this.calculatedActivePowerUnit.Text = "W";
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(175, 487);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(70, 20);
            this.logLabel.TabIndex = 16;
            this.logLabel.Text = "Logging:";
            // 
            // stopLoggingButton
            // 
            this.stopLoggingButton.Location = new System.Drawing.Point(391, 479);
            this.stopLoggingButton.Name = "stopLoggingButton";
            this.stopLoggingButton.Size = new System.Drawing.Size(105, 36);
            this.stopLoggingButton.TabIndex = 17;
            this.stopLoggingButton.Text = "Stop";
            this.stopLoggingButton.UseVisualStyleBackColor = true;
            this.stopLoggingButton.Click += new System.EventHandler(this.stopLoggingButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 579);
            this.Controls.Add(this.stopLoggingButton);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.calculatedActivePowerUnit);
            this.Controls.Add(this.calculatedActivePowerL1TextBox);
            this.Controls.Add(this.calculatedActivePowerL1Label);
            this.Controls.Add(this.powerUnitLabel);
            this.Controls.Add(this.cosPhiUnitLabel);
            this.Controls.Add(this.activePowerL1TexBox);
            this.Controls.Add(this.cosPhiL1TextBox);
            this.Controls.Add(this.amperLabel);
            this.Controls.Add(this.currentL1TextBox);
            this.Controls.Add(this.activePowerL1Label);
            this.Controls.Add(this.cosPhiL1Label);
            this.Controls.Add(this.CL1Label);
            this.Controls.Add(this.startLoggingButton);
            this.Controls.Add(this.VoltageUnitLabel);
            this.Controls.Add(this.VoltageL1TextBox);
            this.Controls.Add(this.VoltageL1LNLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VoltageL1LNLabel;
        private System.Windows.Forms.TextBox VoltageL1TextBox;
        private System.Windows.Forms.Label VoltageUnitLabel;
        private System.Windows.Forms.Button startLoggingButton;
        private System.Windows.Forms.Label CL1Label;
        private System.Windows.Forms.Label cosPhiL1Label;
        private System.Windows.Forms.Label activePowerL1Label;
        private System.Windows.Forms.TextBox currentL1TextBox;
        private System.Windows.Forms.Label amperLabel;
        private System.Windows.Forms.TextBox cosPhiL1TextBox;
        private System.Windows.Forms.TextBox activePowerL1TexBox;
        private System.Windows.Forms.Label cosPhiUnitLabel;
        private System.Windows.Forms.Label powerUnitLabel;
        private System.Windows.Forms.Label calculatedActivePowerL1Label;
        private System.Windows.Forms.TextBox calculatedActivePowerL1TextBox;
        private System.Windows.Forms.Label calculatedActivePowerUnit;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button stopLoggingButton;
    }
}

