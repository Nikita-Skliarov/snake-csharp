using System.ComponentModel.Design;

namespace snake
{
    public partial class Form1 : Form
    {
        private Random _random;
        public Snake snake1;
        public Snake snake2;
        public Cell food;

        public Form1(Random random)
        {
            _random = random;
            InitializeComponent();
        }

        private void startGame(object sender, EventArgs e)
        {
            this.Focus();

            startButton.Enabled = false;
            checkBox1.Enabled = false;

            gameTimer.Tick -= gameTimer_Tick;
            gameField.Paint -= gameField_Paint;

            gameTimer.Tick += gameTimer_Tick;
            gameField.Paint += gameField_Paint;

            snake1 = new Snake(0, 250, 250, Color.Red); // First snake
            snake2 = new Snake(0, 750, 250, Color.Blue); // Second snake
            Snake1Score.Text = "0";
            Snake2Score.Text = "0";

            food = new Cell(_random.Next(20, 980), _random.Next(20, 480));

            gameTimer.Interval = 50;
            gameTimer.Enabled = true;
            gameField.Invalidate();
        }

        private void gameTimer_Tick(object? sender, EventArgs e)
        {
            if (snake1.isEating(food))
            {
                Snake1Score.Text = (int.Parse(Snake1Score.Text) + 1).ToString();
                snake1.Grow();
                food = new Cell(_random.Next(20, 980), _random.Next(20, 480));
            }
            if (snake2.isEating(food))
            {
                Snake2Score.Text = (int.Parse(Snake1Score.Text) + 1).ToString();
                snake2.Grow();
                food = new Cell(_random.Next(20, 980), _random.Next(20, 480));
            }

            snake1.Move();
            snake2.Move();

            CheckCollision(snake1, snake2, "Red Snake");
            CheckCollision(snake2, snake1, "Blue Snake");

            gameField.Invalidate();
        }

        private void CheckCollision(Snake snake, Snake otherSnake, string playerName)
        {
            if (snake.isCollidingItself() || isCollidingWithOtherSnake(snake, otherSnake) || snake.isCollidingWall())
            {
                gameTimer.Enabled = false;
                
                startButton.Enabled = true;
                checkBox1.Enabled = true;
                MessageBox.Show($"Game Over! {playerName} lost.");
            }
        }

        private bool isCollidingWithOtherSnake(Snake snake, Snake otherSnake)
        {
            for (int i = 0; i < otherSnake.body.Count; i++)
            {
                if (snake.body[0].x == otherSnake.body[i].x && snake.body[0].y == otherSnake.body[i].y)
                {
                    return true;
                }
            }
            return false;
        }

        private void gameField_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush snake1Color = new SolidBrush(Color.Red);
            Brush snake2Color = new SolidBrush(Color.Blue);

            foreach (Cell segment in snake1.body)
            {
                g.FillRectangle(snake1Color, segment.x, segment.y, Settings.CellSize, Settings.CellSize);
            }

            foreach (Cell segment in snake2.body)
            {
                g.FillRectangle(snake2Color, segment.x, segment.y, Settings.CellSize, Settings.CellSize);
            }

            g.FillRectangle(new SolidBrush(Color.Green), food.x, food.y, Settings.CellSize, Settings.CellSize);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W:
                    if (snake1.direction != 2) snake1.direction = 0;
                    break;
                case Keys.D:
                    if (snake1.direction != 3) snake1.direction = 1;
                    break;
                case Keys.S:
                    if (snake1.direction != 0) snake1.direction = 2;
                    break;
                case Keys.A:
                    if (snake1.direction != 1) snake1.direction = 3;
                    break;

                case Keys.Up:
                    if (snake2.direction != 2) snake2.direction = 0;
                    break;
                case Keys.Right:
                    if (snake2.direction != 3) snake2.direction = 1;
                    break;
                case Keys.Down:
                    if (snake2.direction != 0) snake2.direction = 2;
                    break;
                case Keys.Left:
                    if (snake2.direction != 1) snake2.direction = 3;
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Settings.NoEdges = true;
                return;
            }
            Settings.NoEdges = false;
        }
    }
}
