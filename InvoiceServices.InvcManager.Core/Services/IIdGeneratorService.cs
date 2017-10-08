using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceServices.InvcManager.Core.Services
{
    public interface IIdGeneratorService
    {
        string GetNewId();
    }
}
