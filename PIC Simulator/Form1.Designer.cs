namespace PIC_Simulator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Spalte0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spalte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spalte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spalte3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spalte4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spalte5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spalte6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spalte7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.programmtimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Breakpoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codetext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interrupttimer = new System.Windows.Forms.Timer(this.components);
            this.timer0_counter = new System.Windows.Forms.Timer(this.components);
            this.StartStopButton = new System.Windows.Forms.Button();
            this.StepInButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.StepOverButton = new System.Windows.Forms.Button();
            this.StepOutButton = new System.Windows.Forms.Button();
            this.IgnoreButton = new System.Windows.Forms.Button();
            this.label_w_register = new System.Windows.Forms.Label();
            this.label_fsr = new System.Windows.Forms.Label();
            this.label_pcl = new System.Windows.Forms.Label();
            this.label_pclath = new System.Windows.Forms.Label();
            this.label_pc = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(382, 313);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1231, 457);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1865, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ladenToolStripMenuItem,
            this.schließenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.ladenToolStripMenuItem.Text = "laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.schließenToolStripMenuItem.Text = "beenden";
            this.schließenToolStripMenuItem.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1581, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Spalte0,
            this.Spalte1,
            this.Spalte2,
            this.Spalte3,
            this.Spalte4,
            this.Spalte5,
            this.Spalte6,
            this.Spalte7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(16, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(359, 290);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Spalte0
            // 
            this.Spalte0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte0.HeaderText = "00";
            this.Spalte0.MaxInputLength = 2;
            this.Spalte0.Name = "Spalte0";
            this.Spalte0.ReadOnly = true;
            this.Spalte0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte0.Width = 30;
            // 
            // Spalte1
            // 
            this.Spalte1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte1.HeaderText = "01";
            this.Spalte1.MaxInputLength = 2;
            this.Spalte1.Name = "Spalte1";
            this.Spalte1.ReadOnly = true;
            this.Spalte1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte1.Width = 30;
            // 
            // Spalte2
            // 
            this.Spalte2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte2.HeaderText = "02";
            this.Spalte2.MaxInputLength = 2;
            this.Spalte2.Name = "Spalte2";
            this.Spalte2.ReadOnly = true;
            this.Spalte2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte2.Width = 30;
            // 
            // Spalte3
            // 
            this.Spalte3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte3.HeaderText = "03";
            this.Spalte3.MaxInputLength = 2;
            this.Spalte3.Name = "Spalte3";
            this.Spalte3.ReadOnly = true;
            this.Spalte3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte3.Width = 30;
            // 
            // Spalte4
            // 
            this.Spalte4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte4.HeaderText = "04";
            this.Spalte4.MaxInputLength = 2;
            this.Spalte4.Name = "Spalte4";
            this.Spalte4.ReadOnly = true;
            this.Spalte4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte4.Width = 30;
            // 
            // Spalte5
            // 
            this.Spalte5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte5.HeaderText = "05";
            this.Spalte5.MaxInputLength = 2;
            this.Spalte5.Name = "Spalte5";
            this.Spalte5.ReadOnly = true;
            this.Spalte5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte5.Width = 30;
            // 
            // Spalte6
            // 
            this.Spalte6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte6.HeaderText = "06";
            this.Spalte6.MaxInputLength = 2;
            this.Spalte6.Name = "Spalte6";
            this.Spalte6.ReadOnly = true;
            this.Spalte6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte6.Width = 30;
            // 
            // Spalte7
            // 
            this.Spalte7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte7.HeaderText = "07";
            this.Spalte7.MaxInputLength = 2;
            this.Spalte7.Name = "Spalte7";
            this.Spalte7.ReadOnly = true;
            this.Spalte7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spalte7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spalte7.Width = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "W-Reg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "FSR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "PCL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "PCLATH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "PC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_status);
            this.groupBox1.Controls.Add(this.label_pc);
            this.groupBox1.Controls.Add(this.label_pclath);
            this.groupBox1.Controls.Add(this.label_pcl);
            this.groupBox1.Controls.Add(this.label_fsr);
            this.groupBox1.Controls.Add(this.label_w_register);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 368);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 256);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spezialfunktionsregister";
            // 
            // programmtimer
            // 
            this.programmtimer.Interval = 200;
            this.programmtimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Breakpoint,
            this.Codetext});
            this.dataGridView2.Location = new System.Drawing.Point(382, 313);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1232, 495);
            this.dataGridView2.TabIndex = 11;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // Breakpoint
            // 
            this.Breakpoint.HeaderText = "Breakpoint";
            this.Breakpoint.Name = "Breakpoint";
            this.Breakpoint.ReadOnly = true;
            this.Breakpoint.Width = 20;
            // 
            // Codetext
            // 
            this.Codetext.HeaderText = "codetext";
            this.Codetext.MaxInputLength = 132;
            this.Codetext.Name = "Codetext";
            this.Codetext.ReadOnly = true;
            this.Codetext.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Codetext.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Codetext.Width = 1320;
            // 
            // interrupttimer
            // 
            this.interrupttimer.Interval = 50;
            this.interrupttimer.Tick += new System.EventHandler(this.interrupttimer_Tick);
            // 
            // timer0_counter
            // 
            this.timer0_counter.Interval = 50;
            this.timer0_counter.Tick += new System.EventHandler(this.timer0_counter_Tick);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(1691, 342);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(93, 27);
            this.StartStopButton.TabIndex = 12;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // StepInButton
            // 
            this.StepInButton.Location = new System.Drawing.Point(1691, 380);
            this.StepInButton.Name = "StepInButton";
            this.StepInButton.Size = new System.Drawing.Size(93, 27);
            this.StepInButton.TabIndex = 14;
            this.StepInButton.Text = "Step in";
            this.StepInButton.UseVisualStyleBackColor = true;
            this.StepInButton.Click += new System.EventHandler(this.StepInButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1691, 313);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 27);
            this.button5.TabIndex = 15;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // StepOverButton
            // 
            this.StepOverButton.Location = new System.Drawing.Point(1691, 442);
            this.StepOverButton.Name = "StepOverButton";
            this.StepOverButton.Size = new System.Drawing.Size(93, 27);
            this.StepOverButton.TabIndex = 16;
            this.StepOverButton.Text = "Step over";
            this.StepOverButton.UseVisualStyleBackColor = true;
            this.StepOverButton.Click += new System.EventHandler(this.StepOverButton_Click);
            // 
            // StepOutButton
            // 
            this.StepOutButton.Location = new System.Drawing.Point(1691, 411);
            this.StepOutButton.Name = "StepOutButton";
            this.StepOutButton.Size = new System.Drawing.Size(93, 27);
            this.StepOutButton.TabIndex = 17;
            this.StepOutButton.Text = "Step out";
            this.StepOutButton.UseVisualStyleBackColor = true;
            this.StepOutButton.Click += new System.EventHandler(this.StepOutButton_Click);
            // 
            // IgnoreButton
            // 
            this.IgnoreButton.Location = new System.Drawing.Point(1691, 473);
            this.IgnoreButton.Name = "IgnoreButton";
            this.IgnoreButton.Size = new System.Drawing.Size(93, 27);
            this.IgnoreButton.TabIndex = 18;
            this.IgnoreButton.Text = "Ignore";
            this.IgnoreButton.UseVisualStyleBackColor = true;
            this.IgnoreButton.Click += new System.EventHandler(this.IgnoreButton_Click);
            // 
            // label_w_register
            // 
            this.label_w_register.AutoSize = true;
            this.label_w_register.Location = new System.Drawing.Point(82, 20);
            this.label_w_register.Name = "label_w_register";
            this.label_w_register.Size = new System.Drawing.Size(0, 17);
            this.label_w_register.TabIndex = 10;
            // 
            // label_fsr
            // 
            this.label_fsr.AutoSize = true;
            this.label_fsr.Location = new System.Drawing.Point(85, 35);
            this.label_fsr.Name = "label_fsr";
            this.label_fsr.Size = new System.Drawing.Size(46, 17);
            this.label_fsr.TabIndex = 11;
            this.label_fsr.Text = "label7";
            // 
            // label_pcl
            // 
            this.label_pcl.AutoSize = true;
            this.label_pcl.Location = new System.Drawing.Point(85, 52);
            this.label_pcl.Name = "label_pcl";
            this.label_pcl.Size = new System.Drawing.Size(46, 17);
            this.label_pcl.TabIndex = 12;
            this.label_pcl.Text = "label7";
            // 
            // label_pclath
            // 
            this.label_pclath.AutoSize = true;
            this.label_pclath.Location = new System.Drawing.Point(85, 68);
            this.label_pclath.Name = "label_pclath";
            this.label_pclath.Size = new System.Drawing.Size(46, 17);
            this.label_pclath.TabIndex = 13;
            this.label_pclath.Text = "label7";
            // 
            // label_pc
            // 
            this.label_pc.AutoSize = true;
            this.label_pc.Location = new System.Drawing.Point(85, 84);
            this.label_pc.Name = "label_pc";
            this.label_pc.Size = new System.Drawing.Size(46, 17);
            this.label_pc.TabIndex = 14;
            this.label_pc.Text = "label7";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(85, 100);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(46, 17);
            this.label_status.TabIndex = 15;
            this.label_status.Text = "label7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1865, 811);
            this.Controls.Add(this.IgnoreButton);
            this.Controls.Add(this.StepOutButton);
            this.Controls.Add(this.StepOverButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.StepInButton);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "PIC Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schließenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spalte7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer programmtimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Breakpoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codetext;
        private System.Windows.Forms.Timer interrupttimer;
        private System.Windows.Forms.Timer timer0_counter;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Button StepInButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button StepOverButton;
        private System.Windows.Forms.Button StepOutButton;
        private System.Windows.Forms.Button IgnoreButton;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_pc;
        private System.Windows.Forms.Label label_pclath;
        private System.Windows.Forms.Label label_pcl;
        private System.Windows.Forms.Label label_fsr;
        private System.Windows.Forms.Label label_w_register;
    }
}

