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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MoodMind.GUI
{
    public partial class User_Tips : Form
    {
        private int LoggedUserId;
        // Import user32.dll for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public User_Tips(int LoggedUserId)
        {
            this.LoggedUserId = LoggedUserId;
            InitializeComponent();
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Diary user_Diary = new User_Diary(LoggedUserId);
            user_Diary.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Stats user_Stats = new User_Stats(LoggedUserId);
            user_Stats.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            this.Hide();
            User_Chat user_Chat = new User_Chat(LoggedUserId);
            user_Chat.Show();
        }

        private void User_Tips_Load(object sender, EventArgs e)
        {
            string riskLevel;

            DiaryEntry diaryEntry = new DiaryEntry(LoggedUserId);
            diaryEntry.GetWeeklySentiments();

            double maxSentiment = diaryEntry.HappySentiment;
            string maxSentimentName = "Happy";

            if (diaryEntry.SadSentiment > maxSentiment)
            {
                maxSentiment = diaryEntry.SadSentiment;
                maxSentimentName = "Sad";
            }
            if (diaryEntry.NeutralSentiment > maxSentiment)
            {
                maxSentiment = diaryEntry.NeutralSentiment;
                maxSentimentName = "Neutral";
            }
            if (diaryEntry.ShockedSentiment > maxSentiment)
            {
                maxSentiment = diaryEntry.ShockedSentiment;
                maxSentimentName = "Shocked";
            }
            if (diaryEntry.AngrySentiment > maxSentiment)
            {
                maxSentiment = diaryEntry.AngrySentiment;
                maxSentimentName = "Angry";
            }



            if(maxSentimentName == "Happy")
            {
                riskLevel = "low";
            } 
            else if (maxSentimentName == "Sad" ||  maxSentimentName == "Anger")
            {
                riskLevel = "high";
            }
            else
            {
                riskLevel = "medium";
            }

            lbl_Risky.Text = riskLevel;

            Tips tips = new Tips(riskLevel);

            lbl_do.Text = tips.GetDos();
            lbl_dont.Text = tips.GetDonts();
        }

        private void lbl_do_Click(object sender, EventArgs e)
        {

        }

        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click_1(object sender, EventArgs e)
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
