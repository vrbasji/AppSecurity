using System;

namespace AppSecurity.ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var secureChecker = new SecurityChecker.SecurityChecker();
            Console.WriteLine(secureChecker.CanAppRun());
            Console.ReadKey();
        }
    }
}
