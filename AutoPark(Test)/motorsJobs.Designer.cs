namespace AutoPark_Test_
{
    partial class motorsJobs
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
            this.bClose = new System.Windows.Forms.Button();
            this.bjob = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tEjob = new System.Windows.Forms.TextBox();
            this.lEmark = new System.Windows.Forms.Label();
            this.bEjob = new System.Windows.Forms.Button();
            this.bDjob = new System.Windows.Forms.Button();
            this.bDmotor = new System.Windows.Forms.Button();
            this.bEmotor = new System.Windows.Forms.Button();
            this.tEmotor = new System.Windows.Forms.TextBox();
            this.bmotor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(573, 4);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 24;
            this.bClose.Text = "Закрыть";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bjob
            // 
            this.bjob.Location = new System.Drawing.Point(355, 65);
            this.bjob.Name = "bjob";
            this.bjob.Size = new System.Drawing.Size(75, 23);
            this.bjob.TabIndex = 23;
            this.bjob.Text = "Добавить";
            this.bjob.UseVisualStyleBackColor = true;
            this.bjob.Click += new System.EventHandler(this.bjob_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Двигатель: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.job});
            this.dataGridView1.Location = new System.Drawing.Point(355, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(293, 150);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // job
            // 
            this.job.FillWeight = 150F;
            this.job.HeaderText = "job";
            this.job.Name = "job";
            this.job.Width = 200;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView2.Location = new System.Drawing.Point(11, 94);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(293, 150);
            this.dataGridView2.TabIndex = 28;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
            this.dataGridViewTextBoxColumn2.HeaderText = "motor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // tEjob
            // 
            this.tEjob.Location = new System.Drawing.Point(355, 33);
            this.tEjob.Name = "tEjob";
            this.tEjob.Size = new System.Drawing.Size(125, 20);
            this.tEjob.TabIndex = 30;
            // 
            // lEmark
            // 
            this.lEmark.AutoSize = true;
            this.lEmark.Location = new System.Drawing.Point(352, 14);
            this.lEmark.Name = "lEmark";
            this.lEmark.Size = new System.Drawing.Size(46, 13);
            this.lEmark.TabIndex = 29;
            this.lEmark.Text = "Работа:";
            // 
            // bEjob
            // 
            this.bEjob.Location = new System.Drawing.Point(462, 65);
            this.bEjob.Name = "bEjob";
            this.bEjob.Size = new System.Drawing.Size(75, 23);
            this.bEjob.TabIndex = 31;
            this.bEjob.Text = "Изменить";
            this.bEjob.UseVisualStyleBackColor = true;
            this.bEjob.Click += new System.EventHandler(this.bEjob_Click);
            // 
            // bDjob
            // 
            this.bDjob.Location = new System.Drawing.Point(571, 65);
            this.bDjob.Name = "bDjob";
            this.bDjob.Size = new System.Drawing.Size(75, 23);
            this.bDjob.TabIndex = 32;
            this.bDjob.Text = "Удалить";
            this.bDjob.UseVisualStyleBackColor = true;
            this.bDjob.Click += new System.EventHandler(this.bDjob_Click);
            // 
            // bDmotor
            // 
            this.bDmotor.Location = new System.Drawing.Point(229, 65);
            this.bDmotor.Name = "bDmotor";
            this.bDmotor.Size = new System.Drawing.Size(75, 23);
            this.bDmotor.TabIndex = 36;
            this.bDmotor.Text = "Удалить";
            this.bDmotor.UseVisualStyleBackColor = true;
            this.bDmotor.Click += new System.EventHandler(this.bDmotor_Click);
            // 
            // bEmotor
            // 
            this.bEmotor.Location = new System.Drawing.Point(119, 65);
            this.bEmotor.Name = "bEmotor";
            this.bEmotor.Size = new System.Drawing.Size(75, 23);
            this.bEmotor.TabIndex = 35;
            this.bEmotor.Text = "Изменить";
            this.bEmotor.UseVisualStyleBackColor = true;
            this.bEmotor.Click += new System.EventHandler(this.BEmotor_Click);
            // 
            // tEmotor
            // 
            this.tEmotor.Location = new System.Drawing.Point(11, 33);
            this.tEmotor.Name = "tEmotor";
            this.tEmotor.Size = new System.Drawing.Size(125, 20);
            this.tEmotor.TabIndex = 34;
            // 
            // bmotor
            // 
            this.bmotor.Location = new System.Drawing.Point(11, 65);
            this.bmotor.Name = "bmotor";
            this.bmotor.Size = new System.Drawing.Size(75, 23);
            this.bmotor.TabIndex = 37;
            this.bmotor.Text = "Добавить";
            this.bmotor.UseVisualStyleBackColor = true;
            this.bmotor.Click += new System.EventHandler(this.Bmotor_Click);
            // 
            // motorsJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 258);
            this.Controls.Add(this.bmotor);
            this.Controls.Add(this.bDmotor);
            this.Controls.Add(this.bEmotor);
            this.Controls.Add(this.tEmotor);
            this.Controls.Add(this.bDjob);
            this.Controls.Add(this.bEjob);
            this.Controls.Add(this.tEjob);
            this.Controls.Add(this.lEmark);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bjob);
            this.Controls.Add(this.label2);
            this.Name = "motorsJobs";
            this.Text = "Моторы и работы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bjob;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox tEjob;
        private System.Windows.Forms.Label lEmark;
        private System.Windows.Forms.Button bEjob;
        private System.Windows.Forms.Button bDjob;
        private System.Windows.Forms.Button bDmotor;
        private System.Windows.Forms.Button bEmotor;
        private System.Windows.Forms.TextBox tEmotor;
        private System.Windows.Forms.Button bmotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn job;
    }
}