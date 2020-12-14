using AOCHelper;
using System.Collections.Generic;
using System.Linq;

namespace _2020
{
    class Day10 : AOCDay
    {
        public Day10() 
            : base(2020, 10)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();
            int[] joltages = lines.Select(int.Parse).OrderBy(x => x).ToArray();

            int device = joltages[joltages.Length - 1] + 3;

            int curJoltage = 0;

            int diff1 = 0;
            int diff2 = 0;
            int diff3 = 1;

            for (int i = 0; i < joltages.Length; ++i)
            {
                if (joltages[i] - curJoltage == 1)
                    diff1++;
                else if (joltages[i] - curJoltage == 2)
                    diff2++;
                else if (joltages[i] - curJoltage == 3)
                    diff3++;

                curJoltage = joltages[i];
            }

            return diff1 * diff3;
        }

        private Dictionary<int, long> _cachedArrangements;

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();
            int[] joltages = lines.Select(int.Parse).OrderBy(x => x).ToArray();

            int device = joltages[joltages.Length - 1] + 3;

            _cachedArrangements = new Dictionary<int, long>();

            return CalculateArrangements(0, joltages, 0) + 1;
        }

        private long CalculateArrangements(int start, int[] others, int offset)
        {
            long total = 0;

            if(_cachedArrangements.TryGetValue(start, out long amount))
            {
                return amount;
            }

            for(int i = 0; i < 3; ++i)
            {
                if (others.Length > offset + i)
                {
                    int x = others[offset + i];

                    if (x - start < 4)
                    {
                        if(i != 0)
                            total++;

                        total += CalculateArrangements(x, others, offset + i + 1);
                    }
                }
            }

            _cachedArrangements.Add(start, total);

            return total;
        }
    }
}
