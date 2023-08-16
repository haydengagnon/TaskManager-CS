using System;
using System.Data;
using System.Data.SQLite;

namespace TaskManager_CS
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager(string databasePath)
        {
            connectionString = $"Data Source=database.db";
        }

        public void InsertTask(Task task)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Tasks (Title, Description, DueDate) VALUES (@Title, @Description, @DueDate)";
                    command.Parameters.AddWithValue("@Title", task.Title);
                    command.Parameters.AddWithValue("@Description", task.Description);
                    command.Parameters.AddWithValue("@DueDate", task.DueDate);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}