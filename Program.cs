using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bot = new bot();
            bot.RunAsync().GetAwaiter().GetResult();   

        }
    }
}
