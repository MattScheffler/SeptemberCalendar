using System;
using System.Windows.Forms;


namespace SeptemberCalendar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dayButtonClick(object sender, EventArgs e)
        {
            //make a new form for whatever day was selected and hide main form until day is closed
            var dayForm = new DayForm();
            var date = (Button)sender;
            dayForm.Text = date.Text + " September 2016";
            this.Hide();
            dayForm.ShowDialog();

            //change the color of the selected date if needed
            if ((int)Properties.Settings.Default["DateColor"] == 1)
            {
                var button = (Button)sender;
                button.BackColor = System.Drawing.Color.Aqua;
            }

            //bring back the main form
            this.Show();
        }
    }
}
