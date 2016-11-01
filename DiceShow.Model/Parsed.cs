


namespace DiceShow.Model
{
    using System;
    using System.Collections.Generic;

    
    public class Parsed
    {
        public string ParseTree { get; set; }
        public Statement Statement { get; set; }
        public IEnumerable<ParseError> Errors { get; set; }
        public Exception Exception { get; set; }
    }
}