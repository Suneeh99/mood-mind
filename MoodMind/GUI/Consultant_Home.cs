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
    public partial class Consultant_Home : Form
    {
        private int LoggedUserId;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constants for dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public Consultant_Home(int userid)
        {
            LoggedUserId = userid;
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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            IsVerified();
        }
        
        public void IsVerified()
        {
            bool isVerified = Consultant.IsVerified(LoggedUserId);
            if (isVerified)
            {
                this.Hide();
                Consultant_Chat consultant_Chat = new Consultant_Chat(LoggedUserId);
                consultant_Chat.Show();
            }
        }

        private void Consultant_Home_Load(object sender, EventArgs e)
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
