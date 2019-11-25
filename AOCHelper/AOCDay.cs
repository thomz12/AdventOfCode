namespace AOCHelper
{
    public abstract class AOCDay
    {
        private const string NO_ANSWER = "No answer available";

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

        /// <summary>
        /// Execute the first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput.</param>
        /// <returns>The answer (or no answer string)</returns>
        public string ExecutePuzzle1(AOCInput input)
        {
            object answer = Puzzle1(input);
            return GetAnswerString(answer);
        }

        /// <summary>
        /// Execute the second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput.</param>
        /// <returns>The answer (or no answer string)</returns>
        internal string ExecutePuzzle2(AOCInput input)
        {
            object answer = Puzzle2(input);
            return GetAnswerString(answer);
        }

        /// <summary>
        /// Return answer string.
        /// </summary>
        /// <param name="answer">The object to convert.</param>
        /// <returns>No answer string or the converted answer.</returns>
        private static string GetAnswerString(object answer)
        {
            string answerString = answer?.ToString();
            return string.IsNullOrEmpty(answerString) ? NO_ANSWER : answerString;
        }

        /// <summary>
        /// Function to implement for first puzzle of the day.
        /// </summary>
        /// <param name="input">The AOCInput.</param>
        /// <returns>The answer.</returns>
        public abstract object Puzzle1(AOCInput input);

        /// <summary>
        /// Function to implement for second puzzle of the day.
        /// </summary>
        /// <param name="input">The AOCInput.</param>
        /// <returns>The answer.</returns>
        public abstract object Puzzle2(AOCInput input);
    }
}
