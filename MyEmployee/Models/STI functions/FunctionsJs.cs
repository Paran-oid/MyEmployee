using System.Numerics;

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

        public BigInteger Factoriel(string arg)
        {
            var temp = BigInteger.Parse(arg);
            BigInteger res = 1;
            for(BigInteger i =2; i<=temp; i++)
            {
                res *= i;
            }
            return res;
        }
        public BigInteger Puissance(string value1, string value2)
        {
            var val1 = int.Parse(value1);
            var val2 = int.Parse(value2);

            if ( val2 == 0)
            {
                return 1;
            }

            for(int i = 1; i<val2; i++)
            {
                val1 *= val1;
            }
            return val1;

        }
        
        public BigInteger PPCM(string value1, string value2)
        {
            var val1 = int.Parse(value1);
            var val2 = int.Parse(value2);

            var ans = val1;

            while(val1 % val2 != 0)
            {
                val1 = val1 + ans;
            }

            return val1;
        }

        public BigInteger PGCD(string value1, string value2)
        {
            var val1 = int.Parse(value1);
            var val2 = int.Parse(value2);

            var P = val1;

            while(val1!=val2)
            {
                if(val1 > val2)
                {
                    val1 = val1 - val2;
                    P = val1;
                }
                else if(val2>val1)
                {
                    val2 = val2 - val1;
                    P = val2;
                }
            }      
            return P;
        }

        public string CB (string value)
        {
            try
            {
                long val = int.Parse(value);
                string binary = Convert.ToString(val, 2);

                return binary;
            }
            catch (OverflowException ex)
            {
                return "Integer Overflow";
            }
            catch (Exception e)
            {
                return "Undefined";
            }
        }

        public string CH (string value)
        {
            try
            {
                long val = int.Parse(value);
                string hexa = Convert.ToString(val, 16);
                return hexa;

            }
            catch (OverflowException ex)
            {
                return "Integer Overflow";
            }
            catch (Exception e)
            {
                return "Undefined";
            }

        }

        public string CBH (string value)
        {
            try
            {
                long dec = Convert.ToInt64(value, 2);
                string hexa = Convert.ToString(dec, 16);
                return hexa;
            }
            catch (OverflowException ex)
            {
                return "Integer Overflow";
            }
            catch (Exception e)
            {
                return "Undefined";
            }
        }
    }
}

