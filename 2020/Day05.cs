using AOCHelper;
using System;
using System.Collections.Generic;

namespace _2020
{
    class Day05 : AOCDay
    {
        public Day05() 
            : base(2020, 5)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] boardingTickets = input.GetInputLines();

            int highestID = 0;

            foreach(string ticket in boardingTickets)
            {
                int rowMin = 0;
                int rowMax = 127;
                int columnMin = 0;
                int columnMax = 8;

                for (int i = 0; i < ticket.Length; ++i)
                {
                    if(ticket[i] == 'F')
                        rowMax -= ((rowMax + 1) - rowMin) / 2;
                    else if(ticket[i] == 'B')
                        rowMin += ((rowMax + 1) - rowMin) / 2;
                    else if (ticket[i] == 'L')
                        columnMax -= ((columnMax + 1) - columnMin) / 2;
                    else if (ticket[i] == 'R')
                        columnMin += ((columnMax + 1) - columnMin) / 2;
                }

                int id = rowMin * 8 + columnMin;

                if (id > highestID)
                    highestID = id;
            }

            return highestID;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] boardingTickets = input.GetInputLines();

            List<int> ids = new List<int>();

            foreach (string ticket in boardingTickets)
            {
                int rowMin = 0;
                int rowMax = 127;
                int columnMin = 0;
                int columnMax = 8;

                for (int i = 0; i < ticket.Length; ++i)
                {
                    if (ticket[i] == 'F')
                        rowMax -= ((rowMax + 1) - rowMin) / 2;
                    else if (ticket[i] == 'B')
                        rowMin += ((rowMax + 1) - rowMin) / 2;
                    else if (ticket[i] == 'L')
                        columnMax -= ((columnMax + 1) - columnMin) / 2;
                    else if (ticket[i] == 'R')
                        columnMin += ((columnMax + 1) - columnMin) / 2;
                }

                int id = rowMin * 8 + columnMin;
                ids.Add(id);
            }

            foreach(int id in ids)
            {
                if(ids.Contains(id - 2) && !ids.Contains(id - 1))
                {
                    return id - 1;
                }
            }

            return -1;
        }
    }
}
