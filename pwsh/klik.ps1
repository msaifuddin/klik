# Load the necessary assembly for Windows Forms
Add-Type -AssemblyName System.Windows.Forms

# Define the MouseOperations class
Add-Type -TypeDefinition @"
using System;
using System.Runtime.InteropServices;

public class MouseOperations
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
"@

# Initialize the timer
$global:timer = New-Object System.Windows.Forms.Timer
$global:timer.Interval = 30000 # Default to 30 seconds

# Define the start and stop actions
$startClicking = {
    $interval = [int]$intervalTextBox.Text
    $global:timer.Interval = $interval * 1000
    $global:timer.Start()
}

$stopClicking = {
    $global:timer.Stop()
}

# Define the action for each timer tick
$global:timer.add_Tick({
    $pos = [System.Windows.Forms.Cursor]::Position
    [MouseOperations]::LeftClick($pos.X, $pos.Y)
})

# Create the form
$form = New-Object System.Windows.Forms.Form
$form.Text = "Klik..."
$form.Size = New-Object System.Drawing.Size(220, 130)
$form.FormBorderStyle = [System.Windows.Forms.FormBorderStyle]::FixedDialog
$form.MaximizeBox = $false
$form.MinimizeBox = $false
$form.StartPosition = [System.Windows.Forms.FormStartPosition]::CenterScreen

# Add a handler to stop the timer and close the application cleanly
$form.add_FormClosed({
    $global:timer.Stop()
    [System.Windows.Forms.Application]::Exit()
})

# Create the interval label
$intervalLabel = New-Object System.Windows.Forms.Label
$intervalLabel.Text = "Interval (seconds):"
$intervalLabel.AutoSize = $true
$intervalLabel.Location = New-Object System.Drawing.Point(20, 20)
$form.Controls.Add($intervalLabel)

# Create the interval text box
$intervalTextBox = New-Object System.Windows.Forms.TextBox
$intervalTextBox.Text = "30" # Default to 30 seconds
$intervalTextBox.Size = New-Object System.Drawing.Size(50, 20)
$intervalTextBox.Location = New-Object System.Drawing.Point(130, 18)
$form.Controls.Add($intervalTextBox)

# Center the buttons
$buttonWidth = 75
$spacing = 10
$startButtonX = ($form.ClientSize.Width - (2 * $buttonWidth + $spacing)) / 2
$stopButtonX = $startButtonX + $buttonWidth + $spacing

# Create the Start button
$startButton = New-Object System.Windows.Forms.Button
$startButton.Text = "Start"
$startButton.Size = New-Object System.Drawing.Size($buttonWidth, 23)
$startButton.Location = New-Object System.Drawing.Point($startButtonX, 60)
$startButton.Add_Click($startClicking)
$form.Controls.Add($startButton)

# Create the Stop button
$stopButton = New-Object System.Windows.Forms.Button
$stopButton.Text = "Stop"
$stopButton.Size = New-Object System.Drawing.Size($buttonWidth, 23)
$stopButton.Location = New-Object System.Drawing.Point($stopButtonX, 60)
$stopButton.Add_Click($stopClicking)
$form.Controls.Add($stopButton)

# Show the form
[void] $form.ShowDialog()
