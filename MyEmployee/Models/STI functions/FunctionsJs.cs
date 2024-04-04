namespace MyEmployee.Models.STI_functions
{
    public class FunctionsJs
    {
        public bool Premier(string arg)
            {
                int temp = Convert.ToInt32(arg);
                for (int i = 2; i < temp; i++)
                {
                    if (temp % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        public bool Palindrome(string arg)
        {
            string temp = "";
            for(int i = arg.Length - 1; i>=0; i--)
            {
                temp += arg[i];
            }
            return (temp == arg);
        }

        public int Factoriel(string arg)
        {
            int temp = Convert.ToInt32(arg);
            int res = 1;
            for(int i=2; i<=temp; i++)
            {
                res *= i;
            }
            return res;
        }
        //ADD REST OF FUNCTIONS
    }
}

