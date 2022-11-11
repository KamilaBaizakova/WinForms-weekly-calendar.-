using System.Drawing;

namespace SchedulerControl
{
    class CategoryUtility
    {
        public static Color GetLabelColor(string text)
        {
            Color color;
            switch (text)
            {
                case "study":
                    color = Color.Yellow;
                    break;
                case "work":
                    color = Color.YellowGreen;
                    break;
                case "training":
                    color = Color.Green;
                    break;
                case "meeting":
                    color = Color.LightSkyBlue;
                    break;
                case "sport":
                    color = Color.DeepSkyBlue;
                    break;
                case "education":
                    color = Color.Blue;
                    break;
                case "other":
                    color = Color.BlueViolet;
                    break;
                default:
                    color = Color.White;
                    break;
            }
            return color;
        }
    }
}
