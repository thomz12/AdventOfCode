using AOCHelper;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day10 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day10() 
            : base(2019, 10)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            string[] map = input.GetInputLines();

            for(int y1 = 0; y1 < map.Length; ++y1)
            {
                for(int x1 = 0; x1 < map[y1].Length; ++x1)
                {
                    // If astroid, we might need to place station here.
                    if (map[y1][x1] == '#')
                    {
                        for (int y2 = 0; y2 < map.Length; ++y2)
                        {
                            for (int x2 = 0; x2 < map[y2].Length; ++x2)
                            {
                                // If same astroid, do nothing.
                                if (y1 == y2 && x1 == x2)
                                    continue;

                                int xDist = x1 - x2;
                                int yDist = y1 - y2;
                                

                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            return null;
        }
    }
}
