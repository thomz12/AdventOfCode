using AOCHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day03 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day03() 
            : base(2019, 3)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            // Parse input.
            string[] lines = input.GetInputLines();

            List<Point> line1 = GetLine(lines[0].Split(','));
            List<Point> line2 = GetLine(lines[1].Split(','));

            // Find intersections.
            List<Point> intersections = line1.Intersect(line2).ToList();

            // Remove 0,0 intersection.
            intersections.RemoveAt(0);
            
            // Calculate closest manhattan distance.
            return intersections.Select(x => Math.Abs(x.X) + Math.Abs(x.Y))
                .OrderBy(x => x).First();
        }

        private List<Point> GetLine(string[] lineData)
        {
            List<Point> line = new List<Point>();
            line.Add(new Point(0, 0));
            Point dirVec = new Point(0, 0);

            foreach (string segment in lineData)
            {
                char dir = segment[0];
                int dist = int.Parse(segment.Substring(1));

                if (dir == 'U')
                    dirVec = new Point(0, 1);
                else if (dir == 'D')
                    dirVec = new Point(0, -1);
                else if (dir == 'L')
                    dirVec = new Point(-1, 0);
                else if (dir == 'R')
                    dirVec = new Point(1, 0);

                for (int i = 0; i < dist; ++i)
                {
                    Point last = line.Last();
                    line.Add(new Point(last.X + dirVec.X, last.Y + dirVec.Y));
                }
            }
            return line;
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            // Parse input.
            string[] lines = input.GetInputLines();

            // Lists to keep track of all distances.
            List<int> distances1;
            List<int> distances2;

            List<Point> line1 = GetLine(lines[0].Split(','), out distances1);
            List<Point> line2 = GetLine(lines[1].Split(','), out distances2);

            // Find intersections.
            List<Point> intersections = line1.Intersect(line2).ToList();

            // Remove 0,0 intersection.
            intersections.RemoveAt(0);

            // Find fewest combines steps to intersection.
            return intersections.Select(x => distances1[line1.IndexOf(x)] + distances2[line2.IndexOf(x)])
                .OrderBy(x => x).First();
        }

        private List<Point> GetLine(string[] lineData, out List<int> distances)
        {
            List<Point> line = new List<Point>();
            distances = new List<int>();
            int totalDist = 0;

            line.Add(new Point(0, 0));
            Point dirVec = new Point(0, 0);

            foreach (string segment in lineData)
            {
                char dir = segment[0];
                int dist = int.Parse(segment.Substring(1));

                if (dir == 'U')
                    dirVec = new Point(0, 1);
                else if (dir == 'D')
                    dirVec = new Point(0, -1);
                else if (dir == 'L')
                    dirVec = new Point(-1, 0);
                else if (dir == 'R')
                    dirVec = new Point(1, 0);

                for (int i = 0; i < dist; ++i)
                {
                    Point last = line.Last();
                    line.Add(new Point(last.X + dirVec.X, last.Y + dirVec.Y));

                    distances.Add(totalDist);
                    totalDist++;
                }
            }
            return line;
        }
    }
}
