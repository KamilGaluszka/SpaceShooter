using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class SpaceShooter : Form
    {
        //Game variables
        readonly Random random = new Random();
        bool moveUp, moveDown, moveLeft, moveRight, shot, gameOver;
        int gameSpeed = 8;
        int gameLevel = 1;
        int levelStage = 1;
        readonly int maxStagesPerLevel = 5;

        //Player variables
        int score = 0;
        int playerSpeed = 8;
        int health = 3;

        //Enemy variables
        int enemySpeed = 8;
        

        public SpaceShooter()
        {
            InitializeComponent();
        }

        private void SpaceShooter_Load(object sender, EventArgs e)
        {

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            PlayerMovement();
            MoveShots();
            MoveEnemies();
            if (CountEnemies() == 0 && !gameOver)
                if (gameLevel % 5 != 0)
                {
                    if (levelStage > maxStagesPerLevel)
                    {
                        levelStage = 1;
                        gameLevel++;
                    }
                    _ = NextStage();
                    CreateEnemies();
                }
        }

        private void PlayerMovement()
        {
            if (moveUp)
                MoveObject(0, player, playerSpeed);
            if (moveDown)
                MoveObject(1, player, playerSpeed);
            if (moveLeft)
                MoveObject(2, player, playerSpeed);
            if (moveRight)
                MoveObject(3, player, playerSpeed);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                moveUp = true;
            if (e.KeyCode == Keys.Down)
                moveDown = true;
            if (e.KeyCode == Keys.Left)
                moveLeft = true;
            if (e.KeyCode == Keys.Right)
                moveRight = true;
            if (e.KeyCode == Keys.Z && !shot)
            {
                MakeAShot(player);
                shot = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                moveUp = false;
            if (e.KeyCode == Keys.Down)
                moveDown = false;
            if (e.KeyCode == Keys.Left)
                moveLeft = false;
            if (e.KeyCode == Keys.Right)
                moveRight = false;
            if (shot)
                shot = false;
            if (e.KeyCode == Keys.Enter && gameOver)
                Restart();
        }

        private void Restart()
        {
            moveUp = moveDown = moveLeft = moveRight = shot = gameOver = false;
            score = 0;
            scoreLabel.Text = "Score: " + score;
            gameSpeed = playerSpeed = enemySpeed = 8;
            player.Top = 500;
            player.Left = 368;
            health = 3;
            gameLevel = levelStage = 1;
            hearts.Width = 16 * health;
            GameTimer.Start();
            ClearShots();
            ClearEnemies();
            this.Controls.RemoveByKey("gameover");
        }

        private void GameOver()
        {
            ClearShots();
            GameTimer.Stop();
            Label label = new Label()
            {
                Text = "GAME OVER! \nPRESS ENTER TO RESTART",
                Top = this.ClientSize.Height / 2 - 40,
                Left = this.ClientSize.Width / 2 - 90,
                Width = 180,
                Height = 80,
                Visible = true,
                Name = "gameover",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            this.Controls.Add(label);
            gameOver = true;
        }

        private void MakeAShot(PictureBox obj)
        {
            PictureBox shot = new PictureBox
            {
                Height = 10,
                Width = 5
            };
            if ((string) obj.Tag == "player")
            {
                shot.BackColor = Color.LightGreen;
                shot.Left = obj.Left + obj.Width / 2 - 2;
                shot.Top = obj.Top - 10;
                shot.Tag = "playerShot";
            }
            else
            {
                shot.BackColor = Color.Red;
                shot.Left = obj.Left + obj.Width / 2 - 2;
                shot.Top = obj.Top + obj.Height + 10;
                shot.Tag = "enemyShot";
            }
            

            this.Controls.Add(shot);
        }

        private void RemovePictureBox(PictureBox pictureBox)
        {
            this.Controls.Remove(pictureBox);
            pictureBox.Dispose();
        }

        private void CreateEnemies()
        {
            levelStage++;
            int n = random.Next(5) + 5;
            int size = 32;
            for(int i = 0; i < n; i++)
            {
                PictureBox enemy = new PictureBox
                {
                    Image = Properties.Resources.Enemy,
                    BackColor = Color.Transparent,
                    Height = size,
                    Width = size,
                    Left = random.Next(this.ClientSize.Width - size),
                    Top = 0,
                    Tag = "enemy"
                };

                this.Controls.Add(enemy);
            }
        }

        private void CreateAsteroids()
        {

        }

        private async Task NextStage()
        {
            ClearShots();
            GameTimer.Stop();
            Label label = new Label()
            {
                Text = "LEVEL: " + gameLevel + "\nSTAGE: " + levelStage,
                Top = this.ClientSize.Height / 2 - 40,
                Left = this.ClientSize.Width / 2 - 90,
                Width = 180,
                Height = 80,
                Visible = true,
                Name = "stage",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                ForeColor = Color.White
            };
            this.Controls.Add(label);
            await Task.Delay(1000);
            this.Controls.RemoveByKey("stage");
            await Task.Delay(1000);
            GameTimer.Start();
        }

        private List<PictureBox> FindEnemies()
        {
            List<PictureBox> enemies = new List<PictureBox>();
            foreach (Control c in this.Controls)
                if (c is PictureBox && (string) c.Tag == "enemy")
                    enemies.Add((PictureBox)c);

            return enemies;
        }

        private void ClearEnemies()
        {
            List<PictureBox> enemies = FindEnemies();
            foreach (PictureBox enemy in enemies)
                RemovePictureBox(enemy);
        }

        private void ClearShots()
        {
            foreach (Control c in this.Controls)
                if (c is PictureBox)
                    if((string)c.Tag == "playerShot" || (string)c.Tag == "enemyShot")
                        RemovePictureBox((PictureBox)c);

        }
        private int CountEnemies()
        {
            List<PictureBox> enemies = FindEnemies();
            int count = enemies.Count;
            
            return count;
        }

        private void MoveObject(int moveDirection, PictureBox obj, int speed)
        {
            switch(moveDirection)
            {
                case 0:
                    if (obj.Top > 0)
                        obj.Top -= speed;
                    break;
                case 1:
                    if (obj.Top + obj.Height < this.ClientSize.Height)
                        obj.Top += speed;
                    break;
                case 2:
                    if (obj.Left > 0)
                        obj.Left -= speed;
                    break;
                default:
                    if (obj.Left + obj.Width < this.ClientSize.Width)
                        obj.Left += speed;
                    break;
            }
        }

        private void GetDamage()
        {
            if(health > 1)
            {
                health--;
                hearts.Width -= 16;
            }
            else
            {
                hearts.Width = 0;
                ClearShots();
                ClearEnemies();
                GameOver();
            }
        }

        private void MoveEnemies()
        {
            List<PictureBox> enemies = FindEnemies();
            bool move, shoot;
            foreach(PictureBox enemy in enemies)
            {
                move = random.NextDouble() > 0.1;
                shoot = random.NextDouble() > 0.95;
                if(move)
                {
                    int moveDirection = random.Next(0, 4);
                    MoveObject(moveDirection, enemy, enemySpeed);
                }
                if(shoot)
                    MakeAShot(enemy);
            }
        }

        private void MoveShots()
        {
            List<PictureBox> enemies = FindEnemies();
            foreach(Control c in this.Controls)
            {
                if(c is PictureBox && (string) c.Tag == "playerShot")
                {
                    c.Top -= gameSpeed;
                    if (c.Top <= 0)
                        RemovePictureBox((PictureBox) c);

                    foreach(PictureBox enemy in enemies)
                        if((c.Top <= enemy.Top + enemy.Height && c.Top >= enemy.Top) && (c.Left + c.Width > enemy.Left && c.Left < enemy.Left + enemy.Width))
                        {
                            RemovePictureBox((PictureBox)c);
                            RemovePictureBox(enemy);
                            score++;
                            scoreLabel.Text = "Score: " + score;
                        }
                }
                if(c is PictureBox && (string) c.Tag == "enemyShot")
                {
                    c.Top += gameSpeed;
                    if (c.Top >= this.ClientSize.Height)
                        RemovePictureBox((PictureBox)c);
                    if((c.Top + c.Height >= player.Top && c.Top + c.Height <= player.Top + player.Height) && (c.Left + c.Width > player.Left && c.Left < player.Left + player.Width))
                    {
                        RemovePictureBox((PictureBox)c);
                        GetDamage();
                    }
                }
            }
        }

    }
}
