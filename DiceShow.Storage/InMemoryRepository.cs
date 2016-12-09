namespace DiceShow.Storage {

	using System.Collections.Generic;
	using DiceShow.Model;
	using System.Linq;
	using System.Threading.Tasks;

	public class InMemoryRepository : IRepository {

		Dictionary<string, DiceLog> _logs = new Dictionary<string, DiceLog>();

		Dictionary<string, Dictionary<int, Record>> _records = new Dictionary<string, Dictionary<int, Record>>();


		public InMemoryRepository(string repositoryName) {
			CurrentRepository = repositoryName;
		}


		public string CurrentRepository { get; private set; }


		public async Task<bool> IsNameAvailableAsync(string logName) {
			return await Task.FromResult(!_logs.ContainsKey(logName));
		}


		public async Task<DiceLog> GetAsync(string logName) {
			var ret = default(DiceLog);
			_logs.TryGetValue(logName, out ret);
			return await Task.FromResult(ret);
		}

		public async Task<Record> GetAsync(string logName, int id) {
			var ret = default(Record);
			var records = default(Dictionary<int, Record>);
			if(_records.TryGetValue(logName, out records)) {
				records.TryGetValue(id, out ret);
			}
			return await Task.FromResult(ret);
		}

		public void Store(DiceLog log) {
			_logs.Add(log.Name, log);
			_records.Add(log.Name, new Dictionary<int, Record>< Record > ());

		}
		public void Store(string logName, Record record) {
			_records[logName].Add(record);

		}



	}
}