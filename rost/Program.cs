using System;
using System.Collections.Generic;
using System.Linq;
using static rost.RandomNumberProvider;

namespace rost
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLength = 4;
            var number = RandomNumberProvider.GetRandomUniqueNumber(numberLength);
            int userResult;
            int attempts = 5;
            CompareResult result = new CompareResult();

            while (attempts > 0)
            {
                Console.WriteLine($"Введите число длинной {numberLength} символа");

                while (!int.TryParse(Console.ReadLine(), out userResult)/* || userResult.ToString().Length != numberLength*/) 
                {
                    Console.WriteLine($"Введите число длинной {numberLength}");
                }

                attempts -= 1;

                result = RandomNumberProvider.CompareNumbers(userResult, number);

                RandomNumberProvider.PrintResult(result);

                if(result.Result == CompareResultCode.Equals)
                {
                    Console.WriteLine("Вы победили");
                    break;
                }
            }

            if(attempts==0 && result.Result != CompareResultCode.Equals)
            {
                Console.WriteLine("Вы проиграли");
            }
            Console.ReadLine();
        }
    }
}
