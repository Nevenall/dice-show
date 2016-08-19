using System;
using System.IO;
using Antlr4.Runtime;
using Microsoft.AspNetCore.Hosting;

namespace DiceShow {
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
                    Console.Write("DiceStream> ");
                    var rawInput = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(rawInput) || rawInput.ToLower() == "help") {
                        Console.WriteLine("enter a dice statement or 'quit' to exit");
                    } else if (rawInput.ToLower() == "quit") {
                        break;
                    } else {
                        try {

                            AntlrInputStream input = new AntlrInputStream(rawInput);
                            DiceLexer lexer = new DiceLexer(input);
                            
                            CommonTokenStream tokens = new CommonTokenStream(lexer);
                            DiceParser parser = new DiceParser(tokens);
                            
                            var t = parser.statement();
                            var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
                            var l = new MyDiceListener();
                            
                            walker.Walk(l, t);
                            
                            if(t.exception != null) {
                            	  // there was a parsing exception
									     throw t.exception;
                            }

                            if(l.Error != null) {
                                /// there was an exception in walking the parse Tree
                                Console.WriteLine("there was a tree walking error. Symbol = {0} Line = {1} Column = {2}", l.Error.Symbol.Text, l.Error.Symbol.Line, l.Error.Symbol.Column);
                            }

                        } catch(Exception ex) {
                            Console.ForegroundColor  = ConsoleColor.Red;
                            Console.WriteLine(ex.ToString());
                            Console.ResetColor();
                        }
                    }
                } while(true);
                
            }
        }
    }
}
