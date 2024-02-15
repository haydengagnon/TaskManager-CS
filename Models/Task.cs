using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TaskManager_CS
{
    public class Task
    {
        public int Id {get; private set;}
        public string Title {get; private set;}
        public string Description {get; private set;}
        public DateTime DueDate {get; private set;}


        public Task(int id, string title, string description, DateTime dueDate)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
        }
    }
}