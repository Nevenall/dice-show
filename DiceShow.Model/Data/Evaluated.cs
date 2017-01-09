using System;
using System.Collections.ObjectModel;

namespace DiceShow.Model
{

	public class Evaluated
	{
		public MyResult Result { get; set; }
		public Collection<string> TraceLog { get; set; } = new Collection<string>();
		public Exception Exception { get; set; }
	}

}