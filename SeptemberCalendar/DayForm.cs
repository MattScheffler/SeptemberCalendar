using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace SeptemberCalendar
{
    public partial class DayForm : Form
    {
        public DayForm()
        {
            InitializeComponent();
        }

        private void buttonCloseDayForm_Click(object sender, EventArgs e)
        {
            if (richTextBox.Text != string.Empty)
                Properties.Settings.Default["DateColor"] = 1;
            else
                Properties.Settings.Default["DateColor"] = 0;
            Properties.Settings.Default.Save();
            this.Close();
        }

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
