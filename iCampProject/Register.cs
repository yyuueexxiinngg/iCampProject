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

        private void ClearText(Control ctrlTop)
        {
            if (ctrlTop.GetType() == typeof(TextBox))
                ctrlTop.Text = "";
            else
            {
                foreach (Control ctrl in ctrlTop.Controls)
                {
                    ClearText(ctrl);
                }
            }
        }

        private void newCamper_Click(object sender, EventArgs e)
        {
            combo_select_camper.SelectedIndex = -1;
            dateTimePicker_start.Value = DateTime.Now;
            dateTimePicker_leave.Value = DateTime.Now;
            ClearText(this);
        }

        private void Register_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                String cmdText = "SELECT name FROM camper_info"; 
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    combo_select_camper.Items.Add(reader.GetString(0));
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

        private void combo_select_camper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_select_camper.SelectedIndex != -1)
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
                        dateTimePicker_start.Value = DateTime.Parse(reader.GetString(8));
                        //camper_start_date.Text = reader.GetString(8);
                        dateTimePicker_leave.Value = DateTime.Parse(reader.GetString(9));
                        //camper_leave_date.Text = reader.GetString(9);
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

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (combo_select_camper.SelectedIndex == -1)
            {
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    String cmdtext = "INSERT INTO camper_info (" +
                        "`name`, `preferred_name`, `bunk`, `age`, `nationality`, `restriction`, `medications`, `start_date`, `leave_date`, `transportation`, `parent1_name`, `parent1_phone`, `parent1_email`, `parent2_name`, `parent2_phone`, `parent2_email`) " +
                        "VALUES ('" +
                        camper_name.Text + "', '" +
                        camper_preferred_name.Text + "', '" +
                        camper_bunk.Text + "', '" +
                        camper_age.Text + "', '" +
                        camper_nationality.Text + "', '" +
                        camper_restriction.Text + "', '" +
                        camper_medications.Text + "', '" +
                        dateTimePicker_start.Value.ToString() + "', '" +
                        dateTimePicker_leave.Value.ToString() + "', '" +
                        camper_transportation.Text + "', '" +
                        camper_parent1_name.Text + "', '" +
                        camper_parent1_phone.Text + "', '" +
                        camper_parent1_email.Text + "', '" +
                        camper_parent2_name.Text + "', '" +
                        camper_parent2_phone.Text + "', '" +
                        camper_parent2_email.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(cmdtext, conn);
                    cmd.ExecuteNonQuery();
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
            else
            {
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    String cmdtext = "UPDATE camper_info SET " +
                        "`name`='" + camper_name.Text + "', " +
                        "`preferred_name`='" + camper_preferred_name.Text + "', " +
                        "`bunk`='" + camper_bunk.Text + "', " +
                        "`age`='" + camper_age.Text + "', " +
                        "`nationality`='" + camper_nationality.Text + "', " +
                        "`restriction`='" + camper_restriction.Text + "', " +
                        "`medications`='" + camper_medications.Text + "', " +
                        "`start_date`='" + dateTimePicker_start.Value.ToString() + "', " +
                        "`leave_date`='" + dateTimePicker_leave.Value.ToString() + "', " +
                        "`transportation`='" + camper_transportation.Text + "', " +
                        "`parent1_name`='" + camper_parent1_name.Text + "', " +
                        "`parent1_phone`='" + camper_parent1_phone.Text + "', " +
                        "`parent1_email`='" + camper_parent1_email.Text + "', " +
                        "`parent2_name`='" + camper_parent2_name.Text + "', " +
                        "`parent2_phone`='" + camper_parent2_phone.Text + "', " +
                        "`parent2_email`='" + camper_parent2_email.Text + "' " +
                        "WHERE `name`='" + combo_select_camper.SelectedItem.ToString() + "'";

                    MySqlCommand cmd = new MySqlCommand(cmdtext, conn);
                    cmd.ExecuteNonQuery();
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
            ClearText(this);
            dateTimePicker_start.Value = DateTime.Now;
            dateTimePicker_leave.Value = DateTime.Now;
            combo_select_camper.SelectedIndex = -1;
            combo_select_camper.Items.Clear();
            Register_Load(sender, e);
            MessageBox.Show("Changes saved successfully!");
        }
    }
}
