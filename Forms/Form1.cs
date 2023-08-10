using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager_CS;

public partial class Form1 : Form
{
    private const int SCREEN_WIDTH = 600;
    private const int SCREEN_HEIGHT = 800;

    public Form1()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
        this.DoubleBuffered = true;
        this.BackColor = Color.Black;

        Label home = new Label();
        home.Text = "Home";
        home.ForeColor = Color.White;
        home.BackColor = Color.Black;
        home.Font = new Font(home.Font.FontFamily, 32);
        home.Size = new Size(SCREEN_WIDTH, 100);
        home.TextAlign = ContentAlignment.MiddleCenter;

        Button addTask = new Button();
        addTask.Text = "Add New Task";
        addTask.ForeColor = Color.Black;
        addTask.BackColor = Color.Green;
        addTask.Font = new Font(addTask.Font.FontFamily, 20);
        addTask.Size = new Size(150, 100);
        addTask.Location = new Point(SCREEN_WIDTH - 160, SCREEN_HEIGHT - 110);
        addTask.TextAlign = ContentAlignment.MiddleCenter;



        this.Controls.Add(home);
        this.Controls.Add(addTask);
    }
}
