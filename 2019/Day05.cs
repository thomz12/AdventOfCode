using AOCHelper;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day05 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day05() 
            : base(2019, 5)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            int[] program = input.GetInput(",").Select(x => int.Parse(x)).ToArray();

            IntcodeComputer computer = new IntcodeComputer(program);
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
            int[] program = input.GetInput(",").Select(x => int.Parse(x)).ToArray();

            IntcodeComputer computer = new IntcodeComputer(program);
            computer.Run(5);

            return computer.Outputs[0];
        }
    }
}
