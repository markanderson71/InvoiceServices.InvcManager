using System;
using System.Threading.Tasks;
using InvoiceServices.InvcManager.Core.Model;

namespace InvoiceServices.InvcManager.Core
{
    public interface  IRepository
    {
        bool IsAvailable();
        Task<bool> AddInvoice(Invoice newInvoice);
    }
}
