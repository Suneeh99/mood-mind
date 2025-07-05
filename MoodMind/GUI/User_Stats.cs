using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MoodMind.GUI
{
    public partial class User_Stats : Form
    {
        // Import user32.dll for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private int LoggedUserId;
        public User_Stats(int LoggedUserId)
        {
            this.LoggedUserId = LoggedUserId;
            InitializeComponent();
            DisplayWeeklySentiments();
            DisplayMonthlySentiments();
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

        }

        private void User_Stats_Load(object sender, EventArgs e)
        {
            DiaryEntry diaryEntry = new DiaryEntry(LoggedUserId);

            diaryEntry.getTodaystats();

            lbl_first.Text = "Happiness";
            lbl_1per.Text = diaryEntry.HappySentiment.ToString() + "%";

            lbl_second.Text = "Sadness";
            lbl_2per.Text = diaryEntry.SadSentiment.ToString() + "%";
            
            lbl_third.Text = "Shocked";
            lbl_3per.Text = diaryEntry.ShockedSentiment.ToString() + "%";
            
            lbl_fourth.Text = "Anger";
            lbl_4per.Text = diaryEntry.AngrySentiment.ToString() + "%";
            
            lbl_fifth.Text = "Neutral";
            lbl_5per.Text = diaryEntry.NeutralSentiment.ToString() + "%";
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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            User_Diary user_Diary = new User_Diary(LoggedUserId);
            user_Diary.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            User_Tips user_Tips = new User_Tips(LoggedUserId);
            user_Tips.Show();
        }

        private void btn_chat_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Chat user_Chat = new User_Chat(LoggedUserId);
            user_Chat.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lbl_1sent_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void DisplayWeeklySentiments()
        {
            DiaryEntry diaryEntry = new DiaryEntry(LoggedUserId);

            diaryEntry.GetWeeklySentiments();

            CreateDonutChart(chart_week, diaryEntry);
        }

        private void DisplayMonthlySentiments()
        {
            DiaryEntry diaryEntry = new DiaryEntry(LoggedUserId);

            diaryEntry.GetMonthlySentiments();

            CreateDonutChart(chart_month, diaryEntry);
        }

        private void CreateDonutChart(Chart chart, DiaryEntry diaryEntry)
        {
            chart.Series.Clear();
            chart.Titles.Clear();


            Series series = new Series
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new System.Drawing.Font("Arial", 10f),
                IsValueShownAsLabel = true
            };


            series.Points.AddXY("Happiness", diaryEntry.HappySentiment);
            series.Points.AddXY("Sadness", diaryEntry.SadSentiment);
            series.Points.AddXY("Neutral", diaryEntry.NeutralSentiment);
            series.Points.AddXY("Shocked", diaryEntry.ShockedSentiment);
            series.Points.AddXY("Anger", diaryEntry.AngrySentiment);

            chart.Series.Add(series);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void menuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
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
