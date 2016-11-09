namespace DiceShow.Model
{


    ///<summary>
    /// A container for permanently recorded dice rolls. 
    ///</summary>
    public class DiceLog
    {
        ///<summary>
        /// A friendly name and identifier for the dice log. 
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// An optional password for accessing the dice log. 
        ///</summary>
        public string Password { get; set; }



    }
}