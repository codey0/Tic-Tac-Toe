namespace Tic_Tac_Toe
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PlayerVsPlayerButton = new System.Windows.Forms.Button();
            this.ComputerPlayer1Button = new System.Windows.Forms.Button();
            this.ComputerPlayer2Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 493);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 26);
            this.textBox1.TabIndex = 1;
            // 
            // PlayerVsPlayerButton
            // 
            this.PlayerVsPlayerButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PlayerVsPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.PlayerVsPlayerButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PlayerVsPlayerButton.Location = new System.Drawing.Point(32, 567);
            this.PlayerVsPlayerButton.Name = "PlayerVsPlayerButton";
            this.PlayerVsPlayerButton.Size = new System.Drawing.Size(441, 69);
            this.PlayerVsPlayerButton.TabIndex = 2;
            this.PlayerVsPlayerButton.Text = "Player Vs Player";
            this.PlayerVsPlayerButton.UseVisualStyleBackColor = false;
            this.PlayerVsPlayerButton.Click += new System.EventHandler(this.PlayerVsPlayerButton_Click);
            // 
            // ComputerPlayer1Button
            // 
            this.ComputerPlayer1Button.BackColor = System.Drawing.SystemColors.Control;
            this.ComputerPlayer1Button.Location = new System.Drawing.Point(32, 525);
            this.ComputerPlayer1Button.Name = "ComputerPlayer1Button";
            this.ComputerPlayer1Button.Size = new System.Drawing.Size(200, 35);
            this.ComputerPlayer1Button.TabIndex = 3;
            this.ComputerPlayer1Button.Text = "Computer Player 1";
            this.ComputerPlayer1Button.UseVisualStyleBackColor = false;
            this.ComputerPlayer1Button.Click += new System.EventHandler(this.ComputerPlayer1Button_Click);
            // 
            // ComputerPlayer2Button
            // 
            this.ComputerPlayer2Button.BackColor = System.Drawing.SystemColors.Control;
            this.ComputerPlayer2Button.Location = new System.Drawing.Point(273, 525);
            this.ComputerPlayer2Button.Name = "ComputerPlayer2Button";
            this.ComputerPlayer2Button.Size = new System.Drawing.Size(200, 35);
            this.ComputerPlayer2Button.TabIndex = 4;
            this.ComputerPlayer2Button.Text = "Computer Player 2";
            this.ComputerPlayer2Button.UseVisualStyleBackColor = false;
            this.ComputerPlayer2Button.Click += new System.EventHandler(this.ComputerPlayer2Button_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(506, 648);
            this.Controls.Add(this.ComputerPlayer2Button);
            this.Controls.Add(this.ComputerPlayer1Button);
            this.Controls.Add(this.PlayerVsPlayerButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button PlayerVsPlayerButton;
        private System.Windows.Forms.Button ComputerPlayer1Button;
        private System.Windows.Forms.Button ComputerPlayer2Button;
    }
}