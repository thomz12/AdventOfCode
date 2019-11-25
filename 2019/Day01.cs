using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    class Day01 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day01() 
            : base(2018, 1)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override string Puzzle1(AOCInput input)
        {
            int freq = 0;
            string[] lines = input.GetInputLines();

            foreach (string line in lines)
                freq += int.Parse(line);

            return freq.ToString();
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override string Puzzle2(AOCInput input)
        {
            return null;
        }
    }
}
