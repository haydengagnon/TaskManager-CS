using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManager_CS;

public partial class Form1 : Form
{
    private const int SCREEN_WIDTH = 1280;
    private const int SCREEN_HEIGHT = 720;

    public Form1()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
        this.DoubleBuffered = true;
        this.BackColor = Color.Black;

        Label toDo = new Label();
        toDo.Text = "Tasks";
        
    }
}
