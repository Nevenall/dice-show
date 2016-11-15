namespace DiceShow.Model
{

    public interface IRepository
    {

        // I will have an observable of Rolls. Maybe statements, whatever the eventual  type that we store will be. 
        // there will be some changes because the stored type will contain the 

        // test a name for a new DiceLog 
        // Create a new DiceLog, with name and id
        // Get a DiceLog by id 
        // Get the rolls for a dice log. Rolls or statements? or requests? 
        // what do we can the whole structure of the user imput, the maybe parsed dice roll, and the results
        // and any errors that might have happened?
        // If we are making a dice log, then maybe the overarching entity is called an Entry? 
        // that's pretty logical. 
        // Entry, or LogEntry?  


        // create a dice log
        // Record id are strings or ints? 
        // we can use 
        // 

        string CurrentRepository { get;  }

        bool IsNameAvailable(string logName);
        
        DiceLog Get(string logName);
        Record Get(string logName, int id);


        void Store(DiceLog log);

        void Store(string logName, Record record);


    }

}