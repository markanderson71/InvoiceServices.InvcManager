using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceServices.InvcManager.ViewModel
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel()
        {

        }
        public string Id { get;  set; }

        public DateTime Date { get;  set; }

        public string CustomerId { get; set; }

        //public List<LineItem> LineItem { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
