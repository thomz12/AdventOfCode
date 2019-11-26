using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018
{
    class Day02 : AOCDay
    {
        public Day02() 
            : base(2018, 2)
        {
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int twos = 0;
            int threes = 0;

            foreach(string line in lines)
            {
                bool two = false;
                bool three = false;

                foreach(char c in line)
                {
                    int amount = line.Where(x => x == c).Count();

                    if (amount == 2)
                        two = true;
                    if (amount == 3)
                        three = true;
                }

                if (two)
                    twos++;
                if (three)
                    threes++;
            }

            return twos * threes;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            string answer = "";
            int amount = 0;

            foreach(string line1 in lines)
            {
                foreach(string line2 in lines)
                {
                    if (line2 == line1)
                        continue;

                    int diff = 0;
                    string tmpAns = "";

                    for (int i = 0; i < line2.Length; i++)
                    {
                        if (line1[i] == line2[i])
                        {
                            diff++;
                            tmpAns += line1[i];
                        }
                    }

                    if (diff > amount)
                    {
                        answer = tmpAns;
                        amount = diff;
                    }
                }
            }
            return answer;
        }
    }
}
