using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using MyLib;

namespace AutoPark_Test_
{
    public partial class Add : System.Windows.Forms.Form
    {
        
        public Add()
        {
            InitializeComponent();
            Insert();
        }
        void Insert() {

            motorBox.Items.Clear();
            foreach (string motor in Program.typeMotor.Keys)
            { //Запись в массив   
                motorBox.Items.Add(motor);
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
             
            Program.auto.Add(
                    new Auto(tBmark.Text.ToString(), tBmodel.Text.ToString(),
                         Program.typeMotor[motorBox.SelectedItem.ToString()],
                                            motorBox.SelectedItem.ToString()
                                                                           ));
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
