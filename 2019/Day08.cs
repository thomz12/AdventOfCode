using AOCHelper;
using System;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day08 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day08() 
            : base(2019, 8)
        {

        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            int[] data = input.GetInput().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

            int width = 25;
            int height = 6;

            int[][] layers = new int[data.Length / (width * height)][];

            // Copy layer data.
            for (int i = 0; i < layers.Length; ++i)
            {
                layers[i] = new int[width * height];
                Array.Copy(data, i * (width * height), layers[i], 0, width * height);
            }

            // Get layer with least zeroes.
            int[] leastZeroes = layers.OrderBy(image => image.Count(x => x == 0)).First();

            return leastZeroes.Count(x => x == 1) * leastZeroes.Count(x => x == 2);
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            int[] data = input.GetInput().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

            int width = 25;
            int height = 6;

            int[][] layers = new int[data.Length / (width * height)][];

            // Copy layer data.
            for (int i = 0; i < layers.Length; ++i)
            {
                layers[i] = new int[width * height];
                Array.Copy(data, i * (width * height), layers[i], 0, width * height);
            }

            int[] image = new int[width * height];

            // Get image data by combining the layers.
            for (int i = 0; i < width * height; ++i)
            {
                for(int j = 0; j < layers.Length; ++j)
                {
                    if(layers[j][i] != 2)
                    {
                        image[i] = layers[j][i];
                        break;
                    }
                }
            }

            // Visualize the image in the console.
            for(int i = 0; i < height; ++i)
            { 
                for(int j = 0; j < width; ++j)
                    Console.Write(image[j + width * i] == 0 ? " " : "X");

                Console.WriteLine();
            }

            return "See console ouptut.";
        }
    }
}
