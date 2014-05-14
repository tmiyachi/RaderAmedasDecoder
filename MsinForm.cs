using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace RaderAmedasDecoder
{
    public partial class MainForm : Form
    {

        String grib2FolderPath;
        

        public MainForm()
        {
            InitializeComponent();
            grib2FolderPath = Properties.Settings.Default.Grib2FolderPath;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            dateSelecterControlStart.initializeDate();
            dateSelecterControlEnd.initializeDate();
        }

        private void フォルダ設定FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm f = new SettingForm();
            f.Grib2FolderPath = Properties.Settings.Default.Grib2FolderPath;
            if (f.ShowDialog() == DialogResult.OK) {
                grib2FolderPath = f.Grib2FolderPath;
                Properties.Settings.Default.Grib2FolderPath = grib2FolderPath;
                Properties.Settings.Default.Save();
            }

        }

        private void ButtonDecodeStart_Click(object sender, EventArgs e)
        {
            ///
            /// デコードスタート
            ///
            
            ///
            /// 期間の取得
            ///             
            DateTime startDate = dateSelecterControlStart.selectedTime.ToUniversalTime();
            DateTime endDate   = dateSelecterControlEnd.selectedTime.ToUniversalTime();
            
            if (startDate > endDate) 
            {
                MessageBox.Show("終了時刻が開始時刻より前です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            ///
            /// ファイル名のリストを作成
            ///
            ArrayList filenameList = new ArrayList();
            FilePathFuctory fpf = new FilePathFuctory(grib2FolderPath);

            DateTime date = startDate;
            String gfilepath;
            while (date <= endDate)
            {                
                gfilepath = fpf.getRaFilePath(date);

                if (File.Exists(gfilepath))
                {
                    filenameList.Add(gfilepath);
                }
                else
                {
                    MessageBox.Show("ファイル" + gfilepath + "が存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                date = date.AddMinutes(30);
            }

            ///
            /// grib2ファイルの読み込み
            ///
 
            //float[] rainData = new float[filenameList.Count];

            foreach (String filepath in filenameList)
           {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);

                RAGrib2 grb = new RAGrib2(fs);
                toolStripStatusLabel1.Text = grb.maximumValeOfLevel.ToString();

                fs.Dispose();
           }

            // 終了
            //toolStripStatusLabel1.Text = "finish";
                

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
