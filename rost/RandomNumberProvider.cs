using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rost
{
    class RandomNumberProvider
    {
        public static int GetRandomUniqueNumber(int numberLength)
        {
            if (numberLength > 9)
            {
                throw new Exception("Cant create number with unique numerals");
            }

            if (numberLength < 1)
            {
                return 0;
            }

            Random rnd = new Random();
            List<int> numerals = Enumerable.Range(0, 9).ToList();


            numerals.Sort((x, y) => rnd.Next(-1, 1));

            var number = string.Join("", numerals.Take(numberLength));

            while (number.StartsWith("0"))//0123 = 123
            {
                numerals.Sort((x, y) => rnd.Next(-1, 1));
                number = string.Join("", numerals.Take(numberLength));
            }

            return Convert.ToInt32(string.Join("", numerals.Take(numberLength))); 
        }

        public static void PrintResult(CompareResult result)
        {
            foreach(var el in result.ListResult)
            {
                Console.WriteLine(el);
            }
        }

        public static CompareResult CompareNumbers(int userNumber, int number)
        {
            int numberLength = number.ToString().Length;
            if (userNumber == number)
            {
                return new CompareResult()
                {
                    Result = CompareResultCode.Equals,
                    ListResult = Enumerable.Repeat("BULL", numberLength).ToList()
                };
            }

            List<string> resultList = new List<string>();
            string userNumberString = userNumber.ToString();
            string numberString = number.ToString();

            for (int i = 0; i < numberString.Length; i++) //будет неправильный результат если пользователь введет не уникальное число
            {
                for (int j = 0; j < userNumberString.Length; j++)
                {
                    if (numberString[i] == userNumberString[j])
                    {
                        if(i==j)
                        {
                            resultList.Add("BULL");
                        }
                        else
                        {
                            resultList.Add("COW");
                        }
                        continue;
                    }
                }
            }

            return new CompareResult() { ListResult = resultList, Result = CompareResultCode.NotEquals };
        }

        public sealed class CompareResult
        {
            public CompareResultCode Result { get; set; } = CompareResultCode.NotEquals;
            public List<string> ListResult = new List<string>();
        }
    }
}
