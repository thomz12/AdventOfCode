using AOCHelper;

namespace _2020
{
    class Day03 : AOCDay
    {
        public Day03() 
            : base(2020, 3)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int posX = 0;
            int posY = 0;

            int trees = 0;

            while(posY < lines.Length)
            {
                if (lines[posY][(posX % lines[posY].Length)] == '#')
                    trees++;

                posX += 3;
                posY += 1;
            }

            return trees;
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] lines = input.GetInputLines();

            int[] patternX = { 1, 3, 5, 7, 1 };
            int[] patternY = { 1, 1, 1, 1, 2 };

            long product = 1;

            for (int i = 0; i < patternX.Length; ++i)
            {
                int posX = 0;
                int posY = 0;

                int trees = 0;

                while (posY < lines.Length)
                {
                    if (lines[posY][(posX % lines[posY].Length)] == '#')
                        trees++;

                    posX += patternX[i];
                    posY += patternY[i];
                }

                product *= trees;
            }

            return product;
        }
    }
}
