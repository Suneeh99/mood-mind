using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodMind
{
    public class DataBaseConnector
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                                AttachDbFilename=C:\MoodMind\MoodMind.mdf;
                                                Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
