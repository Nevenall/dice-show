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
                    } else  {
                        // to start with we echo your input
                        Console.WriteLine(rawInput);
                        
                        AntlrInputStream input = new AntlrInputStream(rawInput);
                        DiceLexer lexer = new DiceLexer(input);
                        CommonTokenStream tokens = new CommonTokenStream(lexer);
                        DiceParser parser = new DiceParser(tokens);



                        // DiceParser.CompilationUnitContext tree = parser.compilationUnit(); // parse a compilationUnit

                        // MyListener extractor = new MyListener(parser);
                        // ParseTreeWalker.DEFAULT.walk(extractor, tree); // initiate walk of tree with listener in use of default walker

                    }
                } while(true);
                
            }
        }
    }
}
