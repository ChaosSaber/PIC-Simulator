namespace Funktionsgenerator
{
    partial class Form1
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
            this.dataGridView_FG = new System.Windows.Forms.DataGridView();
            this.Kanal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FG)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_FG
            // 
            this.dataGridView_FG.AllowUserToAddRows = false;
            this.dataGridView_FG.AllowUserToDeleteRows = false;
            this.dataGridView_FG.AllowUserToResizeColumns = false;
            this.dataGridView_FG.AllowUserToResizeRows = false;
            this.dataGridView_FG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kanal1});
            this.dataGridView_FG.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_FG.Name = "dataGridView_FG";
            this.dataGridView_FG.RowHeadersWidth = 85;
            this.dataGridView_FG.RowTemplate.Height = 24;
            this.dataGridView_FG.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_FG.Size = new System.Drawing.Size(203, 115);
            this.dataGridView_FG.TabIndex = 0;
            // 
            // Kanal1
            // 
            this.Kanal1.HeaderText = "Kanal1";
            this.Kanal1.Name = "Kanal1";
            this.Kanal1.Width = 65;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 317);
            this.Controls.Add(this.dataGridView_FG);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_FG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kanal1;
    }
}

