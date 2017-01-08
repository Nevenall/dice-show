
namespace DiceShow.Storage
{
	using System;
	using System.Linq;
	using Microsoft.Extensions.Configuration;
	using Newtonsoft.Json;
	using Flurl.Http;
	using Flurl;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Text.Encodings.Web;
	using DiceShow.Storage.Models;

	public class Console
	{

		public static void WriteLine(object message, System.ConsoleColor color = ConsoleColor.White)
		{
			System.Console.ForegroundColor = color;
			System.Console.WriteLine(message);
			System.Console.ResetColor();
		}
	}





	public class Program
	{



		public static void Main(string[] args)
		{
			MainAsync(args).Wait();
		}

		private static async Task MainAsync(string[] args)
		{
			try
			{
				var config = new ConfigurationBuilder()
									 .AddEnvironmentVariables("diceshow_")
									 .Build();

				var connection = config["storage_connection"];

				// now we can parse things and use flurl to create and query docs? that's the plan. 

				// The trick is that we can't have meta data about collections right?
				// collections are just containers.
				//see if we need to tweak the default http server settings to allow for more rapid connection action

				// Structure --> AccountEndpoint={uri};AccountKey={key}
				var endpoint = connection.Split(';')[0].Split('=')[1];
				var key = connection.Split(';')[1].Split(new char[] { '=' }, count: 2)[1];

				Console.WriteLine($"Connecting to Storage using endpoint='{endpoint}' and key='{key}'", ConsoleColor.Green);



				// var result = await endpoint.GetDatabasesAsync(key);
				// Console.WriteLine(JsonConvert.SerializeObject(result), ConsoleColor.Cyan);

				// var db = await endpoint.GetDatabaseAsync(key, "nondb");
				// Console.WriteLine(JsonConvert.SerializeObject(db), ConsoleColor.Cyan);




				// var db = await endpoint.CreateDatabaseAsync(key, id: "testdb")
				// .ReceiveString();

				// Console.WriteLine(db, ConsoleColor.Cyan);

				await Task.Yield();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex, ConsoleColor.Red);
			}
			finally
			{
				Console.WriteLine("<Enter> to Quit");
				System.Console.ReadLine();
			}
		}


	}
}
