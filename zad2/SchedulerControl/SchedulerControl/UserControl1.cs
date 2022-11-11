using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchedulerControl
{
    public partial class UserControl1 : UserControl
    {
        private int dataGridRowsCount = 48;
        public event EventHandler Reminder;

        public UserControl1()
        {
            InitializeComponent();
            DataGridViewUtility.PopulateDataGridView(dataGridView1, dataGridRowsCount);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.BackColor = CategoryUtility.GetLabelColor(comboBox1.Text);
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Color color;
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            color = CategoryUtility.GetLabelColor(text);
            e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
            e.Graphics.DrawString(text, e.Font, new SolidBrush(((ComboBox)sender).ForeColor), new Point(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedColumnsCount = DataGridViewUtility.GetSelectedColumnsCount(dataGridView1);
            if (selectedColumnsCount > 1)
                return;
            if (!String.IsNullOrEmpty(comboBox1.Text) && !String.IsNullOrEmpty(textBox1.Text) && dataGridView1.SelectedCells.Count > 0)
            {
                var reminderDate = UserTask.AddTaskAndGetReminderDate(dataGridView1, comboBox1.Text, textBox1.Text);
                int interval = (int)(reminderDate - DateTime.Now).TotalMilliseconds;
                if (interval > 0)
                {
                    var timer = new System.Timers.Timer(interval);
                    timer.Elapsed += (s, args) => OnTimerElapsed(sender, e);
                    timer.AutoReset = false;
                    timer.Enabled = true;
                }
            }
        }        

        public void OnTimerElapsed(object sender, EventArgs e)
        {
            this.Invoke(Reminder, new EventArgs());
        }
    }
}
