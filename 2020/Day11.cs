using AOCHelper;
using System;
using System.Collections.Generic;

namespace _2020
{
    class Day11 : AOCDay
    {
        public Day11() 
            : base(2020, 11)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            char[,] map = new char[lines[0].Length, lines.Length];

            for(int x = 0; x < lines[0].Length; ++x)
            {
                for(int y = 0; y < lines.Length; ++y)
                {
                    map[x, y] = lines[y][x];
                }
            }

            int[,] directions = new int[,]
            {
                { -1, -1 },
                { -1,  0 },
                { -1,  1 },

                {  0, -1 },
                {  0,  1 },

                {  1, -1 },
                {  1,  0 },
                {  1,  1 },
            };

            char[,] newMap = new char[lines[0].Length, lines.Length];
            Array.Copy(map, newMap, lines[0].Length * lines.Length);

            int prevTotal = 0;

            while (true)
            {
                for (int x = 0; x < lines[0].Length; ++x)
                {
                    for (int y = 0; y < lines.Length; ++y)
                    {
                        if (map[x, y] == '.')
                            continue;

                        bool occupied = map[x, y] == '#';
                        int adjacentOccupied = 0;

                        for (int i = 0; i < 8; ++i)
                        {
                            int xPos = x + directions[i, 0];
                            int yPos = y + directions[i, 1];

                            // Make sure it's in range.
                            if (xPos < 0 || yPos < 0 || xPos >= lines[0].Length || yPos >= lines.Length)
                                continue;

                            if (map[xPos, yPos] == '#')
                                adjacentOccupied++;
                        }

                        if (!occupied && adjacentOccupied == 0)
                            newMap[x, y] = '#';

                        if (occupied && adjacentOccupied >= 4)
                            newMap[x, y] = 'L';
                    }
                }

                int total = 0;

                for (int x = 0; x < lines[0].Length; ++x)
                {
                    for (int y = 0; y < lines.Length; ++y)
                    {
                        if (newMap[x, y] == '#')
                            total++;
                    }
                }

                if(prevTotal == total)
                {
                    return total;
                }

                prevTotal = total;

                Array.Copy(newMap, map, lines[0].Length * lines.Length);
            }
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            char[,] map = new char[lines[0].Length, lines.Length];

            for (int x = 0; x < lines[0].Length; ++x)
            {
                for (int y = 0; y < lines.Length; ++y)
                {
                    map[x, y] = lines[y][x];
                }
            }

            int[,] directions = new int[,]
            {
                { -1, -1 },
                { -1,  0 },
                { -1,  1 },

                {  0, -1 },
                {  0,  1 },

                {  1, -1 },
                {  1,  0 },
                {  1,  1 },
            };

            char[,] newMap = new char[lines[0].Length, lines.Length];
            Array.Copy(map, newMap, lines[0].Length * lines.Length);

            int prevTotal = 0;

            while (true)
            {
                for (int x = 0; x < lines[0].Length; ++x)
                {
                    for (int y = 0; y < lines.Length; ++y)
                    {
                        if (map[x, y] == '.')
                            continue;

                        bool occupied = map[x, y] == '#';
                        int adjacentOccupied = 0;

                        for (int i = 0; i < 8; ++i)
                        {
                            for (int j = 1; j < 100; ++j)
                            {
                                int xPos = x + directions[i, 0] * j;
                                int yPos = y + directions[i, 1] * j;

                                // Make sure it's in range.
                                if (xPos < 0 || yPos < 0 || xPos >= lines[0].Length || yPos >= lines.Length)
                                    continue;

                                if (map[xPos, yPos] == '#')
                                {
                                    adjacentOccupied++;
                                    break;
                                }
                                if (map[xPos, yPos] == 'L')
                                {
                                    break;
                                }
                            }
                        }

                        if (!occupied && adjacentOccupied == 0)
                            newMap[x, y] = '#';

                        if (occupied && adjacentOccupied >= 5)
                            newMap[x, y] = 'L';
                    }
                }

                int total = 0;

                for (int x = 0; x < lines[0].Length; ++x)
                {
                    for (int y = 0; y < lines.Length; ++y)
                    {
                        if (newMap[x, y] == '#')
                            total++;
                    }
                }

                if (prevTotal == total)
                {
                    return total;
                }

                prevTotal = total;

                Array.Copy(newMap, map, lines[0].Length * lines.Length);
            }
        }
    }
}
