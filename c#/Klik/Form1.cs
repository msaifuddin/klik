using System;
using System.Windows.Forms;

namespace Klik
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private int interval = 30000; // Default to 30 seconds

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(intervalTextBox.Text, out result))
            {
                interval = result * 1000;
                timer = new System.Windows.Forms.Timer();
                timer.Interval = interval;
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
            Application.Exit();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var pos = Cursor.Position;
            MouseOperations.LeftClick(pos.X, pos.Y);
        }
    }
}
