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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MoodMind.GUI
{
    public partial class User_Diary : Form
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
        private string entry = ""; 
        private int EntryId1;
        private int EntryId2;
        private DateTime date1;
        private DateTime date2;

        public User_Diary(int LoggedUserId)
        {
            this.LoggedUserId = LoggedUserId;
            InitializeComponent();
            date1 = DateTime.Now.AddDays(-1).Date;
            date2 = DateTime.Now.Date;
            lbl_tdyDate.Text = date2.ToString("yyyy-MM-dd");
            lbl_ystDate.Text = date1.ToString("yyyy-MM-dd");
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

        private void User_Diary_Load(object sender, EventArgs e)
        {
            txt_entry1.Text =  getEntry(date1, lbl_entryId1, LoggedUserId);
            txt_entry2.Text = getEntry(date2, lbl_entryId2, LoggedUserId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Stats user_Stats = new User_Stats(LoggedUserId);
            user_Stats.Show();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Tips user_Tips = new User_Tips(LoggedUserId);
            user_Tips.Show();
        }

        private void btn_chats_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Chat user_Chat = new User_Chat(LoggedUserId);
            user_Chat.Show();
        }

        private void txt_entry1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) 
            {
                e.Handled = true;

                entry = txt_entry1.Text.Trim();

                crudOperations(entry, LoggedUserId, lbl_entryId1, lbl_ystDate);
            }
        }

        private void lbl_tdyDate_Click(object sender, EventArgs e)
        {

        }

        private static string getEntry(DateTime date, Label lbl, int userId)
        {
            var entries = DiaryEntry.ViewEntriesByDate(date, userId);
            if (entries != null && entries.Count > 0)
            {
                if (entries.Count > 0)
                {
                    var en = entries.First();
                    lbl.Text = en.Key.ToString();
                    return en.Value;
                }
            }
            else
            {
                lbl.Text = "";
                return "Click Here to add Entry...";
            }
            return "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            date1 = date1.AddDays(-2).Date;
            date2 = date2.AddDays(-2).Date;

            // Update date labels
            lbl_tdyDate.Text = date2.ToString("yyyy-MM-dd");
            lbl_ystDate.Text = date1.ToString("yyyy-MM-dd");

            // Hide lbl_tdy and lbl_yst when navigating back
            lbl_tdy.Visible = false;
            lbl_yst.Visible = false;

            // Update text entries
            txt_entry1.Text = getEntry(date1, lbl_entryId1, LoggedUserId);
            txt_entry2.Text = getEntry(date2, lbl_entryId2, LoggedUserId);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;

            if(date2.AddDays(2) <= today)
            {
                date1 = date1.AddDays(2).Date;
                date2 = date2.AddDays(2).Date;
            }

            lbl_tdyDate.Text = date2.ToString("yyyy-MM-dd");
            lbl_ystDate.Text = date1.ToString("yyyy-MM-dd");

            
            lbl_tdy.Visible = date2 == today && date2.AddDays(-2) != today;
            lbl_yst.Visible = date1 == today.AddDays(-1) && date1.AddDays(-2) != today;

            
            txt_entry1.Text = getEntry(date1, lbl_entryId1, LoggedUserId);
            txt_entry2.Text = getEntry(date2, lbl_entryId2, LoggedUserId);
        }
    
        private async static void crudOperations(string entry, int LoggedUserId, Label lbl_entryId, Label lbl_date)
        {
            if (string.IsNullOrEmpty(lbl_entryId.Text) && !string.IsNullOrEmpty(entry))
            {
                DiaryEntry newEntry = new DiaryEntry(entry, LoggedUserId);
                await newEntry.AnalyzeSentiments();

                DateTime date;
                DateTime.TryParse(lbl_date.Text, out date);

                bool success = newEntry.CreateEntry(date);

                if (success)
                {
                    MessageBox.Show("Diary entry created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_entryId.Text = newEntry.EntryId.ToString();
                }
                else
                {
                    MessageBox.Show("Failed to create diary entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!string.IsNullOrEmpty(lbl_entryId.Text) && !string.IsNullOrEmpty(entry))
            {

                DiaryEntry existingEntry = new DiaryEntry(entry, LoggedUserId)
                {
                    EntryId = Convert.ToInt32(lbl_entryId.Text)
                };

                await existingEntry.AnalyzeSentiments();

                bool success = existingEntry.UpdateEntry();

                if (success)
                {
                    MessageBox.Show("Diary entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update diary entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!string.IsNullOrEmpty(lbl_entryId.Text) && string.IsNullOrEmpty(entry))
            {
                DiaryEntry entryToDelete = new DiaryEntry(entry, LoggedUserId)
                {
                    EntryId = Convert.ToInt32(lbl_entryId.Text)
                };
                bool success = false;
                DialogResult result = MessageBox.Show("Are you sure you want to delte the entry",
                          "Confirm Close",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    success = entryToDelete.DeleteEntry();
                }

                if (success)
                {
                    MessageBox.Show("Diary entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete diary entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (string.IsNullOrEmpty(lbl_entryId.Text) && string.IsNullOrEmpty(entry)) // NO ACTION
            {
                MessageBox.Show("Enter your Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_entry2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                entry = txt_entry2.Text.Trim();

                crudOperations(entry, LoggedUserId, lbl_entryId2, lbl_tdyDate);
            }
        }

        private void txt_entry1_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_entry1.Text == "Click Here to add Entry...")
            {
                txt_entry1.Text = "";
            }
        }

        private void txt_entry2_MouseClick(object sender, MouseEventArgs e)
        {
            if(txt_entry2.Text == "Click Here to add Entry...")
            {
                txt_entry2.Text = "";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
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
