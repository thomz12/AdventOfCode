using AOCHelper;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day09 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day09() 
            : base(2019, 9)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            long[] software = input.GetInput(",").Select(x => long.Parse(x)).ToArray();

            IntcodeComputer computer = new IntcodeComputer(software, false);
            computer.Run(1);

            return computer.Outputs.Last();
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            long[] software = input.GetInput(",").Select(x => long.Parse(x)).ToArray();

            IntcodeComputer computer = new IntcodeComputer(software, false);
            computer.Run(2);

            return computer.Outputs.Last();
        }
    }
}
