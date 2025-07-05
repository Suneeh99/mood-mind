using MoodMind.GUI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MoodMind
{
    public partial class Login : Form
    {
        // Import user32.dll for window dragging
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;


        public Login()
        {
            InitializeComponent();
            SetPlaceholder(txt_Username, lbl_username, "Username");
            SetPlaceholder(txt_Password, lbl_password, "Password");
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

                    if (textBox == txt_Password)
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_password_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Signup user_Signup = new User_Signup();
            user_Signup.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txt_Username.Text;
            string password = txt_Password.Text;

            if (username == "Username" || password == "Password")
            {
                MessageBox.Show("Enter Username and Password", "danger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User_all user = new User_all(username, password);

            if (!user.IsValidCredentials())
            {
                MessageBox.Show("Invalid Credentials", "danger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Login Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                if (user.Role == "user")
                {
                    User_Diary user_Diary = new User_Diary(user.UserId);
                    user_Diary.Show();
                }
                else if (user.Role == "consultant")
                {
                    bool isVerified = Consultant.IsVerified(user.UserId);
                    if (isVerified)
                    {
                        Consultant_Chat consultant_Chat = new Consultant_Chat(user.UserId);
                        consultant_Chat.Show();
                    }
                    else
                    {
                        Consultant_Home consultant_Home = new Consultant_Home(user.UserId);
                        consultant_Home.Show();
                    }

                } else
                {
                    Admin_ApproveConsultants admin_ApproveConsultants = new Admin_ApproveConsultants();
                    admin_ApproveConsultants.Show();
                    this.Hide();
                }
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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
    }
}
