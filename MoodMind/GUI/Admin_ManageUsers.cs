using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MoodMind.GUI
{
    public partial class Admin_ManageUsers : Form
    {
        // Import user32.dll for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        int selectedUserid;
        public Admin_ManageUsers()
        {
            InitializeComponent();
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

        }

        private void btn_stats_Click(object sender, EventArgs e)
        {
            Admin_Stats admin_Stats = new Admin_Stats();
            admin_Stats.Show();
            this.Hide();
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            Admin_Payments admin_Payments = new Admin_Payments();
            admin_Payments.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_ApproveConsultants admin_ApproveConsultants = new Admin_ApproveConsultants();
            admin_ApproveConsultants.Show();
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

        private void Admin_ManageUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                DataTable users = User_all.GetUsers();

                UserList.DataSource = users;
                UserList.DisplayMember = "FullName";
                UserList.ValueMember = "id";
                UserList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading consultants: {ex.Message}");
            }
        }

        private void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserList.SelectedValue != null)
            {
                try
                {
                    DataRowView selectedItem = (DataRowView)UserList.SelectedItem;

                    selectedUserid = Convert.ToInt32(selectedItem["id"]);

                    DataRow userDetails = User.GetUserDetails(selectedUserid);

                    if (userDetails != null)
                    {
                        string username = userDetails["username"].ToString();
                        lbl_fullname.Text = userDetails["Fullname"].ToString();
                        txt_fname.Text = userDetails["fname"].ToString();
                        txt_lname.Text = userDetails["lname"].ToString();
                        txt_username.Text = userDetails["username"].ToString();
                        txt_contact.Text = userDetails["contact"].ToString();
                        dobPicker.Value = DateTime.Parse(userDetails["dob"].ToString());


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

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = txt_fname.Text;
            string lname = txt_lname.Text;
            string contact = txt_contact.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;

            DateTime dateOfBirth = dobPicker.Value;

            string contactPattern = @"^\d{10}$";
            if (!Regex.IsMatch(contact, contactPattern))
            {
                MessageBox.Show("Invalid contact number. Please enter a 10-digit phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want Update the user?",
                                      "Confirm Close",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            bool success = false;
            // Check the user's response
            if (result == DialogResult.Yes)
            {
                success = User.UpdateUserDetails(selectedUserid, username, password, fname, lname, contact, dateOfBirth);

            }

            if (success)
            {
                MessageBox.Show("User details updated successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Failed to update user details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadUsers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mood_Stats mood_Stats = new Mood_Stats(selectedUserid, lbl_fullname.Text);
            mood_Stats.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedUserid <= 0)
            {
                MessageBox.Show("Invalid user ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Deletion", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                bool success = User.DeleteUser(selectedUserid);

                if (success)
                {
                    MessageBox.Show("User deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadUsers();
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

        private void button7_Click(object sender, EventArgs e)
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
