using System.Collections.ObjectModel;
using System.Linq;

namespace DiceShow.Sys.Models
{

    public class Statement
    {

        public Statement()
        {
            Dice = new Collection<Dice>();
        }

        public Collection<Dice> Dice { get; set; }

        public override string ToString()
        {
            return $"{string.Join(", ", from d in Dice select d)}";
        }

    }

}