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
        string motorS="";
       
        
        public myAuto(int number)
        {//экземпляр для добавления нового товара
            InitializeComponent();
            this.number = number;
            if(Program.auto[number].motor != null)  
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

            motorBox.Items.Clear();//очищение списка моторов
            int i = 0;
            foreach (string motor in Program.typeMotor.Keys) //Запись данных об моторах
            {
                motorBox.Items.Add(motor);
                if (Program.auto[number].motor != null && Program.typeMotor[motorS] == Program.typeMotor[motor]){
                    motorBox.SelectedIndex = i;//Ставим текущий индекс мотора
                }
                i++;
            }
            if (Program.auto[number].motor != null)
            {  
                jobsBox.Items.Clear();//очистка списка работ
                foreach(string name in Program.typeJob[Program.auto[number].motor.id].Keys)
                    jobsBox.Items.Add(name);
                JobData();//Вывод истории работ
            }
            return;
        }

        private void JobData() {
            Program.auto[number].motor.jobInsert(Program.auto[number].num);
            foreach (Job job in Program.auto[number].motor.job) {
                dataGridView1.Rows.Add(job.getJob());
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
                                                    + number + ",'" + Program.typeJob[Program.auto[number].motor.id][jobsBox.Text.ToString()] + "','" + dateTime.Value.ToString("dd.MM.yyyy HH:mm") + "')");
            JobData();//Обнавляем каталог
        }

       

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {//обновление информации о машине
            if (tModel.Text.ToString()== Program.auto[number].model  &&
                motorBox.SelectedItem.ToString() == motorS &&
                tMark.Text.ToString() == Program.auto[number].mark)//Проверка на заполнение полей
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
            Program.auto[number].update(tModel.Text.ToString(), tMark.Text.ToString(), 
                Program.typeMotor[motorBox.SelectedItem.ToString()], motorBox.SelectedItem.ToString());
            
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
