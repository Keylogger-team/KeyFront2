using System;
using System.Windows;

namespace keyfront2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.dataGridView1.BackgroundColor = Color.FromArgb(255, 105, 105, 105);

            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;


            ToolStripMenuItem fileItem = new ToolStripMenuItem("View");

            ToolStripMenuItem newItem = new ToolStripMenuItem("Visibility") { Checked = true, CheckOnClick = true };
            newItem.Click += newItem_Click;
            fileItem.DropDownItems.Add(newItem);
            


            ToolStripMenuItem saveItem = new ToolStripMenuItem("Todo list") { Checked = true, CheckOnClick = true };
            saveItem.Click += saveItem_Click;


            fileItem.DropDownItems.Add(saveItem);

            ToolStripMenuItem visibilityCalendarItem = new ToolStripMenuItem("Calendar") { Checked = true, CheckOnClick = true };
            visibilityCalendarItem.Click += visibilityCalendarItem_Click;


            fileItem.DropDownItems.Add(visibilityCalendarItem);

            menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem formsItem = new ToolStripMenuItem("Window");
            ToolStripMenuItem newFormsItem = new ToolStripMenuItem("Todo list");
            newFormsItem.Click += newFormsItem_Click;
            ToolStripMenuItem newFormsItem1 = new ToolStripMenuItem("Calendar");
            newFormsItem1.Click += newFormsItem1_Click;
            menuStrip1.Items.Add(formsItem);
            formsItem.DropDownItems.Add(newFormsItem);
            formsItem.DropDownItems.Add(newFormsItem1);


            ToolStripMenuItem aboutItem = new ToolStripMenuItem("Info");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Your note for the day";
            textBox1.ForeColor = Color.Gray;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = String.Format("Chosen data: {0}", dateTimePicker1.Value.ToShortDateString());

            if (textBox1.ForeColor != Color.Gray) textBox1.Text = null;
            
            if (Mas1.Contains(dateTimePicker1.Value.ToShortDateString()))
            {
                textBox1.Text = Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())];
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            
            unvisible unvisible1= new unvisible();
            unvisible1.Show();

        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private int n = 0;
        private List<string> Mas = new List<string>();
        private List<string> Mas1 = new List<string>();
        private void notes(object sender, EventArgs e)
        {
            
        }

        private void newNote()
        {
            if (Mas1.Contains(dateTimePicker1.Value.ToShortDateString()))
            {
                Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())] = textBox1.Text;
            }
            else 
            {
                ++n;
                Mas.Add(textBox1.Text);
                Mas1.Add(dateTimePicker1.Value.ToShortDateString());
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Form2 calendar = new Form2();
            calendar.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
        void newItem_Click(object sender, EventArgs e)
        {
            if (Opacity == 1) Opacity = 0.50;
            else Opacity = 1;
        }
        void saveItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Visible) this.dataGridView1.Visible = false;
            else this.dataGridView1.Visible = true;
        }
        void newFormsItem_Click(object sender, EventArgs e)
        {
            unvisible unvisible1 = new unvisible();
            unvisible1.Show();
        }
        void newFormsItem1_Click(object sender, EventArgs e)
        {
            Form2 calendar = new Form2();
            calendar.Show();
        }
        void visibilityCalendarItem_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Visible)
            {
                this.dateTimePicker1.Visible = false;
                this.textBox1.Visible = false;
                this.button1.Visible = false;
                this.label1.Visible = false;
            }
            else
            {
                this.dateTimePicker1.Visible = true;
                this.textBox1.Visible = true;
                this.button1.Visible = true;
                this.label1.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Focused && textBox1.ForeColor == Color.Gray) textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.newNote();

        }

    }
}