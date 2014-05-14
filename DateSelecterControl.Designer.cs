namespace RaderAmedasDecoder
{
    partial class DateSelecterControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerSelected = new System.Windows.Forms.DateTimePicker();
            this.buttonBackHour = new System.Windows.Forms.Button();
            this.buttonBackMin = new System.Windows.Forms.Button();
            this.buttonProgressMin = new System.Windows.Forms.Button();
            this.buttonProgressHour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerSelected
            // 
            this.dateTimePickerSelected.Checked = false;
            this.dateTimePickerSelected.CustomFormat = " yyyy年 MM月 dd日 HH時 mm分";
            this.dateTimePickerSelected.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePickerSelected.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSelected.Location = new System.Drawing.Point(3, 3);
            this.dateTimePickerSelected.Name = "dateTimePickerSelected";
            this.dateTimePickerSelected.Size = new System.Drawing.Size(266, 23);
            this.dateTimePickerSelected.TabIndex = 0;
            // 
            // buttonBackHour
            // 
            this.buttonBackHour.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.buttonBackHour.Location = new System.Drawing.Point(3, 32);
            this.buttonBackHour.Name = "buttonBackHour";
            this.buttonBackHour.Size = new System.Drawing.Size(62, 23);
            this.buttonBackHour.TabIndex = 1;
            this.buttonBackHour.Text = "<<";
            this.buttonBackHour.UseVisualStyleBackColor = true;
            this.buttonBackHour.Click += new System.EventHandler(this.buttonBackHour_Click);
            // 
            // buttonBackMin
            // 
            this.buttonBackMin.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.buttonBackMin.Location = new System.Drawing.Point(71, 32);
            this.buttonBackMin.Name = "buttonBackMin";
            this.buttonBackMin.Size = new System.Drawing.Size(62, 23);
            this.buttonBackMin.TabIndex = 2;
            this.buttonBackMin.Text = "< ";
            this.buttonBackMin.UseVisualStyleBackColor = true;
            this.buttonBackMin.Click += new System.EventHandler(this.buttonBackMin_Click);
            // 
            // buttonProgressMin
            // 
            this.buttonProgressMin.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.buttonProgressMin.Location = new System.Drawing.Point(139, 32);
            this.buttonProgressMin.Name = "buttonProgressMin";
            this.buttonProgressMin.Size = new System.Drawing.Size(62, 23);
            this.buttonProgressMin.TabIndex = 3;
            this.buttonProgressMin.Text = ">";
            this.buttonProgressMin.UseVisualStyleBackColor = true;
            this.buttonProgressMin.Click += new System.EventHandler(this.buttonProgressMin_Click);
            // 
            // buttonProgressHour
            // 
            this.buttonProgressHour.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.buttonProgressHour.Location = new System.Drawing.Point(207, 32);
            this.buttonProgressHour.Name = "buttonProgressHour";
            this.buttonProgressHour.Size = new System.Drawing.Size(62, 23);
            this.buttonProgressHour.TabIndex = 4;
            this.buttonProgressHour.Text = ">>";
            this.buttonProgressHour.UseVisualStyleBackColor = true;
            this.buttonProgressHour.Click += new System.EventHandler(this.buttonProgressHour_Click);
            // 
            // DateSelecterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonProgressHour);
            this.Controls.Add(this.buttonProgressMin);
            this.Controls.Add(this.buttonBackMin);
            this.Controls.Add(this.buttonBackHour);
            this.Controls.Add(this.dateTimePickerSelected);
            this.Name = "DateSelecterControl";
            this.Size = new System.Drawing.Size(272, 58);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerSelected;
        private System.Windows.Forms.Button buttonBackHour;
        private System.Windows.Forms.Button buttonBackMin;
        private System.Windows.Forms.Button buttonProgressMin;
        private System.Windows.Forms.Button buttonProgressHour;
    }
}
