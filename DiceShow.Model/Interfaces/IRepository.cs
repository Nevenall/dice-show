using System.Threading.Tasks;

namespace DiceShow.Model {

	public interface IRepository {

		/*
		repo dev notes

		so, we can look at how we want to actually use the repo, 
		and sync that up with how db storage actually works. 

		how we want to use it
		most of what we will do is load a dice log 
		and display things about it, like the name and the records associatd with it that have resulted in a roll
		those that fail to parse we don't generallty show. 
		
		So, once we have retrieved the initial records, we only store 
		the updated rolls will actually come through a different channel. that's important to remember,

		*/
		string CurrentRepository { get; }

		Task<bool> IsNameAvailableAsync(string logName);

		Task<DiceLog> GetAysnc(string logName);
		Task<Record> GetAysnc(string logName, int id);

		void StoreAysnc(DiceLog log);
		void StoreAysnc(string logName, Record record);
	}

}