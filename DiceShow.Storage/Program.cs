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

                System.Console.WriteLine(JsonConvert.SerializeObject(config.AsEnumerable(), Formatting.Indented));


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
