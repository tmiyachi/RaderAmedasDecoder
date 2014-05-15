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
            FilePathFuctory fpf = new FilePathFuctory(grib2FolderPath);

            DateTime date = startDate;
            String gfilepath;

            ///
            /// 出力用データテーブル
            ///
            String pointMeshCode = "9999-99-99";
            DataTable dt = new DataTable();
            dt.Columns.Add("時刻", typeof(DateTime)); // 日付
            dt.Columns.Add(pointMeshCode, typeof(float));
            
            ///
            while (date <= endDate)
            {                
                gfilepath = fpf.getRaFilePath(date);

                if (!File.Exists(gfilepath))               
                {
                    MessageBox.Show("ファイル" + gfilepath + "が存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DataRow dr = dt.NewRow();
                dr["時刻"] = date;
                dr[pointMeshCode] = 1.0;
                dt.Rows.Add(dr);

                date = date.AddMinutes(30);
                
            }

            ///
            /// grib2ファイルの読み込み
            ///
             
            /// バックグラウンドで処理
            object[] args = new object[2];
            args[0] = startDate;
            args[1] = endDate;

            ButtonDecodeStart.Enabled = false;
            buttonCancel.Enabled = true;
            bw.RunWorkerAsync(args);  

           // date = startDate;
           // for(int i=0; i<100; i++)
           //{
           //    gfilepath = fpf.getRaFilePath(date);
           //    using (FileStream fs = new FileStream(gfilepath, FileMode.Open, FileAccess.Read))
           //    {

           //        RAGrib2 grb = new RAGrib2(fs);
           //    }
               
           //  //   toolStripStatusLabel2.Text = i.ToString() + "番目";
           //  //   Application.DoEvents();
           //     //System.Threading.Thread.Sleep(1000);
           //}

            ///
            /// 書き込み
            ///
            String csvfilepath = "C:\\Users\\miyachi\\Desktop\\hoge.csv";
           using ( StreamWriter sr = new StreamWriter(csvfilepath, false, Encoding.GetEncoding("Shift_JIS")))
           {

              int colCount = dt.Columns.Count;
       int lastColIndex = colCount - 1;

    //ヘッダを書き込む
 
        for (int i = 0; i < colCount; i++)
        {
            //ヘッダの取得
            string field = dt.Columns[i].Caption;
            //"で囲む
            //field = EncloseDoubleQuotesIfNeed(field);
            //フィールドを書き込む
            sr.Write(field);
            //カンマを書き込む
            if (lastColIndex > i)
            {
                sr.Write(',');
            }
        
        
    }
        //改行する
        sr.Write("\r\n");
        //レコードを書き込む
        foreach (DataRow row in dt.Rows)
        {
            for (int i = 0; i < colCount; i++)
            {
                //フィールドの取得
                string field = row[i].ToString();
                //"で囲む
               // field = EncloseDoubleQuotesIfNeed(field);
                //フィールドを書き込む
                sr.Write(field);
                //カンマを書き込む
                if (lastColIndex > i)
                {
                    sr.Write(',');
                }
            }
            //改行する
            sr.Write("\r\n");
        }
        }

            // 終了
            toolStripStatusLabel1.Text = "finish";
            
            

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            DateTime startDate = (DateTime)args[0];
            DateTime endDate = (DateTime)args[1];

            
            FilePathFuctory fpf = new FilePathFuctory(grib2FolderPath);

            String gfilepath;
            DateTime date;
            int i = 0;
            date = startDate;
            while (date <= endDate)
            {
                gfilepath = fpf.getRaFilePath(date);
                using (FileStream fs = new FileStream(gfilepath, FileMode.Open, FileAccess.Read))
                {

                    RAGrib2 grb = new RAGrib2(fs);
                }
                bw.ReportProgress(i, date);
                //   toolStripStatusLabel2.Text = i.ToString() + "番目";
                //   Application.DoEvents();
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                //System.Threading.Thread.Sleep(5000);
                date = date.AddMinutes(30);
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DateTime date = (DateTime)e.UserState;
            toolStripStatusLabel2.Text = date.ToString("yyyy/MM/dd HH:mm") + "を処理中";
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        if (e.Cancelled == true)
        {
            toolStripStatusLabel2.Text = "デコードを中止しました。";            
        }
        else
        {
            toolStripStatusLabel2.Text = "デコードを終了。";
        }
        ButtonDecodeStart.Enabled = true;
        buttonCancel.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
            buttonCancel.Enabled = false;
            toolStripStatusLabel2.Text = "キャンセル中...。";
        }
   
        


    }
}
