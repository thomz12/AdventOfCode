using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOCHelper
{
    /// <summary>
    /// Instructions how to run the puzzles.
    /// </summary>
    [Flags]
    public enum RunMode
    {
        /// <summary>
        /// Run no puzzle.
        /// </summary>
        NONE = 0,
        /// <summary>
        /// Run only puzzle 1.
        /// </summary>
        PART_1 = 1,
        /// <summary>
        /// Run only puzzle 2.
        /// </summary>
        PART_2 = 2,
        /// <summary>
        /// Run both puzzles.
        /// </summary>
        BOTH = 3
    }
}
