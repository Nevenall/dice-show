

using System;
using System.Collections.Generic;

namespace DiceShow.Ops.Models
{
    public class Parsed
    {
        public string ParseTree { get; set; }
        public Statement Statement { get; set; }
        public IEnumerable<ParseError> Errors { get; set; }
        public Exception Exception { get; set; }
    }
}