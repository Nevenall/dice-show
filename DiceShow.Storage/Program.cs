using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DiceShow.Storage
{
    public class Program
    {


        public static void Main(string[] args)
        {
            try
            {
                var config = new ConfigurationBuilder()
                     .AddEnvironmentVariables("diceshow_")
                     .Build();

                var connection = config["storage_connection"];

                System.Console.WriteLine($"Connecting to Storage using '{connection}'");

                



            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
            finally
            {
                System.Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
}
