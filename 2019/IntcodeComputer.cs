using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace _2019
{
    /// <summary>
    /// Class representing an Intcode Computer.
    /// </summary>
    class IntcodeComputer
    {
        // The intcode program.
        private long[] _program;

        // Parameter modes.
        private int[] _modes;

        // The Instruction Pointer.
        private long _ip;

        // The relative base for parameter mode 2.
        private long _rb;

        // Outputs of the computer in a run.
        private List<long> _outputs;

        // Indicates if the computer uses the console at all. (For input and output)
        private bool _useConsole;

        /// <summary>
        /// Indicates if the computer halted.
        /// </summary>
        public bool Halted { get; private set; }

        /// <summary>
        /// All computer outputs from last run.
        /// </summary>
        public ReadOnlyCollection<long> Outputs { get { return _outputs.AsReadOnly(); } }

        /// <summary>
        /// Intcode Computer constructor.
        /// </summary>
        /// <param name="program">The program to execute.</param>
        /// <param name="useConsole">Use console input and output or not.</param>
        public IntcodeComputer(long[] program, bool useConsole = true)
        {
            _program = program;
            Array.Resize(ref _program, 100000);

            _modes = new int[3] { 0, 0, 0 };
            _outputs = new List<long>();

            _useConsole = useConsole;
        }

        /// <summary>
        /// Run the intcode program.
        /// If <see cref="_useConsole"> is false, and no more input is available the computer 
        /// will stop executing until a new run is called with new input parameters. 
        /// </summary>
        public void Run(params long[] input)
        {
            if(Halted)
            {
                _ip = 0;
                _outputs.Clear();
            }

            // Amount of inputs used.
            int inputUsed = 0;

            // Continue until OP code 99.
            while (true)
            {
                long opCode = GetOPCode(_program[_ip]);

                // If OP code is 99 (HALT) stop executing.
                if (opCode == 99)
                {
                    Halted = true;
                    break;
                }

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
                            // If no console, wait until next Run with input.
                            if (!_useConsole)
                                return;

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

                        if(_useConsole)
                            Console.WriteLine(_outputs.Last());

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
                    // SET RELATIVE BASE
                    case 9:
                        _rb += GetValue(1);
                        _ip += 2;
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
        private long GetValue(int offset, bool forceAddres = false)
        {
            int mode = _modes[offset - 1];

            if (forceAddres)
            {
                if(mode == 0)
                    return _program[_ip + offset];
                else if(mode == 2)
                    return _program[_ip + offset] + _rb;
            }

            switch(mode)
            {
                case 0:
                    return _program[_program[_ip + offset]];
                case 1:
                    return _program[_ip + offset];
                case 2:
                    return _program[_program[_ip + offset] + _rb];
            }

            return 0;
        }

        /// <summary>
        /// Retrieve OP code and parameter modes.
        /// </summary>
        /// <param name="opCode">The raw code to progress.</param>
        /// <returns>The OP code. Sets the modes in <see cref="_modes"/></returns>
        private long GetOPCode(long opCode)
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
