using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodMind
{
    internal class Statistics
    {
        public int MaleUsers { get; set; }
        public int FemaleUsers { get; set; }
        public int AgeGroup1 { get; set; }  
        public int AgeGroup2 { get; set; }  
        public int AgeGroup3 { get; set; } 
        public int AgeGroup4 { get; set; } 
        public int AgeGroup5 { get; set; }  
        public int HappyCount { get; set; }
        public int SadCount { get; set; }
        public int NeutralCount { get; set; }
        public int AngryCount { get; set; }
        public int ShockedCount { get; set; }
        public int TotalDiaryEntries { get; set; }
        private SqlConnection connection;

        public Statistics()
        {
            connection = DataBaseConnector.GetConnection();
        }

        public Statistics GetStatistics()
        {
            Statistics stats = new Statistics();

            string query = @"
            SELECT u.gender, 
                   u.dob,
                   de.happy, de.sad, de.neutral, de.angry, de.shocked
            FROM user_user u
            LEFT JOIN diary_entry de ON u.uid = de.uid;";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Gender-based user count
                    string gender = reader["gender"].ToString();
                    if (gender == "Male")
                    {
                        stats.MaleUsers++;
                    }
                    else if (gender == "Female")
                    {
                        stats.FemaleUsers++;
                    }

                    DateTime dob = Convert.ToDateTime(reader["dob"]);
                    int age = DateTime.Now.Year - dob.Year;
                    if (age >= 18 && age <= 25)
                    {
                        stats.AgeGroup1++;
                    }
                    else if (age >= 26 && age <= 35)
                    {
                        stats.AgeGroup2++;
                    }
                    else if (age >= 36 && age <= 45)
                    {
                        stats.AgeGroup3++;
                    }
                    else if (age >= 46 && age <= 60)
                    {
                        stats.AgeGroup4++;
                    }
                    else if (age > 60)
                    {
                        stats.AgeGroup5++;
                    }
                    stats.HappyCount += reader["happy"] != DBNull.Value ? (int)Math.Round(Convert.ToSingle(reader["happy"])) : 0;
                    stats.SadCount += reader["sad"] != DBNull.Value ? (int)Math.Round(Convert.ToSingle(reader["sad"])) : 0;
                    stats.NeutralCount += reader["neutral"] != DBNull.Value ? (int)Math.Round(Convert.ToSingle(reader["neutral"])) : 0;
                    stats.AngryCount += reader["angry"] != DBNull.Value ? (int)Math.Round(Convert.ToSingle(reader["angry"])) : 0;
                    stats.ShockedCount += reader["shocked"] != DBNull.Value ? (int)Math.Round(Convert.ToSingle(reader["shocked"])) : 0;

                    stats.TotalDiaryEntries++;
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

            return stats;
        }


    }
}
