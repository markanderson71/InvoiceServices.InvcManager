using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceServices.InvcManager.Core.Model
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

        public string CustomerId { get; set; }
        
        public List<LineItem> LineItem { get; set; }

        public DateTime CreatedOn { get; set; }
        


    }
}
