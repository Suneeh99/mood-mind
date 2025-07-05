 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MoodMind.GUI
{
    public partial class Admin_ApproveConsultants : Form
    {
        // Import user32.dll for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private int selectedConsultantId;
        public Admin_ApproveConsultants()
        {
            InitializeComponent();
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

        }

        private void Admin_ApproveConsultants_Load(object sender, EventArgs e)
        {
            LoadConsultants();
        }

        private void btn_chat_Click(object sender, EventArgs e)
        {
            Admin_Payments admin_Payments = new Admin_Payments();
            admin_Payments.Show();
            this.Hide();
        }
        private void LoadConsultants()
        {
            try
            {
                DataTable consultants = User_all.GetConsultants("PENDING");

                ConsultantListBox.DataSource = consultants;
                ConsultantListBox.DisplayMember = "FullName";
                ConsultantListBox.ValueMember = "id";
                ConsultantListBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading consultants: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

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

        private void ConsultantListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ConsultantListBox.SelectedValue != null)
            {
                try
                {
                    DataRowView selectedItem = (DataRowView)ConsultantListBox.SelectedItem;

                    selectedConsultantId = Convert.ToInt32(selectedItem["id"]);

                    DataRow consultantDetails = Consultant.GetConsultantDetails(selectedConsultantId);

                    if (consultantDetails != null)
                    {
                        string username = consultantDetails["username"].ToString();
                        lbl_consName.Text = consultantDetails["Fullname"].ToString();
                        lbl_contact.Text = consultantDetails["contact"].ToString();
                        txt_profileLink.Text = consultantDetails["profile_link"].ToString();

                        string folderPath = @"C:\MoodMind\CVs";
                        string filePath = Path.Combine(folderPath, $"{username}_CV.pdf");

                        btn_downloadCV.Tag = filePath;
                    }
                    else
                    {
                        MessageBox.Show("Consultant details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btn_downloadCV_Click(object sender, EventArgs e)
        {
            string filePath = btn_downloadCV.Tag?.ToString();

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                System.Diagnostics.Process.Start("explorer.exe", filePath);
            }
            else
            {
                MessageBox.Show("CV file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isUpdated = false;

            DialogResult result = MessageBox.Show("Are you sure you want to Approve this consultant?",
                                      "Confirm Close",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                isUpdated = Consultant.updateStatus(selectedConsultantId, "APPROVED");

            }

            if (isUpdated)
            {
                MessageBox.Show("Consultant approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to approve the consultant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadConsultants();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isUpdated = false;

            DialogResult result = MessageBox.Show("Are you sure you want to Reject this consultant?",
                                      "Confirm Close",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                isUpdated = Consultant.updateStatus(selectedConsultantId, "REJECTED");

            }

            if (isUpdated)
            {
                MessageBox.Show("Consultant approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to approve the consultant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadConsultants();
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
