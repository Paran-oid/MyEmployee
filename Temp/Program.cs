namespace MyProgram
{
    class Program
    {
        static void Main(String[] args)
        {
            char[][] board = new char[][] {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };




            bool res = Solution.IsValidSudoku(board);
            Console.WriteLine(res);

            Console.Read();
        }
        public class Solution
        {
            public static bool IsValidSudoku(char[][] board)
            {
                bool Valid(char[] row, ref HashSet<char>? numbers)
                {
                    Dictionary<char, int> Dict = new Dictionary<char, int>();
                    foreach (char item in row)
                    {
                        if (item != '.')
                        {
                            if (!Dict.ContainsKey(item))
                            {
                                Dict[item] = 1;
                                if (!numbers.Contains(item))
                                {
                                    numbers.Add(item);
                                }
                                continue;
                            }
                            else
                            {
                                Dict[item]++;
                            }
                            if (Dict[item] > 1)
                            {
                                return false;
                            }
                            if (!numbers.Contains(item))
                            {
                                numbers.Add(item);
                            }
                        }
                    }
                    return true;
                }
                // INSERTING VARIABLES
                HashSet<char>? numbers = new HashSet<char>();

                //ROW CHECKING
                bool temp = true;

                for (int i = 0; i < 9; i++)
                {
                    temp = Valid(board[i], ref numbers);
                    if (temp == false)
                    {
                        return false;
                    }
                }

                //COLUMN CHECKING

                List<char> tempList = new List<char>();
                char[] tempArr;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        tempList.Add(board[j][i]);
                    }
                    tempArr = tempList.ToArray();
                    temp = Valid(tempArr, ref numbers);
                    if (temp == false)
                    {
                        return false;
                    }
                    tempList.Clear();
                }

                //BOX CHECK
                int k = 0;
                int l = 0;
                for (int time = 0; time < 3; time++)
                {
                    for (int i = l; i < 3+l; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            tempList.Add(board[i+l][j + k]);
                        }
                    }

                    tempArr = tempList.ToArray();
                    temp = Valid(tempArr, ref numbers);

                    if (temp == false)
                    {
                        return false;
                    }

                    tempList.Clear();

                    k += 3;
                    
                    if (k>6 && l<6)
                    {
                        l += 3;
                        k = 0;
                    }
                }
                bool containsAllDigits = true;
                for (char digit = '1'; digit <= '9'; digit++)
                {
                    if (!numbers.Contains(digit))
                    {
                        return false;
                    }
                }
                return temp;
            }
        }
    }
}