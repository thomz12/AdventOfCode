using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AOCHelper
{
    /// <summary>
    /// Extra helper for running puzzles, and timing their duration.
    /// </summary>
    public class AOCRunner
    {
        private AOCInput _input;
        private bool _done = false;

        /// <summary>
        /// Construct a AOCRunner, used for solving puzzles and recording time. It also get a correct <see cref="AOCInput"/>
        /// </summary>
        /// <param name="puzzle">The day to solve.</param>
        public AOCRunner(AOCDay puzzle)
        {
            Console.WriteLine($"Running puzzles for { puzzle.Year } day { puzzle.Day }...");

            // Setup input getter.
            _input = new AOCInput(puzzle.Year, puzzle.Day);

            // Run and report puzzles.
            Console.WriteLine($"Puzzle 1: { RunPuzzle(puzzle.ExecutePuzzle1, out int time1) } - took { time1 }ms");
            Console.WriteLine($"Puzzle 2: { RunPuzzle(puzzle.ExecutePuzzle2, out int time2) } - took { time2 }ms");

            // Done, report total time and Read() to keep console alive.
            Console.WriteLine($"Done running puzzles! (Total time: { time1 + time2 }ms)");
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
            _done = false;

            string answer = null;
            int executeTime = 0;

            // Play a spinning animation and execute the puzzle.
            Parallel.Invoke(
                () => Spin(),
                () => answer = Execute(puzzle, out executeTime)
            );

            time = executeTime;
            return answer;
        }

        /// <summary>
        /// Execte puzzle function.
        /// </summary>
        /// <param name="puzzle">The function to execute.</param>
        /// <param name="time">The time the function took to execute.</param>
        /// <returns>The answer to the puzzle.</returns>
        private string Execute(Func<AOCInput, string> puzzle, out int time)
        {
            // Start a stopwatch.
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Get the awnser.
            string answer = puzzle(_input);

            // Stop stopwatch and record time.
            watch.Stop();
            time = (int)watch.ElapsedMilliseconds;

            _done = true;
            return answer;
        }

        /// <summary>
        /// Show spin animation while puzzle is executing, until the <see cref="_done"/> flag is set to true.
        /// </summary>
        private void Spin()
        {
            Console.CursorVisible = false;
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;

            char[] chars = new char[] { '/', '-', '\\', '|' };

            for(int i = 0; !_done; ++i)
            {
                int posX = Console.CursorLeft;
                int posY = Console.CursorTop;

                Console.SetCursorPosition(startX, startY);
                Console.Write(chars[i % chars.Length]);

                Console.SetCursorPosition(posX, posY);

                Thread.Sleep(100);
            }
            Console.CursorVisible = true;
        }
    }
}
