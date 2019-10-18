namespace Bluetooth
{
    partial class BluetoothForm
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
            this.foundDevicesListBox = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.pairButton = new System.Windows.Forms.Button();
            this.sendFileButton = new System.Windows.Forms.Button();
            this.foundDevicesInfoLabel = new System.Windows.Forms.Label();
            this.unpairButton = new System.Windows.Forms.Button();
            this.logInfoLabel = new System.Windows.Forms.Label();
            this.pairedDevicesListBox = new System.Windows.Forms.ListBox();
            this.pairedDevicesInfoLabel = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.fileInfoLabel = new System.Windows.Forms.Label();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // foundDevicesListBox
            // 
            this.foundDevicesListBox.FormattingEnabled = true;
            this.foundDevicesListBox.ItemHeight = 16;
            this.foundDevicesListBox.Location = new System.Drawing.Point(31, 65);
            this.foundDevicesListBox.Name = "foundDevicesListBox";
            this.foundDevicesListBox.Size = new System.Drawing.Size(238, 180);
            this.foundDevicesListBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(275, 65);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(98, 38);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // pairButton
            // 
            this.pairButton.Location = new System.Drawing.Point(275, 109);
            this.pairButton.Name = "pairButton";
            this.pairButton.Size = new System.Drawing.Size(98, 40);
            this.pairButton.TabIndex = 2;
            this.pairButton.Text = "Pair";
            this.pairButton.UseVisualStyleBackColor = true;
            this.pairButton.Click += new System.EventHandler(this.PairButton_Click);
            // 
            // sendFileButton
            // 
            this.sendFileButton.Location = new System.Drawing.Point(479, 450);
            this.sendFileButton.Name = "sendFileButton";
            this.sendFileButton.Size = new System.Drawing.Size(119, 38);
            this.sendFileButton.TabIndex = 3;
            this.sendFileButton.Text = "Send file";
            this.sendFileButton.UseVisualStyleBackColor = true;
            // 
            // foundDevicesInfoLabel
            // 
            this.foundDevicesInfoLabel.AutoSize = true;
            this.foundDevicesInfoLabel.Location = new System.Drawing.Point(93, 36);
            this.foundDevicesInfoLabel.Name = "foundDevicesInfoLabel";
            this.foundDevicesInfoLabel.Size = new System.Drawing.Size(102, 17);
            this.foundDevicesInfoLabel.TabIndex = 5;
            this.foundDevicesInfoLabel.Text = "Found Devices";
            // 
            // unpairButton
            // 
            this.unpairButton.Location = new System.Drawing.Point(275, 296);
            this.unpairButton.Name = "unpairButton";
            this.unpairButton.Size = new System.Drawing.Size(98, 46);
            this.unpairButton.TabIndex = 6;
            this.unpairButton.Text = "Unpair";
            this.unpairButton.UseVisualStyleBackColor = true;
            this.unpairButton.Click += new System.EventHandler(this.UnpairButton_Click);
            // 
            // logInfoLabel
            // 
            this.logInfoLabel.AutoSize = true;
            this.logInfoLabel.Location = new System.Drawing.Point(653, 36);
            this.logInfoLabel.Name = "logInfoLabel";
            this.logInfoLabel.Size = new System.Drawing.Size(32, 17);
            this.logInfoLabel.TabIndex = 8;
            this.logInfoLabel.Text = "Log";
            // 
            // pairedDevicesListBox
            // 
            this.pairedDevicesListBox.FormattingEnabled = true;
            this.pairedDevicesListBox.ItemHeight = 16;
            this.pairedDevicesListBox.Location = new System.Drawing.Point(31, 296);
            this.pairedDevicesListBox.Name = "pairedDevicesListBox";
            this.pairedDevicesListBox.Size = new System.Drawing.Size(238, 196);
            this.pairedDevicesListBox.TabIndex = 9;
            // 
            // pairedDevicesInfoLabel
            // 
            this.pairedDevicesInfoLabel.AutoSize = true;
            this.pairedDevicesInfoLabel.Location = new System.Drawing.Point(93, 264);
            this.pairedDevicesInfoLabel.Name = "pairedDevicesInfoLabel";
            this.pairedDevicesInfoLabel.Size = new System.Drawing.Size(103, 17);
            this.pairedDevicesInfoLabel.TabIndex = 10;
            this.pairedDevicesInfoLabel.Text = "Paired Devices";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(673, 417);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(105, 17);
            this.filePathLabel.TabIndex = 11;
            this.filePathLabel.Text = "No file selected";
            // 
            // fileInfoLabel
            // 
            this.fileInfoLabel.AutoSize = true;
            this.fileInfoLabel.Location = new System.Drawing.Point(633, 417);
            this.fileInfoLabel.Name = "fileInfoLabel";
            this.fileInfoLabel.Size = new System.Drawing.Size(34, 17);
            this.fileInfoLabel.TabIndex = 12;
            this.fileInfoLabel.Text = "File:";
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(479, 406);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(119, 38);
            this.chooseFileButton.TabIndex = 14;
            this.chooseFileButton.Text = "Choose file";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Location = new System.Drawing.Point(479, 65);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(380, 324);
            this.logRichTextBox.TabIndex = 15;
            this.logRichTextBox.Text = "";
            // 
            // BluetoothForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(900, 526);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.fileInfoLabel);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.pairedDevicesInfoLabel);
            this.Controls.Add(this.pairedDevicesListBox);
            this.Controls.Add(this.unpairButton);
            this.Controls.Add(this.logInfoLabel);
            this.Controls.Add(this.foundDevicesInfoLabel);
            this.Controls.Add(this.sendFileButton);
            this.Controls.Add(this.pairButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.foundDevicesListBox);
            this.MaximumSize = new System.Drawing.Size(918, 573);
            this.MinimumSize = new System.Drawing.Size(918, 573);
            this.Name = "BluetoothForm";
            this.Text = "Bluetooth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox foundDevicesListBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button pairButton;
        private System.Windows.Forms.Button sendFileButton;
        private System.Windows.Forms.Label foundDevicesInfoLabel;
        private System.Windows.Forms.Button unpairButton;
        private System.Windows.Forms.Label logInfoLabel;
        private System.Windows.Forms.ListBox pairedDevicesListBox;
        private System.Windows.Forms.Label pairedDevicesInfoLabel;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Label fileInfoLabel;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.RichTextBox logRichTextBox;
    }
}

