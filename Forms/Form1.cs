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
        Label title = new Label();

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
            AddTaskForm taskform = new AddTaskForm(taskList, UpdateTaskDisplay);
            taskform.ShowDialog();
        }
        public void UpdateTaskDisplay()
        {
            //Clear existing task labels below title label
            foreach (Control control in Controls)
            {
                if(control is Label taskLabel && control != title)
                {
                    Controls.Remove(control);
                    control.Dispose();
                }
            }

            //Display tasks below title label
            int yOffset = title.Bottom + 10;
            foreach (var task in taskList)
            {
                Label taskLabel = new Label();
                taskLabel.Text = $"{task.Title} - {task.Description} - {task.DueDate.ToShortDateString()}";
                taskLabel.ForeColor = Color.White;
                taskLabel.Size = new Size(SCREEN_WIDTH - 10, 50);
                taskLabel.Font = new Font(taskLabel.Font.FontFamily, 18);
                taskLabel.Location = new Point(10, yOffset);
                yOffset += taskLabel.Height + 5;
                Controls.Add(taskLabel);
            }
        }
    }

    public class Task
    {
        public string Title {get; private set;}
        public string Description {get; private set;}
        public DateTime DueDate {get; private set;}

        public Task(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
        }
    }   
}