using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager_CS
{
    public partial class AddTaskForm : Form
    {
        private const int SCREEN_WIDTH = 600;
        private const int SCREEN_HEIGHT = 800;
        private List<Task> taskList;
        private Action updateDisplay;
        TextBox titleTextBox = new System.Windows.Forms.TextBox();
        TextBox descriptionTextBox = new System.Windows.Forms.TextBox();
        DateTimePicker dueDatePicker = new DateTimePicker();
        Button addButton = new Button();

        public AddTaskForm(List<Task> taskList, Action updateDisplay)
        {
            InitializeComponent();
            this.taskList = taskList;
            this.updateDisplay = updateDisplay;
                     
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;

            titleTextBox.Size = new Size(SCREEN_WIDTH - 10, 200);
            titleTextBox.Location = new Point(5, 5);
            titleTextBox.PlaceholderText = "Title";
            titleTextBox.AcceptsReturn = true;
            titleTextBox.AcceptsTab = true;
            titleTextBox.Font = new Font(titleTextBox.Font.FontFamily, 28);
            this.Controls.Add(titleTextBox);
            
            descriptionTextBox.Size = new Size(SCREEN_WIDTH - 10, SCREEN_HEIGHT - 200);
            descriptionTextBox.AutoSize = false;
            descriptionTextBox.AcceptsReturn = true;
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Location = new Point(5, 65);
            descriptionTextBox.PlaceholderText = "Description";
            this.Controls.Add(descriptionTextBox);

            dueDatePicker.Size = new Size(SCREEN_WIDTH - 10, 100);
            dueDatePicker.Font = new Font(dueDatePicker.Font.FontFamily, 28);
            dueDatePicker.Location = new Point(5, 670);
            this.Controls.Add(dueDatePicker);

            addButton.Size = new Size(SCREEN_WIDTH - 10, 50);
            addButton.Font = new Font(addButton.Font.FontFamily, 28);
            addButton.Location = new Point(5, SCREEN_HEIGHT - 60);
            addButton.Text = "Submit Task";
            addButton.TextAlign = ContentAlignment.MiddleCenter;
            addButton.ForeColor = Color.White;
            addButton.BackColor = Color.Green;
            addButton.Click += new EventHandler(onButtonClickedAddButton);
            this.Controls.Add(addButton);
        }

        private void onButtonClickedAddButton(object sender, EventArgs e)
        {
            Task newTask = GetTask();
            taskList.Add(newTask);
            updateDisplay();
            this.Close();
        }

        public Task GetTask()
        {
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            DateTime dueDate = dueDatePicker.Value;

            return new Task(0, title, description, dueDate);
        }
    }
}