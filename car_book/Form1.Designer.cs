namespace car_book
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.car_name = new System.Windows.Forms.TextBox();
            this.car_year = new System.Windows.Forms.TextBox();
            this.car_engine = new System.Windows.Forms.TextBox();
            this.car_door = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.data_base = new System.Windows.Forms.DataGridView();
            this.ip = new System.Windows.Forms.TextBox();
            this.port_out = new System.Windows.Forms.TextBox();
            this.port_in = new System.Windows.Forms.TextBox();
            this.svr_run = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fix = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.log_rec_size = new System.Windows.Forms.ToolStripStatusLabel();
            this.log = new System.Windows.Forms.ToolStripStatusLabel();
            this.c_data = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_base)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // car_name
            // 
            this.car_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.car_name.Location = new System.Drawing.Point(81, 71);
            this.car_name.MinimumSize = new System.Drawing.Size(216, 40);
            this.car_name.Name = "car_name";
            this.car_name.Size = new System.Drawing.Size(270, 49);
            this.car_name.TabIndex = 0;
            this.car_name.Text = "Nissan";
            this.car_name.TextChanged += new System.EventHandler(this.car_name_TextChanged);
            // 
            // car_year
            // 
            this.car_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.car_year.Location = new System.Drawing.Point(79, 162);
            this.car_year.MinimumSize = new System.Drawing.Size(216, 40);
            this.car_year.Name = "car_year";
            this.car_year.Size = new System.Drawing.Size(270, 49);
            this.car_year.TabIndex = 1;
            this.car_year.Text = "2008";
            this.car_year.TextChanged += new System.EventHandler(this.car_year_TextChanged);
            // 
            // car_engine
            // 
            this.car_engine.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.car_engine.Location = new System.Drawing.Point(79, 248);
            this.car_engine.MinimumSize = new System.Drawing.Size(216, 40);
            this.car_engine.Name = "car_engine";
            this.car_engine.Size = new System.Drawing.Size(270, 49);
            this.car_engine.TabIndex = 2;
            this.car_engine.Text = "1,6";
            this.car_engine.TextChanged += new System.EventHandler(this.car_tank_TextChanged);
            // 
            // car_door
            // 
            this.car_door.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.car_door.Location = new System.Drawing.Point(79, 332);
            this.car_door.MinimumSize = new System.Drawing.Size(216, 40);
            this.car_door.Name = "car_door";
            this.car_door.Size = new System.Drawing.Size(270, 49);
            this.car_door.TabIndex = 3;
            this.car_door.Text = "-";
            this.car_door.TextChanged += new System.EventHandler(this.car_door_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(81, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Марка Авто";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(79, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Год выпуска";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(79, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Объем двигателя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(79, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Число дверей";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(81, 404);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(270, 60);
            this.add.TabIndex = 8;
            this.add.Text = "Дабавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(84, 470);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(270, 60);
            this.delete.TabIndex = 9;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(86, 536);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(270, 60);
            this.load.TabIndex = 10;
            this.load.Text = "Загрузить XML";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(86, 602);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(270, 60);
            this.save.TabIndex = 11;
            this.save.Text = "Сохранить XML";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // data_base
            // 
            this.data_base.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_base.DefaultCellStyle = dataGridViewCellStyle1;
            this.data_base.Location = new System.Drawing.Point(381, 71);
            this.data_base.MultiSelect = false;
            this.data_base.Name = "data_base";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_base.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_base.RowHeadersWidth = 82;
            this.data_base.RowTemplate.Height = 33;
            this.data_base.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_base.Size = new System.Drawing.Size(912, 595);
            this.data_base.TabIndex = 12;
            // 
            // ip
            // 
            this.ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ip.Location = new System.Drawing.Point(1320, 91);
            this.ip.MinimumSize = new System.Drawing.Size(216, 40);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(216, 44);
            this.ip.TabIndex = 13;
            this.ip.Text = "127.0.0.1";
            // 
            // port_out
            // 
            this.port_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.port_out.Location = new System.Drawing.Point(1320, 182);
            this.port_out.MinimumSize = new System.Drawing.Size(216, 40);
            this.port_out.Name = "port_out";
            this.port_out.Size = new System.Drawing.Size(216, 44);
            this.port_out.TabIndex = 14;
            this.port_out.Text = "3000";
            // 
            // port_in
            // 
            this.port_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.port_in.Location = new System.Drawing.Point(1320, 268);
            this.port_in.MinimumSize = new System.Drawing.Size(216, 40);
            this.port_in.Name = "port_in";
            this.port_in.Size = new System.Drawing.Size(216, 44);
            this.port_in.TabIndex = 15;
            this.port_in.Text = "3002";
            // 
            // svr_run
            // 
            this.svr_run.Location = new System.Drawing.Point(1320, 324);
            this.svr_run.Name = "svr_run";
            this.svr_run.Size = new System.Drawing.Size(216, 62);
            this.svr_run.TabIndex = 16;
            this.svr_run.Text = "Server_Run";
            this.svr_run.UseVisualStyleBackColor = true;
            this.svr_run.Click += new System.EventHandler(this.svr_run_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(381, 669);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(671, 55);
            this.clear.TabIndex = 17;
            this.clear.Text = "Очистить базу";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1363, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Адрес клиента";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(1376, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Порт клиента";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(1375, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Порт сервера";
            // 
            // fix
            // 
            this.fix.AutoSize = true;
            this.fix.Location = new System.Drawing.Point(1320, 148);
            this.fix.Name = "fix";
            this.fix.Size = new System.Drawing.Size(28, 27);
            this.fix.TabIndex = 21;
            this.fix.UseVisualStyleBackColor = true;
            this.fix.CheckedChanged += new System.EventHandler(this.fix_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.log_rec_size,
            this.log});
            this.statusStrip1.Location = new System.Drawing.Point(0, 760);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1572, 42);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // log_rec_size
            // 
            this.log_rec_size.Name = "log_rec_size";
            this.log_rec_size.Size = new System.Drawing.Size(96, 32);
            this.log_rec_size.Text = "rec_size";
            // 
            // log
            // 
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(48, 32);
            this.log.Text = "log";
            // 
            // c_data
            // 
            this.c_data.AutoEllipsis = true;
            this.c_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.c_data.Location = new System.Drawing.Point(1053, 669);
            this.c_data.MinimumSize = new System.Drawing.Size(240, 55);
            this.c_data.Name = "c_data";
            this.c_data.Size = new System.Drawing.Size(240, 55);
            this.c_data.TabIndex = 23;
            this.c_data.Text = "данных 0";
            this.c_data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1572, 802);
            this.Controls.Add(this.c_data);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fix);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.svr_run);
            this.Controls.Add(this.port_in);
            this.Controls.Add(this.port_out);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.data_base);
            this.Controls.Add(this.save);
            this.Controls.Add(this.load);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.car_door);
            this.Controls.Add(this.car_engine);
            this.Controls.Add(this.car_year);
            this.Controls.Add(this.car_name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server car book";
            ((System.ComponentModel.ISupportInitialize)(this.data_base)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox car_name;
        public System.Windows.Forms.TextBox car_year;
        public System.Windows.Forms.TextBox car_engine;
        public System.Windows.Forms.TextBox car_door;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DataGridView data_base;
        public System.Windows.Forms.TextBox ip;
        public System.Windows.Forms.TextBox port_out;
        public System.Windows.Forms.TextBox port_in;
        private System.Windows.Forms.Button svr_run;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox fix;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel log_rec_size;
        private System.Windows.Forms.ToolStripStatusLabel log;
        private System.Windows.Forms.Label c_data;
    }
}

