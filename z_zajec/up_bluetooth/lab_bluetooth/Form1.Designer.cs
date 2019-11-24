namespace lab_bluetooth
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
            this.discoveryListBox = new System.Windows.Forms.ListBox();
            this.discoverButton = new System.Windows.Forms.Button();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.pairedListBox = new System.Windows.Forms.ListBox();
            this.pairButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.selectedFileLabel = new System.Windows.Forms.Label();
            this.sendfileButton = new System.Windows.Forms.Button();
            this.sendFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // discoveryListBox
            // 
            this.discoveryListBox.FormattingEnabled = true;
            this.discoveryListBox.ItemHeight = 20;
            this.discoveryListBox.Location = new System.Drawing.Point(47, 34);
            this.discoveryListBox.Name = "discoveryListBox";
            this.discoveryListBox.Size = new System.Drawing.Size(294, 364);
            this.discoveryListBox.TabIndex = 0;
            // 
            // discoverButton
            // 
            this.discoverButton.Location = new System.Drawing.Point(373, 34);
            this.discoverButton.Name = "discoverButton";
            this.discoverButton.Size = new System.Drawing.Size(119, 64);
            this.discoverButton.TabIndex = 1;
            this.discoverButton.Text = "Discover";
            this.discoverButton.UseVisualStyleBackColor = true;
            this.discoverButton.Click += new System.EventHandler(this.discoverButton_Click);
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Location = new System.Drawing.Point(594, 34);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(515, 364);
            this.logRichTextBox.TabIndex = 2;
            this.logRichTextBox.Text = "";
            // 
            // pairedListBox
            // 
            this.pairedListBox.FormattingEnabled = true;
            this.pairedListBox.ItemHeight = 20;
            this.pairedListBox.Location = new System.Drawing.Point(47, 442);
            this.pairedListBox.Name = "pairedListBox";
            this.pairedListBox.Size = new System.Drawing.Size(294, 204);
            this.pairedListBox.TabIndex = 3;
            // 
            // pairButton
            // 
            this.pairButton.Location = new System.Drawing.Point(373, 104);
            this.pairButton.Name = "pairButton";
            this.pairButton.Size = new System.Drawing.Size(119, 64);
            this.pairButton.TabIndex = 4;
            this.pairButton.Text = "Pair";
            this.pairButton.UseVisualStyleBackColor = true;
            this.pairButton.Click += new System.EventHandler(this.pairButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 709);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(594, 442);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(119, 64);
            this.selectFileButton.TabIndex = 6;
            this.selectFileButton.Text = "Select file";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // selectedFileLabel
            // 
            this.selectedFileLabel.AutoSize = true;
            this.selectedFileLabel.Location = new System.Drawing.Point(733, 464);
            this.selectedFileLabel.Name = "selectedFileLabel";
            this.selectedFileLabel.Size = new System.Drawing.Size(117, 20);
            this.selectedFileLabel.TabIndex = 7;
            this.selectedFileLabel.Text = "No file selected";
            // 
            // sendfileButton
            // 
            this.sendfileButton.Location = new System.Drawing.Point(373, 442);
            this.sendfileButton.Name = "sendfileButton";
            this.sendfileButton.Size = new System.Drawing.Size(119, 64);
            this.sendfileButton.TabIndex = 8;
            this.sendfileButton.Text = "Send file";
            this.sendfileButton.UseVisualStyleBackColor = true;
            this.sendfileButton.Click += new System.EventHandler(this.sendfileButton_Click);
            // 
            // sendFileProgressBar
            // 
            this.sendFileProgressBar.Location = new System.Drawing.Point(373, 523);
            this.sendFileProgressBar.Name = "sendFileProgressBar";
            this.sendFileProgressBar.Size = new System.Drawing.Size(100, 23);
            this.sendFileProgressBar.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1189, 709);
            this.Controls.Add(this.sendFileProgressBar);
            this.Controls.Add(this.sendfileButton);
            this.Controls.Add(this.selectedFileLabel);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pairButton);
            this.Controls.Add(this.pairedListBox);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.discoverButton);
            this.Controls.Add(this.discoveryListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox discoveryListBox;
        private System.Windows.Forms.Button discoverButton;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.ListBox pairedListBox;
        private System.Windows.Forms.Button pairButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label selectedFileLabel;
        private System.Windows.Forms.Button sendfileButton;
        private System.Windows.Forms.ProgressBar sendFileProgressBar;
    }
}

