using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodMind.GUI
{
    public partial class User_Signup : Form
    {
        // Import user32.dll for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public User_Signup()
        {
            InitializeComponent();
            SetPlaceholder(txt_fname, lbl_fname, "First Name");
            SetPlaceholder(txt_lname, lbl_lname, "Last Name");
            SetPlaceholder(txt_birthday, lbl_birthday, "Birthday");
            SetPlaceholder(txt_contact, lbl_contact, "Contact No.");
            SetPlaceholder(txt_username, lbl_username, "Username");
            SetPlaceholder(txt_password, lbl_password, "Password");
            SetPlaceholder(txt_confirmPass, lbl_confirmPass, "Confirm Password");
            menuBar.MouseDown += new MouseEventHandler(menuBar_MouseDown);

        }

        private void SetPlaceholder(TextBox textBox, Label label, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    label.Text = placeholder;
                    label.ForeColor = Color.Gray;
                    if(textBox == txt_password || textBox == txt_confirmPass)
                    {
                        textBox.UseSystemPasswordChar = true;
                    }
                    if(textBox == txt_birthday)
                    {
                        txt_birthday.Visible = false;
                        dobPicker.Visible = true;
                    }
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                    label.Text = "";
                    textBox.UseSystemPasswordChar = false;
                }
            };
        }

        private void User_Signup_Load(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consultant_Signup consultant_Signup = new Consultant_Signup();
            consultant_Signup.Show();
        }

        private void txt_confirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = txt_fname.Text;
            string lname = txt_lname.Text;
            string contact = txt_contact.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            string confirmPass = txt_confirmPass.Text;
            string role = "user";

            DateTime dateOfBirth = dobPicker.Value;

            string gender = rd_male.Checked ? "Male" : (rd_female.Checked ? "Female" : "");

            if(gender == "")
            {
                MessageBox.Show("Please select your gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPass)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contactPattern = @"^\d{10}$"; 
            if (!Regex.IsMatch(contact, contactPattern))
            {
                MessageBox.Show("Invalid contact number. Please enter a 10-digit phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            User user = new User(fname, lname, contact, username, password, role, dateOfBirth, gender);
            
            if (user.create())
            {
                MessageBox.Show("Account created successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
            }
         }

        private void txt_birthday_TextChanged(object sender, EventArgs e)
        {

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
    }
}
