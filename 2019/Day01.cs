using AOCHelper;
using System.Linq;

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
            : base(2019, 1)
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

            return lines.Select(x => GetFuel(int.Parse(x))).Sum();
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int totalFuel = 0;

            foreach(string line in lines)
            {
                int fuel = GetFuel(int.Parse(line));
                int extra = fuel;

                while (extra >= 0)
                {
                    extra = GetFuel(extra);
                    if (extra > 0)
                        fuel += extra;
                }

                totalFuel += fuel;
            }

            return totalFuel;
        }

        public int GetFuel(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}
