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

        public override string ToString()
        {
            if (this.Description != null)
            {
                return $"{this.Description} : {string.Join(", ", from d in this.Dice select d)}";
            }
            else
            {
                return $"{string.Join(", ", from d in this.Dice select d)}";
            }
        }

    }

}