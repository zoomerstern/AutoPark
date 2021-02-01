using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using MyLib;

namespace AutoPark_Test_
{
    public partial class Add : System.Windows.Forms.Form
    {

        Dictionary<string, int> motor = new Dictionary<string, int>();
        
        public Add()
        {
            InitializeComponent();
            Insert();
            
        }
        void Insert() {

            motorBox.Items.Clear();
            
            MyLib.DataSQL.requestRead("SELECT * FROM motors ");
            while (MyLib.DataSQL.reader.Read())
            { //Запись в массив
                motor.Add(MyLib.DataSQL.reader[1].ToString(), int.Parse(MyLib.DataSQL.reader[0].ToString()));
                motorBox.Items.Add(MyLib.DataSQL.reader[1].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tBmark.Text.ToString() == "" || tBmodel.Text.ToString() == "" 
                || motorBox.Text.ToString() == "" )
            {
                MessageBox.Show("Заполненны не все поля");
                return;
            }
            Auto newAuro = new Auto(tBmark.Text.ToString(), tBmodel.Text.ToString(),
                                   motor[motorBox.SelectedItem.ToString()],
                                   motorBox.SelectedItem.ToString()
                                   );
            Program.auto.Add(newAuro);
            //Form.


            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
