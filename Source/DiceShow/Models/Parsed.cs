

using System;

namespace DiceShow.Models
{
    public class Parsed
    {
        public Roll Roll { get; set; }
        public ParseError Error { get; set; }

        public Exception Exception { get; set; }
    }
}