using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InvoiceServices.InvcManager.Core.Model;

namespace InvoiceServices.InvcManager.Core
{
    public class InvoiceManager
    {
        private IRepository repository;
        private ILogger logger;

        public InvoiceManager(IRepository repository, DetailManager detailManager, ILogger<InvoiceManager> logger)
        {
            
            this.repository = repository;
            this.logger = logger;
            logger.LogInformation("Invoice Manager Initialized");

        }

        public async Task<bool> AddInvoice (Invoice newInvoice)
        {
            logger.LogInformation("Add Invoice");
                        
            Task invoiceAddTask = repository.AddInvoice(newInvoice);

            logger.LogInformation("DO SOMETHING ELSE");

            //DetailManager.AddDetails(newInvoice.LineItems);
            //Store the Items in the ItemDetails database
            await invoiceAddTask;

            return true;
        }


        public async Task<Invoice> GetInvoice(string id)
        {
            logger.LogInformation("GetInvoice");
            return await repository.GetInvoice(id);

        }
    }
}
