namespace DiceShow.Storage {

	using System.Collections.Generic;
	using DiceShow.Model;
	using System.Linq;
	using System.Threading.Tasks;
	using System;

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

		public async void StoreAsync(DiceLog log) {
			_logs.Add(log.Name, log);
			_records.Add(log.Name, new Dictionary<int, Record>());
			await Task.Yield();
		}
		public async void StoreAsync(string logName, Record record) {
			var records = default(Dictionary<int, Record>);
			if(_records.TryGetValue(logName, out records)) {
				records.Add(record.Id, record);
			}
			await Task.Yield();
		}

		public Task<DiceLog> GetAysnc(string logName) {
			return GetAsync(logName);
		}

		public Task<Record> GetAysnc(string logName, int id) {
			return GetAsync(logName, id);
		}

		public void StoreAysnc(DiceLog log) {
			StoreAsync(log);
		}

		public void StoreAysnc(string logName, Record record) {
			StoreAsync(logName, record);
		}
	}
}