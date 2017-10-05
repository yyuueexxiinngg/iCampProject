using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace iCampProject
{
    public partial class Register : Form
    {
        string cs = @"server=localhost;userid=root;password='';database=icamp";
        MySqlConnection conn = null;
        MySqlDataReader reader = null;


        public Register()
        {
            InitializeComponent();
        }

        private void newCamper_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                String cmdText = "SELECT name FROM camper_info"; // sql command as string
                MySqlCommand cmd = new MySqlCommand(cmdText, conn); // set the command to the connection
                reader = cmd.ExecuteReader(); // excute and get into the datareader
                //cmd.ExecuteNonQuery(); Execute with no query
                while (reader.Read())
                {
                    combo_select_camper.Items.Add(reader.GetString(0)); // get the information as a string at the column index 0
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally // what to do after try/catch is done
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void combo_select_camper_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = combo_select_camper.SelectedItem.ToString();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                String cmdText = "SELECT * FROM camper_info WHERE name='" + name + "'";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    camper_name.Text = reader.GetString(1);
                    camper_preferred_name.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    camper_bunk.Text = reader.GetString(3);
                    camper_age.Text = reader.GetString(4);
                    camper_nationality.Text = reader.GetString(5);
                    camper_restriction.Text = reader.IsDBNull(6) ? "" : reader.GetString(6);
                    camper_medications.Text = reader.IsDBNull(7) ? "" : reader.GetString(7);
                    camper_start_date.Text = reader.GetString(8);
                    camper_leave_date.Text = reader.GetString(9);
                    camper_transportation.Text = reader.GetString(10);
                    camper_parent1_name.Text = reader.GetString(11);
                    camper_parent1_phone.Text = reader.GetString(12);
                    camper_parent1_email.Text = reader.IsDBNull(13) ? "" : reader.GetString(13);
                    camper_parent2_name.Text = reader.IsDBNull(14) ? "" : reader.GetString(14);
                    camper_parent2_phone.Text = reader.IsDBNull(15) ? "" : reader.GetString(15);
                    camper_parent2_email.Text = reader.IsDBNull(16) ? "" : reader.GetString(16);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
