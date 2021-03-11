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
        static CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken ct = tokenSource.Token;
        
        
        // умножение
        static void Multiply()
        {
            while (true)
            {
                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Operation mul is cancelled");
                    return;
                }
                if (showMul)
                {
                    Console.WriteLine($"multiply = {value}");
                    showMul = false;
                }
                value *= 3;
                Thread.Sleep(3000);
            }
        }
        static async void MultiplyAsync()
        {
             await Task.Run(()=> Multiply());        
        }
        

        // сложение
        static void Sum()
        {
            while (true)
            {
                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Operation sum is cancelled");
                    return;
                }
                if (showSum)
                {
                    Console.WriteLine($"sum = {value}");
                    showSum = false;
                }
                value += 2;
                Thread.Sleep(2000);
            }
        }
        
        static async void SumAsync()
        {
            await Task.Run(()=> Sum());        
        }
        

        static void Main(string[] args)
        {
            SumAsync();
            MultiplyAsync();
            Console.WriteLine("Input command: show or stop");
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "show")
                {
                    showMul = true;
                    showSum = true;
                }
                else if (command == "stop")
                {
                    Console.WriteLine("ok stop");
                    tokenSource.Cancel();
                }
            }
        }
    }
}