using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodMind
{
    internal class Chats
    {
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }

        private SqlConnection connection;

        public Chats(int userId, int consultantId, string message)
        {
            SenderId = userId;
            ReceiverId = consultantId;
            Message = message;
            
            connection = DataBaseConnector.GetConnection();
        }

        public Chats()
        {
            connection = DataBaseConnector.GetConnection();
        }

        public void SaveChat()
        {
            try
            {
                string query = "INSERT INTO chats (senderId, receiverId, message) VALUES (@SenderId, @ReceiverId, @Message)";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@SenderId", SenderId);
                cmd.Parameters.AddWithValue("@ReceiverId", ReceiverId);
                cmd.Parameters.AddWithValue("@Message", Message);

                connection.Open();
                cmd.ExecuteNonQuery();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(" "+ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable GetChatHistory(int userId, int otherUserId)
        {
            try
            {
                string query = @"
                    SELECT * 
                    FROM chats 
                    WHERE (senderId = @UserId AND receiverId = @OtherUserId) 
                       OR (senderId = @OtherUserId AND receiverId = @UserId)
                    ORDER BY chatid";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@OtherUserId", otherUserId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable chatHistory = new DataTable();
                adapter.Fill(chatHistory);
                return chatHistory;
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
