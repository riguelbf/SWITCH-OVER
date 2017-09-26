using MongoDB.Driver;
using SWITCH_OVER.Shared.Events;
using SWITCH_OVER.Shared.Repository;

namespace SWITCH_OVER.Repository.Repositories
{
	public class RepositoryNoSqlBase<TDocument> : IRepositoryNoSqlBase<TDocument> where TDocument : Event
	{
		private readonly MongoClient _client;
		private readonly IMongoDatabase _database;
		private readonly IMongoCollection<TDocument> _collection;

		public RepositoryNoSqlBase(string collectionName)
		{
			_client = new MongoClient();
			_database = _client.GetDatabase("demoDb");
			_collection = _database.GetCollection<TDocument>(collectionName);
		}



	}
}