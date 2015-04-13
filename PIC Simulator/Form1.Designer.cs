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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(514, 312);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1230, 457);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
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
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.ladenToolStripMenuItem.Text = "laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.schließenToolStripMenuItem.Text = "schließen";
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
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
            this.dataGridView1.Location = new System.Drawing.Point(16, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(324, 290);
            this.dataGridView1.TabIndex = 3;
            // 
            // Spalte0
            // 
            this.Spalte0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Spalte0.HeaderText = "00";
            this.Spalte0.MaxInputLength = 2;
            this.Spalte0.Name = "Spalte0";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1865, 811);
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
    }
}

