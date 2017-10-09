using System;
using System.Threading.Tasks;

namespace InvoiceServices.InvcManager.Core
{
    public interface  IRepository
    {
        bool IsAvailable();
        Task<bool> AddInvoice(Invoice newInvoice);
    }
}
