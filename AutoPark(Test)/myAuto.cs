using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using MyLib;
namespace AutoPark_Test_
{
    public partial class myAuto : System.Windows.Forms.Form
    {

        int motor=-1; //индекс мотора
        int number;// Номер машины
        string motorS="";// Имя мотора
       
        
        public myAuto(int number)
        {//экземпляр для добавления нового товара
            InitializeComponent();
            this.number = number;
            if(Program.auto[number].motor != null)  //Если у мотора у машины есть запоминаем его имя
                motorS = Program.auto[number].motor.name;
            //Выводим данные о машине
            tMark.Text = Program.auto[number].mark;//Марка
            tModel.Text = Program.auto[number].model;//Модель
            dateTime.Format = DateTimePickerFormat.Custom;
            dateTime.CustomFormat = "yyyy.MM.dd HH:mm";//Форматы даты работы
            DataLoad();//Загружаем данные об машине
        }

        private void DataLoad()//Вывод данных
        {
            //Вывод моторов
            motorBox.Items.Clear();//очищение списка моторов
            int i = 0;
            foreach (string motor in Program.typeMotor.Keys) //Запись данных об моторах
            {
                motorBox.Items.Add(motor);
                if (Program.auto[number].motor != null && Program.typeMotor[motorS] == Program.typeMotor[motor])
                    motorBox.SelectedIndex = i;//Ставим текущий индекс мотора
                i++;
            }
            TypeJobData();
            return;
        }
        private void TypeJobData() {
            //Вывод типо работ мотора
            jobsBox.SelectedItem= null;
            jobsBox.Items.Clear();//очистка списка работ
            if (Program.auto[number].motor != null)
            {
                foreach (string name in Program.typeJob[Program.auto[number].motor.id].Keys)
                    jobsBox.Items.Add(name);
                JobData();//Вывод истории работ
            }
            return;
        }
        private void JobData() {
            //Вывод данных о работах
            dataGridView1.Rows.Clear();
            Program.auto[number].motorJobInset();
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
            Program.auto[number].motorJobAdd((Program.typeJob[Program.auto[number].motor.id][jobsBox.Text.ToString()]).ToString()
                                             ,dateTime.Value.ToString("dd.MM.yyyy HH:mm"));
            JobData();//Обнавляем каталог
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void update_Click(object sender, EventArgs e)
        {//обновление информации о машине
            if (tModel.Text.ToString()== Program.auto[number].model  &&
                motorBox.SelectedItem.ToString() == motorS &&
                tMark.Text.ToString() == Program.auto[number].mark)//Проверка на заполнение полей
                return;
            if (motorBox.SelectedItem.ToString() != motorS )
            {// если изменить мотор
                //будт удалены все работы с этим моторм
                MessageBox.Show("В случае замены мотора будут удалены все работы с машиной, т.к. они ориентированны на другой тип двигателя.");
                DialogResult dialogResult = MessageBox.Show("Вы согласны?", "Согласие", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)//если согласны
                    Program.auto[number].deleteMotor();
                else
                    motorBox.SelectedIndex = motor;//Изменение позиции в чекбокс
                
                if(motorBox.SelectedItem.ToString() != motorS)
                    motorS =motorBox.SelectedItem.ToString();   
            }
            Program.auto[number].update(tModel.Text.ToString(), tMark.Text.ToString(), 
                Program.typeMotor[motorS], motorS);
            TypeJobData();//обновляем данные
            MessageBox.Show("Изменения внесены");
        }

        private void JobDelete_Click(object sender, EventArgs e)
        {
            //Удаление Работы
            if (dataGridView1.RowCount <2 || dataGridView1[0, dataGridView1.CurrentRow.Index].Value== null) //Проверка на нажатие
                return;
            //Определяем модель и его таблицу
            int id = int.Parse(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            //Удаляем в таблице
            Program.auto[number].motor.jobDelete(id);
            //Вывод работ
            JobData();
        }
    }
}
