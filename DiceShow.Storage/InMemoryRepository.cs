namespace DiceShow.Storage
{

    using System.Collections.Generic;
    using DiceShow.Model;
    using System.Linq;

    public class InMemoryRepository : IRepository
    {

        Dictionary<string, DiceLog> _logs = new Dictionary<string, DiceLog>();

        Dictionary<string, List<Record>> _records = new Dictionary<string, List<Record>>();


        /// Store logs, and maybe store the records as a tuple? 

        public InMemoryRepository(string repositoryName)
        {
            CurrentRepository = repositoryName;
        }


        public string CurrentRepository { get; private set; }


        public bool IsNameAvailable(string logName)
        {

            return !_logs.ContainsKey(logName);

        }


        public DiceLog Get(string logName)
        {
            return _logs[logName];

        }

        public Record Get(string logName, int id)
        {
            return _records[logName].SingleOrDefault(el => el.Id == id);
        }

        public void Store(DiceLog log)
        {
            _logs.Add(log.Name, log);
            _records.Add(log.Name, new List<Record>());

        }
        public void Store(string logName, Record record)
        {
            _records[logName].Add(record);

        }



    }
}