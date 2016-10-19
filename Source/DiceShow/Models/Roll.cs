using System.Collections.ObjectModel;
using System.Linq;

namespace DiceShow.Models
{

    public class Roll
    {

        public Roll()
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