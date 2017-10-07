using InvoiceServices.InvcManager.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace InvoiceServices.InvcManager.Data
{
    public class DataSource:IRepository
    {
         private MongoClient client;
         private IMongoDatabase database;

         //public IMongoCollection<LineItem> InvoiceCollection { get; }

         public DataSource(DatabaseSettings dbSettings)
         {


             this.client = new MongoClient(dbSettings.ConnectionString);
             this.database = client.GetDatabase(dbSettings.DatabaseName);
             //this.InvoiceCollection = database.GetCollection<LineItem>("LineItems");

           //  if (!BsonClassMap.IsClassMapRegistered(typeof(LineItem)))
           //  {
          //       SetSerializationForObjectId();
          //   }
         }

         private static void SetSerializationForObjectId()
         {
           //  BsonClassMap.RegisterClassMap<LineItem>(cm => { cm.AutoMap(); cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId)); });
             //BsonClassMap.RegisterClassMap<LineItem>(cm => { cm.AutoMap(); cm.UnmapMember(m => m.LineItemTotal); });
             // BsonClassMap.RegisterClassMap<Customer>(cm => { cm.AutoMap(); cm.IdMemberMap(new StringSerializer(BsonType.ObjectId)); });
         }

        public bool IsAvailable()
        {
            var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "dbstats", 1 }, { "scale", 1 } });

            var result = database.RunCommand<BsonDocument>(command);

            return true;
        }
    }
}
