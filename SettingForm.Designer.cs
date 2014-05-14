namespace RaderAmedasDecoder
{
    partial class SettingForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxGrib2Folder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectGrib2Folder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.button1.Location = new System.Drawing.Point(177, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "設定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.button2.Location = new System.Drawing.Point(280, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "キャンセル";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBoxGrib2Folder
            // 
            this.textBoxGrib2Folder.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.textBoxGrib2Folder.Location = new System.Drawing.Point(12, 58);
            this.textBoxGrib2Folder.Name = "textBoxGrib2Folder";
            this.textBoxGrib2Folder.Size = new System.Drawing.Size(278, 22);
            this.textBoxGrib2Folder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "grib2ファイル格納フォルダ";
            // 
            // buttonSelectGrib2Folder
            // 
            this.buttonSelectGrib2Folder.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.buttonSelectGrib2Folder.Location = new System.Drawing.Point(296, 58);
            this.buttonSelectGrib2Folder.Name = "buttonSelectGrib2Folder";
            this.buttonSelectGrib2Folder.Size = new System.Drawing.Size(59, 24);
            this.buttonSelectGrib2Folder.TabIndex = 4;
            this.buttonSelectGrib2Folder.Text = "選択";
            this.buttonSelectGrib2Folder.UseVisualStyleBackColor = true;
            this.buttonSelectGrib2Folder.Click += new System.EventHandler(this.buttonSelectGrib2Folder_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 142);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSelectGrib2Folder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGrib2Folder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "SettingForm";
            this.Text = "フォルダの設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxGrib2Folder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectGrib2Folder;
    }
}