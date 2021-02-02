using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using MyLib;

namespace AutoPark_Test_
{
    public partial class motorsJobs : System.Windows.Forms.Form
    {
     
        Dictionary<string, int> typeJob;//Спиосок работ
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
            if(Program.typeMotor!=null)
                foreach (string motor in Program.typeMotor.Keys)
                { //Запись в массив   
                    string[] s = { Program.typeMotor[motor].ToString(), motor };
                    dataGridView2.Rows.Add(s);
                }
            return;
        }

        private void JobLoad()//Вывод данных о работах над моторами
        {
            if (imotor == -1) return; //какой индекс мотора
            typeJob = new Dictionary<string, int>();

            dataGridView1.Rows.Clear();
            MyLib.DataSQL.requestRead("SELECT id, name FROM typejob where type=" + imotor);
            while (MyLib.DataSQL.reader.Read()) //Запись данных об работах над моторм
            {
                typeJob.Add(MyLib.DataSQL.reader[1].ToString(), int.Parse(MyLib.DataSQL.reader[0].ToString()));
                string[] s = { MyLib.DataSQL.reader[0].ToString(), MyLib.DataSQL.reader[1].ToString() };
                dataGridView1.Rows.Add(s);
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

            MyLib.DataSQL.request("INSERT INTO  motors ([name]) VALUES ( '" + tEmotor.Text.ToString() + "')");
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

            MotorLoad();
            imotor = -1;
            tEmotor.Text = "";

        }
        private void bDmotor_Click(object sender, EventArgs e)
        {//Удаление мотора
            if (tEmotor.Text.ToString() == "" || imotor == -1)
                return;
            // Есть ли машины и работы по данному мотору
            MyLib.DataSQL.requestRead("SELECT * FROM typejob, park where typejob.type=" + imotor + " or park.motor=" + imotor);
            if (MyLib.DataSQL.reader.Read())
            {//Если да, то выводим сообщение
                MessageBox.Show("В случае удаления мотора будут удалены все работы и машины связанные с этим мотором");
                DialogResult dialogResult = MessageBox.Show("Вы согласны?", "Согласие", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return;
                //Удаление всех данных связанных с ээтим моторм
                //== typejob
                MyLib.DataSQL.requestRead("SELECT id FROM typejob park where type=" + imotor);
                if (MyLib.DataSQL.reader.Read())
                    MyLib.DataSQL.request("DELETE FROM  typejob where type=" + imotor);
                //==  park
                MyLib.DataSQL.requestRead("SELECT num FROM park where motor=" + imotor);
                //int num = -1;
                //if (reader.Read())
                //{
                //    num = int.Parse(reader[0].ToString());
                //    request("DELETE FROM  park where motor=" + imotor);
                //}
                ////== job
                //requestRead("SELECT id FROM job where num=" + num);
                //if (reader.Read())
                //    request("DELETE FROM  job where num=" + num);

            }
            //== motors
            MyLib.DataSQL.request("DELETE FROM motors WHERE id=" + imotor);
            //==
            MotorLoad();//Обновление списка моторв
            dataGridView1.Rows.Clear();//Сброс списка работа по мотору
            imotor = -1;//Сброс индекса мотора
            tEmotor.Text = "";//Сброс названия мотора в текст боксе
        }

     

        private void bClose_Click(object sender, EventArgs e)
        {// закрыть окно
            Close();
        }

        private void bjob_Click(object sender, EventArgs e)
        {//Добавление работы над мотором
            if (tEjob.Text.ToString() == "" || typeJob == null || typeJob.ContainsKey(tEjob.Text.ToString()) )
                return;
            MyLib.DataSQL.request("INSERT INTO  typejob ([name],[type]) VALUES ( '" + tEjob.Text.ToString() + "',"+imotor+")");
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
            JobLoad();
            ijob = -1;
            tEjob.Text = "";
        }

        private void bDjob_Click(object sender, EventArgs e)
        {//Удаление работы
            if (tEjob.Text.ToString() == "" || ijob == -1)
                return;
            MyLib.DataSQL.request("DELETE FROM typejob WHERE id=" + ijob);
            JobLoad();
            ijob = -1;
            tEjob.Text = ""; 
        }
    }
}
