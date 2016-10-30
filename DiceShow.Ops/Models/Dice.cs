namespace DiceShow.Ops.Models
{

    public class Dice
    {


        public string Id { get; set; }
        public int Number { get; set; }

        public int Sides { get; set; }


        public override string ToString()
        {
            return Id != null ? $"{Id} {Number}d{Sides}" : $"{Number}d{Sides}";
        }


    }




}