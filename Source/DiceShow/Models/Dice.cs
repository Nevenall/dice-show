namespace DiceShow.Models
{

    public class Dice
    {

        public int Number { get; set; }

        public int Sides { get; set; }


        public override string ToString()
        {
            return $"{this.Number}d{this.Sides}";
        }


    }




}