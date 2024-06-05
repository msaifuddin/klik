namespace Klik
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            intervalTextBox = new TextBox();
            startButton = new Button();
            stopButton = new Button();
            statusLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(154, 25);
            label1.TabIndex = 0;
            label1.Text = "Interval (seconds):";
            // 
            // intervalTextBox
            // 
            intervalTextBox.Location = new Point(191, 20);
            intervalTextBox.Margin = new Padding(4, 5, 4, 5);
            intervalTextBox.MaxLength = 4;
            intervalTextBox.Name = "intervalTextBox";
            intervalTextBox.Size = new Size(70, 31);
            intervalTextBox.TabIndex = 1;
            intervalTextBox.Text = "30";
            // 
            // startButton
            // 
            startButton.Location = new Point(17, 83);
            startButton.Margin = new Padding(4, 5, 4, 5);
            startButton.Name = "startButton";
            startButton.Size = new Size(107, 38);
            startButton.TabIndex = 2;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(156, 83);
            stopButton.Margin = new Padding(4, 5, 4, 5);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(107, 38);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusLabel.Location = new Point(17, 53);
            statusLabel.Margin = new Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(146, 25);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "Status: Stopped";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 136);
            Controls.Add(statusLabel);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(intervalTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Klik";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label statusLabel;  // Add this line
    }
}
