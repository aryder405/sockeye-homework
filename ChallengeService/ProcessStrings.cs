using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeService
{
    public class ProcessStrings : IProcessStrings
    {
        public IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input)
        {
            var output = new List<List<string>>();

            // YOUR CODE GOES HERE
            var cleanedInput = input.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).Distinct().ToList();
            cleanedInput.Sort();

            var masterList = new HashSet<string>();

            foreach (var item in cleanedInput)
            {
                if (!masterList.Add(item))
                {
                    continue;
                }

                var results = new List<string>();
                results.Add(item);
                results.AddRange(cleanedInput.Where(x => x != item && IsAnagram(x, item)));
                results.ForEach(x => masterList.Add(x));

                output.Add(results);
            }

            return output;
        }

        private bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;

            s1 = s1.ToLower().Trim();
            s2 = s2.ToLower().Trim();

            if (s1.Length != s2.Length)
                return false;

            if (String.Concat(s1.OrderBy(c => c)).Equals(String.Concat(s2.OrderBy(c => c))))
                return true;

            return false;
        }
    }
}
