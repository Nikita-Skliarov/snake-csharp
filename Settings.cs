using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public static class Settings
    {
        /// <summary>
        /// Size of the cell
        /// </summary>
        public static int CellSize = 10;

        /// <summary>
        /// Initial distance between cells. Also used as distance to move
        /// </summary>
        public static int CellsDistance = 10;

        /// <summary>
        /// Game rule = if true, the snake will die if it hits the wall
        /// </summary>
        public static bool NoEdges = false;

        /// <summary>
        /// Number of times food is eaten before we get more food in the field.
        /// </summary>
        public static int TimesWhenFoodDoubles = 2;

        /// <summary>
        /// Maximum number of food items on the field
        /// </summary>
        public static int MaxFoodOnField = 10;

        public static List<Cell> Portals = new List<Cell>()
        {
            new Cell(250, 400),
            new Cell(750, 100),
        };
    }
}
