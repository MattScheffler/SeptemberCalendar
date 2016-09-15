using System;
using System.Windows.Forms;
using System.Xml.Linq;


namespace SeptemberCalendar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            colorChange();
        }

        private void dayButtonClick(object sender, EventArgs e)
        {
            //make a new form for whatever day was selected and hide main form until day is closed.
            DayForm dayForm = new DayForm();
            Button date = (Button)sender;
            dayForm.Text = date.Text + " September 2016";
            dayForm.ShowDialog();
            this.Show();
            colorChange();
        }

        //Checks each day, if any data exists for a day the color of the button for it is changed, else the color goes to default.
        public void colorChange()
        {
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10,
            button11, button12, button13, button14, button15, button16, button17, button18, button19, button20,
            button21, button22, button23, button24, button25, button26, button27, button28, button29, button30};

            int day = 0;
            var root = XElement.Load("SeptemberData.xml");
            foreach (XElement data in root.Elements())
            {
                if (data.Element("data").Value != String.Empty)
                {
                    buttons[day].BackColor = System.Drawing.Color.Aqua;
                }
                else
                    buttons[day].BackColor = Button.DefaultBackColor;
                ++day;
            }
        }
    }
}
