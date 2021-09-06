﻿

using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.Core

{
    public class DbClient : IDBClient
    {
        private readonly IMongoCollection<Book> _books; 
        public DbClient(IOptions<BookStoreDBConfig> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstoreDbConfig.Value.Books_Collection_Name);

        }
        public IMongoCollection<Book> GetBookCollection() => _books;
      
    }
}
