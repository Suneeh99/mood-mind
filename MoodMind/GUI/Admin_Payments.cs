using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MoodMind.GUI
{
    public partial class Admin_Payments : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public Admin_Payments()
        {
            InitializeComponent();
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_ApproveConsultants admin_ApproveConsultants = new Admin_ApproveConsultants();
            admin_ApproveConsultants.Show();
            this.Hide();
        }

        private void btn_stats_Click(object sender, EventArgs e)
        {
            Admin_ManageUsers admin_ManageUsers = new Admin_ManageUsers();
            admin_ManageUsers.Show();
            this.Hide();
        }

        private void btn_tips_Click(object sender, EventArgs e)
        {
            Admin_Stats admin_Stats = new Admin_Stats();
            admin_Stats.Show();
            this.Hide();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close MoodMind?",
                                                  "Confirm Close",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }

        }

        private void btn_chat_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Payments_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = Consult_Sessions.GetConsultationData();
                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CalculateTotals()
        {
            int totalDays = 0;
            decimal totalIncome = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string plan = row.Cells["Plan"].Value?.ToString() ?? string.Empty;

                decimal income = 0;
                switch (plan.ToLower())
                {
                    case "basic":
                        income = 499;
                        totalDays += 3;
                        break;
                    case "standard":
                        income = 1199;
                        totalDays += 7;
                        break;
                    case "premium":
                        income = 2999;
                        totalDays += 30;
                        break;
                }

                totalIncome += income;

            }

            lbl_days.Text = $"{totalDays}";
            lbl_income.Text = $"LKR {totalIncome.ToString()}"; 
        }

        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?",
                          "Confirm Close",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Dispose();
            }
        }
    }
}
