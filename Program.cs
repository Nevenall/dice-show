using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DiceStream {
    public class Program {
        public static void Main(string[] args) {

            if (args.Length == 0 || args[0].ToLower() == "web") {
                var host = new WebHostBuilder()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseKestrel()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();

            } else {
                /// make a parse repl
                do {
                    Console.Write("DiceStream> " );
                    var input = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(input) || input.ToLower() == "help") {
                        Console.WriteLine("enter a dice statement or 'quit' to exit");
                    } else if (input.ToLower() == "quit") {
                        break;
                    } else  {
                        // to start with we echo your input
                        Console.WriteLine(input);
                        
                    }
                } while(true);
                
            }
        }
    }
}
