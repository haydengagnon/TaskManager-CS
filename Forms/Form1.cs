using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager_CS
{
    public partial class Form1 : Form
    {
        private const int SCREEN_WIDTH = 600;
        private const int SCREEN_HEIGHT = 800;
        List<Task> taskList = new List<Task>();

        public Form1()
        {
            InitializeComponent();
            initiate();
            
            void initiate()
            {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;

            Button newTask = new Button();
            newTask.Text = "New Task";
            newTask.Font = new Font(newTask.Font.FontFamily, 20);
            newTask.ForeColor = Color.White;
            newTask.BackColor = Color.SlateGray;
            newTask.Size = new Size(100, 60);
            newTask.TextAlign = ContentAlignment.MiddleCenter;
            newTask.Location = new Point(SCREEN_WIDTH - 100, 0);
            newTask.Click += new EventHandler(onButtonClickedNewTask);
            this.Controls.Add(newTask);

            //Create Title at the top of the app
            Label title = new Label();
            title.Text = "Task Manager";
            title.Font = new Font(title.Font.FontFamily, 32);
            title.ForeColor = Color.White;
            title.BackColor = Color.SlateGray;
            title.Size = new Size(SCREEN_WIDTH, 60);
            title.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(title);
            }
        }
        private void onButtonClickedNewTask(object sender, EventArgs e)
        {
            //open addtaskform.cs
            AddTaskForm taskform = new AddTaskForm();
            taskform.Show();
        }
    }

    public class Task
    {
        string title;
        string description;
        DateTime duedate;

        public Task(string title, string description, DateTime duedate)
        {
            this.title = title;
            this.description = description;
            this.duedate = duedate;
        }
    }
}

