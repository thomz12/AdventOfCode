using AOCHelper;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Day of the advent of code 2019, containing solutions of the two puzzles.
    /// </summary>
    public class Day02 : AOCDay
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public Day02() 
            : base(2019, 2)
        {

        }

        /// <summary>
        /// Class representing an Intcode Computer.
        /// </summary>
        class IntcodeComputer
        {
            // The intcode program.
            private int[] _program;

            // The Instruction Pointer.
            private int _ip;

            /// <summary>
            /// Intcode Computer constructor.
            /// </summary>
            /// <param name="program">The program to execute.</param>
            public IntcodeComputer(int[] program)
            {
                _program = program;
            }

            /// <summary>
            /// Run the intcode program.
            /// </summary>
            /// <returns>Value at index 0.</returns>
            public int Run()
            {
                _ip = 0;

                // Continue until OP code 99.
                while (_program[_ip] != 99)
                {
                    switch (_program[_ip])
                    {
                        case 1:
                            _program[_program[_ip + 3]] = _program[_program[_ip + 1]] + _program[_program[_ip + 2]];
                            _ip += 4;
                            break;
                        case 2:
                            _program[_program[_ip + 3]] = _program[_program[_ip + 1]] * _program[_program[_ip + 2]];
                            _ip += 4;
                            break;
                    }
                }

                return _program[0];
            }
        }

        /// <summary>
        /// The first puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle1(AOCInput input)
        {
            int[] program = input.GetInput(",").Select(x => int.Parse(x)).ToArray();

            program[1] = 12;
            program[2] = 2;

            IntcodeComputer computer = new IntcodeComputer(program);
            return computer.Run();
        }

        /// <summary>
        /// The second puzzle.
        /// </summary>
        /// <param name="input">The AOCInput object for getting the input.</param>
        /// <returns>The answer.</returns>
        public override object Puzzle2(AOCInput input)
        {
            int[] program = input.GetInput(",").Select(x => int.Parse(x)).ToArray();

            for (int noun = 0; noun < 99; ++noun)
            {
                for (int verb = 0; verb < 99; ++verb)
                {
                    program[1] = noun;
                    program[2] = verb;

                    IntcodeComputer computer = new IntcodeComputer((int[])program.Clone());
                    int output = computer.Run();

                    if (output == 19690720)
                        return 100 * noun + verb;
                }
            }

            return "Program failed!";
        }
    }
}
