using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.Versioning;

namespace Klik
{
    [SupportedOSPlatform("windows6.1")]
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer? countdownTimer;
        private int interval;
        private int countdown;

        public Form1()
        {
            InitializeComponent();
            statusLabel.Text = "Status: Stopped";  // Initialize status label
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(intervalTextBox.Text, out int result))
            {
                if (result <= 0)
                {
                    MessageBox.Show("Interval must be greater than 0", "Invalid Interval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                interval = result;
                countdown = result;

                if (countdownTimer == null)
                {
                    countdownTimer = new System.Windows.Forms.Timer();
                    countdownTimer.Interval = 1000;  // 1 second
                    countdownTimer.Tick += CountdownTimer_Tick;
                }

                countdownTimer.Start();
                statusLabel.Text = $"Status: Running, Klik in {countdown}s";  // Update status label
            }
            else
            {
                MessageBox.Show("Please enter a valid number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (countdownTimer != null)
            {
                countdownTimer.Stop();
                countdownTimer.Dispose();
                countdownTimer = null;
            }

            statusLabel.Text = "Status: Stopped";  // Update status label
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (countdownTimer != null)
            {
                countdownTimer.Stop();
                countdownTimer.Dispose();
                countdownTimer = null;
            }

            Application.Exit();
        }

        private void CountdownTimer_Tick(object? sender, EventArgs e)
        {
            countdown--;
            if (countdown > 0)
            {
                statusLabel.Text = $"Status: Running, Klik in {countdown}s";
            }
            else
            {
                var pos = Cursor.Position;
                MouseOperations.LeftClick(pos.X, pos.Y);
                statusLabel.Text = "Status: Running, Klik!";
                countdown = interval;
            }
        }
    }

    [SupportedOSPlatform("windows6.1")]
    public static class MouseOperations
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public static void LeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
    }
}
