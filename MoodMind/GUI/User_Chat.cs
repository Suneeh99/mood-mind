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


    public partial class User_Chat : Form
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
        private int selectedConsultantId;
        private string selectedPlan;
        public User_Chat(int LoggedUserId)
        {
            this.LoggedUserId = LoggedUserId;
            InitializeComponent();
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

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

        private void btn_tips_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Tips user_Tips = new User_Tips(LoggedUserId);
            user_Tips.Show();
        }

        private void btn_stats_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Stats user_Stats = new User_Stats(LoggedUserId);
            user_Stats.Show();
        }

        private void btn_diary_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Diary user_Diary = new User_Diary(LoggedUserId);
            user_Diary.Show();
        }

        private void LoadConsultants()
        {
            try
            {
                DataTable consultants = User_all.GetConsultants("APPROVED");
                ConsultantListBox.DataSource = consultants;
                ConsultantListBox.DisplayMember = "FullName";
                ConsultantListBox.ValueMember = "id";
                ConsultantListBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading consultants: {ex.Message}");
            }
        }

        private void User_Chat_Load(object sender, EventArgs e)
        {
            LoadConsultants();
            panel_default.Visible = true;
            pnl_payment1.Visible = false;;
            pnl_payment2.Visible = false;
            pnl_plans.Visible = false;
        }

        private void ConsultantListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ConsultantListBox.SelectedIndex != -1)
            {
                DataRowView selectedItem = (DataRowView)ConsultantListBox.SelectedItem;

                selectedConsultantId = (int)selectedItem["id"];

                lbl_id.Text = selectedConsultantId.ToString();
                lbl_consName.Text = selectedItem["Fullname"].ToString();

                panel_default.Visible = false;
                Consult_Sessions session = new Consult_Sessions();
                session.ConsultId = selectedConsultantId;
                session.UserId = LoggedUserId;

                var expirationDate = session.GetExpirationDate();

                if (!expirationDate.HasValue)
                {
                    lbl_time.Text = "Locked";
                    pnl_payment1.Visible = false;
                    pnl_payment2.Visible = false;
                    pnl_plans.Visible = true;
                }
                else
                {
                    TimeSpan remainingTime = session.GetRemainingTime(expirationDate.Value);
                    pnl_payment1.Visible = false;
                    pnl_payment2.Visible = false;
                    pnl_plans.Visible = false;
                    lbl_time.Text = $"{remainingTime.Days:D2}D {remainingTime.Hours:D2}H {remainingTime.Minutes:D2}M"; 
                    LoadChatHistory();
                }
            }
        }

        private void LoadChatHistory()
        {
            try
            {
                Chats op = new Chats();

                DataTable chatHistory = op.GetChatHistory(LoggedUserId, selectedConsultantId);
                ChatTextBox.Clear();

                foreach (DataRow row in chatHistory.Rows)
                {
                    string sender = row["senderId"].ToString() == LoggedUserId.ToString() ? "Me" : "Consultant";
                    string message = row["message"].ToString();
                    ChatTextBox.AppendText($"{sender}: {message}\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chat history: {ex.Message}");
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string message = txt_message.Text;

            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    Chats chat = new Chats(LoggedUserId, selectedConsultantId, message);
                    chat.SaveChat();

                    ChatTextBox.AppendText($"Me: {message}\n");
                    txt_message.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending message: {ex.Message}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnl_payment1.Visible = true;
            pnl_payment2.Visible = true;
            selectedPlan = "basic";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnl_payment1.Visible = true;
            pnl_payment2.Visible = true;
            selectedPlan = "standard";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnl_payment1.Visible = true;
            pnl_payment2.Visible = true;
            selectedPlan = "premium";
        }

        private void btn_paynow_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_paynow_Click_1(object sender, EventArgs e)
        {
            decimal price = 0;
            DateTime expire = DateTime.Now;

            if (selectedPlan == "basic")
            {
                price = 499;
                expire = DateTime.Now.AddDays(3);
            }
            else if (selectedPlan == "standard")
            {
                price = 1199;
                expire = DateTime.Now.AddDays(7);

            }
            else if (selectedPlan == "premium")
            {
                price = 2999;
                expire = DateTime.Now.AddDays(30);
            }

            if (!string.IsNullOrEmpty(txt_cardName.Text) && !string.IsNullOrEmpty(txt_cardNo.Text) &&
                !string.IsNullOrEmpty(txt_expDate.Text) && !string.IsNullOrEmpty(txt_secCode.Text))
            {

                Consult_Sessions newSession = new Consult_Sessions(LoggedUserId, selectedConsultantId, selectedPlan, price, expire);
                newSession.Create();
                MessageBox.Show("Sucessfully Purchased", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnl_payment1.Visible = false;
                pnl_payment2.Visible = false;
                pnl_plans.Visible = false;
            }
            else
            {
                MessageBox.Show("Enter Valid Details");
            }
        }

        private void pnl_payment1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_default_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            pnl_payment1.Visible = false;
            pnl_payment2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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
