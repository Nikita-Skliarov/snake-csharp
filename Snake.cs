using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public class Snake
    {
        // Properties 
        public int direction; // 0 - up, 1 - right, 2 - down, 3 - left

        public List<Cell> body;

        // Methods
        /// <summary>
        /// Move the snake in the current direction
        /// </summary>
        /// <algo>
        /// 1. Define old head and new head in the same position as the head
        /// 2. Move new head in the direction of the snake
        /// 3. Move the rest of the body from the tail forward (each cell takes the position of the next one
        /// 4. Set the new head as the head of the snake
        /// </algo>
        public void Move()
        {
            Cell oldHead = this.body[0];
            Cell newHead = new Cell(oldHead.x, oldHead.y);

            switch (this.direction)
            {
                case 0: newHead.y -= Settings.CellsDistance; break; 
                case 1: newHead.x += Settings.CellsDistance; break;
                case 2: newHead.y += Settings.CellsDistance; break; 
                case 3: newHead.x -= Settings.CellsDistance; break;
            }


            if (Settings.NoEdges)
            {
                if (newHead.x < 0) newHead.x = 1000 - Settings.CellsDistance;
                if (newHead.x >= 1000) newHead.x = 0;
                if (newHead.y < 0) newHead.y = 500 - Settings.CellsDistance;
                if (newHead.y >= 500) newHead.y = 0;
            }

            foreach (Cell portal in Settings.Portals)
            {
                if (isTouchingPortal(portal))
                {
                    Cell otherPortal = Settings.Portals.FirstOrDefault(p => p != portal);

                    if (otherPortal != null)
                    {
                        newHead.x = otherPortal.x;
                        newHead.y = otherPortal.y;

                        switch (this.direction)
                        {
                            case 0: newHead.y -= Settings.CellsDistance * 2; break; // Up
                            case 1: newHead.x += Settings.CellsDistance * 2; break; // Right
                            case 2: newHead.y += Settings.CellsDistance * 2; break; // Down
                            case 3: newHead.x -= Settings.CellsDistance * 2; break; // Left
                        }
                    }
                    break;
                }
            }


            // Move body correctly
            for (int i = this.body.Count - 1; i > 0; i--)
            {
                this.body[i].x = this.body[i - 1].x;
                this.body[i].y = this.body[i - 1].y;
            }

            this.body[0] = newHead;
        }


        /// <summary>
        /// Grow the snake by one cell. Add new cell to the end of the snake
        /// </summary>
        /// <algo>
        /// 1. Define the new cell same as the tail of the snake
        /// 3. Change coordinates of the new cell in the direction of the snake
        /// 2. Add the new cell to the end of the snake
        /// </algo>
        public void Grow()
        {
            Cell tail = this.body.Last();

            Cell newCell = new Cell(tail.x, tail.y);

            switch (this.direction)
            {
                case 0: newCell.y += Settings.CellsDistance; break;
                case 1: newCell.x -= Settings.CellsDistance; break; 
                case 2: newCell.y -= Settings.CellsDistance; break; 
                case 3: newCell.x += Settings.CellsDistance; break; 
            }

            this.body.Add(newCell);
        }

        /// <summary>
        /// Check if the snakes head has reached food
        /// </summary>
        /// <algo>
        /// 1. If the head of the snake is in the same position as the food, return true. Otherwise, return false
        /// </algo>
        public bool isEating(Cell food)
        {
            int distanceX = Math.Abs(this.body[0].x - food.x);
            int distanceY = Math.Abs(this.body[0].y - food.y);

            return distanceX < Settings.CellSize && distanceY < Settings.CellSize;
        }

       public bool isTouchingPortal(Cell portal)
        {
            int distanceX = Math.Abs((this.body[0].x - portal.x) + 5);
            int distanceY = Math.Abs((this.body[0].y - portal.y) + 5);
            return distanceX < Settings.CellSize && distanceY < Settings.CellSize;
        }

        /// <summary>
        /// Check if the snake has collided with itself
        /// </summary>
        /// <algo>
        /// If the head of the snake is in the same 
        /// </algo>
        public bool isCollidingItself()
        {
            for (int i = 1; i < this.body.Count; i++)
            {
                if (this.body[0].x == this.body[i].x && this.body[0].y == this.body[i].y) return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the snake has collided with the wall
        /// </summary>
        /// <algo>
        /// If head of the snake reaches the wall and Settings.NoEdges is false, return true. Game stops then in Form1.cs
        /// </algo>
        public bool isCollidingWall()
        {
            /*if (newHead.x < 0) newHead.x = 1000 - Settings.CellsDistance;
            if (newHead.x >= 1000) newHead.x = 0;
            if (newHead.y < 0) newHead.y = 500 - Settings.CellsDistance;
            if (newHead.y >= 500) newHead.y = 0;*/
            Cell snakeHead = this.body[0];
            if ((snakeHead.x < 0 || snakeHead.x >= 1000 || snakeHead.y < 0 || snakeHead.y >= 500) && !Settings.NoEdges)
            {
                return true;
            }
            return false;
        }

        // Constructor
        public Snake(int direction, int startX, int startY, Color color)
        {
            this.direction = direction;
            this.body = new List<Cell>();

            for (int i = 0; i < 10; i++)
            {
                this.body.Add(new Cell(startX, startY + Settings.CellsDistance * i));
            }
        }
    }
}
