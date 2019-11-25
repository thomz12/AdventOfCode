using System;
using System.Diagnostics;

namespace AOCHelper
{
    /// <summary>
    /// Extra helper for running puzzles, and timing their duration.
    /// </summary>
    public class AOCRunner
    {
        private AOCInput _input;

        /// <summary>
        /// Construct a AOCRunner, used for solving puzzles and recording time. It also get a correct <see cref="AOCInput"/>
        /// </summary>
        /// <param name="puzzle">The day to solve.</param>
        public AOCRunner(AOCDay puzzle)
        {
            Console.WriteLine($"Running puzzles for {puzzle.Year} day {puzzle.Day}...");

            // Setup input getter.
            _input = new AOCInput(puzzle.Year, puzzle.Day);

            // Solve and report puzzles.
            Console.WriteLine($"Puzzle 1: {RunPuzzle(puzzle.Puzzle1, out int time1)} - took {time1}ms");
            Console.WriteLine($"Puzzle 2: {RunPuzzle(puzzle.Puzzle2, out int time2)} - took {time2}ms");

            // Done, report total time and Read() to keep console alive.
            Console.WriteLine($"Done running puzzles! (Total time: {time1 + time2}ms)");
            Console.Read();
        }

        /// <summary>
        /// Run a given puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle to run.</param>
        /// <param name="time">[out] The time the puzzle took to solve in milliseconds.</param>
        /// <returns>The answer of the puzzle.</returns>
        private string RunPuzzle(Func<AOCInput, string> puzzle, out int time)
        {
            // Start a stopwatch.
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Get the awnser.
            string answer = puzzle(_input);

            // Stop stopwatch and record time.
            watch.Stop();
            time = (int)watch.ElapsedMilliseconds;

            // return the awnser.
            return answer;
        }
    }
}
