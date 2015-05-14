using System.Drawing;

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


        private void initialize_my_Component()
        {
            this.dataGridView_status.Rows.Add();

            this.dataGridView_option.Rows.Add();

            this.dataGridView_intcon.Rows.Add();

            dataGridView_PortA.TopLeftHeaderCell.Value = "RA";
            dataGridView_PortA.Rows.Add();
            dataGridView_PortA.Rows.Add();
            dataGridView_PortA.Rows[0].HeaderCell.Value = "TrisA";
            dataGridView_PortA.Rows[1].HeaderCell.Value = "PortA";
            dataGridView_PortB.TopLeftHeaderCell.Value = "RB";
            dataGridView_PortB.Rows.Add();
            dataGridView_PortB.Rows.Add();
            dataGridView_PortB.Rows[0].HeaderCell.Value = "TrisB";
            dataGridView_PortB.Rows[1].HeaderCell.Value = "PortB";

            dataGridView_Speicher.RowCount = 32;//32 Zeilen à 8 Register/Byte = 256/FFH Register
            for (int i = 0; i < 32; i++)
                dataGridView_Speicher.Rows[i].HeaderCell.Value = (i * 8).ToString("X2");

            dataGridView_code.Columns[1].DefaultCellStyle.Font = new Font("Courier New", 12, GraphicsUnit.Pixel);//Spalte mit dem Code
            dataGridView_code.Columns[0].DefaultCellStyle.Font = new Font("Arial", 20, GraphicsUnit.Pixel);//Spalte mit dem Breakpoint

            //Filter für die Dateieen, die eingelesen werden
            openFileDialog1.Filter = "lst files (*.lst)|*.lst";
        }
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView_Speicher = new System.Windows.Forms.DataGridView();
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
            this.dataGridView_intcon = new System.Windows.Forms.DataGridView();
            this.GIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T0IE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RBIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T0IF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RBIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_intcon = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView_option = new System.Windows.Forms.DataGridView();
            this.RBP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTEDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T0CS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T0SE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PS2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PS0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_option = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_status = new System.Windows.Forms.DataGridView();
            this.IRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RP1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RP0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_status = new System.Windows.Forms.Label();
            this.label_pc = new System.Windows.Forms.Label();
            this.label_pclath = new System.Windows.Forms.Label();
            this.label_pcl = new System.Windows.Forms.Label();
            this.label_fsr = new System.Windows.Forms.Label();
            this.label_w_register = new System.Windows.Forms.Label();
            this.programmtimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView_code = new System.Windows.Forms.DataGridView();
            this.Breakpoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codetext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interrupttimer = new System.Windows.Forms.Timer(this.components);
            this.timer0_counter = new System.Windows.Forms.Timer(this.components);
            this.dataGridView_PortA = new System.Windows.Forms.DataGridView();
            this._4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_PortB = new System.Windows.Forms.DataGridView();
            this.@__7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IgnoreButton = new System.Windows.Forms.Button();
            this.StepOutButton = new System.Windows.Forms.Button();
            this.StepOverButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.StepInButton = new System.Windows.Forms.Button();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.groupBox_funktionsgenerator = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_FG_verhältnis = new System.Windows.Forms.TextBox();
            this.textBox_FG_frequenz = new System.Windows.Forms.TextBox();
            this.textBox_FG_pin = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nctoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rA7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rB7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_Funktionsgenerator = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label_laufzeit = new System.Windows.Forms.Label();
            this.comboBox_quarzfrequenz = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_quarzfrquenz = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label_Stack6_Wert = new System.Windows.Forms.Label();
            this.label_Stack7_Wert = new System.Windows.Forms.Label();
            this.label_Stack5_Wert = new System.Windows.Forms.Label();
            this.label_Stack4_Wert = new System.Windows.Forms.Label();
            this.label_Stack3_Wert = new System.Windows.Forms.Label();
            this.label_Stack2_Wert = new System.Windows.Forms.Label();
            this.label_Stack1_Wert = new System.Windows.Forms.Label();
            this.label_Stack0_Wert = new System.Windows.Forms.Label();
            this.label_Stack7_Pfeil = new System.Windows.Forms.Label();
            this.label_Stack6_Pfeil = new System.Windows.Forms.Label();
            this.label_Stack5_Pfeil = new System.Windows.Forms.Label();
            this.label_Stack4_Pfeil = new System.Windows.Forms.Label();
            this.label_Stack3_Pfeil = new System.Windows.Forms.Label();
            this.label_Stack2_Pfeil = new System.Windows.Forms.Label();
            this.label_Stack1_Pfeil = new System.Windows.Forms.Label();
            this.label_Stack0_Pfeil = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Speicher)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_intcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_option)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PortA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PortB)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox_funktionsgenerator.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(286, 284);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(924, 342);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1304, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ladenToolStripMenuItem,
            this.schließenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ladenToolStripMenuItem.Text = "laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.schließenToolStripMenuItem.Text = "beenden";
            this.schließenToolStripMenuItem.Click += new System.EventHandler(this.schließenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1196, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_Speicher
            // 
            this.dataGridView_Speicher.AllowUserToAddRows = false;
            this.dataGridView_Speicher.AllowUserToDeleteRows = false;
            this.dataGridView_Speicher.AllowUserToResizeColumns = false;
            this.dataGridView_Speicher.AllowUserToResizeRows = false;
            this.dataGridView_Speicher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Speicher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridView_Speicher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Speicher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Spalte0,
            this.Spalte1,
            this.Spalte2,
            this.Spalte3,
            this.Spalte4,
            this.Spalte5,
            this.Spalte6,
            this.Spalte7});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Speicher.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridView_Speicher.Location = new System.Drawing.Point(12, 42);
            this.dataGridView_Speicher.MultiSelect = false;
            this.dataGridView_Speicher.Name = "dataGridView_Speicher";
            this.dataGridView_Speicher.ReadOnly = true;
            this.dataGridView_Speicher.RowHeadersWidth = 50;
            this.dataGridView_Speicher.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_Speicher.RowTemplate.ReadOnly = true;
            this.dataGridView_Speicher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Speicher.Size = new System.Drawing.Size(269, 236);
            this.dataGridView_Speicher.TabIndex = 3;
            this.dataGridView_Speicher.TabStop = false;
            this.dataGridView_Speicher.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Speicher_CellDoubleClick);
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
            this.Spalte0.Width = 25;
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
            this.Spalte1.Width = 25;
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
            this.Spalte2.Width = 25;
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
            this.Spalte3.Width = 25;
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
            this.Spalte4.Width = 25;
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
            this.Spalte5.Width = 25;
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
            this.Spalte6.Width = 25;
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
            this.Spalte7.Width = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "W-Reg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "FSR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "PCL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PCLATH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "PC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_intcon);
            this.groupBox1.Controls.Add(this.label_intcon);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dataGridView_option);
            this.groupBox1.Controls.Add(this.label_option);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dataGridView_status);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 357);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spezialfunktionsregister";
            // 
            // dataGridView_intcon
            // 
            this.dataGridView_intcon.AllowUserToAddRows = false;
            this.dataGridView_intcon.AllowUserToDeleteRows = false;
            this.dataGridView_intcon.AllowUserToOrderColumns = true;
            this.dataGridView_intcon.AllowUserToResizeColumns = false;
            this.dataGridView_intcon.AllowUserToResizeRows = false;
            this.dataGridView_intcon.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_intcon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_intcon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_intcon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridView_intcon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_intcon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GIE,
            this.PIE,
            this.T0IE,
            this.INTE,
            this.RBIE,
            this.T0IF,
            this.INTF,
            this.RBIF});
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_intcon.DefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridView_intcon.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_intcon.Location = new System.Drawing.Point(1, 238);
            this.dataGridView_intcon.MultiSelect = false;
            this.dataGridView_intcon.Name = "dataGridView_intcon";
            this.dataGridView_intcon.ReadOnly = true;
            this.dataGridView_intcon.RowHeadersVisible = false;
            this.dataGridView_intcon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_intcon.Size = new System.Drawing.Size(240, 47);
            this.dataGridView_intcon.TabIndex = 19;
            this.dataGridView_intcon.TabStop = false;
            this.dataGridView_intcon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_intcon_CellClick);
            // 
            // GIE
            // 
            this.GIE.HeaderText = "GIE";
            this.GIE.Name = "GIE";
            this.GIE.ReadOnly = true;
            this.GIE.Width = 30;
            // 
            // PIE
            // 
            this.PIE.HeaderText = "PIE";
            this.PIE.Name = "PIE";
            this.PIE.ReadOnly = true;
            this.PIE.Width = 30;
            // 
            // T0IE
            // 
            this.T0IE.HeaderText = "T0IE";
            this.T0IE.Name = "T0IE";
            this.T0IE.ReadOnly = true;
            this.T0IE.Width = 30;
            // 
            // INTE
            // 
            this.INTE.HeaderText = "INTE";
            this.INTE.Name = "INTE";
            this.INTE.ReadOnly = true;
            this.INTE.Width = 30;
            // 
            // RBIE
            // 
            this.RBIE.HeaderText = "RBIE";
            this.RBIE.Name = "RBIE";
            this.RBIE.ReadOnly = true;
            this.RBIE.Width = 30;
            // 
            // T0IF
            // 
            this.T0IF.HeaderText = "T0IF";
            this.T0IF.Name = "T0IF";
            this.T0IF.ReadOnly = true;
            this.T0IF.Width = 30;
            // 
            // INTF
            // 
            this.INTF.HeaderText = "INTF";
            this.INTF.Name = "INTF";
            this.INTF.ReadOnly = true;
            this.INTF.Width = 30;
            // 
            // RBIF
            // 
            this.RBIF.HeaderText = "RBIF";
            this.RBIF.Name = "RBIF";
            this.RBIF.ReadOnly = true;
            this.RBIF.Width = 30;
            // 
            // label_intcon
            // 
            this.label_intcon.AutoSize = true;
            this.label_intcon.Location = new System.Drawing.Point(67, 222);
            this.label_intcon.Name = "label_intcon";
            this.label_intcon.Size = new System.Drawing.Size(35, 13);
            this.label_intcon.TabIndex = 23;
            this.label_intcon.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "NTCON";
            // 
            // dataGridView_option
            // 
            this.dataGridView_option.AllowUserToAddRows = false;
            this.dataGridView_option.AllowUserToDeleteRows = false;
            this.dataGridView_option.AllowUserToResizeColumns = false;
            this.dataGridView_option.AllowUserToResizeRows = false;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_option.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridView_option.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_option.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_option.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_option.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridView_option.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RBP,
            this.INTEDG,
            this.T0CS,
            this.T0SE,
            this.PSA,
            this.PS2,
            this.PS1,
            this.PS0});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_option.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridView_option.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_option.Location = new System.Drawing.Point(1, 163);
            this.dataGridView_option.MultiSelect = false;
            this.dataGridView_option.Name = "dataGridView_option";
            this.dataGridView_option.ReadOnly = true;
            this.dataGridView_option.RowHeadersVisible = false;
            this.dataGridView_option.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_option.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_option.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_option.Size = new System.Drawing.Size(240, 52);
            this.dataGridView_option.TabIndex = 20;
            this.dataGridView_option.TabStop = false;
            this.dataGridView_option.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_option_CellClick);
            // 
            // RBP
            // 
            this.RBP.HeaderText = "RBP";
            this.RBP.Name = "RBP";
            this.RBP.ReadOnly = true;
            this.RBP.Width = 27;
            // 
            // INTEDG
            // 
            this.INTEDG.HeaderText = "INTEDG";
            this.INTEDG.Name = "INTEDG";
            this.INTEDG.ReadOnly = true;
            this.INTEDG.Width = 45;
            // 
            // T0CS
            // 
            this.T0CS.HeaderText = "T0CS";
            this.T0CS.Name = "T0CS";
            this.T0CS.ReadOnly = true;
            this.T0CS.Width = 30;
            // 
            // T0SE
            // 
            this.T0SE.HeaderText = "T0SE";
            this.T0SE.Name = "T0SE";
            this.T0SE.ReadOnly = true;
            this.T0SE.Width = 30;
            // 
            // PSA
            // 
            this.PSA.HeaderText = "PSA";
            this.PSA.Name = "PSA";
            this.PSA.ReadOnly = true;
            this.PSA.Width = 27;
            // 
            // PS2
            // 
            this.PS2.HeaderText = "PS2";
            this.PS2.Name = "PS2";
            this.PS2.ReadOnly = true;
            this.PS2.Width = 27;
            // 
            // PS1
            // 
            this.PS1.HeaderText = "PS1";
            this.PS1.Name = "PS1";
            this.PS1.ReadOnly = true;
            this.PS1.Width = 27;
            // 
            // PS0
            // 
            this.PS0.HeaderText = "PS0";
            this.PS0.Name = "PS0";
            this.PS0.ReadOnly = true;
            this.PS0.Width = 27;
            // 
            // label_option
            // 
            this.label_option.AutoSize = true;
            this.label_option.Location = new System.Drawing.Point(67, 147);
            this.label_option.Name = "label_option";
            this.label_option.Size = new System.Drawing.Size(35, 13);
            this.label_option.TabIndex = 21;
            this.label_option.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Option";
            // 
            // dataGridView_status
            // 
            this.dataGridView_status.AllowUserToAddRows = false;
            this.dataGridView_status.AllowUserToDeleteRows = false;
            this.dataGridView_status.AllowUserToResizeColumns = false;
            this.dataGridView_status.AllowUserToResizeRows = false;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView_status.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridView_status.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_status.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_status.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dataGridView_status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_status.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IRP,
            this.RP1,
            this.RP0,
            this.TO,
            this.PD,
            this.Z,
            this.DC,
            this.C});
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_status.DefaultCellStyle = dataGridViewCellStyle39;
            this.dataGridView_status.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_status.Location = new System.Drawing.Point(0, 97);
            this.dataGridView_status.MultiSelect = false;
            this.dataGridView_status.Name = "dataGridView_status";
            this.dataGridView_status.ReadOnly = true;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_status.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.dataGridView_status.RowHeadersVisible = false;
            this.dataGridView_status.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_status.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_status.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_status.Size = new System.Drawing.Size(241, 43);
            this.dataGridView_status.TabIndex = 19;
            this.dataGridView_status.TabStop = false;
            this.dataGridView_status.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_status_CellClick);
            // 
            // IRP
            // 
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.IRP.DefaultCellStyle = dataGridViewCellStyle38;
            this.IRP.HeaderText = "IRP";
            this.IRP.Name = "IRP";
            this.IRP.ReadOnly = true;
            this.IRP.Width = 30;
            // 
            // RP1
            // 
            this.RP1.HeaderText = "RP1";
            this.RP1.Name = "RP1";
            this.RP1.ReadOnly = true;
            this.RP1.Width = 30;
            // 
            // RP0
            // 
            this.RP0.HeaderText = "RP0";
            this.RP0.Name = "RP0";
            this.RP0.ReadOnly = true;
            this.RP0.Width = 30;
            // 
            // TO
            // 
            this.TO.HeaderText = "TO";
            this.TO.Name = "TO";
            this.TO.ReadOnly = true;
            this.TO.Width = 30;
            // 
            // PD
            // 
            this.PD.HeaderText = "PD";
            this.PD.Name = "PD";
            this.PD.ReadOnly = true;
            this.PD.Width = 30;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            this.Z.ReadOnly = true;
            this.Z.Width = 30;
            // 
            // DC
            // 
            this.DC.HeaderText = "DC";
            this.DC.Name = "DC";
            this.DC.ReadOnly = true;
            this.DC.Width = 30;
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.ReadOnly = true;
            this.C.Width = 30;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(64, 81);
            this.label_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(35, 13);
            this.label_status.TabIndex = 15;
            this.label_status.Text = "label7";
            // 
            // label_pc
            // 
            this.label_pc.AutoSize = true;
            this.label_pc.Location = new System.Drawing.Point(64, 68);
            this.label_pc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_pc.Name = "label_pc";
            this.label_pc.Size = new System.Drawing.Size(35, 13);
            this.label_pc.TabIndex = 14;
            this.label_pc.Text = "label7";
            // 
            // label_pclath
            // 
            this.label_pclath.AutoSize = true;
            this.label_pclath.Location = new System.Drawing.Point(64, 55);
            this.label_pclath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_pclath.Name = "label_pclath";
            this.label_pclath.Size = new System.Drawing.Size(35, 13);
            this.label_pclath.TabIndex = 13;
            this.label_pclath.Text = "label7";
            // 
            // label_pcl
            // 
            this.label_pcl.AutoSize = true;
            this.label_pcl.Location = new System.Drawing.Point(64, 42);
            this.label_pcl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_pcl.Name = "label_pcl";
            this.label_pcl.Size = new System.Drawing.Size(35, 13);
            this.label_pcl.TabIndex = 12;
            this.label_pcl.Text = "label7";
            // 
            // label_fsr
            // 
            this.label_fsr.AutoSize = true;
            this.label_fsr.Location = new System.Drawing.Point(64, 28);
            this.label_fsr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_fsr.Name = "label_fsr";
            this.label_fsr.Size = new System.Drawing.Size(35, 13);
            this.label_fsr.TabIndex = 11;
            this.label_fsr.Text = "label7";
            // 
            // label_w_register
            // 
            this.label_w_register.AutoSize = true;
            this.label_w_register.Location = new System.Drawing.Point(64, 15);
            this.label_w_register.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_w_register.Name = "label_w_register";
            this.label_w_register.Size = new System.Drawing.Size(35, 13);
            this.label_w_register.TabIndex = 10;
            this.label_w_register.Text = "label7";
            // 
            // programmtimer
            // 
            this.programmtimer.Interval = 1;
            this.programmtimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView_code
            // 
            this.dataGridView_code.AllowUserToAddRows = false;
            this.dataGridView_code.AllowUserToDeleteRows = false;
            this.dataGridView_code.AllowUserToResizeColumns = false;
            this.dataGridView_code.AllowUserToResizeRows = false;
            this.dataGridView_code.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_code.ColumnHeadersVisible = false;
            this.dataGridView_code.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Breakpoint,
            this.Codetext});
            this.dataGridView_code.Location = new System.Drawing.Point(286, 284);
            this.dataGridView_code.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_code.MultiSelect = false;
            this.dataGridView_code.Name = "dataGridView_code";
            this.dataGridView_code.ReadOnly = true;
            this.dataGridView_code.RowHeadersVisible = false;
            this.dataGridView_code.RowTemplate.Height = 24;
            this.dataGridView_code.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_code.Size = new System.Drawing.Size(924, 372);
            this.dataGridView_code.TabIndex = 11;
            this.dataGridView_code.TabStop = false;
            this.dataGridView_code.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
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
            // dataGridView_PortA
            // 
            this.dataGridView_PortA.AllowUserToAddRows = false;
            this.dataGridView_PortA.AllowUserToDeleteRows = false;
            this.dataGridView_PortA.AllowUserToResizeColumns = false;
            this.dataGridView_PortA.AllowUserToResizeRows = false;
            this.dataGridView_PortA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PortA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._4,
            this._3,
            this._2,
            this._1,
            this._0});
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_PortA.DefaultCellStyle = dataGridViewCellStyle41;
            this.dataGridView_PortA.Location = new System.Drawing.Point(287, 42);
            this.dataGridView_PortA.MultiSelect = false;
            this.dataGridView_PortA.Name = "dataGridView_PortA";
            this.dataGridView_PortA.ReadOnly = true;
            this.dataGridView_PortA.RowHeadersWidth = 62;
            this.dataGridView_PortA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_PortA.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_PortA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_PortA.Size = new System.Drawing.Size(139, 66);
            this.dataGridView_PortA.TabIndex = 19;
            this.dataGridView_PortA.TabStop = false;
            this.dataGridView_PortA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_PortA_CellClick);
            // 
            // _4
            // 
            this._4.HeaderText = "4";
            this._4.Name = "_4";
            this._4.ReadOnly = true;
            this._4.Width = 15;
            // 
            // _3
            // 
            this._3.HeaderText = "3";
            this._3.Name = "_3";
            this._3.ReadOnly = true;
            this._3.Width = 15;
            // 
            // _2
            // 
            this._2.HeaderText = "2";
            this._2.Name = "_2";
            this._2.ReadOnly = true;
            this._2.Width = 15;
            // 
            // _1
            // 
            this._1.HeaderText = "1";
            this._1.Name = "_1";
            this._1.ReadOnly = true;
            this._1.Width = 15;
            // 
            // _0
            // 
            this._0.HeaderText = "0";
            this._0.Name = "_0";
            this._0.ReadOnly = true;
            this._0.Width = 15;
            // 
            // dataGridView_PortB
            // 
            this.dataGridView_PortB.AllowUserToAddRows = false;
            this.dataGridView_PortB.AllowUserToDeleteRows = false;
            this.dataGridView_PortB.AllowUserToResizeColumns = false;
            this.dataGridView_PortB.AllowUserToResizeRows = false;
            this.dataGridView_PortB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PortB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__7,
            this.@__6,
            this.@__5,
            this.@__4,
            this.@__3,
            this.@__2,
            this.@__1,
            this.@__0});
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_PortB.DefaultCellStyle = dataGridViewCellStyle42;
            this.dataGridView_PortB.Location = new System.Drawing.Point(287, 114);
            this.dataGridView_PortB.MultiSelect = false;
            this.dataGridView_PortB.Name = "dataGridView_PortB";
            this.dataGridView_PortB.ReadOnly = true;
            this.dataGridView_PortB.RowHeadersWidth = 62;
            this.dataGridView_PortB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_PortB.Size = new System.Drawing.Size(184, 66);
            this.dataGridView_PortB.TabIndex = 20;
            this.dataGridView_PortB.TabStop = false;
            this.dataGridView_PortB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_PortB_CellClick);
            // 
            // __7
            // 
            this.@__7.HeaderText = "7";
            this.@__7.Name = "__7";
            this.@__7.ReadOnly = true;
            this.@__7.Width = 15;
            // 
            // __6
            // 
            this.@__6.HeaderText = "6";
            this.@__6.Name = "__6";
            this.@__6.ReadOnly = true;
            this.@__6.Width = 15;
            // 
            // __5
            // 
            this.@__5.HeaderText = "5";
            this.@__5.Name = "__5";
            this.@__5.ReadOnly = true;
            this.@__5.Width = 15;
            // 
            // __4
            // 
            this.@__4.HeaderText = "4";
            this.@__4.Name = "__4";
            this.@__4.ReadOnly = true;
            this.@__4.Width = 15;
            // 
            // __3
            // 
            this.@__3.HeaderText = "3";
            this.@__3.Name = "__3";
            this.@__3.ReadOnly = true;
            this.@__3.Width = 15;
            // 
            // __2
            // 
            this.@__2.HeaderText = "2";
            this.@__2.Name = "__2";
            this.@__2.ReadOnly = true;
            this.@__2.Width = 15;
            // 
            // __1
            // 
            this.@__1.HeaderText = "1";
            this.@__1.Name = "__1";
            this.@__1.ReadOnly = true;
            this.@__1.Width = 15;
            // 
            // __0
            // 
            this.@__0.HeaderText = "0";
            this.@__0.Name = "__0";
            this.@__0.ReadOnly = true;
            this.@__0.Width = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IgnoreButton);
            this.groupBox2.Controls.Add(this.StepOutButton);
            this.groupBox2.Controls.Add(this.StepOverButton);
            this.groupBox2.Controls.Add(this.resetButton);
            this.groupBox2.Controls.Add(this.StepInButton);
            this.groupBox2.Controls.Add(this.StartStopButton);
            this.groupBox2.Location = new System.Drawing.Point(1216, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(83, 175);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Steuerpult";
            // 
            // IgnoreButton
            // 
            this.IgnoreButton.Enabled = false;
            this.IgnoreButton.Location = new System.Drawing.Point(5, 148);
            this.IgnoreButton.Margin = new System.Windows.Forms.Padding(2);
            this.IgnoreButton.Name = "IgnoreButton";
            this.IgnoreButton.Size = new System.Drawing.Size(70, 22);
            this.IgnoreButton.TabIndex = 24;
            this.IgnoreButton.Text = "Ignore";
            this.IgnoreButton.UseVisualStyleBackColor = true;
            this.IgnoreButton.Click += new System.EventHandler(this.IgnoreButton_Click);
            // 
            // StepOutButton
            // 
            this.StepOutButton.Enabled = false;
            this.StepOutButton.Location = new System.Drawing.Point(5, 98);
            this.StepOutButton.Margin = new System.Windows.Forms.Padding(2);
            this.StepOutButton.Name = "StepOutButton";
            this.StepOutButton.Size = new System.Drawing.Size(70, 22);
            this.StepOutButton.TabIndex = 23;
            this.StepOutButton.Text = "Step out";
            this.StepOutButton.UseVisualStyleBackColor = true;
            this.StepOutButton.Click += new System.EventHandler(this.StepOutButton_Click);
            // 
            // StepOverButton
            // 
            this.StepOverButton.Enabled = false;
            this.StepOverButton.Location = new System.Drawing.Point(5, 123);
            this.StepOverButton.Margin = new System.Windows.Forms.Padding(2);
            this.StepOverButton.Name = "StepOverButton";
            this.StepOverButton.Size = new System.Drawing.Size(70, 22);
            this.StepOverButton.TabIndex = 22;
            this.StepOverButton.Text = "Step over";
            this.StepOverButton.UseVisualStyleBackColor = true;
            this.StepOverButton.Click += new System.EventHandler(this.StepOverButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(5, 18);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(70, 22);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // StepInButton
            // 
            this.StepInButton.Enabled = false;
            this.StepInButton.Location = new System.Drawing.Point(5, 73);
            this.StepInButton.Margin = new System.Windows.Forms.Padding(2);
            this.StepInButton.Name = "StepInButton";
            this.StepInButton.Size = new System.Drawing.Size(70, 22);
            this.StepInButton.TabIndex = 20;
            this.StepInButton.Text = "Step in";
            this.StepInButton.UseVisualStyleBackColor = true;
            this.StepInButton.Click += new System.EventHandler(this.StepInButton_Click);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Enabled = false;
            this.StartStopButton.Location = new System.Drawing.Point(5, 42);
            this.StartStopButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(70, 22);
            this.StartStopButton.TabIndex = 19;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // groupBox_funktionsgenerator
            // 
            this.groupBox_funktionsgenerator.Controls.Add(this.label11);
            this.groupBox_funktionsgenerator.Controls.Add(this.label10);
            this.groupBox_funktionsgenerator.Controls.Add(this.label9);
            this.groupBox_funktionsgenerator.Controls.Add(this.textBox_FG_verhältnis);
            this.groupBox_funktionsgenerator.Controls.Add(this.textBox_FG_frequenz);
            this.groupBox_funktionsgenerator.Controls.Add(this.textBox_FG_pin);
            this.groupBox_funktionsgenerator.Location = new System.Drawing.Point(287, 186);
            this.groupBox_funktionsgenerator.Name = "groupBox_funktionsgenerator";
            this.groupBox_funktionsgenerator.Size = new System.Drawing.Size(184, 92);
            this.groupBox_funktionsgenerator.TabIndex = 22;
            this.groupBox_funktionsgenerator.TabStop = false;
            this.groupBox_funktionsgenerator.Text = "Funktionsgenerator";
            this.groupBox_funktionsgenerator.Enter += new System.EventHandler(this.groupBox_funktionsgenerator_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Verhältnis";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Frequenz(kHz)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Port-Pin";
            // 
            // textBox_FG_verhältnis
            // 
            this.textBox_FG_verhältnis.Location = new System.Drawing.Point(93, 70);
            this.textBox_FG_verhältnis.Name = "textBox_FG_verhältnis";
            this.textBox_FG_verhältnis.ReadOnly = true;
            this.textBox_FG_verhältnis.Size = new System.Drawing.Size(85, 20);
            this.textBox_FG_verhältnis.TabIndex = 2;
            this.textBox_FG_verhältnis.Text = "50:50";
            this.textBox_FG_verhältnis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_FG_frequenz
            // 
            this.textBox_FG_frequenz.Location = new System.Drawing.Point(93, 44);
            this.textBox_FG_frequenz.Name = "textBox_FG_frequenz";
            this.textBox_FG_frequenz.Size = new System.Drawing.Size(85, 20);
            this.textBox_FG_frequenz.TabIndex = 1;
            this.textBox_FG_frequenz.Text = "20";
            this.textBox_FG_frequenz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FG_frequenz.TextChanged += new System.EventHandler(this.textBox_FG_frequenz_TextChanged);
            // 
            // textBox_FG_pin
            // 
            this.textBox_FG_pin.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox_FG_pin.Location = new System.Drawing.Point(93, 18);
            this.textBox_FG_pin.Name = "textBox_FG_pin";
            this.textBox_FG_pin.ReadOnly = true;
            this.textBox_FG_pin.Size = new System.Drawing.Size(85, 20);
            this.textBox_FG_pin.TabIndex = 0;
            this.textBox_FG_pin.Text = "nc";
            this.textBox_FG_pin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nctoolStripMenuItem,
            this.rAToolStripMenuItem,
            this.rBToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(90, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // nctoolStripMenuItem
            // 
            this.nctoolStripMenuItem.Name = "nctoolStripMenuItem";
            this.nctoolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.nctoolStripMenuItem.Text = "nc";
            this.nctoolStripMenuItem.Click += new System.EventHandler(this.nctoolStripMenuItem_Click);
            // 
            // rAToolStripMenuItem
            // 
            this.rAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rA0ToolStripMenuItem,
            this.rA1ToolStripMenuItem,
            this.rA2ToolStripMenuItem,
            this.rA3ToolStripMenuItem,
            this.rA4ToolStripMenuItem,
            this.rA5ToolStripMenuItem,
            this.rA6ToolStripMenuItem,
            this.rA7ToolStripMenuItem});
            this.rAToolStripMenuItem.Name = "rAToolStripMenuItem";
            this.rAToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.rAToolStripMenuItem.Text = "RA";
            // 
            // rA0ToolStripMenuItem
            // 
            this.rA0ToolStripMenuItem.Name = "rA0ToolStripMenuItem";
            this.rA0ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA0ToolStripMenuItem.Text = "RA0";
            this.rA0ToolStripMenuItem.Click += new System.EventHandler(this.rA0ToolStripMenuItem_Click);
            // 
            // rA1ToolStripMenuItem
            // 
            this.rA1ToolStripMenuItem.Name = "rA1ToolStripMenuItem";
            this.rA1ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA1ToolStripMenuItem.Text = "RA1";
            this.rA1ToolStripMenuItem.Click += new System.EventHandler(this.rA1ToolStripMenuItem_Click);
            // 
            // rA2ToolStripMenuItem
            // 
            this.rA2ToolStripMenuItem.Name = "rA2ToolStripMenuItem";
            this.rA2ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA2ToolStripMenuItem.Text = "RA2";
            this.rA2ToolStripMenuItem.Click += new System.EventHandler(this.rA2ToolStripMenuItem_Click);
            // 
            // rA3ToolStripMenuItem
            // 
            this.rA3ToolStripMenuItem.Name = "rA3ToolStripMenuItem";
            this.rA3ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA3ToolStripMenuItem.Text = "RA3";
            this.rA3ToolStripMenuItem.Click += new System.EventHandler(this.rA3ToolStripMenuItem_Click);
            // 
            // rA4ToolStripMenuItem
            // 
            this.rA4ToolStripMenuItem.Name = "rA4ToolStripMenuItem";
            this.rA4ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA4ToolStripMenuItem.Text = "RA4";
            this.rA4ToolStripMenuItem.Click += new System.EventHandler(this.rA4ToolStripMenuItem_Click);
            // 
            // rA5ToolStripMenuItem
            // 
            this.rA5ToolStripMenuItem.Name = "rA5ToolStripMenuItem";
            this.rA5ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA5ToolStripMenuItem.Text = "RA5";
            this.rA5ToolStripMenuItem.Click += new System.EventHandler(this.rA5ToolStripMenuItem_Click);
            // 
            // rA6ToolStripMenuItem
            // 
            this.rA6ToolStripMenuItem.Name = "rA6ToolStripMenuItem";
            this.rA6ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA6ToolStripMenuItem.Text = "RA6";
            this.rA6ToolStripMenuItem.Click += new System.EventHandler(this.rA6ToolStripMenuItem_Click);
            // 
            // rA7ToolStripMenuItem
            // 
            this.rA7ToolStripMenuItem.Name = "rA7ToolStripMenuItem";
            this.rA7ToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.rA7ToolStripMenuItem.Text = "RA7";
            this.rA7ToolStripMenuItem.Click += new System.EventHandler(this.rA7ToolStripMenuItem_Click);
            // 
            // rBToolStripMenuItem
            // 
            this.rBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rB0ToolStripMenuItem,
            this.rB1ToolStripMenuItem,
            this.rB2ToolStripMenuItem,
            this.rB3ToolStripMenuItem,
            this.rB4ToolStripMenuItem,
            this.rB5ToolStripMenuItem,
            this.rB6ToolStripMenuItem,
            this.rB7ToolStripMenuItem});
            this.rBToolStripMenuItem.Name = "rBToolStripMenuItem";
            this.rBToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.rBToolStripMenuItem.Text = "RB";
            // 
            // rB0ToolStripMenuItem
            // 
            this.rB0ToolStripMenuItem.Name = "rB0ToolStripMenuItem";
            this.rB0ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB0ToolStripMenuItem.Text = "RB0";
            this.rB0ToolStripMenuItem.Click += new System.EventHandler(this.rB0ToolStripMenuItem_Click);
            // 
            // rB1ToolStripMenuItem
            // 
            this.rB1ToolStripMenuItem.Name = "rB1ToolStripMenuItem";
            this.rB1ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB1ToolStripMenuItem.Text = "RB1";
            this.rB1ToolStripMenuItem.Click += new System.EventHandler(this.rB1ToolStripMenuItem_Click);
            // 
            // rB2ToolStripMenuItem
            // 
            this.rB2ToolStripMenuItem.Name = "rB2ToolStripMenuItem";
            this.rB2ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB2ToolStripMenuItem.Text = "RB2";
            this.rB2ToolStripMenuItem.Click += new System.EventHandler(this.rB2ToolStripMenuItem_Click);
            // 
            // rB3ToolStripMenuItem
            // 
            this.rB3ToolStripMenuItem.Name = "rB3ToolStripMenuItem";
            this.rB3ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB3ToolStripMenuItem.Text = "RB3";
            this.rB3ToolStripMenuItem.Click += new System.EventHandler(this.rB3ToolStripMenuItem_Click);
            // 
            // rB4ToolStripMenuItem
            // 
            this.rB4ToolStripMenuItem.Name = "rB4ToolStripMenuItem";
            this.rB4ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB4ToolStripMenuItem.Text = "RB4";
            this.rB4ToolStripMenuItem.Click += new System.EventHandler(this.rB4ToolStripMenuItem_Click);
            // 
            // rB5ToolStripMenuItem
            // 
            this.rB5ToolStripMenuItem.Name = "rB5ToolStripMenuItem";
            this.rB5ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB5ToolStripMenuItem.Text = "RB5";
            this.rB5ToolStripMenuItem.Click += new System.EventHandler(this.rB5ToolStripMenuItem_Click);
            // 
            // rB6ToolStripMenuItem
            // 
            this.rB6ToolStripMenuItem.Name = "rB6ToolStripMenuItem";
            this.rB6ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB6ToolStripMenuItem.Text = "RB6";
            this.rB6ToolStripMenuItem.Click += new System.EventHandler(this.rB6ToolStripMenuItem_Click);
            // 
            // rB7ToolStripMenuItem
            // 
            this.rB7ToolStripMenuItem.Name = "rB7ToolStripMenuItem";
            this.rB7ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.rB7ToolStripMenuItem.Text = "RB7";
            this.rB7ToolStripMenuItem.Click += new System.EventHandler(this.rB7ToolStripMenuItem_Click);
            // 
            // timer_Funktionsgenerator
            // 
            this.timer_Funktionsgenerator.Enabled = true;
            this.timer_Funktionsgenerator.Interval = 50;
            this.timer_Funktionsgenerator.Tick += new System.EventHandler(this.timer_Funktionsgenerator_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label_laufzeit);
            this.groupBox3.Location = new System.Drawing.Point(535, 124);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(104, 56);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Laufzeit";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1, 31);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 19);
            this.button2.TabIndex = 2;
            this.button2.Text = "zurücksetzen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_laufzeit
            // 
            this.label_laufzeit.AutoSize = true;
            this.label_laufzeit.Location = new System.Drawing.Point(4, 15);
            this.label_laufzeit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_laufzeit.Name = "label_laufzeit";
            this.label_laufzeit.Size = new System.Drawing.Size(41, 13);
            this.label_laufzeit.TabIndex = 0;
            this.label_laufzeit.Text = "label12";
            // 
            // comboBox_quarzfrequenz
            // 
            this.comboBox_quarzfrequenz.FormattingEnabled = true;
            this.comboBox_quarzfrequenz.Location = new System.Drawing.Point(4, 19);
            this.comboBox_quarzfrequenz.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_quarzfrequenz.Name = "comboBox_quarzfrequenz";
            this.comboBox_quarzfrequenz.Size = new System.Drawing.Size(92, 21);
            this.comboBox_quarzfrequenz.TabIndex = 24;
            this.comboBox_quarzfrequenz.SelectedIndexChanged += new System.EventHandler(this.comboBox_quarzfrequenz_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_quarzfrquenz);
            this.groupBox4.Controls.Add(this.comboBox_quarzfrequenz);
            this.groupBox4.Location = new System.Drawing.Point(535, 43);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(104, 65);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quarzfrequenz";
            // 
            // label_quarzfrquenz
            // 
            this.label_quarzfrquenz.AutoSize = true;
            this.label_quarzfrquenz.Location = new System.Drawing.Point(4, 41);
            this.label_quarzfrquenz.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_quarzfrquenz.Name = "label_quarzfrquenz";
            this.label_quarzfrquenz.Size = new System.Drawing.Size(41, 13);
            this.label_quarzfrquenz.TabIndex = 25;
            this.label_quarzfrquenz.Text = "label13";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_Stack6_Wert);
            this.groupBox5.Controls.Add(this.label_Stack7_Wert);
            this.groupBox5.Controls.Add(this.label_Stack5_Wert);
            this.groupBox5.Controls.Add(this.label_Stack4_Wert);
            this.groupBox5.Controls.Add(this.label_Stack3_Wert);
            this.groupBox5.Controls.Add(this.label_Stack2_Wert);
            this.groupBox5.Controls.Add(this.label_Stack1_Wert);
            this.groupBox5.Controls.Add(this.label_Stack0_Wert);
            this.groupBox5.Controls.Add(this.label_Stack7_Pfeil);
            this.groupBox5.Controls.Add(this.label_Stack6_Pfeil);
            this.groupBox5.Controls.Add(this.label_Stack5_Pfeil);
            this.groupBox5.Controls.Add(this.label_Stack4_Pfeil);
            this.groupBox5.Controls.Add(this.label_Stack3_Pfeil);
            this.groupBox5.Controls.Add(this.label_Stack2_Pfeil);
            this.groupBox5.Controls.Add(this.label_Stack1_Pfeil);
            this.groupBox5.Controls.Add(this.label_Stack0_Pfeil);
            this.groupBox5.Location = new System.Drawing.Point(708, 43);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 235);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Stack";
            // 
            // label_Stack6_Wert
            // 
            this.label_Stack6_Wert.AutoSize = true;
            this.label_Stack6_Wert.Location = new System.Drawing.Point(68, 134);
            this.label_Stack6_Wert.Name = "label_Stack6_Wert";
            this.label_Stack6_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack6_Wert.TabIndex = 15;
            this.label_Stack6_Wert.Text = "label27";
            // 
            // label_Stack7_Wert
            // 
            this.label_Stack7_Wert.AutoSize = true;
            this.label_Stack7_Wert.Location = new System.Drawing.Point(68, 151);
            this.label_Stack7_Wert.Name = "label_Stack7_Wert";
            this.label_Stack7_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack7_Wert.TabIndex = 14;
            this.label_Stack7_Wert.Text = "label26";
            // 
            // label_Stack5_Wert
            // 
            this.label_Stack5_Wert.AutoSize = true;
            this.label_Stack5_Wert.Location = new System.Drawing.Point(68, 117);
            this.label_Stack5_Wert.Name = "label_Stack5_Wert";
            this.label_Stack5_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack5_Wert.TabIndex = 13;
            this.label_Stack5_Wert.Text = "label25";
            // 
            // label_Stack4_Wert
            // 
            this.label_Stack4_Wert.AutoSize = true;
            this.label_Stack4_Wert.Location = new System.Drawing.Point(68, 97);
            this.label_Stack4_Wert.Name = "label_Stack4_Wert";
            this.label_Stack4_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack4_Wert.TabIndex = 12;
            this.label_Stack4_Wert.Text = "label24";
            // 
            // label_Stack3_Wert
            // 
            this.label_Stack3_Wert.AutoSize = true;
            this.label_Stack3_Wert.Location = new System.Drawing.Point(68, 80);
            this.label_Stack3_Wert.Name = "label_Stack3_Wert";
            this.label_Stack3_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack3_Wert.TabIndex = 11;
            this.label_Stack3_Wert.Text = "label23";
            // 
            // label_Stack2_Wert
            // 
            this.label_Stack2_Wert.AutoSize = true;
            this.label_Stack2_Wert.Location = new System.Drawing.Point(68, 60);
            this.label_Stack2_Wert.Name = "label_Stack2_Wert";
            this.label_Stack2_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack2_Wert.TabIndex = 10;
            this.label_Stack2_Wert.Text = "label22";
            // 
            // label_Stack1_Wert
            // 
            this.label_Stack1_Wert.AutoSize = true;
            this.label_Stack1_Wert.Location = new System.Drawing.Point(68, 43);
            this.label_Stack1_Wert.Name = "label_Stack1_Wert";
            this.label_Stack1_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack1_Wert.TabIndex = 9;
            this.label_Stack1_Wert.Text = "label21";
            // 
            // label_Stack0_Wert
            // 
            this.label_Stack0_Wert.AutoSize = true;
            this.label_Stack0_Wert.Location = new System.Drawing.Point(68, 26);
            this.label_Stack0_Wert.Name = "label_Stack0_Wert";
            this.label_Stack0_Wert.Size = new System.Drawing.Size(41, 13);
            this.label_Stack0_Wert.TabIndex = 8;
            this.label_Stack0_Wert.Text = "label20";
            // 
            // label_Stack7_Pfeil
            // 
            this.label_Stack7_Pfeil.AutoSize = true;
            this.label_Stack7_Pfeil.Location = new System.Drawing.Point(7, 151);
            this.label_Stack7_Pfeil.Name = "label_Stack7_Pfeil";
            this.label_Stack7_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack7_Pfeil.TabIndex = 7;
            this.label_Stack7_Pfeil.Text = "label19";
            // 
            // label_Stack6_Pfeil
            // 
            this.label_Stack6_Pfeil.AutoSize = true;
            this.label_Stack6_Pfeil.Location = new System.Drawing.Point(7, 134);
            this.label_Stack6_Pfeil.Name = "label_Stack6_Pfeil";
            this.label_Stack6_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack6_Pfeil.TabIndex = 6;
            this.label_Stack6_Pfeil.Text = "label18";
            // 
            // label_Stack5_Pfeil
            // 
            this.label_Stack5_Pfeil.AutoSize = true;
            this.label_Stack5_Pfeil.Location = new System.Drawing.Point(7, 117);
            this.label_Stack5_Pfeil.Name = "label_Stack5_Pfeil";
            this.label_Stack5_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack5_Pfeil.TabIndex = 5;
            this.label_Stack5_Pfeil.Text = "label17";
            // 
            // label_Stack4_Pfeil
            // 
            this.label_Stack4_Pfeil.AutoSize = true;
            this.label_Stack4_Pfeil.Location = new System.Drawing.Point(7, 97);
            this.label_Stack4_Pfeil.Name = "label_Stack4_Pfeil";
            this.label_Stack4_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack4_Pfeil.TabIndex = 4;
            this.label_Stack4_Pfeil.Text = "label16";
            // 
            // label_Stack3_Pfeil
            // 
            this.label_Stack3_Pfeil.AutoSize = true;
            this.label_Stack3_Pfeil.Location = new System.Drawing.Point(7, 80);
            this.label_Stack3_Pfeil.Name = "label_Stack3_Pfeil";
            this.label_Stack3_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack3_Pfeil.TabIndex = 3;
            this.label_Stack3_Pfeil.Text = "label15";
            // 
            // label_Stack2_Pfeil
            // 
            this.label_Stack2_Pfeil.AutoSize = true;
            this.label_Stack2_Pfeil.Location = new System.Drawing.Point(7, 60);
            this.label_Stack2_Pfeil.Name = "label_Stack2_Pfeil";
            this.label_Stack2_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack2_Pfeil.TabIndex = 2;
            this.label_Stack2_Pfeil.Text = "label14";
            // 
            // label_Stack1_Pfeil
            // 
            this.label_Stack1_Pfeil.AutoSize = true;
            this.label_Stack1_Pfeil.Location = new System.Drawing.Point(7, 43);
            this.label_Stack1_Pfeil.Name = "label_Stack1_Pfeil";
            this.label_Stack1_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack1_Pfeil.TabIndex = 1;
            this.label_Stack1_Pfeil.Text = "label13";
            // 
            // label_Stack0_Pfeil
            // 
            this.label_Stack0_Pfeil.AutoSize = true;
            this.label_Stack0_Pfeil.Location = new System.Drawing.Point(7, 26);
            this.label_Stack0_Pfeil.Name = "label_Stack0_Pfeil";
            this.label_Stack0_Pfeil.Size = new System.Drawing.Size(41, 13);
            this.label_Stack0_Pfeil.TabIndex = 0;
            this.label_Stack0_Pfeil.Text = "label12";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1304, 659);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox_funktionsgenerator);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView_PortB);
            this.Controls.Add(this.dataGridView_PortA);
            this.Controls.Add(this.dataGridView_code);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_Speicher);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PIC Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Speicher)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_intcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_option)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PortA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PortB)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox_funktionsgenerator.ResumeLayout(false);
            this.groupBox_funktionsgenerator.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        public System.Windows.Forms.DataGridView dataGridView_Speicher;
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
        public System.Windows.Forms.DataGridView dataGridView_code;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_pc;
        private System.Windows.Forms.Label label_pclath;
        private System.Windows.Forms.Label label_pcl;
        private System.Windows.Forms.Label label_fsr;
        private System.Windows.Forms.Label label_w_register;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn IRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn RP1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RP0;
        private System.Windows.Forms.DataGridViewTextBoxColumn TO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridView dataGridView_intcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn T0IE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RBIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn T0IF;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTF;
        private System.Windows.Forms.DataGridViewTextBoxColumn RBIF;
        private System.Windows.Forms.Label label_intcon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView_option;
        private System.Windows.Forms.DataGridViewTextBoxColumn RBP;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTEDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn T0CS;
        private System.Windows.Forms.DataGridViewTextBoxColumn T0SE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PS2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PS0;
        private System.Windows.Forms.Label label_option;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_PortA;
        private System.Windows.Forms.DataGridView dataGridView_PortB;
        private System.Windows.Forms.DataGridViewTextBoxColumn __7;
        private System.Windows.Forms.DataGridViewTextBoxColumn __6;
        private System.Windows.Forms.DataGridViewTextBoxColumn __5;
        private System.Windows.Forms.DataGridViewTextBoxColumn __4;
        private System.Windows.Forms.DataGridViewTextBoxColumn __3;
        private System.Windows.Forms.DataGridViewTextBoxColumn __2;
        private System.Windows.Forms.DataGridViewTextBoxColumn __1;
        private System.Windows.Forms.DataGridViewTextBoxColumn __0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button IgnoreButton;
        private System.Windows.Forms.Button StepOutButton;
        private System.Windows.Forms.Button StepOverButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button StepInButton;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.GroupBox groupBox_funktionsgenerator;
        private System.Windows.Forms.TextBox textBox_FG_verhältnis;
        private System.Windows.Forms.TextBox textBox_FG_frequenz;
        private System.Windows.Forms.TextBox textBox_FG_pin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem nctoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rB7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rA0ToolStripMenuItem;
        private System.Windows.Forms.Timer timer_Funktionsgenerator;
        private System.Windows.Forms.DataGridViewTextBoxColumn _4;
        private System.Windows.Forms.DataGridViewTextBoxColumn _3;
        private System.Windows.Forms.DataGridViewTextBoxColumn _2;
        private System.Windows.Forms.DataGridViewTextBoxColumn _1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _0;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox_quarzfrequenz;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_quarzfrquenz;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        internal System.Windows.Forms.Label label_laufzeit;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Label label_Stack6_Wert;
        internal System.Windows.Forms.Label label_Stack7_Wert;
        internal System.Windows.Forms.Label label_Stack5_Wert;
        internal System.Windows.Forms.Label label_Stack4_Wert;
        internal System.Windows.Forms.Label label_Stack3_Wert;
        internal System.Windows.Forms.Label label_Stack2_Wert;
        internal System.Windows.Forms.Label label_Stack1_Wert;
        internal System.Windows.Forms.Label label_Stack0_Wert;
        internal System.Windows.Forms.Label label_Stack7_Pfeil;
        internal System.Windows.Forms.Label label_Stack6_Pfeil;
        internal System.Windows.Forms.Label label_Stack5_Pfeil;
        internal System.Windows.Forms.Label label_Stack4_Pfeil;
        internal System.Windows.Forms.Label label_Stack3_Pfeil;
        internal System.Windows.Forms.Label label_Stack2_Pfeil;
        internal System.Windows.Forms.Label label_Stack1_Pfeil;
        internal System.Windows.Forms.Label label_Stack0_Pfeil;
    }
}

