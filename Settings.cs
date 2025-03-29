﻿using System;
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
    }
}
