using AOCHelper;
using System.Collections.Generic;

namespace _2020
{
    class Day08 : AOCDay
    {
        public Day08() 
            : base(2020, 8)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] program = input.GetInputLines();

            int accumulator = 0;

            List<int> visited = new List<int>();

            for (int programCounter = 0; programCounter < program.Length; ++programCounter)
            {
                if (visited.Contains(programCounter))
                    return accumulator;

                visited.Add(programCounter);

                switch(program[programCounter][0])
                {
                    case 'n':
                        break;
                    case 'a':
                        int accChange = GetValueFromInstruction(program[programCounter]);
                        accumulator += accChange;
                        break;
                    case 'j':
                        int jmpValue = GetValueFromInstruction(program[programCounter]);
                        programCounter += (jmpValue - 1);
                        break;

                }
            }

            return null;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] program = input.GetInputLines();

            for (int i = 0; i < program.Length; ++i)
            {
                if (program[i][0] == 'n' || program[i][0] == 'j')
                {
                    if(program[i][0] == 'n')
                        program[i] = program[i].Replace('n', 'j');
                    else
                        program[i] = program[i].Replace('j', 'n');

                    int programCounter;
                    int accumulator = 0;
                    List<int> visited = new List<int>();

                    for (programCounter = 0; programCounter < program.Length; ++programCounter)
                    {
                        if (visited.Contains(programCounter))
                            break;

                        visited.Add(programCounter);

                        switch (program[programCounter][0])
                        {
                            case 'n':
                                break;
                            case 'a':
                                int accChange = GetValueFromInstruction(program[programCounter]);
                                accumulator += accChange;
                                break;
                            case 'j':
                                int jmpValue = GetValueFromInstruction(program[programCounter]);
                                programCounter += (jmpValue - 1);
                                break;

                        }
                    }

                    if (programCounter == program.Length)
                    {
                        return accumulator;
                    }
                    else
                    {
                        // restore program.
                        if (program[i][0] == 'n')
                            program[i] = program[i].Replace('n', 'j');
                        else
                            program[i] = program[i].Replace('j', 'n');
                    }
                }
            }

            return null;
        }

        private int GetValueFromInstruction(string instruction)
        {
            string[] split = instruction.Split(' ');
            if (split[1][0] == '+')
                split[1] = split[1].Remove(0, 1);

            return int.Parse(split[1]);
        }
    }
}
