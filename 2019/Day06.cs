using AOCHelper;
using System.Collections.Generic;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day06 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day06() 
            : base(2019, 6)
        {

        }

        class Orbit
        {
            public string name;
            public Orbit lower;
            public List<Orbit> higher;

            // Path finding variables.
            public int dist;
            public Orbit path;

            public Orbit(string name)
            {
                this.name = name;
                lower = null;
                path = null;
                higher = new List<Orbit>();
                dist = int.MaxValue;
            }

            public List<Orbit> GetOrbits()
            {
                List<Orbit> orbits = new List<Orbit>(higher);
                orbits.Add(lower);
                return orbits;
            }
        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            // Get input.
            string[] lines = input.GetInputLines().Select(x => x.Trim()).ToArray();
            Dictionary<string, Orbit> orbits = GetOrbits(lines);

            int orbitCount = 0;

            // Count down to the COM.
            foreach (Orbit orbit in orbits.Values)
            {
                Orbit lower = orbit.lower;

                while (lower != null)
                {
                    orbitCount++;
                    lower = lower.lower;
                }
            }

            return orbitCount;
        }

        /// <summary>
        /// Used for parsing the input.
        /// </summary>
        /// <param name="lines">The puzzle input split in lines.</param>
        /// <returns>Dictionary with name as key, orbit as value.</returns>
        private Dictionary<string, Orbit> GetOrbits(string[] lines)
        {
            Dictionary<string, Orbit> orbits = new Dictionary<string, Orbit>();

            foreach (string line in lines)
            {
                string[] split = line.Split(')');

                Orbit lower;
                Orbit higher;

                if (!orbits.TryGetValue(split[0], out lower))
                {
                    lower = new Orbit(split[0]);
                    orbits.Add(split[0], lower);
                }

                if (!orbits.TryGetValue(split[1], out higher))
                {
                    higher = new Orbit(split[1]);
                    orbits.Add(split[1], higher);
                }

                lower.higher.Add(higher);
                higher.lower = lower;
            }

            return orbits;
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            // Get input.
            string[] lines = input.GetInputLines().Select(x => x.Trim()).ToArray();
            Dictionary<string, Orbit> orbits = GetOrbits(lines);

            // Get target and start orbit.
            Orbit start = orbits["YOU"].lower;
            Orbit target = orbits["SAN"].lower;

            List<Orbit> visited = new List<Orbit>();
            start.dist = 0;
            visited.Add(start);

            bool found = false;

            while (!found)
            {
                Orbit cur = visited.OrderBy(x => x.dist).First();
                List<Orbit> neighbours = cur.GetOrbits();

                foreach(Orbit neighbour in neighbours)
                {
                    if (neighbour == null)
                        continue;

                    if (neighbour.dist > cur.dist + 1)
                    {
                        neighbour.dist = cur.dist + 1;
                        neighbour.path = cur;
                        visited.Add(neighbour);

                        if (neighbour == target)
                            found = true;
                    }
                }
                visited.Remove(cur);
            }

            // Reconstruct path found, keep track of steps required.
            Orbit path = target;
            int transfers = 0;

            while(path != null)
            {
                path = path.path;

                if(path != null)
                    transfers++;
            }

            return transfers;
        }
    }
}
