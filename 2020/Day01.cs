using AOCHelper;
using System.Collections.Generic;

namespace _2020
{
    class Day01 : AOCDay
    {
        public Day01() 
            : base(2020, 1)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();
            int[] numbers = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = int.Parse(lines[i]);
            }

            for (int i = 0; i < numbers.Length; ++i)
            {
                for (int j = 0; j < numbers.Length; ++j)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if(numbers[i] + numbers[j] == 2020)
                    {
                        return numbers[i] * numbers[j];
                    }
                }
            }

            return null;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();
            int[] numbers = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = int.Parse(lines[i]);
            }

            for (int i = 0; i < numbers.Length; ++i)
            {
                for (int j = 0; j < numbers.Length; ++j)
                {
                    for (int k = 0; k < numbers.Length; ++k)
                    {
                        if (i == j || i == k || j == k)
                        {
                            continue;
                        }

                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            return numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }
            }

            return null;
        }
    }
}
