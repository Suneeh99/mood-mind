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
    internal class Consult_Sessions
    {
        public int SessionID { get; set; }
        public int UserId { get; set; }
        public int ConsultId { get; set; }
        public string ChatPlan { get; set; }
        public Decimal Price { get; set; }
        public DateTime PurchaseDateTime{ get; set; }
        public DateTime ExpireDateTime{ get; set; }
        private SqlConnection connection;
        
        public Consult_Sessions()
        {
            connection = DataBaseConnector.GetConnection();
        }
        public Consult_Sessions(int uid, int cid, string chatplan, decimal price, DateTime expire)
        {
            this.UserId = uid;
            this.ConsultId = cid;
            this.ChatPlan = chatplan;
            this.Price = price;
            this.ExpireDateTime = expire;
            connection = DataBaseConnector.GetConnection();
        }
        public bool Create()
        {
            try
            {
                string sql = @"INSERT into consult_session (uid, cid, chatplan, price, expired_datetime)
                            VALUES (@uid, @cid, @chatplan, @price, @expireDate)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@uid", UserId);
                command.Parameters.AddWithValue("@cid", ConsultId);
                command.Parameters.AddWithValue("@chatplan", ChatPlan);
                command.Parameters.AddWithValue("@price", Price);
                command.Parameters.AddWithValue("@expireDate", ExpireDateTime);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public DateTime? GetExpirationDate()
        {
            try
            {
                string query = @"
                        SELECT expired_datetime 
                        FROM consult_session 
                        WHERE uid = @UserId 
                          AND cid = @ConsultantId 
                          AND expired_datetime > GETDATE()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@ConsultantId", ConsultId);

                    connection.Open();

                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDateTime(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching expiration date: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return null; 
        }

        public TimeSpan GetRemainingTime(DateTime expireTime)
        {
            DateTime now = DateTime.Now;
            return expireTime - now;
        }
        
        public static DataTable GetPatients(int cid)
        {
            DataTable patients = new DataTable();
            SqlConnection connection;
            connection = DataBaseConnector.GetConnection();

            try
            {
                string query = @" SELECT u.id, CONCAT(u.fname, ' ', u.lname) AS FullName 
                                    FROM user_all u
                                    WHERE u.id IN (SELECT uid FROM consult_session WHERE cid = @cid)";

                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@cid", cid);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(patients);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return patients;
        }

        public static DataTable GetConsultationData()
        {
            SqlConnection connection = DataBaseConnector.GetConnection();
            DataTable dt = new DataTable();

            string query = @"
                    SELECT
                        cs.purchase_datetime AS 'PaymentDate',
                        CONCAT(ua_patient.fname, ' ', ua_patient.lname) AS 'PatientName',
                        CONCAT(ua_consultant.fname, ' ', ua_consultant.lname) AS 'ConsultantName',
                        cs.chatplan AS 'Plan'
                    FROM consult_session cs
                    JOIN user_all ua_patient ON cs.uid = ua_patient.id
                    JOIN user_all ua_consultant ON cs.cid = ua_consultant.id;";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching consultation data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt; // Return the DataTable containing the query results
        }
    }
}
