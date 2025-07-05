using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodMind
{
    internal class DiaryEntry
    {
        public int EntryId { get; set; }
        public int UserId { get; set; }

        public string Entry { get; set; }
        public double HappySentiment { get; set; }
        public double SadSentiment { get; set; }
        public double NeutralSentiment { get; set; }
        public double ShockedSentiment { get; set; }
        public double AngrySentiment { get; set; }


        private SqlConnection connection;

        public DiaryEntry(string entry, int userId)
        {
            this.UserId = userId;
            this.Entry = entry;
            this.HappySentiment = 0;
            this.SadSentiment = 0;
            this.NeutralSentiment = 0;
            this.AngrySentiment = 0;
            connection = DataBaseConnector.GetConnection();
        }

        public DiaryEntry(int userId)
        {
            this.UserId = userId;
            connection = DataBaseConnector.GetConnection();
        }

        public async Task AnalyzeSentiments()
        {
            try
            {
                var emotions = await SentimentAnalyze.DetectEmotions(Entry);
                
                foreach (var line in emotions.Split('\n'))
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        var emotion = parts[0].Trim().ToLower();
                        var score = Convert.ToDouble(parts[1].Trim().TrimEnd('%'));

                        switch (emotion)
                        {
                            case "joy":
                                HappySentiment = score;
                                break;
                            case "sadness":
                                SadSentiment = score;
                                break;
                            case "neutral":
                                NeutralSentiment = score;
                                break;
                            case "surprise":
                                ShockedSentiment = score;
                                break;
                            case "anger":
                                AngrySentiment = score;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error analyzing sentiments: {ex.Message}");
            }
        }

        public bool CreateEntry(DateTime createDate)
        {
            try
            {
                connection.Open(); 

                var query = "INSERT INTO diary_entry ( uid ,entry, " +
                            "happy, sad, neutral, " +
                            "shocked, angry, createDate) " +
                            "VALUES (@userId, @entry, @happy, @sad," +
                            " @neutral, @shocked, @angry, @createDate)";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", this.UserId);
                command.Parameters.AddWithValue("@entry", this.Entry);
                command.Parameters.AddWithValue("@happy", this.HappySentiment);
                command.Parameters.AddWithValue("@sad", this.SadSentiment);
                command.Parameters.AddWithValue("@neutral", this.NeutralSentiment);
                command.Parameters.AddWithValue("@shocked", this.ShockedSentiment);
                command.Parameters.AddWithValue("@angry", this.AngrySentiment);
                command.Parameters.AddWithValue("@CreateDate", createDate);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
            catch (SqlException ex)
            {
                
                MessageBox.Show($"Error creating entry: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close(); 
            }
        }

        public bool UpdateEntry()
        {
            try
            {
                connection.Open();

                var query = "UPDATE diary_entry SET entry = @entry, happy = @happy, sad = @sad, " +
                            "neutral = @neutral, shocked = @shocked , angry = @angry " +
                            "WHERE eid = @eid";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@entry", this.Entry);
                command.Parameters.AddWithValue("@happy", this.HappySentiment);
                command.Parameters.AddWithValue("@sad", this.SadSentiment);
                command.Parameters.AddWithValue("@neutral", this.NeutralSentiment);
                command.Parameters.AddWithValue("@shocked", this.ShockedSentiment);
                command.Parameters.AddWithValue("@angry", this.AngrySentiment);
                command.Parameters.AddWithValue("@eid", this.EntryId);

                int rowsAffected = command.ExecuteNonQuery(); 
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating entry: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close(); 
            }
        }

        public bool DeleteEntry()
        {
            try
            {
                connection.Open(); 

                var query = "DELETE FROM diary_entry WHERE eid = @eid";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@eid", this.EntryId);

                
                int rowsAffected = command.ExecuteNonQuery(); 

                return rowsAffected > 0; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting entry: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Dictionary<int, string> ViewEntriesByDate(DateTime date, int userId)
        {
            SqlConnection connection = DataBaseConnector.GetConnection();
            var entries = new Dictionary<int, string>();

            try
            {
                connection.Open();

                var query = "SELECT eid, entry FROM diary_entry WHERE " +
                    "createDate = @CreateDate AND uid = @userid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CreateDate", date.Date);
                    command.Parameters.AddWithValue("@userid", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int eid = reader.GetInt32(reader.GetOrdinal("eid")); 
                            string entry = reader.GetString(reader.GetOrdinal("entry"));
                            entries[eid] = entry; 

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing entries: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return entries;
        }

        public void getTodaystats()
        {
            DateTime date = DateTime.Now;
            try
            {
                connection.Open();

                var query = "SELECT * FROM diary_entry WHERE " +
                    "createDate = @CreateDate AND uid = @userid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CreateDate", date.Date);
                    command.Parameters.AddWithValue("@userid", this.UserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HappySentiment = reader.GetDouble(reader.GetOrdinal("happy"));
                            SadSentiment = reader.GetDouble(reader.GetOrdinal("sad"));
                            NeutralSentiment = reader.GetDouble(reader.GetOrdinal("neutral"));
                            ShockedSentiment = reader.GetDouble(reader.GetOrdinal("shocked"));
                            AngrySentiment = reader.GetDouble(reader.GetOrdinal("angry"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing Sentimentals: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void GetWeeklySentiments()
        {
            try
            {
                connection.Open();

                string query = @"
                SELECT 
                    SUM(happy) AS happy,
                    SUM(sad) AS sad,
                    SUM(neutral) AS neutral,
                    SUM(shocked) AS shocked,
                    SUM(angry) AS angry
                FROM diary_entry
                WHERE uid = @UserId AND createDate >= DATEADD(DAY, -7, GETDATE())";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", this.UserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HappySentiment = reader.GetDouble(reader.GetOrdinal("happy"));
                            SadSentiment = reader.GetDouble(reader.GetOrdinal("sad"));
                            NeutralSentiment = reader.GetDouble(reader.GetOrdinal("neutral"));
                            ShockedSentiment = reader.GetDouble(reader.GetOrdinal("shocked"));
                            AngrySentiment = reader.GetDouble(reader.GetOrdinal("angry"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing Sentimentals: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void GetMonthlySentiments()
        {
            try
            {
                connection.Open();

                string query = @"
                SELECT 
                    SUM(happy) AS happy,
                    SUM(sad) AS sad,
                    SUM(neutral) AS neutral,
                    SUM(shocked) AS shocked,
                    SUM(angry) AS angry
                FROM diary_entry
                WHERE uid = @UserId 
                AND createDate >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)  -- Start of current month
                AND createDate < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0);  -- Start of next month";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", this.UserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HappySentiment = reader.GetDouble(reader.GetOrdinal("happy"));
                            SadSentiment = reader.GetDouble(reader.GetOrdinal("sad"));
                            NeutralSentiment = reader.GetDouble(reader.GetOrdinal("neutral"));
                            ShockedSentiment = reader.GetDouble(reader.GetOrdinal("shocked"));
                            AngrySentiment = reader.GetDouble(reader.GetOrdinal("angry"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error viewing Sentimentals: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        
    }
}

