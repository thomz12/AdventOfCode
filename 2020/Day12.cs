using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2020
{
    class Day12 : AOCDay
    {
        public Day12() 
            : base(2020, 12)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] instructions = input.GetInputLines();

            int posX = 0;
            int posY = 0;

            int dir = 0;

            int[,] directions = new int[,]
            {
                { 1, 0 }, // east
                { 0, 1 }, // south
                { -1, 0 }, // west
                { 0, -1 }, // north
            };

            foreach (string instruction in instructions)
            {
                char action = instruction[0];
                int amount = int.Parse(new string(instruction.Skip(1).ToArray()));

                int moveDir = dir;
                int moveAmount = 0;

                switch (action)
                {
                    case 'N':
                        moveDir = 3;
                        moveAmount = amount;
                        break;
                    case 'E':
                        moveDir = 0;
                        moveAmount = amount;
                        break;
                    case 'S':
                        moveDir = 1;
                        moveAmount = amount;
                        break;
                    case 'W':
                        moveDir = 2;
                        moveAmount = amount;
                        break;
                    case 'L':
                        dir -= amount / 90;
                        break;
                    case 'R':
                        dir += amount / 90;
                        break;
                    case 'F':
                        moveAmount = amount;
                        break;
                }

                posX += directions[Modulo(moveDir, 4), 0] * moveAmount;
                posY += directions[Modulo(moveDir, 4), 1] * moveAmount;
            }

            return Math.Abs(posX) + Math.Abs(posY);
        }

        private int Modulo(int a, int b)
        {
            return a - b * (int)Math.Floor((double)a / b);
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] instructions = input.GetInputLines();

            int posX = 0;
            int posY = 0;
            int dir = 0;

            int waypointX = 10;
            int waypointY = -1;

            int[,] directions = new int[,]
            {
                { 1, 0 }, // east
                { 0, 1 }, // south
                { -1, 0 }, // west
                { 0, -1 }, // north
            };

            foreach (string instruction in instructions)
            {
                char action = instruction[0];
                int amount = int.Parse(new string(instruction.Skip(1).ToArray()));

                int moveDir = dir;
                int moveAmount = 0;

                switch (action)
                {
                    case 'N':
                        moveDir = 3;
                        moveAmount = amount;
                        break;
                    case 'E':
                        moveDir = 0;
                        moveAmount = amount;
                        break;
                    case 'S':
                        moveDir = 1;
                        moveAmount = amount;
                        break;
                    case 'W':
                        moveDir = 2;
                        moveAmount = amount;
                        break;
                    case 'L':
                        int counterClockwiseRotations = amount / 90;

                        for (int i = 0; i < counterClockwiseRotations; ++i)
                        {
                            int temp = waypointX;
                            waypointX = waypointY;
                            waypointY = -temp;
                        }

                        break;
                    case 'R':
                        int clockwiseRotations = amount / 90;

                        for(int i = 0; i < clockwiseRotations; ++i)
                        {
                            int temp = waypointX;
                            waypointX = -waypointY;
                            waypointY = temp;
                        }

                        break;
                    case 'F':
                        posX += waypointX * amount;
                        posY += waypointY * amount;
                        break;
                }

                waypointX += directions[Modulo(moveDir, 4), 0] * moveAmount;
                waypointY += directions[Modulo(moveDir, 4), 1] * moveAmount;
            }

            return Math.Abs(posX) + Math.Abs(posY);
        }
    }
}
