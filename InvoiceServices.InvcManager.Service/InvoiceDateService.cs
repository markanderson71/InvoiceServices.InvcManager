using InvoiceServices.InvcManager.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceServices.InvcManager.Service
{
    public class InvoiceDateService:IInvoiceDateService
    {
        private readonly ILogger<InvoiceDateService> logger;

        public InvoiceDateService(ILogger<InvoiceDateService> logger)
        {
            logger.LogInformation("InvoiceDateService Initialized");
            this.logger = logger;
        }

        public DateTime GetDateTime()
        {
            logger.LogInformation("GetDateTimeRequested");

            DateTime dt = DateTime.UtcNow;

            logger.LogDebug("DateTime returned {0}",dt);
            logger.LogInformation("GetDateTime Complete");
            return dt;
        }
    }
}
