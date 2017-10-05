using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCampProject
{
    public partial class RegisterActivities : Form
    {
        public RegisterActivities()
        {
            InitializeComponent();
        }

        private void RegisterActivities_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String test = dateTimePicker1.Value.ToString();
            MessageBox.Show(dateTimePicker1.Value.ToString());
            dateTimePicker1.Value = DateTime.Parse(test);
        }
    }
}
