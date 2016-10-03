using System;
using System.IO;
using Antlr4.Runtime;
using Microsoft.AspNetCore.Hosting;
using DiceShow.Parsing;

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

                            if (parsed.Exception != null)
                            {
                                Console.WriteLine($"There was an exception parsing -- {parsed.Exception}");
                            }
                            else if (parsed.Error != null)
                            {
                                Console.WriteLine($"There was an error parsing -- {parsed.Error}");
                            }
                            else
                            {
                                Console.WriteLine($"Parsed Roll -- {parsed.Roll}");
                                var executer = new Executer(new RandomRoller());
                                var executed = executer.Execute(parsed.Roll);
                                if (executed.Exception != null)
                                {
                                    Console.WriteLine($"There was an exception executing -- {executed.Exception}");
                                }
                                else if (executed.Error != null)
                                {
                                    Console.WriteLine($"There was an error executing -- {executed.Error}");
                                }
                                else
                                {
                                    Console.WriteLine($"Executed Roll -- {executed.Result}");
                                }
                            }
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
