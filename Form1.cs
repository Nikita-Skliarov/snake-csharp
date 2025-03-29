using System.ComponentModel.Design;

namespace snake
{
    public partial class Form1 : Form
    {
        private Random _random;
        public Snake snake1;
        public Snake snake2;
        public List<Cell> foods;
        public int totalScore;
        public bool foodsIsRecentlyConsumed = false;

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
            numberFoodDoublesInput.Enabled = false;
            maxFoodOnFieldInput.Enabled = false;

            gameTimer.Tick -= gameTimer_Tick;
            gameField.Paint -= gameField_Paint;

            gameTimer.Tick += gameTimer_Tick;
            gameField.Paint += gameField_Paint;

            snake1 = new Snake(0, 250, 250, Color.Red);
            snake2 = new Snake(0, 750, 250, Color.Blue);
            Snake1Score.Text = "0";
            Snake2Score.Text = "0";
            totalScore = 0;

            foods = new List<Cell>();
            SpawnFoods(1); // Start with 3 food items

            gameTimer.Interval = 50;
            gameTimer.Enabled = true;
            gameField.Invalidate();
        }

        private void gameTimer_Tick(object? sender, EventArgs e)
        {
            CheckFoodConsumption(snake1, Snake1Score);
            CheckFoodConsumption(snake2, Snake2Score);
             
            if (totalScore % Settings.TimesWhenFoodDoubles == 0 && totalScore != 0 && foodsIsRecentlyConsumed)
            {
                if (foods.Count * 2 >= Settings.MaxFoodOnField)
                {
                    SpawnFoods(Settings.MaxFoodOnField);
                }
                else
                {
                    SpawnFoods(foods.Count * 2);
                }
            }

            foodsIsRecentlyConsumed = false; // reset that food was consumed for next ticks

            snake1.Move();
            snake2.Move();

            CheckCollision(snake1, snake2, "Red Snake");
            CheckCollision(snake2, snake1, "Blue Snake");

            gameField.Invalidate();
        }

        private void CheckFoodConsumption(Snake snake, Label scoreLabel)
        {
            for (int i = 0; i < foods.Count; i++)
            {
                if (snake.isEating(foods[i]))
                {
                    scoreLabel.Text = (int.Parse(scoreLabel.Text) + 1).ToString();
                    totalScore++;
                    snake.Grow();
                    foodsIsRecentlyConsumed = true;
                    foods[i] = new Cell(_random.Next(20, 980), _random.Next(20, 480)); // Respawn food that was eaten
                }
            }
        }

        private void CheckCollision(Snake snake, Snake otherSnake, string playerName)
        {
            if (snake.isCollidingItself() || isCollidingWithOtherSnake(snake, otherSnake) || snake.isCollidingWall())
            {
                gameTimer.Enabled = false;
                startButton.Enabled = true;
                checkBox1.Enabled = true;
                numberFoodDoublesInput.Enabled = true;
                maxFoodOnFieldInput.Enabled = true;
                MessageBox.Show($"Game Over! {playerName} lost.");
            }
        }

        private bool isCollidingWithOtherSnake(Snake snake, Snake otherSnake)
        {
            foreach (var segment in otherSnake.body)
            {
                if (snake.body[0].x == segment.x && snake.body[0].y == segment.y)
                {
                    return true;
                }
            }
            return false;
        }

        private void SpawnFoods(int count)
        {
            if (foods.Count >= Settings.MaxFoodOnField) return; // If we already have the maximum, do nothing
            foods.Clear();
            for (int i = 0; i < count; i++)
            {
                foods.Add(new Cell(_random.Next(20, 980), _random.Next(20, 480)));
            }
        }

        private void gameField_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush snake1Color = new SolidBrush(Color.Red);
            Brush snake2Color = new SolidBrush(Color.Blue);
            Brush foodColor = new SolidBrush(Color.Green);
            Brush portalColor = new SolidBrush(Color.Yellow);

            foreach (Cell segment in snake1.body)
            {
                g.FillRectangle(snake1Color, segment.x, segment.y, Settings.CellSize, Settings.CellSize);
            }

            foreach (Cell segment in snake2.body)
            {
                g.FillRectangle(snake2Color, segment.x, segment.y, Settings.CellSize, Settings.CellSize);
            }

            foreach (Cell food in foods)
            {
                g.FillRectangle(foodColor, food.x, food.y, Settings.CellSize, Settings.CellSize);
            }

            foreach (Cell portal in Settings.Portals)
            {
                g.FillRectangle(portalColor, portal.x, portal.y, Settings.CellSize + 5, Settings.CellSize + 5);
            }
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
            Settings.NoEdges = checkBox1.Checked;
        }

        private void numberFoodDoublesInput_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool isNumeric = int.TryParse(numberFoodDoublesInput.Text, out number);
            if (isNumeric)
            {
                Settings.TimesWhenFoodDoubles = number;
            }
        }

        private void maxFoodOnFieldInput_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool isNumeric = int.TryParse(maxFoodOnFieldInput.Text, out number);
            if (isNumeric)
            {
                Settings.MaxFoodOnField = number;
            }
        }
    }
}
