using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodMind
{
    internal class Consultant : User_all
    {
        public int ConsultantId { get; set; }
        public string ProfileLink { get; set; }
        public string Status { get; set; }

        private SqlConnection connection;


        public Consultant(string firstname, string lastname, string contact, string username, string password, string role, string profileLink, string status)
            : base(firstname, lastname, contact, username, password, role)
        {
            this.ProfileLink = profileLink;
            this.Status = status;
            connection = DataBaseConnector.GetConnection();
        }


        public override bool create()
        {

            if (!base.create())
            {
                return false;
            }

            try
            {
                string query = "INSERT INTO user_consultant (user_id, profile_link, status) " +
                               "VALUES (@uid, @profile_link, @status);";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@uid", this.UserId);
                command.Parameters.AddWithValue("@profile_link", this.ProfileLink);
                command.Parameters.AddWithValue("@status", this.Status);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding user-specific data: " + ex.Message);
                return false;
            }
        }

        public static bool IsVerified(int uid)
        {
            SqlConnection connection = DataBaseConnector.GetConnection();

            try
            {

                string query = @"SELECT status FROM user_consultant WHERE user_id = @uid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@uid", uid);

                    connection.Open();

                    string status = command.ExecuteScalar()?.ToString();

                    return status == "APPROVED";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking consultant status: {ex.Message}");
                return false;
            }
            finally
            {
                connection?.Close();
            }
        }


        public static DataRow GetConsultantDetails(int consultantId)
        {
            DataTable detailsTable = new DataTable();
            SqlConnection connection = DataBaseConnector.GetConnection();

            try
            {
                string query = @"
            SELECT u.username, CONCAT(u.fname, ' ', u.lname) AS FullName, u.contact, c.profile_link
            FROM user_consultant c
            INNER JOIN user_all u ON u.id = c.user_id
            WHERE c.user_id = @ConsultantId";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ConsultantId", consultantId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(detailsTable);

                if (detailsTable.Rows.Count > 0)
                {
                    return detailsTable.Rows[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return null;
        }

        public static bool updateStatus(int ConsultantId, string Status)
        {
            try
            {
                string query = @"UPDATE user_consultant 
                         SET status = @status 
                         WHERE user_id = @consultantId";

                using (SqlConnection connection = DataBaseConnector.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status", Status);
                        command.Parameters.AddWithValue("@consultantId", ConsultantId);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}

