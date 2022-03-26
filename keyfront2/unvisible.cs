using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyfront2
{
    public partial class unvisible : Form
    {
        public unvisible()
        {
            InitializeComponent();
        }

        private void unvisible_Load(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.BackgroundColor == Color.Gray) dataGridView1.BackgroundColor = Color.Black;
            else if (dataGridView1.BackgroundColor == Color.Black) dataGridView1.BackgroundColor = Color.White;
            else if (dataGridView1.BackgroundColor == Color.White) dataGridView1.BackgroundColor = Color.Gray;
        }
    }
}
