namespace DiceShow.Models
{

    public class Dice
    {


        public string Id { get; set; } = string.Empty;
        public int Number { get; set; }

        public int Sides { get; set; }


        public override string ToString()
        {
            return $"{Id} {Number}d{Sides}";
        }


    }




}