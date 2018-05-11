using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    static string profilePath;
    static string cssString = @"@-moz-document url(about:newtab)
{
    .activity - stream {
        background - color: #333333 !important;
    }
    .top - sites - list.top - site - outer > a {
        color: #dddddd !important;
    }
    .tile {
        filter: grayscale(42 %) !important;
        opacity: .9 !important;
    }
    @media(min - width: 1280px)
    {
        .activity - stream main {
            width: 989px !important;
        }
    }
    .tabbrowser - tabbox {
        background - color: #000000 !important; 
    }
}";
    static void Main(string[] args)
    {
        Console.WriteLine("Install dark theme into Firefox new tab? y/n");
        char.TryParse(Console.ReadLine(), out char c);
        if (c == 'y')
        {
            string roaming = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Mozilla\Firefox\Profiles");
            if (Directory.Exists(roaming))
            {
                Console.WriteLine("Looking for Firefox profiles folder. Installing under default profile:");
                ICollection profilesList = Directory.EnumerateDirectories(roaming).Where(s => s.Contains("default")).ToArray();
                if (profilesList.Count > 0 && profilesList.Count < 2)
                {
                    foreach (string o in profilesList)
                    {
                        Console.WriteLine(o);
                        profilePath = o;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No singular default profile found. Do you use Firefox Quantum? Or perhaps you need to launch Firefox. Either way, I can't find anything.");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Writing file to profile.");
                if (!File.Exists(profilePath + @"\chrome\userContent.css"))
                {
                    File.WriteAllText(profilePath + @"\chrome\userContent.css", cssString);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Success. Restart Firefox to see changes take effect. Exiting in 3 seconds...");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("userContent.css already exists in your profile. Cancelling.");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    return;
                }

            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You declined. Please type 'y' (without the quotes) to install.");
            Console.ResetColor();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return;
        }
    }
}

