using System;
using System.Windows;
namespace keyfront2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = String.Format("Chosen data: {0}", dateTimePicker1.Value.ToShortDateString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hidden process");
            if (Opacity == 1) Opacity = 0.50;
            else Opacity = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("size is changed");
            if (this.Height == 788 && this.Width == 1359) Size = new Size(500, 500);
            else Size = new Size(1359, 788);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SetForegroundWindow(hwnd);
            //if (button1.Enabled)
            //{
            //    button1.Enabled = false;
            //    button2.Enabled = false;
            //    dataGridView1.Enabled = false;
            //    monthCalendar1.Enabled = false;
            //    dateTimePicker1.Enabled = false;
            //}
            //else
            //{
            //    button1.Enabled = true;
            //    button2.Enabled = true;
            //    dataGridView1.Enabled = true;
            //    monthCalendar1.Enabled = true;
            //    dateTimePicker1.Enabled = true;
            //
            unvisible unvisible1= new unvisible();
            unvisible1.Show();
            //Form1.Close();
            //Application.Exit();
            //if (Form.ActiveForm == unvisible1) Application.Exit();
            //Hide();
        }
        //dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}