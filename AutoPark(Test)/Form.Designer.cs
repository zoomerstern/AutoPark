namespace AutoPark_Test_
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.editJobMotor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 24;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.mark,
            this.model,
            this.motor});
            this.dataGridView1.Location = new System.Drawing.Point(12, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(393, 288);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // num
            // 
            this.num.HeaderText = "num";
            this.num.Name = "num";
            this.num.Width = 50;
            // 
            // mark
            // 
            this.mark.HeaderText = "model";
            this.mark.Name = "mark";
            // 
            // model
            // 
            this.model.HeaderText = "name";
            this.model.Name = "model";
            // 
            // motor
            // 
            this.motor.HeaderText = "motor";
            this.motor.Name = "motor";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(12, 43);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(115, 35);
            this.add.TabIndex = 27;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.Add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(290, 43);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(115, 35);
            this.delete.TabIndex = 28;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(152, 43);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(115, 35);
            this.insert.TabIndex = 29;
            this.insert.Text = "Выбрать";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(343, 2);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(63, 20);
            this.close.TabIndex = 30;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // editJobMotor
            // 
            this.editJobMotor.Location = new System.Drawing.Point(152, 2);
            this.editJobMotor.Name = "editJobMotor";
            this.editJobMotor.Size = new System.Drawing.Size(115, 35);
            this.editJobMotor.TabIndex = 31;
            this.editJobMotor.Text = "Моторы и работы";
            this.editJobMotor.UseVisualStyleBackColor = true;
            this.editJobMotor.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 398);
            this.Controls.Add(this.editJobMotor);
            this.Controls.Add(this.close);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form";
            this.Text = "АвтоПарк";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn mark;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn motor;
        private System.Windows.Forms.Button editJobMotor;
    }
}

