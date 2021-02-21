using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPark_Test_
{
    static class Program
    {
        public static List<MyLib.Auto> auto= new List<MyLib.Auto>();//Парк авто
        public static Dictionary<string, int> typeMotor;//Список видлов моторов
        public static Dictionary<int, Dictionary<string, int>> typeJob;//Список видов работ
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}
