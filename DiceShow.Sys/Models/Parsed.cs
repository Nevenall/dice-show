

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DiceShow.Sys.Models
{
    public class Parsed
    {
        public string ParseTree { get; set; }
        public Statement Statement { get; set; }
        public IEnumerable<ParseError> Errors { get; set; }
        public Exception Exception { get; set; }
    }
}