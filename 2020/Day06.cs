using AOCHelper;
using System;
using System.Linq;

namespace _2020
{
    class Day06 : AOCDay
    {
        public Day06() 
            : base(2020, 6)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            string group = "";

            int sum = 0;

            foreach(string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    group += line;
                }
                else
                {
                    sum += group.Distinct().Count();
                    group = "";
                }
            }

            // Add last group.
            sum += group.Distinct().Count();

            return sum;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            string group = "";
            bool newGroup = true;
            int sum = 0;

            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if(newGroup)
                    {
                        group = line;
                        newGroup = false;
                    }
                    else
                    {
                        group = new String(group.Intersect(line).ToArray());
                    }
                }
                else
                {
                    sum += group.Distinct().Count();
                    group = "";
                    newGroup = true;
                }
            }

            // Add last group.
            sum += group.Distinct().Count();

            return sum;
        }
    }
}
