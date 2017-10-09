using InvoiceServices.InvcManager.Core;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;
using InvoiceServices.InvcManager.Core.Model;

namespace InvoiceServices.InvcManager.Data
{
    public class DataSource:IRepository
    {
         private MongoClient client;
         private IMongoDatabase database;
        private readonly ILogger logger;

        public IMongoCollection<Invoice> invoiceCollection { get; }

         public DataSource(DatabaseSettings dbSettings,ILogger<DataSource> logger)
         {


             this.client = new MongoClient(dbSettings.ConnectionString);
             this.database = client.GetDatabase(dbSettings.DatabaseName);
             this.invoiceCollection = database.GetCollection<Invoice>("Invoices");
             this.logger = logger;

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

        public async Task<bool> AddInvoice(Invoice newInvoice)
        {
            logger.LogInformation("Adding");

            try
            {
                newInvoice.CreatedOn = DateTime.UtcNow;

                await invoiceCollection.InsertOneAsync(newInvoice);
                await Task.Delay(5000);
                logger.LogInformation("After Delay");
            }
            catch(MongoWriteException wre)
            {
                throw new ArgumentOutOfRangeException( ($"InvoiceId value {0} is a duplicate of an existing key: " +  newInvoice.Id), wre);
            }

            
            return true;
        }

        public bool IsAvailable()
        {
            var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "dbstats", 1 }, { "scale", 1 } });

            var result = database.RunCommand<BsonDocument>(command);

            return true;
        }

        public async Task<Invoice> GetInvoice(string id)
        {
            logger.LogInformation("GetInvoice ");
            Invoice invoice = await invoiceCollection.FindAsync<Invoice>(f => f.Id == id).Result.FirstOrDefaultAsync<Invoice>();

            return invoice;


        }
    }
}
