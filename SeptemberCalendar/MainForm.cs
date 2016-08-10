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

        }

        private void dayButtonClick(object sender, EventArgs e)
        {
            var dayForm = new DayForm();
            var date = (Button)sender;
            dayForm.Text = date.Text + " September 2016";
            this.Hide();
            dayForm.ShowDialog();
            if ((int)Properties.Settings.Default["DateColor"] == 1)
            {
                var button = (Button)sender;
                button.BackColor = System.Drawing.Color.Aqua;
            }

            this.Show();
        }
    }
}
