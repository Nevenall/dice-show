using System;
using System.IO;
using Antlr4.Runtime;
using Microsoft.AspNetCore.Hosting;
using DiceShow.Parsing;

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
                    Console.Write("DiceShow> ");
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
                            
                            var tree = parser.roll();
                            var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
                            var listener = new DiceListener();
                            
                            walker.Walk(listener, tree);
									                             
                            if(tree.exception != null) {
							    throw tree.exception;
                            } else if(listener.Error != null) {
                                Console.WriteLine("there was a tree walking error. Symbol = {0} Line = {1} Column = {2}", listener.Error.Symbol.Text, listener.Error.Symbol.Line, listener.Error.Symbol.Column);
                            } else {
                                var executer = new Executer(new RandomRoller());
                                var result = executer.Execute(listener.Roll);
                                Console.WriteLine(result);
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
