using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MoodMind.GUI
{
    public partial class Admin_Stats : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public Admin_Stats()
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

        private void btn_chat_Click(object sender, EventArgs e)
        {
            Admin_Payments admin_Payments = new Admin_Payments();
            admin_Payments.Show();
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

        private void DisplayStatistics(Statistics stats)
        {
            genderChart.Series.Clear();
            genderChart.Titles.Clear();

            Series genderSeries = new Series
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new System.Drawing.Font("Arial", 10f),
                IsValueShownAsLabel = true
            };

            genderSeries.Points.AddXY("Male", stats.MaleUsers);
            genderSeries.Points.AddXY("Female", stats.FemaleUsers);

            genderChart.Series.Add(genderSeries);

            moodChart.Series.Clear();
            moodChart.Titles.Clear();

            Series moodSeries = new Series
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new System.Drawing.Font("Arial", 10f),
                IsValueShownAsLabel = true
            };

            moodSeries.Points.AddXY("Happy", stats.HappyCount);
            moodSeries.Points.AddXY("Sad", stats.SadCount);
            moodSeries.Points.AddXY("Neutral", stats.NeutralCount);
            moodSeries.Points.AddXY("Angry", stats.AngryCount);
            moodSeries.Points.AddXY("Shocked", stats.ShockedCount);

            moodChart.Series.Add(moodSeries);

            ageChart.Series.Clear();
            ageChart.Titles.Clear();

            Series ageSeries = new Series
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new System.Drawing.Font("Arial", 10f),
                IsValueShownAsLabel = true
            };

            ageSeries.Points.AddXY("18-25", stats.AgeGroup1);
            ageSeries.Points.AddXY("26-35", stats.AgeGroup2);
            ageSeries.Points.AddXY("36-45", stats.AgeGroup3);
            ageSeries.Points.AddXY("46-60", stats.AgeGroup4);
            ageSeries.Points.AddXY("60+", stats.AgeGroup5);

            ageChart.Series.Add(ageSeries);

            int Total = stats.MaleUsers + stats.FemaleUsers;

            lbl_usercount.Text = Total.ToString();
            lbl_diarycount.Text = stats.TotalDiaryEntries.ToString();
        }


        private void Admin_Stats_Load(object sender, EventArgs e)
        {
            Statistics stats = new Statistics();
            DisplayStatistics(stats.GetStatistics());

        }

        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click(object sender, EventArgs e)
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
