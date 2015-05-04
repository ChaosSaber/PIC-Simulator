using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funktionsgenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView_FG.Rows.Add();
            dataGridView_FG.Rows.Add();
            dataGridView_FG.Rows.Add();
            dataGridView_FG.Rows[0].HeaderCell.Value = "Port-Pin";
            dataGridView_FG.Rows[1].HeaderCell.Value = "Frequenz(Hz)";
            dataGridView_FG.Rows[2].HeaderCell.Value = "Verhältnis";
        }
    }
}
