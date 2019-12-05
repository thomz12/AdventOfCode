using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _2019
{
    /// <summary>
    /// Class representing an Intcode Computer.
    /// </summary>
    class IntcodeComputer
    {
        // The intcode program.
        private int[] _program;

        // Parameter modes.
        private int[] _modes;

        // The Instruction Pointer.
        private int _ip;

        // Outputs of the computer in a run.
        private List<int> _outputs;

        /// <summary>
        /// All computer outputs from last run.
        /// </summary>
        public ReadOnlyCollection<int> Outputs { get { return _outputs.AsReadOnly(); } }

        /// <summary>
        /// Intcode Computer constructor.
        /// </summary>
        /// <param name="program">The program to execute.</param>
        public IntcodeComputer(int[] program)
        {
            _program = program;
            _modes = new int[3] { 0, 0, 0 };
            _outputs = new List<int>();
        }

        /// <summary>
        /// Run the intcode program.
        /// </summary>
        public void Run(params int[] input)
        {
            // Set instruction pointer to start.
            _ip = 0;

            // Clear outputs.
            _outputs.Clear();

            // Amount of inputs used.
            int inputUsed = 0;

            // Continue until OP code 99.
            while (true)
            {
                int opCode = GetOPCode(_program[_ip]);

                // If OP code is 99 (HALT) stop executing.
                if (opCode == 99)
                    break;

                switch (opCode)
                {
                    // ADD
                    case 1:
                        _program[GetValue(3, true)] = GetValue(1) + GetValue(2);
                        _ip += 4;
                        break;
                    // MULTIPLY
                    case 2:
                        _program[GetValue(3, true)] = GetValue(1) * GetValue(2);
                        _ip += 4;
                        break;
                    // INPUT
                    case 3:
                        if (inputUsed >= input.Length)
                        {
                            Console.WriteLine("\nInput: ");
                            int consoleInput = int.Parse(Console.ReadLine());
                            _program[GetValue(1, true)] = consoleInput;
                        }
                        else
                        {
                            _program[GetValue(1, true)] = input[inputUsed];
                            inputUsed++;
                        }

                        _ip += 2;
                        break;
                    // OUTPUT
                    case 4:
                        _outputs.Add(GetValue(1));
                        Console.WriteLine(GetValue(1));
                        _ip += 2;
                        break;
                    // JUMP IF TRUE
                    case 5:
                        if (GetValue(1) != 0)
                            _ip = GetValue(2);
                        else
                            _ip += 3;
                        break;
                    // JUMP IF FALSE
                    case 6:
                        if (GetValue(1) == 0)
                            _ip = GetValue(2);
                        else
                            _ip += 3;
                        break;
                    // LESS THAN
                    case 7:
                        _program[GetValue(3, true)] = GetValue(1) < GetValue(2) ? 1 : 0;
                        _ip += 4;
                        break;
                    // EQUALS
                    case 8:
                        _program[GetValue(3, true)] = GetValue(1) == GetValue(2) ? 1 : 0;
                        _ip += 4;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets a value with parameter mode in mind.
        /// </summary>
        /// <param name="offset">Offset from the current <see cref="_ip"/></param>
        /// <param name="forceAddres">Force paramter mode to be 0. (Used for writes)</param>
        /// <returns>Value from the program with using parameter mode.</returns>
        private int GetValue(int offset, bool forceAddres = false)
        {
            return (_modes[offset - 1] == 0 && !forceAddres) ? _program[_program[_ip + offset]] : _program[_ip + offset];
        }

        /// <summary>
        /// Retrieve OP code and parameter modes.
        /// </summary>
        /// <param name="opCode">The raw code to progress.</param>
        /// <returns>The OP code. Sets the modes in <see cref="_modes"/></returns>
        private int GetOPCode(int opCode)
        {
            // Reset parameter modes.
            _modes[0] = 0;
            _modes[1] = 0;
            _modes[2] = 0;

            // If instruction contains parameter modes.
            if (opCode > 99)
            {
                string code = opCode.ToString();
                for (int i = code.Length - 3; i >= 0; --i)
                    _modes[code.Length - 3 - i] = int.Parse(code[i].ToString());

                opCode = int.Parse(code.Substring(code.Length - 2));
            }

            return opCode;
        }
    }
}
