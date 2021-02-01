namespace AutoPark_Test_
{
    partial class myAuto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lmark = new System.Windows.Forms.Label();
            this.lmodel = new System.Windows.Forms.Label();
            this.lmotor = new System.Windows.Forms.Label();
            this.motorBox = new System.Windows.Forms.ComboBox();
            this.tModel = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.ljobs = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.jobAdd = new System.Windows.Forms.Button();
            this.jobsBox = new System.Windows.Forms.ComboBox();
            this.jobDelete = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.tMark = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.jobs,
            this.date});
            this.dataGridView1.Location = new System.Drawing.Point(43, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(494, 278);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // jobs
            // 
            this.jobs.HeaderText = "jobs";
            this.jobs.Name = "jobs";
            this.jobs.Width = 200;
            // 
            // date
            // 
            this.date.HeaderText = "date";
            this.date.Name = "date";
            this.date.Width = 200;
            // 
            // lmark
            // 
            this.lmark.AutoSize = true;
            this.lmark.Location = new System.Drawing.Point(40, 17);
            this.lmark.Name = "lmark";
            this.lmark.Size = new System.Drawing.Size(46, 13);
            this.lmark.TabIndex = 1;
            this.lmark.Text = "Марка: ";
            // 
            // lmodel
            // 
            this.lmodel.AutoSize = true;
            this.lmodel.Location = new System.Drawing.Point(198, 17);
            this.lmodel.Name = "lmodel";
            this.lmodel.Size = new System.Drawing.Size(52, 13);
            this.lmodel.TabIndex = 2;
            this.lmodel.Text = "Модель: ";
            // 
            // lmotor
            // 
            this.lmotor.AutoSize = true;
            this.lmotor.Location = new System.Drawing.Point(352, 17);
            this.lmotor.Name = "lmotor";
            this.lmotor.Size = new System.Drawing.Size(87, 13);
            this.lmotor.TabIndex = 3;
            this.lmotor.Text = "Тип двигателя: ";
            // 
            // motorBox
            // 
            this.motorBox.FormattingEnabled = true;
            this.motorBox.Location = new System.Drawing.Point(445, 14);
            this.motorBox.Name = "motorBox";
            this.motorBox.Size = new System.Drawing.Size(100, 21);
            this.motorBox.TabIndex = 5;
            // 
            // tModel
            // 
            this.tModel.Location = new System.Drawing.Point(246, 15);
            this.tModel.Name = "tModel";
            this.tModel.Size = new System.Drawing.Size(100, 20);
            this.tModel.TabIndex = 6;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(556, 5);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(106, 37);
            this.update.TabIndex = 7;
            this.update.Text = "Изменить характеристики";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // ljobs
            // 
            this.ljobs.AutoSize = true;
            this.ljobs.Location = new System.Drawing.Point(553, 118);
            this.ljobs.Name = "ljobs";
            this.ljobs.Size = new System.Drawing.Size(46, 13);
            this.ljobs.TabIndex = 9;
            this.ljobs.Text = "Работа:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Дата:";
            // 
            // jobAdd
            // 
            this.jobAdd.Location = new System.Drawing.Point(556, 55);
            this.jobAdd.Name = "jobAdd";
            this.jobAdd.Size = new System.Drawing.Size(106, 22);
            this.jobAdd.TabIndex = 15;
            this.jobAdd.Text = "Добавить рабоу";
            this.jobAdd.UseVisualStyleBackColor = true;
            this.jobAdd.Click += new System.EventHandler(this.JobAdd_Click);
            // 
            // jobsBox
            // 
            this.jobsBox.FormattingEnabled = true;
            this.jobsBox.Location = new System.Drawing.Point(598, 115);
            this.jobsBox.Name = "jobsBox";
            this.jobsBox.Size = new System.Drawing.Size(122, 21);
            this.jobsBox.TabIndex = 17;
            // 
            // jobDelete
            // 
            this.jobDelete.Location = new System.Drawing.Point(556, 87);
            this.jobDelete.Name = "jobDelete";
            this.jobDelete.Size = new System.Drawing.Size(106, 22);
            this.jobDelete.TabIndex = 19;
            this.jobDelete.Text = "Удалить рабоу";
            this.jobDelete.UseVisualStyleBackColor = true;
            this.jobDelete.Click += new System.EventHandler(this.JobDelete_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(732, 5);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 21;
            this.Close.Text = "Закрыть";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // dateTime
            // 
            this.dateTime.CustomFormat = "MMMMdd, yyyy | hh:mm";
            this.dateTime.Location = new System.Drawing.Point(598, 143);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(179, 20);
            this.dateTime.TabIndex = 22;
            // 
            // tMark
            // 
            this.tMark.Location = new System.Drawing.Point(82, 15);
            this.tMark.Name = "tMark";
            this.tMark.Size = new System.Drawing.Size(100, 20);
            this.tMark.TabIndex = 23;
            // 
            // Auto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 450);
            this.Controls.Add(this.tMark);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.jobDelete);
            this.Controls.Add(this.jobsBox);
            this.Controls.Add(this.jobAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ljobs);
            this.Controls.Add(this.update);
            this.Controls.Add(this.tModel);
            this.Controls.Add(this.motorBox);
            this.Controls.Add(this.lmotor);
            this.Controls.Add(this.lmodel);
            this.Controls.Add(this.lmark);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Auto";
            this.Text = "Машина и работы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lmark;
        private System.Windows.Forms.Label lmodel;
        private System.Windows.Forms.Label lmotor;
        private System.Windows.Forms.ComboBox motorBox;
        private System.Windows.Forms.TextBox tModel;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label ljobs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button jobAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobs;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.ComboBox jobsBox;
        private System.Windows.Forms.Button jobDelete;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.TextBox tMark;
    }
}