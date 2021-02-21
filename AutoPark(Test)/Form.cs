using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using MyLib;

namespace AutoPark_Test_
{

    public partial class Form : System.Windows.Forms.Form
    {
        public int number;
        public Form()
        {
            InitializeComponent();
            MyLib.DataSQL.myConnection = new SQLiteConnection(@"Data Source=Park2.db;");
            //открываем соединение с БД
            MyLib.DataSQL.myConnection.Open();
            DataLoad();// Загрузка каталога машин
        }

       
        private void DataLoad()
        {//обновелние данных
            //Program.auto.Clear();//Обновление списка машин
            Program.auto = DataSQL.LoadAuto();//Новый спис
            Program.typeMotor = DataSQL.LoadMotor();//Список моторов
            Program.typeJob = DataSQL.LoadTypeJob();//Список работ
            GridLoad();
        }
        private void GridLoad() {
            dataGridView1.Rows.Clear();//Отчистка таблицы
            for (int i = 0; i < Program.auto.Count; i++)
            {
                dataGridView1.Rows.Add(
                    new string[4] { Program.auto[i].num.ToString(), Program.auto[i].mark, Program.auto[i].model,
                                    Program.auto[i].motor == null ? "отсутвует" : Program.auto[i].motor.name });
            }
        }

        
        private void Inform()
        {//Вывод данных о машине          
            if (dataGridView1[0, dataGridView1.CurrentRow.Index].Value == null) //Проверка на нажатие
                return;
            //И выделение необходимых элементов
            number =  dataGridView1.CurrentRow.Index;//модель
            //В форму для редактирования переносимм данные товара
            myAuto frm = new myAuto(number);
            if (frm.Enabled != false)
                frm.ShowDialog();
            GridLoad();
            return;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Inform();//Запрос на информацию о товаре      
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            Inform();
        }

        private void Add_Click(object sender, EventArgs e)
        {//Добавлние машины
            Add frm = new Add();
            frm.Owner = this;
            //if (frm.Enabled != false)
                frm.ShowDialog();
            GridLoad();//обновляем каталог
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //Удаление машины
            if (dataGridView1.RowCount<2 || dataGridView1[0, dataGridView1.CurrentRow.Index].Value == null) //Проверка на нажатие
                return;
            //Определяем модель и его таблицу
            int number = dataGridView1.CurrentRow.Index;//модель
            //Удаляем в работы машины
            Program.auto[number].delete();
            Program.auto.Remove(Program.auto[number]);
            GridLoad();
            MessageBox.Show("Инфомация о машине удалена!");
        }

        private void Edit_Click(object sender, EventArgs e)
        {//Вывод окна "моторы и работы"
            motorsJobs frm = new motorsJobs();
            //if (frm.Enabled != false)
                frm.ShowDialog();
            DataLoad();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            MyLib.DataSQL.myConnection.Close();
            Close();
        }
    }
}
