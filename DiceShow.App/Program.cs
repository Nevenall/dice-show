using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DiceShow.App
{
	public class Program
	{

		public static void Main(string[] args)
		{
			
			var host = new WebHostBuilder()
				 .UseContentRoot(Directory.GetCurrentDirectory())
				 .UseStartup<Startup>()
				 .UseIISIntegration()
				 .UseKestrel()
			  	 .Build();

			host.Run();
		}
	}
}
