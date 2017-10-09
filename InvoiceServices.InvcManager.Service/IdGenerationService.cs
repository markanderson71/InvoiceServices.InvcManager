using InvoiceServices.InvcManager.Core.Services;
using Microsoft.Extensions.Logging;
using System;

namespace InvoiceServices.InvcManager.Service
{
    public class IdGenerationService : IIdGeneratorService
    {
        private ILogger logger;

        public IdGenerationService(ILogger<IdGenerationService> logger)
        {
            logger.LogInformation("IdGenerationService Initialized.");
            this.logger = logger;
        }

        public string GetNewId()
        {
            logger.LogInformation("GetNewId Started");

            string id = Guid.NewGuid().ToString();
           
            logger.LogDebug($"New id {0} created.");

            return id;
        }
    }
}
