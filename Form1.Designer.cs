namespace SingleScreenShot
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPicName = new System.Windows.Forms.TextBox();
            this.txtSelectedFile = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioBtnRightScreen = new System.Windows.Forms.RadioButton();
            this.radioBtnLeftScreen = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Location = new System.Drawing.Point(268, 646);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(85, 23);
            this.btnOpenDialog.TabIndex = 1;
            this.btnOpenDialog.Text = "フォルダを選択";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(139, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 567);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtPicName
            // 
            this.txtPicName.Location = new System.Drawing.Point(368, 625);
            this.txtPicName.Name = "txtPicName";
            this.txtPicName.Size = new System.Drawing.Size(100, 19);
            this.txtPicName.TabIndex = 4;
            // 
            // txtSelectedFile
            // 
            this.txtSelectedFile.Location = new System.Drawing.Point(368, 650);
            this.txtSelectedFile.Name = "txtSelectedFile";
            this.txtSelectedFile.Size = new System.Drawing.Size(403, 19);
            this.txtSelectedFile.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 628);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "保存画像名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 601);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "撮影画面";
            // 
            // radioBtnRightScreen
            // 
            this.radioBtnRightScreen.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnRightScreen.Checked = true;
            this.radioBtnRightScreen.Location = new System.Drawing.Point(428, 595);
            this.radioBtnRightScreen.Name = "radioBtnRightScreen";
            this.radioBtnRightScreen.Size = new System.Drawing.Size(54, 24);
            this.radioBtnRightScreen.TabIndex = 9;
            this.radioBtnRightScreen.TabStop = true;
            this.radioBtnRightScreen.Text = "右画面";
            this.radioBtnRightScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnRightScreen.UseVisualStyleBackColor = true;
            this.radioBtnRightScreen.CheckedChanged += new System.EventHandler(this.radioBtnRightScreen_CheckedChanged);
            // 
            // radioBtnLeftScreen
            // 
            this.radioBtnLeftScreen.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioBtnLeftScreen.Location = new System.Drawing.Point(368, 595);
            this.radioBtnLeftScreen.Name = "radioBtnLeftScreen";
            this.radioBtnLeftScreen.Size = new System.Drawing.Size(54, 24);
            this.radioBtnLeftScreen.TabIndex = 10;
            this.radioBtnLeftScreen.TabStop = true;
            this.radioBtnLeftScreen.Text = "左画面";
            this.radioBtnLeftScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnLeftScreen.UseVisualStyleBackColor = true;
            this.radioBtnLeftScreen.CheckedChanged += new System.EventHandler(this.radioBtnLeftScreen_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(578, 598);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 601);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "撮影キー";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioBtnLeftScreen);
            this.Controls.Add(this.radioBtnRightScreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSelectedFile);
            this.Controls.Add(this.txtPicName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOpenDialog);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPicName;
        private System.Windows.Forms.MaskedTextBox txtSelectedFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioBtnRightScreen;
        private System.Windows.Forms.RadioButton radioBtnLeftScreen;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}

