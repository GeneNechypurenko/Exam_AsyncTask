namespace Exam
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            controlsGroupBox = new GroupBox();
            inputTextBox = new TextBox();
            browseButton = new Button();
            infoLabel = new Label();
            searchWordsListBox = new ListBox();
            startButton = new Button();
            pauseButton = new Button();
            cancelButton = new Button();
            statusProgressBar = new ProgressBar();
            reportListBox = new ListBox();
            controlsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // controlsGroupBox
            // 
            controlsGroupBox.Controls.Add(inputTextBox);
            controlsGroupBox.Controls.Add(browseButton);
            controlsGroupBox.Controls.Add(infoLabel);
            controlsGroupBox.Controls.Add(searchWordsListBox);
            controlsGroupBox.Controls.Add(startButton);
            controlsGroupBox.Controls.Add(pauseButton);
            controlsGroupBox.Controls.Add(cancelButton);
            controlsGroupBox.Controls.Add(statusProgressBar);
            controlsGroupBox.Dock = DockStyle.Right;
            controlsGroupBox.Location = new Point(550, 0);
            controlsGroupBox.Name = "controlsGroupBox";
            controlsGroupBox.Size = new Size(250, 450);
            controlsGroupBox.TabIndex = 0;
            controlsGroupBox.TabStop = false;
            // 
            // inputTextBox
            // 
            inputTextBox.Dock = DockStyle.Bottom;
            inputTextBox.Location = new Point(3, 51);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(244, 27);
            inputTextBox.TabIndex = 8;
            inputTextBox.KeyDown += inputTextBox_KeyDown;
            // 
            // browseButton
            // 
            browseButton.Dock = DockStyle.Bottom;
            browseButton.Location = new Point(3, 78);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(244, 29);
            browseButton.TabIndex = 7;
            browseButton.Text = "BROWSE";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Dock = DockStyle.Top;
            infoLabel.Location = new Point(3, 23);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(107, 20);
            infoLabel.TabIndex = 5;
            infoLabel.Text = "current status";
            // 
            // searchWordsListBox
            // 
            searchWordsListBox.Dock = DockStyle.Bottom;
            searchWordsListBox.FormattingEnabled = true;
            searchWordsListBox.Location = new Point(3, 107);
            searchWordsListBox.Name = "searchWordsListBox";
            searchWordsListBox.Size = new Size(244, 224);
            searchWordsListBox.TabIndex = 6;
            searchWordsListBox.KeyDown += searchWordsListBox_KeyDown;
            // 
            // startButton
            // 
            startButton.Dock = DockStyle.Bottom;
            startButton.Location = new Point(3, 331);
            startButton.Name = "startButton";
            startButton.Size = new Size(244, 29);
            startButton.TabIndex = 3;
            startButton.Text = "START";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Dock = DockStyle.Bottom;
            pauseButton.Location = new Point(3, 360);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(244, 29);
            pauseButton.TabIndex = 2;
            pauseButton.Text = "PAUSE";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Bottom;
            cancelButton.Location = new Point(3, 389);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(244, 29);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "CANCEL";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // statusProgressBar
            // 
            statusProgressBar.Dock = DockStyle.Bottom;
            statusProgressBar.Location = new Point(3, 418);
            statusProgressBar.Name = "statusProgressBar";
            statusProgressBar.Size = new Size(244, 29);
            statusProgressBar.TabIndex = 0;
            // 
            // reportListBox
            // 
            reportListBox.Dock = DockStyle.Fill;
            reportListBox.FormattingEnabled = true;
            reportListBox.Location = new Point(0, 0);
            reportListBox.Name = "reportListBox";
            reportListBox.Size = new Size(550, 450);
            reportListBox.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(reportListBox);
            Controls.Add(controlsGroupBox);
            Name = "MainForm";
            Text = "Form1";
            controlsGroupBox.ResumeLayout(false);
            controlsGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox controlsGroupBox;
        private Button startButton;
        private Button pauseButton;
        private Button cancelButton;
        private ProgressBar statusProgressBar;
        private ListBox searchWordsListBox;
        private Label infoLabel;
        private ListBox reportListBox;
        private Button browseButton;
        private TextBox inputTextBox;
    }
}
