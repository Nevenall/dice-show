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
                    Console.Write("DiceStream> " );
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
                            
                            var tree = parser.statement();
                            var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
                            var listener = new MyDiceListener();
                            
                            walker.Walk(listener, tree);
									 
                            
                            if(tree.exception != null) {
                            // there was a parsing exception
							    throw tree.exception;
                            }

                            if(listener.Error != null) {
                                /// there was an exception in walking the parse Tree
                                Console.WriteLine("there was a tree walking error");
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
