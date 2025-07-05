using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MoodMind
{
    internal class User : User_all
    {
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        private SqlConnection connection;



        public User(string firstname, string lastname, string contact, string username, string password, string role, DateTime dateofbirth, string gender)
            : base(firstname, lastname, contact, username, password, role) 
        {
            this.DateOfBirth = dateofbirth;
            this.Gender = gender;
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
                string query = "INSERT INTO user_user (uid, dob, gender) " +
                               "VALUES (@uid, @dob, @gender);";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@uid", this.UserId);
                command.Parameters.AddWithValue("@dob", this.DateOfBirth);
                command.Parameters.AddWithValue("@gender", this.Gender);

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

        public DataTable GetAllUsers()
        {
            DataTable usersTable = new DataTable();

            try
            {
                string query = @"SELECT u.";

                using (SqlConnection connection = DataBaseConnector.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        connection.Open();
                        adapter.Fill(usersTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return usersTable;
        }

        public static DataRow GetUserDetails(int userId)
        {
            DataTable detailsTable = new DataTable();
            SqlConnection connection = DataBaseConnector.GetConnection();

            try
            {
                string query = @"
                            SELECT u.username, u.fname, u.lname, CONCAT(u.fname, ' ' , u.lname) AS Fullname, u.contact, uu.dob
                            FROM user_all u
                            INNER JOIN user_user uu ON u.id = uu.uid
                            WHERE u.id = @userId;
                            ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@userId", userId);
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

        public static bool UpdateUserDetails(int userId, string username, string password, string fname, string lname, string contact, DateTime dob)
        {
            SqlConnection connection = DataBaseConnector.GetConnection();

            bool isUpdated = false;

            string query = @"
                            UPDATE user_all 
                            SET username = @username, fname = @fname, lname = @lname, contact = @contact, password = @password
                            WHERE id = @userId;

                            UPDATE user_user 
                            SET dob = @dob
                            WHERE uid = @userId;";
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    string hashedPassword = Hash.MakeHash(password);

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@dob", dob);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        isUpdated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isUpdated;
        }

        public static bool DeleteUser(int userId)
        {
            bool isDeleted = false;

            SqlConnection connection = DataBaseConnector.GetConnection();
            string query = @"
                        DELETE FROM user_user 
                        WHERE uid = @userId;

                        DELETE FROM user_all 
                        WHERE id = @userId;";

            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        isDeleted = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return isDeleted;
        }
    }
}
