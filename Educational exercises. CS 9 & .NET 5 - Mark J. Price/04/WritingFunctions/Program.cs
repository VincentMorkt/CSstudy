// See https://aka.ms/new-console-template for more information
using static System.Console;
#nullable disable

namespace WritingFunction
{
    class Program
    {
        static void TimesTabel(byte number)
        // Принимает число 0-255
        // Отображает в консоли таблицу умножения 1-12 на принятое число
        {
            WriteLine($"This is the {number} times table");
            for (int row = 1; row <= 12; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
            WriteLine();
        }
        static void RunTimesTable()
        // Запрашивает в консоли ввод числа 0-255
        // Проверяет корректность ввода
        // Если ввод коректен вызывает функцию TimesTabel(byte number) и повторяется в цикле.
        // Иначе сообщает в консоль о некорректном вводе и завершается.
        {
            bool isNumber;
            do
            {
                Write("Enter a number between 0 and 255: ");

                isNumber = byte.TryParse(ReadLine(), out byte number);

                if (isNumber)
                {
                    TimesTabel(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        // Принимает decimal число и двубуквенный код региона
        // Определяет коэфициент НДР по коду региона
        // Возвращает число умноженное на соответсвующий НДС.
        {
            decimal rate = 0.0M;
            switch (twoLetterRegionCode)
            {
                case "CH": // Швейцария
                    rate = 0.08M;
                    break;
                case "DK":
                case "NO":
                    rate = 0.25M;
                    break;
                case "GB":
                case "FR":
                    rate = 0.2M;
                    break;
                case "HU":
                    rate = 0.27M;
                    break;
                case "OR":
                case "AK":
                case "MT":
                    rate = 0.0M;
                    break;
                case "ND":
                case "WI":
                case "ME":
                case "VA":
                    rate = 0.05M;
                    break;
                case "CA":
                    rate = 0.0825M;
                    break;
                default:
                    rate = 0.06M;
                    break;
            }
            return amount * rate;
        }
        static void RunCalculateTax()
        // Запрашивает в консоли ввод числа и двубуквенного кода региона
        // Выводит в консоль сумму налога, полученную из функции CalculateTax(decimal amount, string twoLetterRegionCode)
        // Или сообщает о неправильном вводе числа
        // в случае неправильного кода региона будет применен default: rate = 0.06M;
        {
            Write("Enter an amount: ");
            string amountInText = ReadLine();

            Write("Enter a two-letter region code: ");
            string region = ReadLine();

            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine($"You did not enter a valid amount!");
            }
        }

        /// <summary>
        /// Передайте 32-битное целое число, и оно будет преобразовано в его порядковый эквивалент.
        /// </summary>
        /// <param name="number">Число — это кардинальное значение, например 1, 2, 3 и т. д.</param>
        /// <returns>Число как порядковое значение, например 1-й, 2-й, 3-й и т. д.</returns>
        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    int lastDigit = number % 10;

                    string suffix = lastDigit switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "td",
                        _ => "th"
                    };
                    return $"{number}{suffix}";
            }
        }
        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
            WriteLine();
        }

        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                checked
                {
                    return number * Factorial(number - 1);
                }
            }
        }
        static void RunFactorial()
        {
            while (true)
            {
                Write("Enter a number to find its factorial: ");
                string input = ReadLine();

                if (!int.TryParse(input, out int number))
                {
                    WriteLine("Error: You enter a invalid input.");
                    break;
                }
                for (int i = 1; i <= number; i++)
                {
                    try
                    {
                        WriteLine($"{i}! = {Factorial(i):N0}");
                    }
                    catch (OverflowException)
                    {
                        WriteLine($"{i}! is too big for a 32-bit integer.");
                    }
                }
            }
        }
        /// <summary>
        /// Императивная функция для поиска числа фибоначи с опередлённым порядковым номером
        /// </summary>
        /// <param name="term">Порядковый номер искомого числа фибоначи</param>
        /// <returns>Число фибоначи, соответствующее порядковому номеру</returns>
        static int FibImperative(int term)
        {
            if (term == 1)
            {
                return 0;
            }
            else if (term == 2)
            {
                return 1;
            }
            else
            {
                return FibImperative(term - 1) + FibImperative(term - 2);
            }
        }
        static void RunFibImperative()
        {
            for (int i = 1; i <= 30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
                arg0: CardinalToOrdinal(i),
                arg1: FibImperative(term: i));
            }
        }

        /// <summary>
        /// Декларативная функция для поиска числа фибоначи с опередлённым порядковым номером
        /// </summary>
        /// <param name="term">Порядковый номер искомого числа фибоначи</param>
        /// <returns>Число фибоначи, соответствующее порядковому номеру</returns>
        static int FibFunctional(int term) =>
        term switch
        {
            1 => 0,
            2 => 1,
            _ => FibFunctional(term - 1) + FibFunctional(term - 2)
        };
        static void RunFibFunctional()
        {
            for (int i = 1; i <= 30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
                arg0: CardinalToOrdinal(i),
                arg1: FibFunctional(term: i));
            }
        }
        static void Main(string[] args)
        {
            // RunTimesTable();
            // RunCalculateTax();
            // RunCardinalToOrdinal();
            // RunFactorial();
            // RunFibImperative();
            RunFibFunctional();
        }
    }
}