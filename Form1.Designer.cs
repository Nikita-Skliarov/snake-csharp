namespace snake
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            startButton = new Button();
            gameTimer = new System.Windows.Forms.Timer(components);
            gameField = new Panel();
            Snake1Score = new Label();
            Snake2Score = new Label();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.Lime;
            startButton.Location = new Point(453, 541);
            startButton.Name = "startButton";
            startButton.Size = new Size(130, 95);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startGame;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 40;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // gameField
            // 
            gameField.BackColor = SystemColors.ControlLight;
            gameField.BorderStyle = BorderStyle.FixedSingle;
            gameField.Location = new Point(20, 20);
            gameField.Name = "gameField";
            gameField.Size = new Size(1000, 500);
            gameField.TabIndex = 2;
            // 
            // Snake1Score
            // 
            Snake1Score.AutoSize = true;
            Snake1Score.BackColor = Color.Red;
            Snake1Score.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Snake1Score.ForeColor = SystemColors.Control;
            Snake1Score.Location = new Point(144, 581);
            Snake1Score.Name = "Snake1Score";
            Snake1Score.Size = new Size(32, 37);
            Snake1Score.TabIndex = 3;
            Snake1Score.Text = "0";
            // 
            // Snake2Score
            // 
            Snake2Score.AutoSize = true;
            Snake2Score.BackColor = Color.Blue;
            Snake2Score.Font = new Font("Segoe UI", 20F);
            Snake2Score.ForeColor = SystemColors.Control;
            Snake2Score.Location = new Point(816, 581);
            Snake2Score.Name = "Snake2Score";
            Snake2Score.Size = new Size(32, 37);
            Snake2Score.TabIndex = 4;
            Snake2Score.Text = "0";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(339, 560);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(76, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "No edges";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 648);
            Controls.Add(checkBox1);
            Controls.Add(Snake2Score);
            Controls.Add(Snake1Score);
            Controls.Add(gameField);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button startButton;
        private System.Windows.Forms.Timer gameTimer;
        private Panel gameField;
        private Label Snake1Score;
        private Label Snake2Score;
        private CheckBox checkBox1;
    }
}
