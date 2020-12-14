using AOCHelper;
using System;
using System.Collections.Generic;

namespace _2020
{
    class Day04 : AOCDay
    {
        public Day04() 
            : base(2020, 4)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            string passport = "";
            int valid = 0;

            for (int i = 0; i < lines.Length; ++i)
            {
                if (!string.IsNullOrEmpty(lines[i]) && lines[i].Length != 1)
                {
                    passport += lines[i] + " ";
                }
                else
                {
                    string[] keyvalues = passport.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (keyvalues.Length == 7)
                    {
                        bool isValid = true;

                        if (passport.Contains("cid"))
                            isValid = false;

                        if (isValid)
                            valid++;
                    }
                    else if(keyvalues.Length == 8)
                        valid++;

                    passport = "";
                }
            }

            // > 229 
            // < 243
            return valid;
        }

        public override object Puzzle2(AOCInput input)
        {
            return null;
        }
    }
}
