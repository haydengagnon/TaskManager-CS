using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.Json.Nodes;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

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
            LoadTaskList();
            UpdateTaskDisplay();
            
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;

            Button newTask = new Button();
            newTask.Text = "New Task";
            newTask.Font = new Font(newTask.Font.FontFamily, 20);
            newTask.ForeColor = Color.White;
            newTask.BackColor = Color.SlateGray;
            newTask.Size = new Size(SCREEN_WIDTH / 6, 60);
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

        private void onButtonClickedNewTask(object sender, EventArgs e)
        {
            //open addtaskform.cs
            AddTaskForm taskform = new AddTaskForm(taskList, UpdateTaskDisplay);
            if (taskform.ShowDialog() == DialogResult.OK)
            {
                UpdateTaskDisplay();
            }
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
            int yOffset = 70;
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

        private void LoadTaskList()
        {
            string jsonData = string.Empty;
            if (jsonData != string.Empty)
            {
                jsonData = File.ReadAllText(@"C:\TaskManagerApp\TaskManager-CS\savedform.json");
                JObject jObj = JObject.Parse(jsonData);
                Console.WriteLine(jObj);
            }
            
            //var ids = jObj["Id"]["Title"]["Description"]["DueDate"];

            DateTime dt1 = new DateTime();
            Task task = new Task(0,"Laundry","Do Laundry", dt1);
            taskList.Add(task);
        }
    }
}