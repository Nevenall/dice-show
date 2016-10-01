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

        public string Description { get; set; }

        public Collection<Dice> Dice { get; set; }

        // Add some flags for how to determine the results
        // sum or separate



        public override string ToString()
        {
            return $"{this.Description} : {string.Join(", ", from d in this.Dice select d.ToString())}";
        }

    }

}