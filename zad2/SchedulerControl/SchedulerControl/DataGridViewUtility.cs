using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SchedulerControl
{
    class DataGridViewUtility
    {
        private const string dateFormat = "dddd dd MMMM";
        private const string timeFormat = "HH:mm";

        public static void PopulateDataGridView(DataGridView dataGridView1, int dataGridRowsCount)
        {
            FillColumnHeadersWithDaysOfWeek(dataGridView1);
            FillRowHeadersWithTimeQuants(dataGridView1, dataGridRowsCount);
        }

        private static void FillRowHeadersWithTimeQuants(DataGridView dataGridView1, int dataGridRowsCount)
        {
            dataGridView1.RowHeadersWidth = 70;

            const string startHour = "00:00";
            DateTime startingTime = DateTime.ParseExact(startHour, timeFormat, CultureInfo.CurrentCulture);
            for (int i = 0; i < dataGridRowsCount; i++)
            {
                dataGridView1.Rows.Add(new DataGridViewRow());
                dataGridView1.Rows[i].HeaderCell.Value = startingTime.ToString(timeFormat);
                startingTime = startingTime.AddMinutes(30);
            }
        }

        private static void FillColumnHeadersWithDaysOfWeek(DataGridView dataGridView1)
        {
            DateTime Today = DateTime.Today.Date;
            DateTime monday = Today.Date.AddDays(-(int)Today.DayOfWeek + 1);
            DateTime tuesday = Today.Date.AddDays(-(int)Today.DayOfWeek + 2);
            DateTime wednesday = Today.Date.AddDays(-(int)Today.DayOfWeek + 3);
            DateTime thursday = Today.Date.AddDays(-(int)Today.DayOfWeek + 4);
            DateTime friday = Today.Date.AddDays(-(int)Today.DayOfWeek + 5);
            DateTime saturday = Today.Date.AddDays(-(int)Today.DayOfWeek + 6);
            DateTime sunday = Today.Date.AddDays(-(int)Today.DayOfWeek + 7);
            dataGridView1.Columns[0].HeaderText = monday.ToString(dateFormat);
            dataGridView1.Columns[1].HeaderText = tuesday.ToString(dateFormat);
            dataGridView1.Columns[2].HeaderText = wednesday.ToString(dateFormat);
            dataGridView1.Columns[3].HeaderText = thursday.ToString(dateFormat);
            dataGridView1.Columns[4].HeaderText = friday.ToString(dateFormat);
            dataGridView1.Columns[5].HeaderText = saturday.ToString(dateFormat);
            dataGridView1.Columns[6].HeaderText = sunday.ToString(dateFormat);
        }

        internal static string GetTaskStartingDateAndTime(DataGridView dataGridView1)
        {
            int lowestRowIndex = dataGridView1.SelectedCells.Cast<DataGridViewCell>().Min(cell => cell.RowIndex);
            int columnIndex = dataGridView1.SelectedCells[0].ColumnIndex;
            return $"{dataGridView1[columnIndex, lowestRowIndex].OwningColumn.HeaderText} {dataGridView1[columnIndex, lowestRowIndex].OwningRow.HeaderCell.Value}";

        }

        internal static void WriteTaskToCells(DataGridView dataGridView1, string taskCategory, string taskDescription)
        {
            foreach (DataGridViewTextBoxCell cell in dataGridView1.SelectedCells)
            {
                cell.Style.BackColor = CategoryUtility.GetLabelColor(taskCategory);
                cell.Value = taskDescription;            }
        }

        internal static int GetSelectedColumnsCount(DataGridView dataGridView1)
        {
            return dataGridView1.SelectedCells.Cast<DataGridViewCell>()
                                  .Select(cell => cell.ColumnIndex).Distinct().Count();
        }
    }
}
