using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using System.Linq;

namespace MyLib
{

    public class Auto
    {//Машины
        public int num { get; set; }//номер
        public string mark { get; set; }//марка
        public string model { get; set; }//модель
        public Motor motor=null;//мотор(по умолчанию нет)
        
        public Auto(int num, string mark, string model, Motor motor)
        {//Инициализация из бд
            this.num = num;
            this.mark = mark;
            this.model = model;
            this.motor = motor;
        }
        public Auto( string mark, string model, int id, string name)
        {//Создание новой машины
            this.mark = mark;
            this.model = model;
            motor = new Motor(id,  name);//инициализация мотора
            num=insert();
        }
        private int insert() {
        //Инсерт новой машины
            DataSQL.request( "INSERT INTO  park ([mark],[model],[motor]) VALUES ( '"
                                                    + mark + "','" + model + "'," + motor.id + ")");
            DataSQL.requestRead("SELECT MAX(num) from park");
            DataSQL.reader.Read();
            int result = int.Parse(DataSQL.reader[0].ToString());
            DataSQL.reader.Close();
            return result;
        }
        public void delete()
        {//Удаление
            if (motor.job.Count > 0)
                DataSQL.request("DELETE FROM job WHERE num=" + num);
            //Удаляем машину
            DataSQL.request("DELETE FROM park WHERE num=" + num);
        }
        public void update(string model, string mark, int idM, string motor)
        {
            //Вносим изменения
            this.model = model;
            this.mark = mark;
            this.motor = new Motor(idM, motor);
            MyLib.DataSQL.request("UPDATE park SET model = '" + model +
                "', mark='" + mark + "', motor=" + idM + " WHERE num=" + num);
        }
        public void deleteMotor()
        {
            if (motor.job.Count > 0) {
                motor.job.Clear();  
                DataSQL.request("DELETE FROM  job where num=" + num);
            }
            motor = null;
        }
        public void motorJobInset() {
            motor.jobInsert(num);
        }
        public void motorJobAdd(string typeJob, string dateTime)
        {
            motor.jobAdd(num, typeJob, dateTime);
        }
    }
    public class Motor
    {
        public int id { get; set; }//Ид мотора
        public string name { get; set; }//Имя мотора
        public List<Job> job =  new List<Job>();//Список работ над мотором
        public Motor(int id, string name)
        {//Обновление
            this.id = id;
            this.name = name;
        }
        public void jobInsert(int num) {
            //Инициализация работ
            DataSQL.requestRead("SELECT j.id, t.name, j.date FROM job as j inner join typejob as t on j.job=t.id and j.num="+num);
            job.Clear();
            while (DataSQL.reader.Read()) //Запись в массив
            {
                job.Add(new Job(DataSQL.reader[0].ToString(),
                                DataSQL.reader[1].ToString(),
                                DataSQL.reader[2].ToString()));
            }
            DataSQL.reader.Close();
        }
        public void jobAdd(int num, string typeJob, string dateTime) {
            DataSQL.request("INSERT INTO  job ([num],[job],[date]) VALUES ( "
                                                    + num + ",'" + typeJob + "','" + dateTime + "')");
        }
        public void jobDelete(int id) {
            DataSQL.request("DELETE FROM job WHERE id=" + id);
        }
    }
    public class Job
    {
        private string id { get; set; }
        private string name { get; set; }
        private string date { get; set; }
        public Job(string id, string name, string date) {
            //добавление работы
            this.id = id;
            this.name = name;
            this.date = date;
        }
        public string[] getJob() { 
            //вывод работы
            return new string[] { id, name, date };
        }
    }

    public  class DataSQL
    {
        public static SQLiteConnection myConnection;
        public static SQLiteCommand command;//Переменные для соединения
        public static SQLiteDataReader reader;//Запись

        public static List<Auto> LoadAuto()
        {
            List<Auto> auto = new List<Auto>();
                requestRead("SELECT p.num, p.mark, p.model, m.id, m.name FROM park as p left join motors as m on p.motor=m.id ");
            while (reader.Read()) //Запись в массив
            {
                auto.Add(new Auto(int.Parse(reader[0].ToString()),
                                            reader[1].ToString(),
                                            reader[2].ToString(),
                                            reader[3].ToString() != "" ? new Motor(int.Parse(reader[3].ToString()), reader[4].ToString() ) : null 
                                  ));
            }
            reader.Close();

            return auto;
        }
        public static Dictionary<string, int> LoadMotor() {

            Dictionary<string, int> dict = new Dictionary<string, int>();
            requestRead("SELECT id, name FROM motors ");
            while (reader.Read()) //Запись данных об моторах
            {
                dict.Add(reader[1].ToString(), int.Parse(reader[0].ToString()));// запоминаем ид и название моторв
            }
            reader.Close();
            return dict;
        }
        public static Dictionary<int, Dictionary<string, int>> LoadTypeJob()
        {
            Dictionary<int, Dictionary<string, int>> dict = new Dictionary<int, Dictionary<string, int>>();
            List<int> type = new List<int>();

            requestRead("SELECT id FROM motors" );          
            while (reader.Read()) //Запись данных об видах работ на данный двигатель
            {
                type.Add(int.Parse(reader[0].ToString()));
            }
            reader.Close();

            foreach (int i in type) //Запись данных об видах работ на данный двигатель
            {
                dict.Add(i, new Dictionary<string, int>());
                requestRead("SELECT name, id FROM typejob where type=" + i);
                for (int k=0;  reader.Read();k++) //Запись данных об видах работ на данный двигатель
                {
                    dict[i].Add(reader[0].ToString(), int.Parse(reader[1].ToString()) );
                }
                reader.Close();
            }
           

            return dict;
        }
        public static void request(string query )
        {
            command = new SQLiteCommand(query, myConnection);
            command.ExecuteReader();
        }
        public static void requestRead(string query)
        {
            command = new SQLiteCommand(query, myConnection);
            reader = command.ExecuteReader();
        }

    }
}

