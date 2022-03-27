using System;
using System.Windows;

namespace keyfront2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = null;
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
            ToolStripMenuItem newTextFormItem = new ToolStripMenuItem("Text box");
            newTextFormItem.Click += newTextFormItem_Click;


            menuStrip1.Items.Add(formsItem);
            formsItem.DropDownItems.Add(newFormsItem);
            formsItem.DropDownItems.Add(newFormsItem1);
            formsItem.DropDownItems.Add(newTextFormItem);

            ToolStripMenuItem dataItem = new ToolStripMenuItem("Data");
            ToolStripMenuItem hideHistoryItem = new ToolStripMenuItem("Hide current note history");
            hideHistoryItem.Click += hideHistoryItem_Click;
            menuStrip1.Items.Add(dataItem);
            dataItem.DropDownItems.Add(hideHistoryItem);

            ToolStripMenuItem settingsItem = new ToolStripMenuItem("Settings");
            //ToolStripMenuItem hideHistoryItem = new ToolStripMenuItem("Hide current note history");
            settingsItem.Click += settingsItem_Click;
            menuStrip1.Items.Add(settingsItem);
            //dataItem.DropDownItems.Add(hideHistoryItem);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("Info");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Your note for the day";
            textBox1.ForeColor = Color.Gray;
            settings.opacityOA = opacityOA;
            settings.theme = themeOA;
            settings.descTheme = descThemeF1;
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


        //private void button3_Click(object sender, EventArgs e)
        //{
            
        //    unvisible unvisible1= new unvisible();
        //    unvisible1.Show();

        //}
        

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
                //Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())] = textBox1.Text;
                if (Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())] == textBox1.Text) ;
                else
                {
                    Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())] = textBox1.Text;
                    updateTextBox(Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString()));
                }
            }
            else 
            {
                ++n;
                Mas.Add(textBox1.Text);
                Mas1.Add(dateTimePicker1.Value.ToShortDateString());
                updateTextBox(Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString()));
            }
        }


        //private void button4_Click(object sender, EventArgs e)
        //{
        //    Form2 calendar = new Form2();
        //    calendar.Show();
        //}
        void newTextFormItem_Click(object sender, EventArgs e)
        {
            TextForm textForm = new TextForm();
            opacityOA = settings.opacityOA;
            themeOA = settings.theme;
            textForm.theme_change(themeOA);
            textForm.Opacity = opacityOA;
            textForm.Show();
            
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
        Settings settings = new Settings();
        void settingsItem_Click(object sender, EventArgs e)
        {
            settings = new Settings();
            settings.opacityOA = opacityOA;
            settings.theme = themeOA;
            settings.descTheme = descThemeF1;
            settings.ShowDialog();
            if (!settings.IsDisposed)
            {
                opacityOA = settings.opacityOA;
                themeOA = settings.theme;
                if (descThemeF1 != settings.descTheme)
                {
                    descThemeF1 = settings.descTheme;
                    changeTheme(descThemeF1);
                }
            }

        }
        void changeTheme(int dt)
        {
            //if (dt == 1)
            //{
            //    this.BackgroundImage = Image.FromFile("lighttable.jpg");
            //}
            //else if (dt == 0)
            //{
            //    this.BackgroundImage = Image.FromFile("table.jpg");
            //}
            //else if (dt == 2)
            //{
            //    this.BackgroundImage = Image.FromFile("brick.jpg");
            //}
            switch (dt)
            {
                case 1:
                    this.BackgroundImage = Image.FromFile("lighttable.jpg");
                    break;
                case 2:
                    this.BackgroundImage = Image.FromFile("brick.jpg");
                    break;
                default:
                    this.BackgroundImage = Image.FromFile("table.jpg");
                    break;
            }
        }
        void saveItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Visible) this.dataGridView1.Visible = false;
            else this.dataGridView1.Visible = true;
        }
        void newFormsItem_Click(object sender, EventArgs e)
        {
            unvisible unvisible1 = new unvisible();
            opacityOA = settings.opacityOA;
            unvisible1.Opacity = opacityOA;
            unvisible1.Show();
        }
        void newFormsItem1_Click(object sender, EventArgs e)
        {
            Form2 calendar = new Form2();
            opacityOA = settings.opacityOA;
            calendar.Opacity = opacityOA;
            calendar.Show();
        }
        void hideHistoryItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
        }
        void visibilityCalendarItem_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Visible)
            {
                this.dateTimePicker1.Visible = false;
                this.textBox1.Visible = false;
                this.textBox2.Visible = false;
                this.button1.Visible = false;
                this.label1.Visible = false;
                this.button2.Visible = false;
                this.label2.Visible = false;
            }
            else
            {
                this.dateTimePicker1.Visible = true;
                this.textBox1.Visible = true;
                this.textBox2.Visible = true;
                this.button1.Visible = true;
                this.label1.Visible = true;
                this.button2.Visible = true;
                this.label2.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Focused && textBox1.ForeColor == Color.Gray) textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }


        private void button1_Click(object sender, EventArgs e)

        {
            if (textBox1.Text != "") this.newNote();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void updateTextBox(int i)
        {
            if (textBox2.Text != "") textBox2.Text += "\r\n";
            textBox2.Text += Mas1[i] + "|" + Mas[i];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Height == 108)
            {
                textBox2.Height = 408;
                button2.Location = new Point(469, 554);
            }
            else
            {
                textBox2.Height = 108;
                button2.Location = new Point(469, 254);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public double opacityOA = 0.5;
        public int themeOA = 0;
        public int descThemeF1 = 0;
        

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}