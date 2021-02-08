
namespace SpaceShooter
{
    partial class SpaceShooter
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
            this.components = new System.ComponentModel.Container();
            this.player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.hearts = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearts)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::SpaceShooter.Properties.Resources.Player;
            this.player.Location = new System.Drawing.Point(368, 500);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(32, 32);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Tag = "player";
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 15;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // hearts
            // 
            this.hearts.BackgroundImage = global::SpaceShooter.Properties.Resources.heart;
            this.hearts.Location = new System.Drawing.Point(0, 540);
            this.hearts.Name = "hearts";
            this.hearts.Size = new System.Drawing.Size(48, 16);
            this.hearts.TabIndex = 1;
            this.hearts.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(-3, 521);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(69, 17);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score: 0";
            // 
            // SpaceShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.hearts);
            this.Controls.Add(this.player);
            this.Name = "SpaceShooter";
            this.Text = "SpaceShooter";
            this.Load += new System.EventHandler(this.SpaceShooter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hearts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox hearts;
        private System.Windows.Forms.Label scoreLabel;
    }
}

