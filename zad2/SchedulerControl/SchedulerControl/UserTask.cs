using System;
using System.Globalization;
using System.Windows.Forms;

namespace SchedulerControl
{
    class UserTask
    {
        private const string DateTimeFormat = "dddd dd MMMM HH:mm";

        internal static DateTime GetReminderDate(string taskDateTime)
        {
            return DateTime.ParseExact(taskDateTime, DateTimeFormat, CultureInfo.CurrentCulture).AddMinutes(-15);           
        }
        internal static DateTime AddTaskAndGetReminderDate(DataGridView dataGridView, string taskCategory, string taskDescription)
        {
            DataGridViewUtility.WriteTaskToCells(dataGridView, taskCategory, taskDescription);
            string taskDateTime = DataGridViewUtility.GetTaskStartingDateAndTime(dataGridView);

            return GetReminderDate(taskDateTime);
        }
    }
}
