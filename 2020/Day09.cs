using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2020
{
    class Day09 : AOCDay
    {
        public Day09() 
            : base(2020, 9)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            const int preambleLength = 25;
            string[] lines = input.GetInputLines();
            long[] numbers = lines.Select(long.Parse).ToArray();

            long[] preamble = new long[preambleLength];

            for (int i = 0; i < numbers.Length - 1; ++i)
            {
                preamble[i % preambleLength] = numbers[i];

                if(i >= preambleLength)
                {
                    if(!CheckRule(preamble, numbers[i + 1]))
                    {
                        return numbers[i + 1];
                    }
                }
            }

            return null;
        }

        public override object Puzzle2(AOCInput input)
        {
            const int preambleLength = 25;
            string[] lines = input.GetInputLines();
            long[] numbers = lines.Select(long.Parse).ToArray();

            long[] preamble = new long[preambleLength];

            long answer = 0;

            for (int i = 0; i < numbers.Length - 1; ++i)
            {
                preamble[i % preambleLength] = numbers[i];

                if (i >= preambleLength)
                {
                    if (!CheckRule(preamble, numbers[i + 1]))
                    {
                        answer = numbers[i + 1];
                    }
                }
            }

            int size = 2;

            while (true)
            {
                for(int i = 0; i < numbers.Length - size; ++i)
                {
                    long sum = 0;
                    for(int j = 0; j < size; ++j)
                    {
                        sum += numbers[i + j];
                    }

                    if(sum == answer)
                    {
                        return numbers.Skip(i).Take(size).Min() + numbers.Skip(i).Take(size).Max();
                    }
                }

                size++;
            }

            return null;
        }

        private bool CheckRule(long[] preamble, long number)
        {
            for(int i = 0; i < preamble.Length; ++i)
            {
                for(int j = 0; j < preamble.Length; ++j)
                {
                    if (i == j)
                        continue;

                    if (preamble[i] + preamble[j] == number)
                        return true;
                }
            }

            return false;
        }
    }
}
