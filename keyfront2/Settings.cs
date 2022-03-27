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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            string[] themes = { "Light", "Black" };
            listBox1.Items.AddRange(themes);

            string[] descThemes = { "Default", "Light wood", "Bricks" };
            listBox2.Items.AddRange(descThemes);

            //listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            if (opacityOA == 0.14) trackBar1.Value = 0;
            else if (opacityOA == 0.29) trackBar1.Value = 1;
            else if (opacityOA == 0.43) trackBar1.Value = 2;
            else if (opacityOA == 0.57) trackBar1.Value = 3;
            else if (opacityOA == 0.71) trackBar1.Value = 4;
            else if (opacityOA == 0.86) trackBar1.Value = 5;
            else if (opacityOA == 1) trackBar1.Value = 6;

            if (theme == 0)
            {
                listBox1.SelectedIndex = 0;
                this.BackColor = Color.Gainsboro;
                this.label1.ForeColor = Color.Black;
                this.label2.ForeColor = Color.Black;
                this.label3.ForeColor = Color.Black;
            }
            else if (theme == 1)
            {
                listBox1.SelectedIndex = 1;
                this.BackColor = Color.FromArgb(255, 64, 64, 64);
                this.label1.ForeColor = Color.White;
                this.label2.ForeColor = Color.White;
                this.label3.ForeColor = Color.White;
            }

            switch (descTheme)
            {
                case 1:
                    listBox2.SelectedIndex = 1;
                    break;
                case 2:
                    listBox2.SelectedIndex = 2;
                    break;
                default:
                    listBox2.SelectedIndex = 0;
                    break;
            }
        }

        public double opacityOA;
        public int descTheme;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (trackBar1.Value)
            {
                case 0:
                    opacityOA = 0.14;
                    break;
                case 1:
                    opacityOA = 0.29;
                    break;
                case 2:
                    opacityOA = 0.43;
                    break;
                case 3:
                    opacityOA = 0.57;
                    break;
                case 4:
                    opacityOA = 0.71;
                    break;
                case 5:
                    opacityOA = 0.86;
                    break;
                case 6:
                    opacityOA = 1;
                    break;
                default:
                    opacityOA = 1;
                    break;
            }
        }

        public int theme;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            theme = listBox1.SelectedIndex;
            if (theme == 0)
            {
                //listBox1.SelectedIndex = 0;
                this.BackColor = Color.Gainsboro;
                this.label1.ForeColor = Color.Black;
                this.label2.ForeColor = Color.Black;
                this.label3.ForeColor = Color.Black;
            }
            else if (theme == 1)
            {
                //listBox1.SelectedIndex = 1;
                this.BackColor = Color.FromArgb(255, 64, 64, 64);
                this.label1.ForeColor = Color.White;
                this.label2.ForeColor = Color.White;
                this.label3.ForeColor = Color.White;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            descTheme = listBox2.SelectedIndex;
            
        }
    }
}
