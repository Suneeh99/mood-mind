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
    public partial class Consultant_Signup : Form
    {       
        // Import user32.dll for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private string uploadedFilePath = "";
        public Consultant_Signup()
        {
            InitializeComponent();
            SetPlaceholder(txt_fname, lbl_fname, "First Name");
            SetPlaceholder(txt_lname, lbl_lname, "Last Name");
            SetPlaceholder(txt_contact, lbl_contactNo, "Contact No.");
            SetPlaceholder(txt_linkedIn, lbl_linkedin, "LinkedIn Profile");
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

                    if (textBox == txt_password || textBox == txt_confirmPass)
                    {
                        textBox.UseSystemPasswordChar = true;
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

        private void Consultant_Signup_Load(object sender, EventArgs e)
        {

        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void lbl_imUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Signup login = new User_Signup();
            login.Show();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close this form?",
                                                  "Confirm Close",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            string fname = txt_fname.Text;
            string lname = txt_lname.Text;
            string contact = txt_contact.Text;
            string username = txt_username.Text;
            string password = txt_password.Text;
            string confirmPass = txt_confirmPass.Text;
            string role = "consultant";
            string profileLink = txt_linkedIn.Text;
            string status = "PENDING";


            if (string.IsNullOrEmpty(uploadedFilePath))
            {
                MessageBox.Show("Please upload a CV first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isUploaded = UploadCV(uploadedFilePath, username.Trim());


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

            Consultant consultant = new Consultant(fname, 
                                                    lname, 
                                                    contact, 
                                                    username, 
                                                    password, 
                                                    role, 
                                                    profileLink, 
                                                    status);
           

            if (consultant.create() && isUploaded)
            {
                MessageBox.Show("Account created successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        } 

        private void txt_contactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_uploadCV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                uploadedFilePath = openFileDialog.FileName;
                txt_filePath.Text = "File Path : " + uploadedFilePath; 
            }
        }
        private bool UploadCV(string filePath, string username)
        {
            try
            {
                string fileExtension = Path.GetExtension(filePath);

                string destinationDirectory = @"C:\MoodMind\CVs"; 
                string newFileName = username + "_CV" + fileExtension; 
                string destinationPath = Path.Combine(destinationDirectory, newFileName);

                Directory.CreateDirectory(destinationDirectory);

                File.Copy(filePath, destinationPath, overwrite: true);
                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading CV: " + ex.Message);
                return false;
            }
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

