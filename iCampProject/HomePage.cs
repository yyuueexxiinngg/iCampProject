using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace iCampProject
{
    public partial class HomePage : Form
    {

        string cs = @"server=localhost;userid=root;password='';database=icamp";
        MySqlConnection conn = null;
        MySqlDataReader reader = null;

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            combo_bunk.SelectedIndex = -1;
            combo_bunk.Items.Clear();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                String cmdText = "SELECT DISTINCT bunk_id FROM bunk_camper_selected ORDER BY bunk_id";
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

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            //this.Enabled = false;
            register.ShowDialog();
            //this.Enabled = true;
        }

        private void btn_choose_activeties_Click(object sender, EventArgs e)
        {
            SelectActivities selectActivities = new SelectActivities();
            //this.Enabled = false;
            selectActivities.ShowDialog();
            //this.Enabled = true;
            HomePage_Load(sender, e);
        }

        private void btn_register_activities_Click(object sender, EventArgs e)
        {
            RegisterActivities registerActivities = new RegisterActivities();
            //this.Enabled = false;
            registerActivities.ShowDialog();
            //this.Enabled = true;
        }

        private void btn_export_detail_Click(object sender, EventArgs e)
        {
            if (combo_bunk.SelectedIndex != -1)
            {
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    String out_put = "Name,Activity1,Activity2,Activity3,Activity4,Activity5\n";
                    String cmdText = "SELECT name,act_no,act,act_id FROM (activities RIGHT JOIN activities_selected ON activities.id=activities_selected.act_id) RIGHT JOIN camper_info  WHERE date='" + dateTimePicker1.Value.ToShortDateString() + "' ORDER BY act;";
                    MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        out_put += reader.GetString(0)+"\n";
                    }

                    FileStream fs = new FileStream("..\\..\\..\\Detail Bunk" + combo_bunk.SelectedItem.ToString() + ".csv", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(out_put);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("Export succefully");

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

        private void btn_export_signup_sheet_Click(object sender, EventArgs e)
        {
            if (combo_bunk.SelectedIndex != -1)
            {
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    String out_put = "Activities 1 9:00 am - 10:15 am\nAvtivity,";
                    String act1 = "";
                    String act2 = "";
                    String act3 = "";
                    String act4 = "";
                    String act5 = "";
                    String camper = "";
                    String cmdText = "SELECT activities.id,act_no,act,act_id FROM activities LEFT JOIN activities_selected ON activities.id=activities_selected.act_id WHERE date='" + dateTimePicker1.Value.ToShortDateString() + "' ORDER BY act;";
                    MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            switch (reader.GetString(1))
                            {
                                case "1":
                                    act1 += reader.GetString(2) + ",";
                                    break;
                                case "2":
                                    act2 += reader.GetString(2) + ",";
                                    break;
                                case "3":
                                    act3 += reader.GetString(2) + ",";
                                    break;
                                case "4":
                                    act4 += reader.GetString(2) + ",";
                                    break;
                                case "5":
                                    act5 += reader.GetString(2) + ",";
                                    break;
                                default:
                                    MessageBox.Show("Index error");
                                    break;
                            }
                        }
                    }
                    conn.Close();
                    out_put += act1 + "\n";
                    cmdText = "SELECT name,bunk_camper.bunk_id FROM bunk_camper LEFT JOIN camper_info ON camper_info.id=bunk_camper.camper_id WHERE bunk_id='"+ combo_bunk.SelectedItem.ToString()+"' ORDER BY bunk_id ;";

                    //conn = new MySqlConnection(cs);
                    conn.Open();
                    cmd = new MySqlCommand(cmdText, conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                            camper += reader.GetString(0) + "\n";
                    }
                    //conn.Close();



                    out_put += camper + "\n\nActivities 2 10:45 am - 12:00 am\nAvtivity," + act2 + "\n";
                    out_put += camper + "\n\nActivities 3 01:00 pm - 02:15 pm\nAvtivity," + act3 + "\n";
                    out_put += camper + "\n\nActivities 4 02:45 pm - 04:00 pm\nAvtivity," + act4 + "\n";
                    out_put += camper + "\n\nActivities 5 04:15 pm - 05:30 pm\nAvtivity," + act5 + "\n"+camper;

                    FileStream fs = new FileStream("..\\..\\..\\Sign Up Sheet Bunk"+ combo_bunk.SelectedItem.ToString()+".csv", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(out_put);
                    sw.Flush();
                    sw.Close();
                    fs.Close();

                    MessageBox.Show("Export succefully");

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
