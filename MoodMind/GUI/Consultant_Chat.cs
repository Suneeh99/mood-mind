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
    public partial class Consultant_Chat : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private int LoggedUserId;
        private int selectedUserId;
        public Consultant_Chat(int loggedUserId)
        {
            InitializeComponent();
            LoggedUserId = loggedUserId;
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

        }

        private void Consultant_Chat_Load(object sender, EventArgs e)
        {
            panel_default.Visible = true;
            LoadPatients();
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

        private void panel_default_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadPatients()
        {
            try
            {
                DataTable patients = Consult_Sessions.GetPatients(LoggedUserId);
                PatientListBox.DataSource = patients;
                PatientListBox.DisplayMember = "FullName";
                PatientListBox.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading consultants: {ex.Message}");
            }
        }

        private void PatientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PatientListBox.SelectedIndex != -1)
            {
                DataRowView selectedItem = (DataRowView)PatientListBox.SelectedItem;

                selectedUserId = (int)selectedItem["id"];

                lbl_consName.Text = selectedItem["Fullname"].ToString();

                panel_default.Visible = false;
                Consult_Sessions session = new Consult_Sessions();
                session.ConsultId = LoggedUserId;
                session.UserId = selectedUserId;
                LoadChatHistory();
            }
        }

        private void LoadChatHistory()
        {
            try
            {
                Chats op = new Chats();

                DataTable chatHistory = op.GetChatHistory(LoggedUserId, selectedUserId);
                ChatTextBox.Clear();

                foreach (DataRow row in chatHistory.Rows)
                {
                    string sender = row["senderId"].ToString() == LoggedUserId.ToString() ? "Me" : "Patient";
                    string message = row["message"].ToString();
                    ChatTextBox.AppendText($"{sender}: {message}\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chat history: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mood_Stats mood_Stats = new Mood_Stats(selectedUserId, lbl_consName.Text);
            mood_Stats.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = txt_message.Text;
             
            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    Chats chat = new Chats(LoggedUserId, selectedUserId, message);
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

        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void menuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
