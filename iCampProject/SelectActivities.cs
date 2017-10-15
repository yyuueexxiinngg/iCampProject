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
    public partial class SelectActivities : Form
    {
        string cs = @"server=localhost;userid=root;password='';database=icamp";
        MySqlConnection conn = null;
        MySqlDataReader reader = null;

        public SelectActivities()
        {
            InitializeComponent();
        }

        private void SelectActivities_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                String cmdText = "SELECT DISTINCT bunk_id FROM bunk_camper ORDER BY bunk_id";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    combo_bunk.Items.Add(reader.GetString(0));
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

        private void combo_bunk_SelectedValueChanged(object sender, EventArgs e)
        {
            combo_name.SelectedIndex = -1;
            combo_name.Items.Clear();
            if (combo_bunk.SelectedIndex != -1)
            {
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    String cmdText = "SELECT name FROM bunk_camper LEFT JOIN camper_info ON bunk_camper.camper_id=camper_info.id ORDER BY camper_info.id;";
                    MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        combo_name.Items.Add(reader.GetString(0));
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
                String cmdText = "SELECT * FROM acitvities_date WHERE date='" + date + "'";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(2))
                    {
                        list_activity1.Items.Add(reader.GetString(2));
                    }

                    if (!reader.IsDBNull(3))
                    {
                        list_activity2.Items.Add(reader.GetString(3));
                    }

                    if (!reader.IsDBNull(4))
                    {
                        list_activity3.Items.Add(reader.GetString(4));
                    }

                    if (!reader.IsDBNull(5))
                    {
                        list_activity4.Items.Add(reader.GetString(5));
                    }

                    if (!reader.IsDBNull(6))
                    {
                        list_activity5.Items.Add(reader.GetString(6));
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (list_activity1.SelectedIndex != -1 && list_activity2.SelectedIndex != -1 && list_activity3.SelectedIndex != -1 && list_activity4.SelectedIndex != -1 && list_activity5.SelectedIndex != -1)
            {
                if (combo_bunk.SelectedIndex != -1 && combo_name.SelectedIndex!=-1)
                {
                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();
                        String cmdText = "INSERT INTO bunk_camper_selected (" +
                        "`camper_name`, `bunk_id`, `date`, `activities_1`, `activities_2`, `activities_3`, `activities_4`, `activities_5`) " +
                        "VALUES ('" +
                        combo_name.SelectedItem.ToString()+"', '"+
                        combo_bunk.SelectedItem.ToString() + "', '" +
                        dateTimePicker1.Value.ToShortDateString() + "', '" +
                        list_activity1.Text + "', '" +
                        list_activity2.Text + "', '" +
                        list_activity3.Text + "', '" +
                        list_activity4.Text + "', '" +
                        list_activity5.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            combo_name.Items.Add(reader.GetString(3));
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
                    list_activity1.SelectedIndex = -1;
                    list_activity2.SelectedIndex = -1;
                    list_activity3.SelectedIndex = -1;
                    list_activity4.SelectedIndex = -1;
                    list_activity5.SelectedIndex = -1;
                }

            }
            else
            {
                MessageBox.Show("Please make sure you seleceted all 5 activites!");
            }
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_activity1.SelectedIndex = -1;
            list_activity2.SelectedIndex = -1;
            list_activity3.SelectedIndex = -1;
            list_activity4.SelectedIndex = -1;
            list_activity5.SelectedIndex = -1;
        }

        private void btn_save_next_Click(object sender, EventArgs e)
        {
            if (combo_name.SelectedIndex < combo_name.Items.Count - 1)
            {
                btn_save_Click(sender, e);
                combo_name.SelectedIndex = combo_name.SelectedIndex + 1;
            }
            else
            {
                MessageBox.Show("This is the last camper in the bunk,pleace click save!");
            }
        }
    }
}
