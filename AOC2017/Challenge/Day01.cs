using System.Collections.Generic;
using System.Linq;

namespace AOC2017.Challenge
{
    public class Day01
    {
      

        public int SolveCaptcha(string input, bool computeStep)
        {
            var charList = input.ToCharArray();
            var list = new List<int>();

            charList.ToList().ForEach(e => list.Add(int.Parse(e.ToString())));
            var sum = 0;
            int step = computeStep ? list.Count / 2 : 1;
            var nextIndex = step;
            for (int i = 0; i < list.Count; i++)
            {
                nextIndex = i + step;
                nextIndex = (nextIndex % list.Count);
                if (list[i] == list[nextIndex])
                {
                    sum += list[i];
                }
            }

            return sum;
        }

    }
}