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
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void theme_change(int themeID)
        {
            if (themeID == 0)
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
            }
            else if (themeID == 1)
            {
                textBox1.BackColor = Color.Black;
                textBox1.ForeColor = Color.White;
            }
        }


    }
}
