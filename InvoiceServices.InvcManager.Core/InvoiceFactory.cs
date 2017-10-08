using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using InvoiceServices.InvcManager.Core.Services;

namespace InvoiceServices.InvcManager.Core
{
    public class InvoiceFactory
    {
       
        private ILogger<InvoiceFactory> logger;
        public IIdGeneratorService IdGeneratorService;
        private IInvoiceDateService invoiceDateService;

        public InvoiceFactory(IIdGeneratorService IdGeneratorService, IInvoiceDateService invoiceDateService, ILogger<InvoiceFactory> logger)
        {
            this.logger = logger;
            this.IdGeneratorService = IdGeneratorService;
            this.invoiceDateService = invoiceDateService;
        }

        public Invoice CreateInvoice()
        {
            Invoice invoice = new Invoice(GetId(),GetInvoiceDateTime());
            //set the date of the invoice
            return invoice;
        }

        private string GetId()
        {
            return IdGeneratorService.GetNewId();
        }


        private DateTime GetInvoiceDateTime()
        {
            return invoiceDateService.GetDateTime();
        }







    }
}
