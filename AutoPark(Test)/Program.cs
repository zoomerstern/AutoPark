using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPark_Test_
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static List<MyLib.Auto> auto= new List<MyLib.Auto>();
        public static Dictionary<string, int> typeMotor;//Список моторов
        public static Dictionary<int, Dictionary<string, int>> typeJob;//Список Работ
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}
