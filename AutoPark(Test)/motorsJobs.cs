using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using MyLib;

namespace AutoPark_Test_
{
    public partial class motorsJobs : System.Windows.Forms.Form
    {
     
        int imotor = -1;//индекс мотора
        int ijob = -1;//индекс работы
        public motorsJobs()
        {
            InitializeComponent();
            MotorLoad();//объявляем список моторв
        }

        private void MotorLoad()//Вывод данных о моторах
        {
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            if (Program.typeMotor!=null)
                foreach (string motor in Program.typeMotor.Keys)
                { //Запись в массив   
                    dataGridView2.Rows.Add(new string[]{ Program.typeMotor[motor].ToString(), motor } );
                }
            return;
        }

        private void JobLoad()//Вывод данных о работах над моторами
        {
            if (imotor == -1) return; //какой индекс мотора
            dataGridView1.Rows.Clear();
            if(Program.typeJob.ContainsKey(imotor) && Program.typeJob[imotor]!=null)
                foreach (string job in Program.typeJob[imotor].Keys) //Запись данных об работах над моторм
                {
                    dataGridView1.Rows.Add(new string[] { Program.typeJob[imotor][job].ToString(), job });
                }
            return;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount < 2 || dataGridView2[0, dataGridView2.CurrentRow.Index].Value==null)
                return;//Проверка на коректный вобор из списка моторов
            tEmotor.Text = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString(); //Выводим название мотора
            imotor = int.Parse(dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString()); //Запомниаем индекс моторах
            JobLoad();//Выводим работы по мотору
            return;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount < 2 || dataGridView1[0, dataGridView1.CurrentRow.Index].Value == null)
                return;
            tEjob.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();//Вывод названия работы
            ijob = int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());//Запомниаем индекс работы
            return;
        }

        private void Bmotor_Click(object sender, EventArgs e)
        {//Добавить мотр список
            if (tEmotor.Text.ToString() == "" || Program.typeMotor==null || Program.typeMotor.ContainsKey(tEmotor.Text.ToString()) )
                return;
            int num = -1;
            MyLib.DataSQL.request("INSERT INTO  motors ([name]) VALUES ( '" + tEmotor.Text.ToString() + "')");
            MyLib.DataSQL.requestRead("SELECT MAX(id) FROM motors");
            if (MyLib.DataSQL.reader.Read())
            {
                num = int.Parse(MyLib.DataSQL.reader[0].ToString());
            }
            Program.typeMotor.Add(tEmotor.Text.ToString(), num);
            Program.typeJob.Add(num, new Dictionary<string, int>());
            MotorLoad();// Обновление списка моторов
            imotor = -1;//Сброс индекса мотора
            tEmotor.Text = "";//Сброс мотора в текст боксе
        }
        private void BEmotor_Click(object sender, EventArgs e)
        {//Измнить мотор
            if (tEmotor.Text.ToString() == "" || imotor == -1)
                return;

            MyLib.DataSQL.request("UPDATE motors SET name = '" + tEmotor.Text.ToString() +
                 "' WHERE id=" + imotor);
            foreach (var pair in Program.typeMotor) {
                if (pair.Value == imotor) {
                    Program.typeMotor.Remove(pair.Key);
                    Program.typeMotor.Add(tEmotor.Text.ToString(), pair.Value);
                    break;
                }
            }
            MotorLoad();
            imotor = -1;
            tEmotor.Text = "";

        }
        private void bDmotor_Click(object sender, EventArgs e)
        {//Удаление мотора
            if (tEmotor.Text.ToString() == "" || imotor == -1)
                return;
            // Есть ли машины и работы по данному мотору
            MessageBox.Show("В случае удаления мотора будут удалены все работы связанные с этим мотором");
            DialogResult dialogResult = MessageBox.Show("Вы согласны?", "Согласие", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            //Удаление всех данных связанных с ээтим моторм
            //== typejob
            if (Program.typeJob.ContainsKey(imotor))
            {
                Program.typeJob.Remove(imotor);
                MyLib.DataSQL.request("DELETE FROM  typejob where type=" + imotor);
            }
            //== Auto motor and Auto job
            Program.auto.FindAll(x => x.motor.id == imotor).ForEach(delegate (Auto cur) {
                cur.deleteMotor();
            });
            //== motors
            Program.typeMotor.Remove(tEmotor.Text.ToString());
            MyLib.DataSQL.request("DELETE FROM motors WHERE id=" + imotor);
            //==
            imotor = -1;//Сброс индекса мотора
            tEmotor.Text = "";//Сброс названия мотора в текст боксе
            MotorLoad();//Обновление списка моторв
        }

     

        private void bClose_Click(object sender, EventArgs e)
        {// закрыть окно
            Close();
        }

        private void bjob_Click(object sender, EventArgs e)
        {//Добавление работы над мотором
            if (tEjob.Text.ToString() == "" || Program.typeJob[imotor].ContainsKey(tEjob.Text.ToString()) )
                return;
            MyLib.DataSQL.request("INSERT INTO  typejob ([name],[type]) VALUES ( '" + tEjob.Text.ToString() + "',"+imotor+")");
            MyLib.DataSQL.requestRead("SELECT MAX(id) FROM typejob");
            MyLib.DataSQL.reader.Read();
            Program.typeJob[imotor].Add(tEjob.Text.ToString(), int.Parse(MyLib.DataSQL.reader[0].ToString()));
            JobLoad();
            ijob = -1;
            tEjob.Text = "";
        }

        private void bEjob_Click(object sender, EventArgs e)
        {//Редактирование работы
            if (tEjob.Text.ToString() == "" || ijob == -1)
                return;
            MyLib.DataSQL.request("UPDATE typejob SET name = '" + tEjob.Text.ToString() +
                 "' WHERE id=" + ijob);
            foreach (var pair in Program.typeJob[imotor])
            {
                if (pair.Value == ijob)
                {
                    Program.typeJob[imotor].Remove(pair.Key);
                    Program.typeJob[imotor].Add(tEjob.Text.ToString(), pair.Value);
                    break;
                }
            }

            JobLoad();
            ijob = -1;
            tEjob.Text = "";
        }

        private void bDjob_Click(object sender, EventArgs e)
        {//Удаление работы
            if (tEjob.Text.ToString() == "" || ijob == -1)
                return;
            MyLib.DataSQL.request("DELETE FROM typejob WHERE id=" + ijob);
            Program.typeJob[imotor].Remove(tEjob.Text.ToString());
            JobLoad();
            ijob = -1;
            tEjob.Text = ""; 
        }
    }
}
