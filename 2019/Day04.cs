using AOCHelper;
using System.Linq;
using System.Collections.Generic;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day04 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day04() 
            : base(2019, 4)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            int[] range = input.GetInput("-").Select(x => int.Parse(x)).ToArray();

            int count = 0;

            for(int i = range[0]; i < range[1]; ++i)
            {
                string password = i.ToString();

                bool ascending = password.Zip(password.Skip(1), (a, b) => a <= b).All(x => x);
                bool same = password.Zip(password.Skip(1), (a, b) => a == b).Any(x => x);

                if (same && ascending)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            int[] range = input.GetInput("-").Select(x => int.Parse(x)).ToArray();

            int count = 0;

            for (int i = range[0]; i < range[1]; ++i)
            {
                string password = i.ToString();

                bool ascending = password.Zip(password.Skip(1), (a, b) => a <= b).All(x => x);
                bool same = false;

                for (int j = 0; j < password.Length - 1; ++j)
                {
                    if (password[j] == password[j + 1])
                    {
                        if ((j + 2 >= password.Length || password[j] != password[j + 2]) && 
                            (j - 1 < 0 || password[j] != password[j - 1]))
                        {
                            same = true;
                            break;
                        }
                    }
                }

                if (same && ascending)
                    count++;
            }

            return count;
        }
    }
}
