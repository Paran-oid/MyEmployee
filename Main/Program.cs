namespace MyProgram
{
    class Program
    {
        static void Main(String[] args)
        {
            string[] strs = { "eat", "ate", "balls" };
            Console.WriteLine(Solution.GroupAnagrams(strs));
            Console.Read();
        }

    }
    public class Solution
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            SortedDictionary<char, int> Anagram(string item)
            {
                SortedDictionary<char, int> res = new SortedDictionary<char, int>();

                foreach (char ch in item)
                {
                    if (res.ContainsKey(ch))
                    {
                        res[ch]++;
                    }
                    else
                    {
                        res[ch] = 1;
                    }
                }
                return res;
            }

            if (strs.Length == 0)
            {
                return new List<IList<string>>();
            }

            List<List<string>> result = new List<List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j <= result.Count; j++)
                {
                    if (j != result.Count && Anagram(strs[i])==Anagram(result[j][0]))
                    {
                        result[j].Add(strs[i]);
                        break;
                    }
                    else if (j == result.Count)
                    {
                        result.Add(new List<string> { strs[i] });
                        break;
                    }
                }
            }
            return (IList<IList<string>>)result;
        }
    }


}