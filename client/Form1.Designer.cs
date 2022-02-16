namespace client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_data = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.req1 = new System.Windows.Forms.Button();
            this.port_in = new System.Windows.Forms.TextBox();
            this.port_out = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.data_base = new System.Windows.Forms.DataGridView();
            this.req2 = new System.Windows.Forms.Button();
            this.req3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.terminal = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_base)).BeginInit();
            this.SuspendLayout();
            // 
            // c_data
            // 
            this.c_data.AutoEllipsis = true;
            this.c_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.c_data, "c_data");
            this.c_data.Name = "c_data";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // clear
            // 
            resources.ApplyResources(this.clear, "clear");
            this.clear.Name = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // req1
            // 
            resources.ApplyResources(this.req1, "req1");
            this.req1.Name = "req1";
            this.req1.UseVisualStyleBackColor = true;
            this.req1.Click += new System.EventHandler(this.req1_Click);
            // 
            // port_in
            // 
            resources.ApplyResources(this.port_in, "port_in");
            this.port_in.Name = "port_in";
            // 
            // port_out
            // 
            resources.ApplyResources(this.port_out, "port_out");
            this.port_out.Name = "port_out";
            // 
            // ip
            // 
            resources.ApplyResources(this.ip, "ip");
            this.ip.Name = "ip";
            // 
            // data_base
            // 
            this.data_base.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_base.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.data_base, "data_base");
            this.data_base.MultiSelect = false;
            this.data_base.Name = "data_base";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_base.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.data_base.RowTemplate.Height = 33;
            this.data_base.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // req2
            // 
            resources.ApplyResources(this.req2, "req2");
            this.req2.Name = "req2";
            this.req2.UseVisualStyleBackColor = true;
            this.req2.Click += new System.EventHandler(this.req2_Click);
            // 
            // req3
            // 
            resources.ApplyResources(this.req3, "req3");
            this.req3.Name = "req3";
            this.req3.UseVisualStyleBackColor = true;
            this.req3.Click += new System.EventHandler(this.req3_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // terminal
            // 
            this.terminal.BackColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.terminal, "terminal");
            this.terminal.ForeColor = System.Drawing.Color.Lime;
            this.terminal.FormattingEnabled = true;
            this.terminal.Name = "terminal";
            this.terminal.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.terminal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.req3);
            this.Controls.Add(this.req2);
            this.Controls.Add(this.c_data);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.req1);
            this.Controls.Add(this.port_in);
            this.Controls.Add(this.port_out);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.data_base);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.data_base)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label c_data;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button req1;
        public System.Windows.Forms.TextBox port_in;
        public System.Windows.Forms.TextBox port_out;
        public System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.DataGridView data_base;
        private System.Windows.Forms.Button req2;
        private System.Windows.Forms.Button req3;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox terminal;
    }
}

