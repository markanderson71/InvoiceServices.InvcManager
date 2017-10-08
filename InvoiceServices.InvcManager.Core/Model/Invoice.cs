using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceServices.InvcManager.Core
{
    public class Invoice
    {
        public Invoice(string id, DateTime Date)
        {
            this.Id = id;
            this.Date = Date;
        }

        public string Id { get; private set; }

        public DateTime Date { get; private set; }


    }
}
