using System;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DiceShow
{
    public class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length == 0 || args[0].ToLower() == "web")
            {
                var host = new WebHostBuilder()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseKestrel()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();

            }
            else
            {
                /// make a parse repl
                do
                {
                    Console.Write("DiceShow> ");
                    var rawInput = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(rawInput) || rawInput.ToLower() == "help")
                    {
                        Console.WriteLine("enter a dice statement or 'quit' to exit");
                    }
                    else if (rawInput.ToLower() == "quit" || rawInput.ToLower() == "exit")
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            var parser = new Parser();
                            var parsed = parser.Parse(rawInput);

                            Console.WriteLine("-- Parsing -- ");
                            Console.WriteLine($"Tree -- {parsed.ParseTree}");
                            Console.WriteLine($"Exception -- {parsed.Exception}");
                            Console.WriteLine($"Errors -- {string.Join(", ", parsed.Errors)}");
                            Console.WriteLine($"Roll -- {parsed.Statement}");

                            var executer = new Executer(new RandomRoller());
                            var executed = executer.Evaluate(parsed.Statement);

                            Console.WriteLine("-- Executed --");
                            Console.WriteLine($"Exception -- {executed.Exception}");
                            Console.WriteLine($"Results -- {executed.Result}");

                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.ToString());
                            Console.ResetColor();
                        }
                    }
                } while (true);

            }
        }
    }
}
