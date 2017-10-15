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
        int id;
        Dictionary<string,string> camper_id = new Dictionary<string, string>();
        Dictionary<string, string> act_id = new Dictionary<string, string>();
        Dictionary<int, string> selection = new Dictionary<int, string>();

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
                    String cmdText = "SELECT bunk_camper.id,name FROM bunk_camper LEFT JOIN camper_info ON bunk_camper.camper_id=camper_info.id ORDER BY camper_info.name;";
                    MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        combo_name.Items.Add(reader.GetString(1));
                        if (!camper_id.ContainsKey(reader.GetString(1)))
                        {
                            camper_id.Add(reader.GetString(1), reader.GetString(0));
                        }
                        else
                        {
                            camper_id[reader.GetString(1)] = reader.GetString(0);
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
                String cmdText = "SELECT activities.id,act_no,act,act_id FROM activities LEFT JOIN activities_selected ON activities.id=activities_selected.act_id WHERE date='"+date+"' ORDER BY act;";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        switch (reader.GetString(1))
                        {
                            case "1":
                                list_activity1.Items.Add(reader.GetString(2));
                                if (!act_id.ContainsKey("1," + reader.GetString(2)))
                                {
                                    act_id.Add("1," + reader.GetString(2), reader.GetString(0));
                                }
                                else
                                {
                                   act_id["1," + reader.GetString(2)] =  reader.GetString(0);
                                }
                                break;
                            case "2":
                                list_activity2.Items.Add(reader.GetString(2));
                                if (!act_id.ContainsKey("2," + reader.GetString(2)))
                                {
                                    act_id.Add("2," + reader.GetString(2), reader.GetString(0));
                                }
                                else
                                {
                                    act_id["2," + reader.GetString(2)] = reader.GetString(0);
                                }
                                break;
                            case "3":
                                list_activity3.Items.Add(reader.GetString(2));
                                if (!act_id.ContainsKey("3," + reader.GetString(2)))
                                {
                                    act_id.Add("3," + reader.GetString(2), reader.GetString(0));
                                }
                                else
                                {
                                    act_id["3," + reader.GetString(2)] = reader.GetString(0);
                                }
                                break;
                            case "4":
                                list_activity4.Items.Add(reader.GetString(2));
                                if (!act_id.ContainsKey("4," + reader.GetString(2)))
                                {
                                    act_id.Add("4," + reader.GetString(2), reader.GetString(0));
                                }
                                else
                                {
                                    act_id["4," + reader.GetString(2)] = reader.GetString(0);
                                }
                                break;
                            case "5":
                                list_activity5.Items.Add(reader.GetString(2));
                                if (!act_id.ContainsKey("5," + reader.GetString(2)))
                                {
                                    act_id.Add("5," + reader.GetString(2), reader.GetString(0));
                                }
                                else
                                {
                                    act_id["5," + reader.GetString(2)] = reader.GetString(0);
                                }
                                break;
                            default:
                                MessageBox.Show("Index error");
                                break;
                        }
                    }

                }
                conn.Close();
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(3))
                    {
                        switch (reader.GetString(1))
                        {
                            case "1":
                                list_activity1.SelectedIndex = list_activity1.FindString(reader.GetString(2));
                                break;
                            case "2":
                                list_activity2.SelectedIndex = list_activity2.FindString(reader.GetString(2));
                                break;
                            case "3":
                                list_activity3.SelectedIndex = list_activity3.FindString(reader.GetString(2));
                                break;
                            case "4":
                                list_activity4.SelectedIndex = list_activity4.FindString(reader.GetString(2));
                                break;
                            case "5":
                                list_activity5.SelectedIndex = list_activity5.FindString(reader.GetString(2));
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

        private void save_selection(object sender, EventArgs e,String selection)
        {
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                String cmdText = "INSERT INTO activities_selected (`id`, `act_id`) VALUES ('" + camper_id[combo_name.SelectedItem.ToString()] + "', '" + act_id[selection] + "')";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: You can not change selection in this version. We apologize for inconvenience");
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
                    for(int i = 1; i <= 5; i++)
                    {
                        save_selection(sender, e, i+","+selection[i]);
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

        private void list_activity1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_activity1.SelectedIndex != -1)
            {
            if (selection.ContainsKey(1))
            {
                selection[1] = list_activity1.SelectedItem.ToString();
            }
            else
            {
                selection.Add(1, list_activity1.SelectedItem.ToString());
            }
            }
        }

        private void list_activity2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_activity2.SelectedIndex != -1)
            {
                if (selection.ContainsKey(2))
            {
                selection[2] = list_activity2.SelectedItem.ToString();
            }
            else
            {
                selection.Add(2, list_activity2.SelectedItem.ToString());
            }
            }
        }

        private void list_activity3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_activity3.SelectedIndex != -1)
            {
                if (selection.ContainsKey(3))
                {
                    selection[3] = list_activity3.SelectedItem.ToString();
                }
                else
                {
                    selection.Add(3, list_activity3.SelectedItem.ToString());
                }
            }
        }

        private void list_activity4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_activity4.SelectedIndex != -1)
            {
                if (selection.ContainsKey(4))
                {
                    selection[4] = list_activity4.SelectedItem.ToString();
                }
                else
                {
                    selection.Add(4, list_activity4.SelectedItem.ToString());
                }
            }
        }

        private void list_activity5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_activity5.SelectedIndex != -1)
            {
                if (selection.ContainsKey(5))
            {
                selection[5] = list_activity5.SelectedItem.ToString();
            }
            else
            {
                selection.Add(5, list_activity5.SelectedItem.ToString());
            }
            }
        }
    }
}
