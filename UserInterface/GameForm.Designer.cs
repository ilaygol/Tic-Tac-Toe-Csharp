﻿
namespace UserInterface
{
    partial class GameForm
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
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player1ScoreLabel = new System.Windows.Forms.Label();
            this.Player2ScoreLabel = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Label.Location = new System.Drawing.Point(206, 260);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(73, 17);
            this.Player1Label.TabIndex = 0;
            this.Player1Label.Text = "Player 1:";
            this.Player1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player1ScoreLabel
            // 
            this.Player1ScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1ScoreLabel.Location = new System.Drawing.Point(285, 260);
            this.Player1ScoreLabel.Name = "Player1ScoreLabel";
            this.Player1ScoreLabel.Size = new System.Drawing.Size(17, 17);
            this.Player1ScoreLabel.TabIndex = 1;
            this.Player1ScoreLabel.Text = "0";
            this.Player1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player2ScoreLabel
            // 
            this.Player2ScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2ScoreLabel.Location = new System.Drawing.Point(474, 260);
            this.Player2ScoreLabel.Name = "Player2ScoreLabel";
            this.Player2ScoreLabel.Size = new System.Drawing.Size(16, 17);
            this.Player2ScoreLabel.TabIndex = 3;
            this.Player2ScoreLabel.Text = "0";
            this.Player2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player2Label
            // 
            this.Player2Label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Label.Location = new System.Drawing.Point(404, 260);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(64, 17);
            this.Player2Label.TabIndex = 2;
            this.Player2Label.Text = "Player 2:";
            this.Player2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 295);
            this.Controls.Add(this.Player2ScoreLabel);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1ScoreLabel);
            this.Controls.Add(this.Player1Label);
            this.Name = "GameForm";
            this.Text = "TicTacToeMisere";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label Player1ScoreLabel;
        private System.Windows.Forms.Label Player2ScoreLabel;
        private System.Windows.Forms.Label Player2Label;
    }
}

