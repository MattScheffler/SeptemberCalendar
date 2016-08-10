using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SeptemberCalendar
{
    public partial class DayForm : Form
    {
        public DayForm()
        {
            InitializeComponent();
        }

        //close the form, if the user added information update the setting to change button colors on the main form
        private void buttonCloseDayForm_Click(object sender, EventArgs e)
        {
            if (richTextBox.Text != string.Empty)
                Properties.Settings.Default["DateColor"] = 1;
            else
                Properties.Settings.Default["DateColor"] = 0;
            Properties.Settings.Default.Save();
            this.Close();
        }

        //load the XML document to save the information in the correct day
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var root = XElement.Load("SeptemberData.xml");
            foreach (XElement day in root.Elements())
            {
                if (day.Element("date").Value == this.Text)
                    day.Element("data").Value = richTextBox.Text;
            }
            root.Save("SeptemberData.xml");
        }

        //load the user input for the day if any exists already
        private void DayForm_Load(object sender, EventArgs e)
        {
            var root = XElement.Load("SeptemberData.xml");
            foreach (XElement day in root.Elements())
            {
                if (day.Element("date").Value == this.Text)
                    richTextBox.Text = day.Element("data").Value;
            }
        }
    }
}
