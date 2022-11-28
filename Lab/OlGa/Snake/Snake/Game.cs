using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OlGa
{
    public partial class frmGame : Form
    {
        
        private List<Circle> snake = new List<Circle>();
        
        private Circle food = new Circle();

        public frmGame()
        {
            InitializeComponent();
        }

        private void startGame()
        {
            lblGameOver.Visible = false;
            btnPlay.Enabled = false;
            newGameToolStripMenuItem.Enabled = false;
            new Settings();
            tmrTimer.Interval = 1000 / Settings.speed;
            tmrTimer.Tick += updateScreen;
            tmrTimer.Start();
            snake.Clear();
            Circle snakeHead = new Circle() { x = 16, y = 10 };
            snake.Add(snakeHead);
            lblScore.Text = Settings.score.ToString();
            generateFood();
        }

      
        private void generateFood()
        {
            int maxXPos = (picCanvas.Size.Width / Settings.width);
            int maxYPos = (picCanvas.Size.Height / Settings.height);

            Random random = new Random();
            food = new Circle() { x = random.Next(0, maxXPos),
                y = random.Next(0, maxYPos) };
        }

        private void updateScreen(object sender, EventArgs e)
        {
            if (Settings.gameOver) {
                if (Input.KeyPressed(Keys.Return)) { startGame(); }
            }
            else {

                Settings.duration += 1;

                if (Input.KeyPressed(Keys.D) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.A) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.W) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.S) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                movePlayer();
                lblTimer.Text = TimeSpan.FromSeconds(Settings.duration / Settings.speed).ToString();
                lblScore.Text = Settings.score.ToString();
            }

            picCanvas.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.gameOver)
            {
                string msg = "Game Over!\nYour final score is: " + Settings.score + ".";
                msg += "\nPress 'Enter' to play again.";
                msg += "\nPlease put the maximum mark \nfor developers 🙏🏻";
                lblGameOver.Text = msg;
                lblGameOver.Visible = true;
            }
            else
            {
                Brush snakeColour;
                for (int i=0; i<snake.Count; ++i)
                {
                    if (i == 0)
                        snakeColour = Brushes.Black;
                    else
                        snakeColour = Brushes.Green;
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(snake[i].x * Settings.width,
                        snake[i].y * Settings.height,
                        Settings.width, Settings.height));
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.x * Settings.width,
                        food.y * Settings.height, Settings.width,
                        Settings.height));

                }

            }

        }

        private void movePlayer()
        {
            for (int i=snake.Count-1; i>=0; i--) {
                if (i == 0) {
                    switch (Settings.direction) {
                        case Direction.Right:
                            snake[i].x++;
                            break;
                        case Direction.Left:
                            snake[i].x--;
                            break;
                        case Direction.Up:
                            snake[i].y--;
                            break;
                        case Direction.Down:
                            snake[i].y++;
                            break;
                    }
                    int maxXPos = (picCanvas.Size.Width / Settings.width);
                    int maxYPos = (picCanvas.Size.Height / Settings.height);
                    if (snake[i].x < 0 || snake[i].y < 0 
                        || snake[i].x >= maxXPos || snake[i].y >= maxYPos) {
                        die();
                    }
                    for (int j=1; j<snake.Count; ++j) {
                        if (snake[i].x == snake[j].x && snake[i].y == snake[j].y) {
                            die();
                        }
                    }
                    if (snake[i].x == food.x && snake[i].y == food.y) {
                        eat();
                    }
                }
                else {
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;
                }

            }
        }

        private void eat()
        {
            Circle food = new Circle();
            food.x = snake[snake.Count - 1].x;
            food.y = snake[snake.Count - 1].y;
            snake.Add(food);
            Settings.score += Settings.points;
            generateFood();
        }

        private void die()
        {
            Settings.gameOver = true;
            tmrTimer.Tick -= updateScreen;
            tmrTimer.Stop();
            btnPlay.Enabled = true;
        }

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void frmGame_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Focus();
            startGame();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            btnPlay.Text = "Play Game";
            tmrTimer.Enabled = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "This C# implementation of Snake was developed by OlGA ^-^ ";
            
            MessageBox.Show(msg, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlay_Click(sender, e);
        }
    }
}
