namespace AOCHelper
{
    public abstract class AOCDay
    {
        /// <summary>
        /// The AOC year to solve.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// The AOC day to solve.
        /// </summary>
        public int Day { get; private set; }

        /// <summary>
        /// Day constructor.
        /// </summary>
        /// <param name="year">The year to solve.</param>
        /// <param name="day">The day to solve.</param>
        public AOCDay(int year, int day)
        {
            Year = year;
            Day = day;
        }

        public abstract string Puzzle1(AOCInput input);

        public abstract string Puzzle2(AOCInput input);
    }
}
