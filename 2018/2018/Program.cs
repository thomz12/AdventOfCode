using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018
{
    /// <summary>
    /// Contains the entry point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Unused command line arguments.</param>
        static void Main(string[] args)
        {
            // Run the puzzles of the day provided here.
            AOCRunner runner = new AOCRunner(new Day03());
        }
    }
}
