using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;
using System.Data;

namespace MoodMind
{
    internal  class User_all
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
        SqlConnection connection;

        public User_all(string firstname, string lastname, string contact, string username, string password, string role)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Contact = contact;
            this.Username = username;
            this.Password = password;
            this.Role = role;

            connection = DataBaseConnector.GetConnection();
        }

        public User_all(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            connection = DataBaseConnector.GetConnection();
        }

        public virtual bool create()
        {
            string hashedPassword = Hash.MakeHash(Password);

            try
            {
                string query = "INSERT INTO user_all (fname, lname, contact, username, password, role) " +
               "VALUES (@fname, @lname, @contact, @username, @password, @role); " +
               "SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fname", FirstName);
                command.Parameters.AddWithValue("@lname", LastName);
                command.Parameters.AddWithValue("@contact", Contact);
                command.Parameters.AddWithValue("@username", Username);
                command.Parameters.AddWithValue("@password", hashedPassword);
                command.Parameters.AddWithValue("@role", Role);

                connection.Open();
                var result = command.ExecuteScalar();
                connection.Close();

                UserId = Convert.ToInt32(result);

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("" + ex);
                return false;
            }
        }

        public bool IsValidCredentials()
        {
            try
            {
                string sql = "SELECT id, role, password FROM user_all WHERE username = @username";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@username", this.Username);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string storedHashPassword = reader["password"].ToString();
                    this.UserId = Convert.ToInt32(reader["id"]);
                    this.Role = reader["role"].ToString();

                    string hashedPassword = Hash.MakeHash(this.Password);

                    bool isValid = Hash.VerifyHash(this.Password, storedHashPassword);

                    if (isValid)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                connection.Close();
                return false;
            }
        }

        public static DataTable GetConsultants(string status)
        {
            DataTable consultants = new DataTable();
            SqlConnection connection;
            connection = DataBaseConnector.GetConnection();

            try
            {
                string query = @"
            SELECT u.id, CONCAT(u.fname, ' ', u.lname) AS FullName
            FROM user_all u
            INNER JOIN user_consultant c ON u.id = c.user_id
            WHERE u.role = 'consultant' AND c.status = @status";

                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@status", status);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(consultants);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               connection.Close();
            }
            return consultants;
        }

        public static DataTable GetUsers()
        {
            DataTable users = new DataTable();
            SqlConnection connection;
            connection = DataBaseConnector.GetConnection();

            try
            {
                string query = @"
                            SELECT id, CONCAT(fname, ' ', lname) AS FullName
                            FROM user_all WHERE role = 'user'";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(users);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return users;
        }
    }
}
