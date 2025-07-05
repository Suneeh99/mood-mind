using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodMind
{
    internal class Tips
    {
        public int TipId { get; set; }
        public string RiskLevel { get; set; } 
        public string Donts { get; set; }
        public string Dos { get; set; }

        private SqlConnection connection;

        public Tips(string riskLevel)
        {
            this.RiskLevel = riskLevel;
            connection = DataBaseConnector.GetConnection();
        }

        public string GetDos()
        {
            try
            {
                string result = null;

                string query = @"SELECT dos FROM tips WHERE risk_level = @riskLevel";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@riskLevel", RiskLevel);

                    // Execute and check for null result
                    result = command.ExecuteScalar()?.ToString();
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving Do's: {ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetDonts()
        {
            try
            {
                string result = null;

                string query = @"SELECT donts FROM tips WHERE risk_level = @riskLevel";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@riskLevel", RiskLevel);

                    // Execute and check for null result
                    result = command.ExecuteScalar()?.ToString();
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving Don'ts: {ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
