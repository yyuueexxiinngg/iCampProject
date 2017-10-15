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
    public partial class RegisterActivities : Form
    {
        string cs = @"server=localhost;userid=root;password='';database=icamp";
        MySqlConnection conn = null;
        MySqlDataReader reader = null;

        public RegisterActivities()
        {
            InitializeComponent();
        }

        private void RegisterActivities_Load(object sender, EventArgs e)
        {
            combo_add.Items.Add("Activity 1");
            combo_add.Items.Add("Activity 2");
            combo_add.Items.Add("Activity 3");
            combo_add.Items.Add("Activity 4");
            combo_add.Items.Add("Activity 5");
            dateTimePicker1_ValueChanged(sender, e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            list_activity1.Items.Clear();
            list_activity2.Items.Clear();
            list_activity3.Items.Clear();
            list_activity4.Items.Clear();
            list_activity5.Items.Clear();
            String date = dateTimePicker1.Value.ToShortDateString().ToString();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                String cmdText = "SELECT * FROM activities WHERE date='" + date + "' ORDER BY act";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(2))
                    {
                        switch (reader.GetString(2))
                        {
                            case "1":
                                list_activity1.Items.Add(reader.GetString(3));
                                break;
                            case "2":
                                list_activity2.Items.Add(reader.GetString(3));
                                break;
                            case "3":
                                list_activity3.Items.Add(reader.GetString(3));
                                break;
                            case "4":
                                list_activity4.Items.Add(reader.GetString(3));
                                break;
                            case "5":
                                list_activity5.Items.Add(reader.GetString(3));
                                break;
                            default:
                                MessageBox.Show("Index error");
                                break;
                        }
                    }
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

        private void btn_delete_activity_Click(object sender, EventArgs e)
        {
            String num = (sender as Button).Tag.ToString();
            String date = dateTimePicker1.Value.ToShortDateString().ToString();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                String cmdText = "SELECT * FROM activities";
                switch (num)
                {
                    case "1":
                        if (list_activity1.SelectedIndex != -1)
                            cmdText = "DELETE FROM activities WHERE `date`='" + date + "' AND act_no='1' AND `act`='" + list_activity1.SelectedItem.ToString() + "'";
                        break;
                    case "2":
                        if (list_activity2.SelectedIndex != -1)
                            cmdText = "DELETE FROM activities WHERE `date`='" + date + "' AND act_no='2' AND `act`='" + list_activity2.SelectedItem.ToString() + "'";
                        break;
                    case "3":
                        if (list_activity3.SelectedIndex != -1)
                            cmdText = "DELETE FROM activities WHERE `date`='" + date + "' AND act_no='3' AND `act`='" + list_activity3.SelectedItem.ToString() + "'";
                        break;
                    case "4":
                        if (list_activity4.SelectedIndex != -1)
                            cmdText = "DELETE FROM activities WHERE `date`='" + date + "' AND act_no='4' AND `act`='" + list_activity4.SelectedItem.ToString() + "'";
                        break;
                    case "5":
                        if (list_activity5.SelectedIndex != -1)
                            cmdText = "DELETE FROM activities WHERE `date`='" + date + "' AND act_no='5' AND `act`='" + list_activity5.SelectedItem.ToString() + "'";
                        break;
                }

                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.ExecuteNonQuery();

                dateTimePicker1_ValueChanged(sender, e);
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

        private void add_activity(object sender, EventArgs e, String cmdText)
        {
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.ExecuteNonQuery();
                dateTimePicker1_ValueChanged(sender, e);
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

        private void btn_add_activity_Click(object sender, EventArgs e)
        {
            if (textBox_activity.Text != "")
            {
                String cmdText = "";
                switch (combo_add.SelectedIndex)
                {
                    case 0:
                        cmdText = "INSERT INTO activities (`date`, `act_no`, `act`) VALUES ( '" + dateTimePicker1.Value.ToShortDateString().ToString() + "', '1', '" + textBox_activity.Text + "');";
                        add_activity(sender, e, cmdText);
                        break;
                    case 1:
                        cmdText = "INSERT INTO activities (`date`, `act_no`, `act`) VALUES ( '" + dateTimePicker1.Value.ToShortDateString().ToString() + "', '2', '" + textBox_activity.Text + "');";
                        add_activity(sender, e, cmdText);
                        break;
                    case 2:
                        cmdText = "INSERT INTO activities (`date`, `act_no`, `act`) VALUES ( '" + dateTimePicker1.Value.ToShortDateString().ToString() + "', '3', '" + textBox_activity.Text + "');";
                        add_activity(sender, e, cmdText);
                        break;
                    case 3:
                        cmdText = "INSERT INTO activities (`date`, `act_no`, `act`) VALUES ( '" + dateTimePicker1.Value.ToShortDateString().ToString() + "', '4', '" + textBox_activity.Text + "');";
                        add_activity(sender, e, cmdText);
                        break;
                    case 4:
                        cmdText = "INSERT INTO activities (`date`, `act_no`, `act`) VALUES ( '" + dateTimePicker1.Value.ToShortDateString().ToString() + "', '5', '" + textBox_activity.Text + "');";
                        add_activity(sender, e, cmdText);
                        break;
                }
            }
        }
    }
}
