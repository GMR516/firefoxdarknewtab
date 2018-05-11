using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Install dark theme into Firefox new tab? y/n");
        char.TryParse(Console.ReadLine(), out char c);
        if (c == 'y')
        {
            string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Console.WriteLine(roaming);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("You declined. Please type 'y' (without the quotes) to install.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return;
        }
    }
}

