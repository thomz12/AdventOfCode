using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day07 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day07() 
            : base(2019, 7)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            int[] software = input.GetInput(",").Select(x => int.Parse(x)).ToArray();

            IntcodeComputer computer;

            int[] sequence = new int[] { 0, 1, 2, 3, 4 };
            var permutations = GetPermutations<int>(sequence, 5);

            long maxOutput = 0;
            int maxSequence = 0;

            for(int i = 0; i < permutations.Count(); ++i)
            {
                long output = 0;

                for (int j = 0; j < 5; ++j)
                {
                    computer = new IntcodeComputer((long[])software.Clone(), false);
                    computer.Run(permutations.ElementAt(i).ElementAt(j), output);
                    output = computer.Outputs.Last();
                }

                if(output > maxOutput)
                {
                    maxOutput = output;
                    maxSequence = i;
                }
            }

            return maxOutput;
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            int[] software = input.GetInput(",").Select(x => int.Parse(x)).ToArray();

            IntcodeComputer[] computer = new IntcodeComputer[5];
            
            int[] sequence = new int[] { 5, 6, 7, 8, 9 };
            var permutations = GetPermutations<int>(sequence, 5);

            long maxOutput = 0;
            int maxSequence = 0;

            for (int i = 0; i < permutations.Count(); ++i)
            {
                long output = 0;

                // Initialize computers.
                for (int j = 0; j < computer.Length; ++j)
                {
                    computer[j] = new IntcodeComputer((long[])software.Clone(), false);
                    computer[j].Run(permutations.ElementAt(i).ElementAt(j), output);
                    output = computer[j].Outputs.Last();
                }

                int curComp = 0;

                // Computer feedback loop.
                while (true)
                {
                    if (computer[curComp].Halted)
                        break;

                    computer[curComp].Run(output);
                    output = computer[curComp].Outputs.Last();

                    curComp = (curComp + 1) % 5;
                }

                // Check if output is highest. 
                if (output > maxOutput)
                {
                    maxOutput = output;
                    maxSequence = i;
                }
            }

            return maxOutput;
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)), (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
