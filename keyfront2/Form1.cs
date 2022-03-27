using System;
using System.Windows;

namespace keyfront2
{
    public partial class Form1 : Form
    {
        //<numeration format>
        //a.b.c: 
        //a - form number: 1 - Form1(main), 2 - invisible(Todo), 3 - Form2(Calendar), 4 - TextForm, 5 - Settings
        //b - block/element of the current form
        //c - details

        public Form1()
        {
            InitializeComponent();
            //-----------------------------------------------------------------------
            //1.1.1
            //the clock settings
            //-----------------------------------------------------------------------
            label3.Text = "";
            textBox2.Text = null;
            timer1.Enabled = true;
            timer1.Interval = 1000;
            //-----------------------------------------------------------------------
            //1.2.1
            //the dateTimePicker settings: "Chosen date" filling
            //-----------------------------------------------------------------------
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            //-----------------------------------------------------------------------
            //1.3.1
            //the ToolStripMenu: the head of the program
            //-----------------------------------------------------------------------
                    //1.3.1 
                    //View
            ToolStripMenuItem fileItem = new ToolStripMenuItem("View");

                                //Visibility
            ToolStripMenuItem newItem = new ToolStripMenuItem("Visibility") { Checked = true, CheckOnClick = true };
            newItem.Click += newItem_Click;
            fileItem.DropDownItems.Add(newItem);

                                //Todo list
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Todo list") { Checked = true, CheckOnClick = true };
            saveItem.Click += saveItem_Click;
            fileItem.DropDownItems.Add(saveItem);

                                //Calendar
            ToolStripMenuItem visibilityCalendarItem = new ToolStripMenuItem("Calendar") { Checked = true, CheckOnClick = true };
            visibilityCalendarItem.Click += visibilityCalendarItem_Click;
            fileItem.DropDownItems.Add(visibilityCalendarItem);

            menuStrip1.Items.Add(fileItem);

                    //1.3.2
                    //Window
            ToolStripMenuItem formsItem = new ToolStripMenuItem("Window");
                                //Open the window
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

                    //1.3.3
                    //Data
            ToolStripMenuItem dataItem = new ToolStripMenuItem("Data");
                                //Hide history
            ToolStripMenuItem hideHistoryItem = new ToolStripMenuItem("Hide current note history");
            hideHistoryItem.Click += hideHistoryItem_Click;
            menuStrip1.Items.Add(dataItem);
            dataItem.DropDownItems.Add(hideHistoryItem);

                    //1.3.4
                    //Settings
            ToolStripMenuItem settingsItem = new ToolStripMenuItem("Settings");
            settingsItem.Click += settingsItem_Click;
            menuStrip1.Items.Add(settingsItem);

                    //1.3.5
                    //Info & how to start working
            ToolStripMenuItem aboutItem = new ToolStripMenuItem("Info");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);
            //-----------------------------------------------------------------------
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------
            //1.2.3
            //prompt for enable to edit field
            textBox1.Text = "Your note for the day";
            textBox1.ForeColor = Color.Gray;
            //-----------------------------------------------------------------------
            //5.1.1
            //temp settings
            settings.opacityOA = opacityOA;
            settings.theme = themeOA;
            settings.descTheme = descThemeF1;
            //-----------------------------------------------------------------------
        }

        //-----------------------------------------------------------------------

        //settings params
        public double opacityOA = 0.5;  //windows visibility
        public int themeOA = 0;         //cur theme
        public int descThemeF1 = 0;     //cur desctop theme

        //-----------------------------------------------------------------------

        //1.1.1
        //the clock settings
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }
        //-----------------------------------------------------------------------

        //1.1.1
        //clock text field
        private void label3_Click(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------

        //1.2.1
        //the dateTimePicker settings
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Chosen date field
            label1.Text = String.Format("Chosen date: {0}", dateTimePicker1.Value.ToShortDateString());

            //Notes field
                    //if there are no notes, do not reset notes
            if (textBox1.ForeColor != Color.Gray) textBox1.Text = null;

                    //if there is a note on the selected day, show it
            if (Mas1.Contains(dateTimePicker1.Value.ToShortDateString()))
            {
                textBox1.Text = Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())];
            }
        }
        //-----------------------------------------------------------------------

        //1.2.2
        //label1 (Chosen date)
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------
        //notes fields
        private int n = 0;                                  //notes counter
        private List<string> Mas = new List<string>();      //notes list
        private List<string> Mas1 = new List<string>();     //dates list
        //-----------------------------------------------------------------------

        //1.2.3
        //create new note
        private void newNote()
        {
            //will not create the new note if there is note with current date
            if (Mas1.Contains(dateTimePicker1.Value.ToShortDateString()))
            {
                //if the content of the note has not changed, it is not loaded into the history
                if (Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())] == textBox1.Text) ;
                else
                {
                    Mas[Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString())] = textBox1.Text;
                    updateTextBox(Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString()));
                }
            }
            //case new date, new note
            else
            {
                ++n;
                Mas.Add(textBox1.Text);
                Mas1.Add(dateTimePicker1.Value.ToShortDateString());
                updateTextBox(Mas1.IndexOf(dateTimePicker1.Value.ToShortDateString()));
            }
        }
        //-----------------------------------------------------------------------

        //1.2.3
        //delete the prompt
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Focused && textBox1.ForeColor == Color.Gray) textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }
        //-----------------------------------------------------------------------

        //1.2.4
        //notes history field
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------
        //1.2.4
        //new note in history
        void updateTextBox(int i)
        {
            if (textBox2.Text != "") textBox2.Text += "\r\n";
            textBox2.Text += Mas1[i] + "|" + Mas[i];

        }
        //-----------------------------------------------------------------------

        //1.2.4
        //History label
        private void label2_Click(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------

        //1.2.5
        //push button
        private void button1_Click(object sender, EventArgs e)

        {
            if (textBox1.Text != "") this.newNote();

        }
        //-----------------------------------------------------------------------

        //1.2.6
        //history field size change button
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
        //-----------------------------------------------------------------------

        //1.3.1
        //menu strip
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //-----------------------------------------------------------------------

        //1.3.1
        //visibility
        void newItem_Click(object sender, EventArgs e)
        {
            if (Opacity == 1) Opacity = 0.50;
            else Opacity = 1;
        }
        //-----------------------------------------------------------------------

        //1.3.1
        //hide ToDo list (dataGrid)
        void saveItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Visible) this.dataGridView1.Visible = false;
            else this.dataGridView1.Visible = true;
        }
        //-----------------------------------------------------------------------

        //1.3.1
        //Change calendar visibility
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
        //-----------------------------------------------------------------------

        //1.3.2 //2.1.1
        //ToDo new window
        void newFormsItem_Click(object sender, EventArgs e)
        {
            unvisible unvisible1 = new unvisible();
            opacityOA = settings.opacityOA;
            unvisible1.Opacity = opacityOA;
            unvisible1.Show();
        }
        //-----------------------------------------------------------------------

        //1.3.2 //3.1.1
        //Calendar newWindow
        void newFormsItem1_Click(object sender, EventArgs e)
        {
            Form2 calendar = new Form2();
            opacityOA = settings.opacityOA;
            calendar.Opacity = opacityOA;
            calendar.Show();
        }
        //-----------------------------------------------------------------------

        //1.3.3
        //Hide the notes history
        void hideHistoryItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
        }
        //-----------------------------------------------------------------------

        //1.3.4
        //settings Item (Menu strip)
        void settingsItem_Click(object sender, EventArgs e)
        {
            //temp settings
            settings = new Settings();
            settings.opacityOA = opacityOA;
            settings.theme = themeOA;
            settings.descTheme = descThemeF1;
            settings.ShowDialog();

            //save current settings if the settings-form was closed
            if (!settings.IsDisposed)
            {
                opacityOA = settings.opacityOA;
                themeOA = settings.theme;
                //it theme settings were changed -> change the theme
                if (descThemeF1 != settings.descTheme)
                {
                    descThemeF1 = settings.descTheme;
                    changeTheme(descThemeF1);
                }
            }
        }
        //-----------------------------------------------------------------------

        //1.3.5
        //info
        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
        //-----------------------------------------------------------------------

        //1.4.0
        //timer fields: sec,min,hour
        int s, m, h;
        //-----------------------------------------------------------------------

        //1.4.0
        //timer counter & notification
        private void timer2_Tick(object sender, EventArgs e)
        {
            s = s - 1;
            if (s == -1)
            {
                m = m - 1;
                s = 59;
            }

            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }
            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }
            if (h == 0 && m == 0 && s == 0)
            {
                timer1.Stop();
                MessageBox.Show("Time is over!");
            }
        }
        //-----------------------------------------------------------------------

        //1.4.1
        //dataGrid (ToDo list)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //-----------------------------------------------------------------------

        //1.4.1
        //timer 1 button
        private void button3_Click(object sender, EventArgs e)
        {
            s = 0;
            m = 1;
            h = 0;
            timer2.Start();
        }
        //-----------------------------------------------------------------------
       
        //1.4.2
        //timer 2 button
        private void button5_Click(object sender, EventArgs e)
        {
            s = 0;
            m = 10;
            h = 0;
            timer2.Start();
        }
        //-----------------------------------------------------------------------
        //1.4.3
        //timer 3 button
        private void button4_Click(object sender, EventArgs e)
        {
            s = 0;
            m = 5;
            h = 0;
            timer2.Start();
        }
        //-----------------------------------------------------------------------

        //4.1.1
        //create text form
        void newTextFormItem_Click(object sender, EventArgs e)
        {
            TextForm textForm = new TextForm();

            //temp settings
            opacityOA = settings.opacityOA;
            themeOA = settings.theme;
            textForm.theme_change(themeOA);
            textForm.Opacity = opacityOA;

            textForm.Show();

        }
        //-----------------------------------------------------------------------

        //5.1.1
        //settings field-form (current settings)
        Settings settings = new Settings();
        //-----------------------------------------------------------------------

        //5.4.1
        //change desctop theme
        void changeTheme(int dt)
        {
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
       
        //-----------------------------------------------------------------------
        //wtf? DONT DELETE!
        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------
    }
}