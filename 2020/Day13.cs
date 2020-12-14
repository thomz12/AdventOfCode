using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2020
{
    class Day13 : AOCDay
    {
        public Day13() 
            : base(2020, 13)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int earliest = int.Parse(lines[0]);
            int[] busses = lines[1].Split(',').Where(x => !x.Contains("x")).Select(int.Parse).ToArray();

            // Search at lest for the minimum id;
            int attempts = earliest / busses.Min() + 1;

            int closestDistance = int.MaxValue;
            int timeToWait = 0;
            int busID = 0;

            for(int i = 0; i < attempts; ++i)
            {
                for(int j = 0; j < busses.Length; ++j)
                {
                    int distance = Math.Abs(earliest - busses[j] * i);

                    if(distance < closestDistance && busses[j] * i > earliest)
                    {
                        closestDistance = distance;
                        timeToWait = (busses[j] * i) - earliest;
                        busID = busses[j];
                    }
                }
            }

            return timeToWait * busID;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int[] busses = lines[1].Split(',').Select(x => x.Contains("x") ? 0 : int.Parse(x)).ToArray();

            long step = 0;
            long stepSize = busses[0];

            for(int offset = 1; offset < busses.Length; ++offset)
            {
                if (busses[offset] == 0)
                {
                    continue;
                }

                step += stepSize;

                if ((step + offset) % busses[offset] != 0)
                {
                    --offset;
                    continue;
                }

                stepSize = stepSize * busses[offset];
            }

            return step;
        }
    }
}
