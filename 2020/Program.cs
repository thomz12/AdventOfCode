﻿using AOCHelper;
using System;

namespace _2020
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
            AOCDay day = null;

            // Try to get the given or current day to run.
            try
            {
                // If an argument is given, run that day.
                if (args.Length == 1)
                {
                    Console.WriteLine($"Getting puzzle solution for day {args[0]}");
                    Type type = GetTypeByDay(int.Parse(args[0]));
                    day = (AOCDay)Activator.CreateInstance(type);
                }
                // Othwerwise, the current day of the month.
                else
                {
                    Console.WriteLine("Getting the current day...");
                    Type type = GetTypeByDay(DateTime.Now.Day);
                    day = (AOCDay)Activator.CreateInstance(type);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create or find given day.");
#if DEBUG
                Console.WriteLine(ex);
#endif

                return;
            }

            // Run the puzzles of the day.
            AOCRunner runner = new AOCRunner(day, RunMode.BOTH);

#if DEBUG
            // Prevents the console from closing while in debug mode.
            Console.Read();
#endif
        }

        private static Type GetTypeByDay(int day)
        {
            string dayString = day.ToString().PadLeft(2, '0');
            return Type.GetType($"_2020.Day{dayString}");
        }
    }
}
