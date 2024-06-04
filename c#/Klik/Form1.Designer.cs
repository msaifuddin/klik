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
            start = new Button();
            stop = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(154, 25);
            label1.TabIndex = 0;
            label1.Text = "Interval (seconds):";
            // 
            // intervalTextBox
            // 
            intervalTextBox.Location = new Point(175, 20);
            intervalTextBox.Margin = new Padding(4, 5, 4, 5);
            intervalTextBox.Name = "intervalTextBox";
            intervalTextBox.Size = new Size(74, 31);
            intervalTextBox.TabIndex = 1;
            intervalTextBox.Text = "30";
            // 
            // start
            // 
            start.Location = new Point(13, 64);
            start.Margin = new Padding(4, 5, 4, 5);
            start.Name = "start";
            start.Size = new Size(107, 38);
            start.TabIndex = 2;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += startButton_Click;
            // 
            // stop
            // 
            stop.Location = new Point(142, 64);
            stop.Margin = new Padding(4, 5, 4, 5);
            stop.Name = "stop";
            stop.Size = new Size(107, 38);
            stop.TabIndex = 3;
            stop.Text = "Stop";
            stop.UseVisualStyleBackColor = true;
            stop.Click += stopButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 118);
            Controls.Add(stop);
            Controls.Add(start);
            Controls.Add(intervalTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Opacity = 0.7D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Klik";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
    }
}