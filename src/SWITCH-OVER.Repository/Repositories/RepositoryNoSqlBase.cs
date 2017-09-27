using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SWITCH_OVER.Shared.Entities;
using SWITCH_OVER.Shared.Repository;

namespace SWITCH_OVER.Repository.Repositories
{
	public class RepositoryNoSqlBase<TDocument, TIdentity> : IRepositoryNoSqlBase<TDocument, TIdentity> where TDocument : Document<TIdentity>
	{
		private readonly MongoClient _client;
		private readonly IMongoDatabase _database;
		private readonly IMongoCollection<TDocument> _collection;

		public RepositoryNoSqlBase(string dataBaseName, string collectionName)
		{
			_client = new MongoClient();
			_database = _client.GetDatabase(dataBaseName);
			_collection = _database.GetCollection<TDocument>(collectionName);
		}

		public async Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> predicate)
		{
			IEnumerable<TDocument> documents = new List<TDocument>();

			using (var cursor = await _collection.FindAsync<TDocument>(predicate))
			{
				while (await cursor.MoveNextAsync())
				{
					documents = cursor.Current;
				}
			}

			return documents;
		}

		public async Task Insert(TDocument document)
		{
			await _collection.InsertOneAsync(document);
		}

		public async Task<IEnumerable<TDocument>> InsertManyAsync(IEnumerable<TDocument> documents)
		{
			await _collection.InsertManyAsync(documents);
			return await FindAsync(f => documents.Select(s => s.Id).Contains(f.Id));
		}

		public async Task UpdateAsync(TDocument document)
		{
			var filterDefinition = Builders<TDocument>.Filter.Eq(f => f.Id, document.Id);
			await _collection.ReplaceOneAsync(filterDefinition, document);
		}

		public async Task RemoveAsync(TIdentity identity)
		{
			await _collection.DeleteOneAsync(new BsonDocument { { "_id", new ObjectId(identity.ToString()) } });
		}
	}
}