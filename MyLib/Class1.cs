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
        public Motor motor = null;//мотор(по умолчанию нет)
        
        public Auto(int num, string mark, string model)
        {//Инициализация из бд
            this.num = num;
            this.mark = mark;
            this.model = model;
        }
        public Auto( string mark, string model, int id, string name)
        {//Создание новой машины
            this.mark = mark;
            this.model = model;
            motor = new Motor(id,  name);//инициализация мотора
            num=insert();
            DataSQL.reader.Close();
        }
        public int insert() {
        //Инсерт новой машины
            DataSQL.request( "INSERT INTO  park ([mark],[model],[motor]) VALUES ( '"
                                                    + mark + "','" + model + "'," + motor.id + ")");
            DataSQL.requestRead("SELECT MAX(num) from park");
            DataSQL.reader.Read();
            return int.Parse(DataSQL.reader[0].ToString());
        }
        public void delete()
        {//Удаление
            DataSQL.requestRead("select * FROM job WHERE num = " + num);
            if (DataSQL.reader.Read())
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
    }
    public class Motor 
    {
        public int id { get; set; }
        public string name { get; set; }
        List<Job> job = null;
        public Motor(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public void delete()
        {//Удаление
            
            //DataSQL.request("DELETE FROM job WHERE num=" + );
        }

    }
    public class Job
    {
        private string id { get; set; }
        private string name { get; set; }
        private string date { get; set; }
        public Job(string id, string name, string date) {
            this.id = id;
            this.name = name;
            this.date = date;
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
                requestRead("SELECT p.num, p.mark, p.model, m.id, m.name FROM park as p " +
                        "left join motors as m on p.motor=m.id ");
            while (reader.Read()) //Запись в массив
            {
                auto.Add(new Auto(int.Parse(reader[0].ToString()),
                                            reader[1].ToString(),
                                            reader[2].ToString()
                                  ));
                if(reader[3].ToString() != "")
                    auto.Last().motor = new Motor(int.Parse(reader[3].ToString()), reader[4].ToString());
            }
            reader.Close();
           
            for (int i = 0; i < auto.Count; i++)
            {

                requestRead("SELECT j.id, t.name, j.date from job as j " +
                            "inner join typejob as t on j.num=" + auto[i].num +
                                                      " and j.job=t.id ");
                List<Job> job = new List<Job>();
                while (reader.Read()) //Запись в массив
                {
                    job.Add(new Job(reader[0].ToString(),
                                   reader[1].ToString(),
                                   reader[2].ToString()));
                }
                reader.Close();
            }
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

            requestRead("SELECT distinct type FROM typejob" );          
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

