using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019
{
    /// <summary>
    /// Test day, uses a 2018 input from day 1.
    /// </summary>
    class Day00 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day00() 
            : base(2018, 1)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int freq = 0;
            foreach (string line in lines)
                freq += int.Parse(line);

            return freq;
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            List<int> found = new List<int>();

            int freq = 0;
            while (true)
            {
                foreach (string line in lines)
                {
                    if (found.Contains(freq))
                        return freq;

                    found.Add(freq);
                    freq += int.Parse(line);
                }
            }
        }
    }
}
