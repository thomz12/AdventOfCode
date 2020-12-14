using AOCHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2020
{
    class Day07 : AOCDay
    {
        public Day07() 
            : base(2020, 7)
        {
            
        }

        public override object Puzzle1(AOCInput input)
        {
            string[] rules = input.GetInputLines();

            Dictionary<string, Dictionary<string, int>> bags = new Dictionary<string, Dictionary<string, int>>();

            foreach(string rule in rules)
            {
                string[] splitRule = rule.Split(new string[] { "bags contain", "bags", "bag", ",", "."}, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> contains = new Dictionary<string, int>();


                if (!rule.Contains("no other bags."))
                {
                    for (int i = 1; i < splitRule.Length; ++i)
                    {
                        int amount = int.Parse(splitRule[i].Trim().Split(' ')[0]);
                        string name = splitRule[i].Trim().Remove(0, 1 + amount.ToString().Length);

                        contains.Add(name, amount);
                    }
                }

                bags.Add(splitRule[0].Trim(), contains);
            }

            return bags.Keys.Count(x => Contains(bags, x));
        }

        public override object Puzzle2(AOCInput input)
        {
            string[] rules = input.GetInputLines();

            Dictionary<string, Dictionary<string, int>> bags = new Dictionary<string, Dictionary<string, int>>();

            foreach (string rule in rules)
            {
                string[] splitRule = rule.Split(new string[] { "bags contain", "bags", "bag", ",", "." }, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> contains = new Dictionary<string, int>();


                if (!rule.Contains("no other bags."))
                {
                    for (int i = 1; i < splitRule.Length; ++i)
                    {
                        int amount = int.Parse(splitRule[i].Trim().Split(' ')[0]);
                        string name = splitRule[i].Trim().Remove(0, 1 + amount.ToString().Length);

                        contains.Add(name, amount);
                    }
                }

                bags.Add(splitRule[0].Trim(), contains);
            }

            return Count(bags, "shiny gold");
        }

        private bool Contains(Dictionary<string, Dictionary<string, int>> bags, string color)
        {
            return bags[color].ContainsKey("shiny gold") || bags[color].Keys.Any(x => Contains(bags, x));
        }

        private int Count(Dictionary<string, Dictionary<string, int>> bags, string color)
        {
            return bags[color].Sum(x => x.Value * (Count(bags, x.Key) + 1));
        }
    }
}
