using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Entity;
using System.Data.SqlTypes;

namespace TaskManager_CS
{
    public class DatabaseManager
    {
    
        
        public void CreateDatabase()
        {
            string connectionString = "Data Source=database.db";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTable = "CREATE TABLE IF NOT EXISTS tasks (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT, Description TEXT, DueDate TEXT)";
                using (SQLiteCommand command = new SQLiteCommand(createTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertTask()
        {
            string connectionString = "Data Source=database.db";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            string insert = "INSERT INTO tasks (Id, Title, Description, DueDate) VALUES (@Id, @Title, @Description, @DueDate)";
            
        }
    }
}