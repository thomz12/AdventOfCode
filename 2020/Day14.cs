using AOCHelper;
using System.Collections.Generic;
using System.Linq;

namespace _2020
{
    class Day14 : AOCDay
    {
        public Day14()
            : base(2020, 14)
        {

        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            Dictionary<int, ulong> memory = new Dictionary<int, ulong>();

            ulong zeroesMask = 0;
            ulong onesMask = 0;

            foreach (string line in lines)
            {
                string[] split = line.Split(new string[] { "mem[", "]", "=", " " }, System.StringSplitOptions.RemoveEmptyEntries);

                if (split[0].Equals("mask"))
                {
                    zeroesMask = 0;
                    onesMask = 0;

                    for (int i = 0; i < split[1].Length; ++i)
                    {
                        zeroesMask = zeroesMask << 1;
                        onesMask = onesMask << 1;

                        if (split[1][i] == 'X')
                            continue;

                        if (split[1][i] == '0')
                            zeroesMask++;
                        else
                            onesMask++;
                    }
                }
                else
                {
                    int address = int.Parse(split[0]);
                    ulong value = ulong.Parse(split[1]);

                    if (!memory.ContainsKey(address))
                        memory.Add(address, 0);

                    value &= ~zeroesMask;
                    value |= onesMask;

                    memory[address] = value;
                }
            }

            ulong total = 0;

            for (int i = 0; i < memory.Count; ++i)
            {
                total += memory.ElementAt(i).Value;
            }

            return total;
        }

        public override object Puzzle2(AOCInput input)
        {
            input.SetExampleInput(@"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1");

            string[] lines = input.GetInputLines();

            Dictionary<int, ulong> memory = new Dictionary<int, ulong>();

            ulong mask = 0;
            List<ulong> masks = new List<ulong>();

            foreach (string line in lines)
            {
                string[] split = line.Split(new string[] { "mem[", "]", "=", " " }, System.StringSplitOptions.RemoveEmptyEntries);

                if (split[0].Equals("mask"))
                {
                    mask = 0;

                    for (int i = 0; i < split[1].Length; ++i)
                    {
                        mask = mask << 1;

                        if (split[1][i] == '1')
                            mask++;
                    }

                    masks.Add(mask);

                    for (int i = 0; i < split[1].Length; ++i)
                    {
                        if (split[1][i] == 'X')
                        {
                            int maskCount = masks.Count;
                            for (int j = 0; j < maskCount; ++j)
                            {
                                ulong newMask = ((ulong)1 << split[1].Length - 1 - i);
                                newMask = newMask | masks[j];
                                masks.Add(newMask);
                            }
                        }
                    }
                }
                else
                {
                    int address = int.Parse(split[0]);
                    ulong value = ulong.Parse(split[1]);

                    for (int i = 0; i < masks.Count; ++i)
                    {
                        if (!memory.ContainsKey(address))
                            memory.Add(address, 0);

                        memory[address + i] = value | masks[i];
                    }
                }
            }

            ulong total = 0;

            for (int i = 0; i < memory.Count; ++i)
            {
                total += memory.ElementAt(i).Value;
            }

            return total;
        }
    }
}
