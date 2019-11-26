using AOCHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _2018
{
    class Day03 : AOCDay
    {
        public Day03() 
            : base(2018, 3)
        {
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            short[,] overlap = new short[1000,1000];

            int count = 0;

            foreach(string line in lines)
            {
                string[] split = line.Split(' ');

                int id = int.Parse(split[0].Substring(1));

                int x = int.Parse(split[2].Split(',')[0]);
                int y = int.Parse(new string(split[2].Split(',')[1].Where(Char.IsDigit).ToArray()));
                int w = int.Parse(split[3].Split('x')[0]);
                int h = int.Parse(split[3].Split('x')[1]);

                for(int i = x; i < x + w; ++i)
                {
                    for(int j = y; j < y + h; ++j)
                    {
                        overlap[i, j]++;
                        if (overlap[i, j] == 2)
                            count++;
                    }
                }
            }
            return count;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            short[,] overlap = new short[1000, 1000];

            Dictionary<int, Rectangle> rects = new Dictionary<int, Rectangle>();

            foreach (string line in lines)
            {
                string[] split = line.Split(' ');

                int id = int.Parse(split[0].Substring(1));

                int x = int.Parse(split[2].Split(',')[0]);
                int y = int.Parse(new string(split[2].Split(',')[1].Where(Char.IsDigit).ToArray()));
                int w = int.Parse(split[3].Split('x')[0]);
                int h = int.Parse(split[3].Split('x')[1]);

                rects.Add(id, new Rectangle(x, y, w, h));
            }

            foreach (KeyValuePair<int, Rectangle> rect1 in rects)
            {
                bool intersects = false;

                foreach (KeyValuePair<int, Rectangle> rect2 in rects)
                {
                    if (rect1.Key == rect2.Key)
                        continue;

                    if (rect1.Value.IntersectsWith(rect2.Value))
                    {
                        intersects = true;
                        break;
                    }
                }

                if (!intersects)
                    return rect1.Key;
            }

            return null;
        }
    }
}
