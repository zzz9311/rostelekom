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
            RandomNumberProvider randomNumberProvider = new RandomNumberProvider(new ConsolePrinter());
            CompareResultOutput result = new CompareResultOutput();
            int maxNumberLength = 4;
            var number = randomNumberProvider.GetRandomUniqueNumber(maxNumberLength);
            int userNumberResult;
            int attempts = 5;

            while (attempts > 0)
            {
                Console.WriteLine($"Введите число длинной {maxNumberLength} символа");

                while (!int.TryParse(Console.ReadLine(), out userNumberResult)/* || userResult.ToString().Length != numberLength*/)
                {
                    Console.WriteLine($"Введите число длинной {maxNumberLength}");
                }

                attempts -= 1;

                result = randomNumberProvider.CompareNumbers(userNumberResult, number);

                randomNumberProvider.PrintResult(result);

                if (result.CompareResult == CompareResultCode.Equals)
                {
                    Console.WriteLine("Вы победили");
                    break;
                }
            }

            if (attempts == 0 && result.CompareResult != CompareResultCode.Equals)
            {
                Console.WriteLine("Вы проиграли");
            }
            Console.ReadLine();
        }
    }
}
