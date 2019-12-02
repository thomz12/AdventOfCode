using AOCHelper;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day01 : AOCDay
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

            return lines.Select(x => int.Parse(x)).Select(x => GetWeightRecursive(x) - x).Sum();
        }

        /// <summary>
        /// Get weight recursively.
        /// </summary>
        /// <param name="mass">The mass to get fuel for.</param>
        /// <returns>The weight of the module plus its required fuel.</returns>
        public int GetWeightRecursive(int mass)
        {
            if (mass <= 0)
                return 0;

            int fuel = GetWeightRecursive((mass / 3) - 2);
            return mass + fuel;
        }

        /// <summary>
        /// Get the required fuel amounts.
        /// </summary>
        /// <param name="mass">Mass of the module.</param>
        /// <returns>The amount of fuel required for the given module.</returns>
        public int GetFuel(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}
