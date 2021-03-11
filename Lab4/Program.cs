using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        private static int value = 0;
        private static bool showMul = false;
        private static bool showSum = false;
        private static bool isRunning = true;
        
        
        
        // умножение
        static void Multiply()
        {
            while (isRunning)
            {
                if (showMul)
                {
                    Console.WriteLine($"multiply = {value}");
                    showMul = false;
                }
                value *= 3;
                Thread.Sleep(3000);
            }
        }
        static async Task MultiplyAsync()
        {
             await Task.Run(()=> Multiply());        
        }
        

        // сложение
        static void Sum()
        {
            while (isRunning)
            {
                if (showSum)
                {
                    Console.WriteLine($"sum = {value}");
                    showSum = false;
                }
                value += 2;
                Thread.Sleep(2000);
            }
        }
        
        static async Task SumAsync()
        {
            await Task.Run(()=> Sum());        
        }
        

        static async Task Main(string[] args)
        {
            Task sum = SumAsync();
            Task mul = MultiplyAsync();
            Console.WriteLine("Input command: show or stop");
            while (isRunning)
            {
                string command = Console.ReadLine();
                if (command == "show")
                {
                    showMul = true;
                    showSum = true;
                }
                else if (command == "stop")
                {
                    isRunning = false;
                    await sum;
                    await mul;
                }
            }
        }
    }
}