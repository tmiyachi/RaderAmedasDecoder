using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaderAmedasDecoder
{
    public partial class SettingForm : Form
    {

        public String Grib2FolderPath {
            get {
                return textBoxGrib2Folder.Text;
            }
            set {
                textBoxGrib2Folder.Text = value;
            }
        
        }



        public SettingForm()
        {
            InitializeComponent();
        }

        private void buttonSelectGrib2Folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (System.IO.Directory.Exists(textBoxGrib2Folder.Text)) {
                    fbd.SelectedPath = textBoxGrib2Folder.Text;
            }
            if (fbd.ShowDialog() == DialogResult.OK) {
                textBoxGrib2Folder.Text = fbd.SelectedPath;
            }

        }
    }
}
