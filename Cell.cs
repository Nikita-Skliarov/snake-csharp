using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public class Cell
    {
        /// <summary>
        /// X cord of the cell
        /// </summary>
        public int x;

        /// <summary>
        /// Y cord of the cell
        /// </summary>
        public int y;


        /// <summary>
        /// Constructor of the cell
        /// </summary>
        public Cell(int? x = null, int? y = null)
        {
            this.x = x ?? 0;
            this.y = y ?? 0;
        }
    }
}
