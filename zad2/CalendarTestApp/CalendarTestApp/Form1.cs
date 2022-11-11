using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarTestApp
{
    public partial class Form1 : Form
    {
        MessageBoxButtons buttons;
        public Form1()
        {
            InitializeComponent();
            buttons = MessageBoxButtons.OK;
            userControl11.Reminder += new EventHandler(ShowAlarm);
        }

        public void ShowAlarm(object sender, EventArgs e)
        {
            MessageBox.Show($"You have incoming task", "Reminder", buttons);
        }
    }
}
