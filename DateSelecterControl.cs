using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaderAmedasDecoder
{
    public partial class DateSelecterControl : UserControl
    {
        public DateTime selectedTime 
        {
            get 
            {
                return dateTimePickerSelected.Value;
            }
        }

        public DateSelecterControl()
        {
            InitializeComponent();           
        }

        private void buttonBackHour_Click(object sender, EventArgs e)
        {
            dateTimePickerSelected.Value = dateTimePickerSelected.Value.AddHours(-1);
        }

        private void buttonBackMin_Click(object sender, EventArgs e)
        {
            dateTimePickerSelected.Value = dateTimePickerSelected.Value.AddMinutes(-30);
        }

        private void buttonProgressMin_Click(object sender, EventArgs e)
        {
            dateTimePickerSelected.Value = dateTimePickerSelected.Value.AddMinutes(30);
        }

        private void buttonProgressHour_Click(object sender, EventArgs e)
        {
            dateTimePickerSelected.Value = dateTimePickerSelected.Value.AddHours(1);
        }

        public void initializeDate()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.Minute < 30)
            {
                dateTimePickerSelected.Value
                    = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, 0, 0);
            }
            else
            {
                dateTimePickerSelected.Value
                    = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, 30, 0);
            }
            // for test
            dateTimePickerSelected.Value = new DateTime(2013, 9, 1, 18, 0, 0);
        }
    }
}
