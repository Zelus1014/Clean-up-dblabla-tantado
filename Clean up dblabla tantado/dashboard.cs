using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clean_up_dblabla_tantado
{
    public partial class dashboard : Form
    {
        private string connectionString = "Server=localhost;Port=3307;Database=cleanupsystem;User ID=root;Password=FRASERANDNAIVE;";
        public dashboard()
        {
            InitializeComponent();

            ADDNEWCLEANUPFORM.Visible = false;
            SetupDataGridView();
            SetupTrashTypesGrid();
            SetupSummaryGrid();
            LoadCleanupsIntoGrid();

        }

        private void SetupTrashTypesGrid()
        {
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.Columns.Clear();

            dataGridView3.Columns.Add("TrashType", "Trash Type");
            dataGridView3.Columns.Add("TotalBags", "Total Bags Collected");
        }


        private void SetupSummaryGrid()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Clear();

            dataGridView2.Columns.Add("TotalWaste", "Total Waste Collected");
            dataGridView2.Columns.Add("TotalVolunteers", "Total Volunteers");
            dataGridView2.Columns.Add("ThisMonth", "Cleaned Up This Month");
            dataGridView2.Columns.Add("TotalCleanups", "Total Cleanups");
            dataGridView2.Columns.Add("Locations", "Locations Covered");

            // Make headers bold and yellow background
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dataGridView2.EnableHeadersVisualStyles = false;
        }
        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Location", "Location");
            dataGridView1.Columns.Add("CleanupType", "Cleanup Type");
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns.Add("TotalBags", "Total Trash Bags");
            dataGridView1.Columns.Add("Volunteers", "Volunteers");
            dataGridView1.Columns.Add("TrashDetails", "Trash Types (Bags & %)");
        }

        private void LoadCleanupsIntoGrid()
        {
            dataGridView1.Rows.Clear();

            Dictionary<string, int> overallTrashCount = new Dictionary<string, int>();

            // ← DECLARE ALL SUMMARY VARIABLES HERE (outside the loop)
            HashSet<string> locationsCovered = new HashSet<string>();
            int totalVolunteers = 0;
            int totalCleanups = 0;
            int totalBagsAll = 0;
            int cleanupsThisMonth = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT ID, Location, CleanupType, Date, Status, Volunteers FROM Cleanups ORDER BY Date DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable cleanupsTable = new DataTable();
                    adapter.Fill(cleanupsTable);

                    totalCleanups = cleanupsTable.Rows.Count;  // ← Count total cleanups

                    foreach (DataRow row in cleanupsTable.Rows)
                    {
                        int id = Convert.ToInt32(row["ID"]);
                        string location = row["Location"].ToString();
                        string cleanupType = row["CleanupType"].ToString();
                        string dateStr = row["Date"].ToString();  // ← Keep date as string for display
                        string status = row["Status"].ToString();
                        int volunteers = row["Volunteers"] != DBNull.Value ? Convert.ToInt32(row["Volunteers"]) : 0;

                        // ← Add to summary totals
                        locationsCovered.Add(location);
                        totalVolunteers += volunteers;

                        // ← Count cleanups this month (January 2026)
                        if (DateTime.TryParse(dateStr, out DateTime cleanupDate))
                        {
                            if (cleanupDate.Year == 2026 && cleanupDate.Month == 1)
                            {
                                cleanupsThisMonth++;
                            }
                        }

                        var trashDetails = GetTrashDetailsForCleanup(conn, id);

                        int totalBags = trashDetails.Sum(t => t.Bags);
                        totalBagsAll += totalBags;  // ← Add to grand total

                        string detailsText = string.Join(", ", trashDetails.Select(t =>
                            $"{t.Type}: {t.Bags} bag{(t.Bags == 1 ? "" : "s")} ({t.Percentage}%)"));

                        dataGridView1.Rows.Add(location, cleanupType, dateStr, status, totalBags, volunteers, detailsText);

                        foreach (var t in trashDetails)
                        {
                            if (overallTrashCount.ContainsKey(t.Type))
                                overallTrashCount[t.Type] += t.Bags;
                            else
                                overallTrashCount[t.Type] = t.Bags;
                        }
                    }


                    // ← NOW ALL VARIABLES ARE IN SCOPE HERE
                    LoadTrashTypesIntoGrid(overallTrashCount);

                    LoadSummaryIntoGrid(totalBagsAll, totalVolunteers, cleanupsThisMonth, totalCleanups, locationsCovered);

                    ShowOverallTrashSummary(overallTrashCount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }



        private void LoadTrashTypesIntoGrid(Dictionary<string, int> overallTrashCount)
        {
            dataGridView3.Rows.Clear();

            var sorted = overallTrashCount.OrderByDescending(kv => kv.Value);

            foreach (var item in sorted)
            {
                dataGridView3.Rows.Add(item.Key, item.Value);
            }
        }
        private void LoadSummaryIntoGrid(int totalWaste, int totalVolunteers, int cleanupsThisMonth, int totalCleanups, HashSet<string> locations)
        {
            dataGridView2.Rows.Clear();

            // Only one row with all values — no extra header row
            dataGridView2.Rows.Add(
                totalWaste + " bags",
                totalVolunteers,
                cleanupsThisMonth,
                totalCleanups,
                string.Join(", ", locations.OrderBy(l => l))
            );
        }


        private class TrashItem
        {
            public string Type { get; set; }
            public int Bags { get; set; }
            public double Percentage { get; set; }
        }

        private List<TrashItem> GetTrashDetailsForCleanup(MySqlConnection conn, int cleanupId)
        {
            List<TrashItem> list = new List<TrashItem>();

            string query = "SELECT TrashType, Bags FROM TrashDetails WHERE CleanupID = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", cleanupId);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new TrashItem
                {
                    Type = reader["TrashType"].ToString(),
                    Bags = Convert.ToInt32(reader["Bags"])
                });
            }
            reader.Close();

            int total = list.Sum(x => x.Bags);
            if (total > 0)
            {
                foreach (var item in list)
                {
                    item.Percentage = Math.Round((double)item.Bags / total * 100, 1);
                }
            }

            return list;
        }

        private void ShowOverallTrashSummary(Dictionary<string, int> overall)
        {
            Label lblSummary = myCleanups.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblOverallSummary");

            if (lblSummary == null)
            {
                lblSummary = new Label();
                lblSummary.Name = "lblOverallSummary";
                myCleanups.Controls.Add(lblSummary);
            }

            if (overall.Count == 0)
            {
                lblSummary.Text = "No trash data recorded yet.";
                return;
            }

            int grandTotal = overall.Values.Sum();

            var sorted = overall.OrderByDescending(kv => kv.Value);
            string text = "Overall Trash Collection Summary (All Cleanups)\n";
            string highestType = sorted.First().Key;

            foreach (var item in sorted)
            {
                double pct = Math.Round((double)item.Value / grandTotal * 100, 1);
                text += $"{item.Key}: {item.Value} bags ({pct}%)\n";
            }

            text += $"\nMost Collected: {highestType}";

            lblSummary.Text = text;


           


        }

        private void button6_Click(object sender, EventArgs e)
        {
            dash.Visible = true;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            
            
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            
            
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            myCleanups.Visible = true;
            trashtypes.Visible = false;
            ADDNEWCLEANUPFORM.Visible = false;



        }

        private void button19_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = true;
            
            
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            
            
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            
            
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            
            
            
        }

        private void button30_Click(object sender, EventArgs e)
        {
            dash.Visible = false;
            myCleanups.Visible = false;
            trashtypes.Visible = false;
            
            
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void claenupd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void volun_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trashtypes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
           
        }

        private void button36_Click(object sender, EventArgs e)
        {
            
        }

        private void button37_Click(object sender, EventArgs e)
        {
            
        }

        private void button38_Click(object sender, EventArgs e)
        {
            
        }

        private void button35_Click(object sender, EventArgs e)
        {
            
        }

        private void button34_Click(object sender, EventArgs e)
        {
            
        }

        private void button33_Click(object sender, EventArgs e)
        {
            
        }

        private void button47_Click(object sender, EventArgs e)
        {
           
        }

        private void button45_Click(object sender, EventArgs e)
        {
            
        }

        private void button46_Click(object sender, EventArgs e)
        {
           
        }

        private void button44_Click(object sender, EventArgs e)
        {
            
        }

        private void button42_Click(object sender, EventArgs e)
        {
            
        }

        private void button43_Click(object sender, EventArgs e)
        {
            
        }

        private void button32_Click(object sender, EventArgs e)
        {
            
        }

        private void button41_Click(object sender, EventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e)
        {
            
        }

        private void button40_Click(object sender, EventArgs e)
        {
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel69_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button55_Click(object sender, EventArgs e)
        {
            
        }

        private void button54_Click(object sender, EventArgs e)
        {
            
        }

        private void button53_Click(object sender, EventArgs e)
        {
            
        }

        private void button52_Click(object sender, EventArgs e)
        {
            
        }

        private void button62_Click(object sender, EventArgs e)
        {
            
        }

        private void button63_Click(object sender, EventArgs e)
        {
            
        }

        private void button64_Click(object sender, EventArgs e)
        {
            
        }

        private void button50_Click(object sender, EventArgs e)
        {
        }

        private void button48_Click(object sender, EventArgs e)
        {
        }

        private void button49_Click(object sender, EventArgs e)
        {
        }

        private void button59_Click(object sender, EventArgs e)
        {
           
        }

        private void button60_Click(object sender, EventArgs e)
        {
            
        }

        private void button61_Click(object sender, EventArgs e)
        {
            
        }

        private void button56_Click(object sender, EventArgs e)
        {
            
        }

        private void button57_Click(object sender, EventArgs e)
        {
            
        }

        private void button58_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button51_Click(object sender, EventArgs e)
        {
            
        }

        private void button65_Click(object sender, EventArgs e)
        {
            Add_New_Cleanup1 nextForm = new Add_New_Cleanup1();
            nextForm.Show();     
                   

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            ADDNEWCLEANUPFORM.Visible = true;
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel65_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label207_Click(object sender, EventArgs e)
        {

        }

        private void label201_Click(object sender, EventArgs e)
        {

        }

        private void label203_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADDNEWCLEANUPFORM.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADDNEWCLEANUPFORM.Visible = false;
            LoadCleanupsIntoGrid();
            LoadCleanupsIntoGrid();
            System.Windows.Forms.TextBox txtLocation = ADDNEWCLEANUPFORM.Controls["txtLocation"] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox txtCleanupType = ADDNEWCLEANUPFORM.Controls["txtCleanupType"] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox txtDate = ADDNEWCLEANUPFORM.Controls["txtDate"] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox txtStatus = ADDNEWCLEANUPFORM.Controls["txtStatus"] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox txtTrashBags = ADDNEWCLEANUPFORM.Controls["txtTrashBags"] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox txtTrashType = ADDNEWCLEANUPFORM.Controls["txtTrashType"] as System.Windows.Forms.TextBox;
            System.Windows.Forms.TextBox txtVolunteers = ADDNEWCLEANUPFORM.Controls["txtVolunteers"] as System.Windows.Forms.TextBox;
            if (txtLocation == null || txtCleanupType == null || txtDate == null || txtStatus == null ||
                txtTrashBags == null || txtTrashType == null)
            {
                MessageBox.Show("Please ensure all input TextBoxes are named correctly in the designer.");
                return;
            }

            string location = txtLocation.Text.Trim();
            string cleanupType = txtCleanupType.Text.Trim();
            string date = txtDate.Text.Trim();
            string status = txtStatus.Text.Trim();
            string trashTypesInput = txtTrashType.Text.Trim();
            string trashBagsInput = txtTrashBags.Text.Trim();
            string volunteersInput = txtVolunteers.Text.Trim();

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(cleanupType) ||
                string.IsNullOrEmpty(date) || string.IsNullOrEmpty(status) ||
                string.IsNullOrEmpty(trashTypesInput) || string.IsNullOrEmpty(trashBagsInput))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string[] types = trashTypesInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] bagsStr = trashBagsInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (types.Length != bagsStr.Length)
            {
                MessageBox.Show("Number of trash types and bag counts must match.\nExample:\nTrash Type: Plastic, Metal\nTrash Bags: 5, 2");
                return;
            }

            List<int> bags = new List<int>();
            for (int i = 0; i < bagsStr.Length; i++)
            {
                if (!int.TryParse(bagsStr[i].Trim(), out int count) || count < 0)
                {
                    MessageBox.Show($"Invalid bag number: {bagsStr[i]}");
                    return;
                }
                bags.Add(count);
                types[i] = types[i].Trim();
            }

            // ← VOLUNTEERS VALIDATION – PUT THIS HERE
            int volunteerCount = 0;

            if (string.IsNullOrEmpty(volunteersInput) ||
                !int.TryParse(volunteersInput, out volunteerCount) ||
                volunteerCount < 0)
            {
                MessageBox.Show("Please enter a valid number of volunteers (0 or more).");
                return;
            }


            if (string.IsNullOrEmpty(volunteersInput) ||
                !int.TryParse(volunteersInput, out volunteerCount) ||
                volunteerCount < 0)
            {
                MessageBox.Show("Please enter a valid number of volunteers (0 or more).");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlTransaction trans = conn.BeginTransaction();

                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO Cleanups (Location, CleanupType, Date, Status, volunteers) VALUES (@loc, @type, @date, @status, @volunteers); SELECT LAST_INSERT_ID();",
                        conn, trans);

                    cmd.Parameters.AddWithValue("@loc", location);
                    cmd.Parameters.AddWithValue("@type", cleanupType);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@volunteers", volunteerCount);

                    int cleanupId = Convert.ToInt32(cmd.ExecuteScalar());

                    for (int i = 0; i < types.Length; i++)
                    {
                        cmd = new MySqlCommand(
                            "INSERT INTO TrashDetails (CleanupID, TrashType, Bags) VALUES (@cid, @tt, @bags)",
                            conn, trans);
                        cmd.Parameters.AddWithValue("@cid", cleanupId);
                        cmd.Parameters.AddWithValue("@tt", types[i]);
                        cmd.Parameters.AddWithValue("@bags", bags[i]);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Cleanup added successfully!");

                    ADDNEWCLEANUPFORM.Visible = false;
                    LoadCleanupsIntoGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving: " + ex.Message);
                }
            }

        }
        

        private void Logout_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void ADDNEWCLEANUPFORM_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

