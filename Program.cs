using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp21
{
    internal class Program
    {
        static int lowerLimit = 2;
        static int upperLimit = 100;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите нижнее значение:");
            string lowerInput = Console.ReadLine();
            Console.WriteLine("Введите верхнее значение:");
            string upperInput = Console.ReadLine();

            lowerLimit = Convert.ToInt32(lowerInput);
            upperLimit = Convert.ToInt32(upperInput);

            if (lowerLimit <= 0 || upperLimit <= 0)
            {
                lowerLimit = 2;
                upperLimit = 100;
            }

            Thread Prime_Thread = new Thread(() => GeneratePrimes(lowerLimit, upperLimit))
            {
                Name = "PrimeNumberGenerator",
                Priority = ThreadPriority.Normal
            };
            Prime_Thread.Start();

            Thread Fib_Thread = new Thread(() => GenerateFibonacci(upperLimit))
            {
                Name = "FibonacciGenerator",
                Priority = ThreadPriority.Normal
            };
            Fib_Thread.Start();
        }

        static void GeneratePrimes(int low_lim, int up_lim)
        {
            Console.WriteLine($"Генерация простых чисел от {low_lim} до {up_lim}.");
            for (int num = low_lim; num <= up_lim; num++)
            {
                if (IsPrime(num))
                {
                    Console.WriteLine($"Простое число: {num}");
                }
            }
            Console.WriteLine("Генерация простых чисел завершена.");
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) 
            {
                return false;
            }
                
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void GenerateFibonacci(int up_lim)
        {
            int a = 0, b = 1;
            Console.WriteLine("Генерация чисел Фибоначчи.");
            while (a <= up_lim)
            {
                Console.WriteLine($"Число Фибоначчи: {a}");
                int next = a + b;
                a = b;
                b = next;
            }
            Console.WriteLine("Генерация чисел Фибоначчи завершена.");
        }
    }
} 