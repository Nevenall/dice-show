
namespace DiceShow.Model
{
    using System.Linq;
    using System.Collections.ObjectModel;

    ///
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