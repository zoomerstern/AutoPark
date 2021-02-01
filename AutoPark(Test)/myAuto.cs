using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using MyLib;
namespace AutoPark_Test_
{
    public partial class myAuto : System.Windows.Forms.Form
    {

        int motor=-1; int number;
        string mark, model, motorS;
        Dictionary<string, int> typejob;//Спиосок работ
       
        
        public myAuto(int number)
        {//экземпляр для добавления нового товара
            InitializeComponent();
            motorS = Program.auto[number].motor.name;
            //Запоминаем и выводим данные о машине
            tMark.Text = Program.auto[number].mark;
            tModel.Text = Program.auto[number].model;
            dateTime.Format = DateTimePickerFormat.Custom;
            dateTime.CustomFormat = "yyyy.MM.dd HH:mm"; //форматы даты для работ
            DataLoad();//Загружаем данные об машине
        }

        private void DataLoad()//Вывод данных
        {
            typejob = new Dictionary<string, int>();

            JobData();//Вывод истории работ
            motorBox.Items.Clear();//очищение списка моторов
            int i = 0;
            foreach (string motor in Program.typeMotor.Keys) //Запись данных об моторах
            {
                motorBox.Items.Add(motor);
                if (Program.typeMotor[motorS] == Program.typeMotor[motor]){
                    motorBox.SelectedIndex = i;//Ставим текущий индекс мотора
                }
                i++;
            }
            
            mark =tMark.Text;//запоминаем название марки
            MyLib.DataSQL.requestRead("SELECT id, name FROM typejob where type=" + Program.auto[number].motor.id);
            jobsBox.Items.Clear();//очистка списка работ
            while (MyLib.DataSQL.reader.Read()) //Запись данных об видах работ на данный двигатель
            {
                typejob.Add(MyLib.DataSQL.reader[1].ToString(), int.Parse(MyLib.DataSQL.reader[0].ToString()));
                jobsBox.Items.Add(MyLib.DataSQL.reader[1].ToString());
            }
            return;
        }

        private void JobData() {
            //загрузка истории работ над машиной
            List<string[]> data = new List<string[]>();// Массив для данных каталога
            MyLib.DataSQL.requestRead("SELECT * FROM job where num=" + number);//Вывод списка работ по индекусу машины
            while (MyLib.DataSQL.reader.Read()) //Запись в массив
            {
                //Запись данных об работах наж машиной
                data.Add(new string[3]);
                data[data.Count - 1][0] = MyLib.DataSQL.reader[0].ToString();
                data[data.Count - 1][1] = MyLib.DataSQL.reader[2].ToString();
                data[data.Count - 1][2] = MyLib.DataSQL.reader[3].ToString();
            }

            MyLib.DataSQL.reader.Close();
            dataGridView1.Rows.Clear();//Очистка окна каталога
            foreach (string[] s in data)
            {//Запись в  окно каталога
                MyLib.DataSQL.requestRead( "SELECT name FROM typejob WHERE id=" + s[1]);
                MyLib.DataSQL.reader.Read();
                s[1] = MyLib.DataSQL.reader[0].ToString(); ;//Выводим название типа работы
                dataGridView1.Rows.Add(s);
                MyLib.DataSQL.reader.Close();
            }

        }

    

        private void JobAdd_Click(object sender, EventArgs e)
        {//Добавлеие работы
            if ( jobsBox.Text.ToString() == "")
            {
                MessageBox.Show("Заполненны не все полей");
                return;
            }//Проверка на пустые поля
            MyLib.DataSQL.request("INSERT INTO  job ([num],[job],[date]) VALUES ( "
                                                    + number + ",'" + typejob[jobsBox.Text.ToString()] + "','" + dateTime.Value.ToString("dd.MM.yyyy HH:mm") + "')");
            JobData();//Обнавляем каталог
        }

       

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {//обновление информации о машине
            if (tModel.Text.ToString()== model  &&
                motorBox.SelectedItem.ToString() == motorS &&
                tMark.Text.ToString() == mark)//Проверка на заполнение полей
                return;

            if (motorBox.SelectedItem.ToString() != motorS )
            {// если изменить мотор
                if (dataGridView1.Rows.Count > 1)
                {//будт удалены все работы с этим моторм
                    MessageBox.Show("В случае замены мотора будут удалены все работы с машиной, т.к. они ориентированны на другой тип двигателя.");
                    DialogResult dialogResult = MessageBox.Show("Вы согласны?", "Согласие", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)//если согласны
                        MyLib.DataSQL.request("DELETE FROM job WHERE num=" + number);//удаляются работы
                    else
                        motorBox.SelectedIndex = motor;
                }
                if(motorBox.SelectedItem.ToString() != motorS)
                    motorS =motorBox.SelectedItem.ToString();
               
                DataLoad();//обновляем данные
            }
            MessageBox.Show("Изменения внесены");
            mark = tMark.Text.ToString();
            //Вносим изменения
            MyLib.DataSQL.request("UPDATE park SET model = '" + tModel.Text.ToString() + 
                "', mark='"+ tMark.Text.ToString() +
                "', motor="+Program.typeMotor[motorBox.SelectedItem.ToString()] +" WHERE num=" + number);  
        }

        private void JobDelete_Click(object sender, EventArgs e)
        {
            //Удаление товара
            if (dataGridView1.RowCount <2 || dataGridView1[0, dataGridView1.CurrentRow.Index].Value== null) //Проверка на нажатие
                return;
            //Определяем модель и его таблицу
            int id = int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            //Удаляем в таблице
            MyLib.DataSQL.request("DELETE FROM job WHERE id=" + id);
            JobData();
        }
    }
}
