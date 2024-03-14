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
            searchWordsGroupBox = new GroupBox();
            inputTextBox = new TextBox();
            label1 = new Label();
            searchWordsListBox = new ListBox();
            browseButton = new Button();
            statusLabel = new Label();
            startButton = new Button();
            pauseButton = new Button();
            cancelButton = new Button();
            statusProgressBar = new ProgressBar();
            reportListBox = new ListBox();
            currentPathLabel = new Label();
            controlPanelGroupBox = new GroupBox();
            searchStatusGroupBox = new GroupBox();
            reportGroupBox = new GroupBox();
            searchWordsGroupBox.SuspendLayout();
            controlPanelGroupBox.SuspendLayout();
            searchStatusGroupBox.SuspendLayout();
            reportGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // searchWordsGroupBox
            // 
            searchWordsGroupBox.Controls.Add(inputTextBox);
            searchWordsGroupBox.Controls.Add(label1);
            searchWordsGroupBox.Controls.Add(searchWordsListBox);
            searchWordsGroupBox.Location = new Point(550, 0);
            searchWordsGroupBox.Name = "searchWordsGroupBox";
            searchWordsGroupBox.Size = new Size(250, 303);
            searchWordsGroupBox.TabIndex = 0;
            searchWordsGroupBox.TabStop = false;
            searchWordsGroupBox.Text = "FORBIDDEN WORDS LIST";
            // 
            // inputTextBox
            // 
            inputTextBox.BackColor = Color.Ivory;
            inputTextBox.Dock = DockStyle.Top;
            inputTextBox.Location = new Point(3, 267);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(244, 27);
            inputTextBox.TabIndex = 8;
            inputTextBox.KeyDown += inputTextBox_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 247);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 7;
            label1.Text = "ADD NEW WORD";
            // 
            // searchWordsListBox
            // 
            searchWordsListBox.BackColor = Color.Ivory;
            searchWordsListBox.Dock = DockStyle.Top;
            searchWordsListBox.FormattingEnabled = true;
            searchWordsListBox.Location = new Point(3, 23);
            searchWordsListBox.Name = "searchWordsListBox";
            searchWordsListBox.Size = new Size(244, 224);
            searchWordsListBox.TabIndex = 6;
            searchWordsListBox.KeyDown += searchWordsListBox_KeyDown;
            // 
            // browseButton
            // 
            browseButton.Dock = DockStyle.Top;
            browseButton.Location = new Point(3, 110);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(244, 29);
            browseButton.TabIndex = 7;
            browseButton.Text = "BROWSE";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(502, 23);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(31, 20);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "0%";
            // 
            // startButton
            // 
            startButton.Dock = DockStyle.Top;
            startButton.Location = new Point(3, 81);
            startButton.Name = "startButton";
            startButton.Size = new Size(244, 29);
            startButton.TabIndex = 3;
            startButton.Text = "START";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Dock = DockStyle.Top;
            pauseButton.Location = new Point(3, 52);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(244, 29);
            pauseButton.TabIndex = 2;
            pauseButton.Text = "PAUSE";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Top;
            cancelButton.Location = new Point(3, 23);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(244, 29);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "CANCEL";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // statusProgressBar
            // 
            statusProgressBar.Location = new Point(553, 15);
            statusProgressBar.Name = "statusProgressBar";
            statusProgressBar.Size = new Size(244, 29);
            statusProgressBar.TabIndex = 0;
            // 
            // reportListBox
            // 
            reportListBox.BackColor = Color.Ivory;
            reportListBox.Dock = DockStyle.Fill;
            reportListBox.FormattingEnabled = true;
            reportListBox.Location = new Point(3, 23);
            reportListBox.Name = "reportListBox";
            reportListBox.Size = new Size(538, 429);
            reportListBox.TabIndex = 1;
            // 
            // currentPathLabel
            // 
            currentPathLabel.AutoSize = true;
            currentPathLabel.Dock = DockStyle.Left;
            currentPathLabel.Location = new Point(3, 23);
            currentPathLabel.Name = "currentPathLabel";
            currentPathLabel.Size = new Size(102, 20);
            currentPathLabel.TabIndex = 2;
            currentPathLabel.Text = "Current Path:";
            // 
            // controlPanelGroupBox
            // 
            controlPanelGroupBox.Controls.Add(browseButton);
            controlPanelGroupBox.Controls.Add(startButton);
            controlPanelGroupBox.Controls.Add(pauseButton);
            controlPanelGroupBox.Controls.Add(cancelButton);
            controlPanelGroupBox.Location = new Point(550, 309);
            controlPanelGroupBox.Name = "controlPanelGroupBox";
            controlPanelGroupBox.Size = new Size(250, 147);
            controlPanelGroupBox.TabIndex = 8;
            controlPanelGroupBox.TabStop = false;
            controlPanelGroupBox.Text = "CONTROL PANEL";
            // 
            // searchStatusGroupBox
            // 
            searchStatusGroupBox.Controls.Add(statusProgressBar);
            searchStatusGroupBox.Controls.Add(currentPathLabel);
            searchStatusGroupBox.Controls.Add(statusLabel);
            searchStatusGroupBox.Dock = DockStyle.Bottom;
            searchStatusGroupBox.Location = new Point(0, 455);
            searchStatusGroupBox.Name = "searchStatusGroupBox";
            searchStatusGroupBox.Size = new Size(800, 50);
            searchStatusGroupBox.TabIndex = 9;
            searchStatusGroupBox.TabStop = false;
            searchStatusGroupBox.Text = "CURRENT SEARCH STATUS";
            // 
            // reportGroupBox
            // 
            reportGroupBox.Controls.Add(reportListBox);
            reportGroupBox.Dock = DockStyle.Left;
            reportGroupBox.Location = new Point(0, 0);
            reportGroupBox.Name = "reportGroupBox";
            reportGroupBox.Size = new Size(544, 455);
            reportGroupBox.TabIndex = 10;
            reportGroupBox.TabStop = false;
            reportGroupBox.Text = "SEARCH LOGS";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 505);
            Controls.Add(reportGroupBox);
            Controls.Add(searchStatusGroupBox);
            Controls.Add(controlPanelGroupBox);
            Controls.Add(searchWordsGroupBox);
            Name = "MainForm";
            Text = "Forbidden Words Searcher";
            searchWordsGroupBox.ResumeLayout(false);
            searchWordsGroupBox.PerformLayout();
            controlPanelGroupBox.ResumeLayout(false);
            searchStatusGroupBox.ResumeLayout(false);
            searchStatusGroupBox.PerformLayout();
            reportGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox searchWordsGroupBox;
        private Button startButton;
        private Button pauseButton;
        private Button cancelButton;
        private ProgressBar statusProgressBar;
        private ListBox searchWordsListBox;
        private Label statusLabel;
        private ListBox reportListBox;
        private Button browseButton;
        private TextBox inputTextBox;
        private Label currentPathLabel;
        private Label label1;
        private GroupBox controlPanelGroupBox;
        private GroupBox searchStatusGroupBox;
        private GroupBox reportGroupBox;
    }
}
