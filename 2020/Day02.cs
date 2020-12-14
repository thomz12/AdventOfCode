using AOCHelper;
using System.Collections.Generic;

namespace _2020
{
    class Day02 : AOCDay
    {
        public Day02() 
            : base(2020, 2)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int answer = 0;

            for(int i = 0; i < lines.Length; ++i)
            {
                string[] split = lines[i].Split(new char[] { '-', ' ', ':'});

                int min = int.Parse(split[0]);
                int max = int.Parse(split[1]);
                char character = split[2][0];
                string password = split[4];

                int count = 0;

                for(int j = 0; j < password.Length; ++j)
                {
                    if(password[j] == character)
                    {
                        count++;
                    }
                }

                if (count >= min && count <= max)
                    answer++;
            }

            return answer;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int answer = 0;

            for (int i = 0; i < lines.Length; ++i)
            {
                string[] split = lines[i].Split(new char[] { '-', ' ', ':' });

                int first = int.Parse(split[0]);
                int second = int.Parse(split[1]);
                char character = split[2][0];
                string password = split[4];

                bool hasFirst = password[first - 1] == character;
                bool hasSecond = password[second - 1] == character;

                if (hasFirst ^ hasSecond)
                    answer++;
            }

            return answer;
        }
    }
}
