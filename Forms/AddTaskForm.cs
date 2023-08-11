using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager_CS
{
    public partial class AddTaskForm : Form
    {
        private const int SCREEN_WIDTH = 600;
        private const int SCREEN_HEIGHT = 800;
        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private DateTimePicker dueDatePicker;
        private Button addButton;

        public AddTaskForm()
        {
            InitializeComponent();
            initiate();
            
            void initiate()
            {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;

            titleTextBox.PlaceholderText = "Title";
            titleTextBox.AcceptsReturn = true;
            titleTextBox.AcceptsTab = true;
            this.Controls.Add(titleTextBox);
            }
        }
    }
}