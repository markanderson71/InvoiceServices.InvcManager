using InvoiceServices.InvcManager.Core;
using InvoiceServices.InvcManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceServices.InvcManager.Core.Model;

namespace InvoiceServices.InvcManager
{
    public class AutoMapperConfigurationProfile:Profile
    {
        public AutoMapperConfigurationProfile()
        {
            CreateMap<string, string>().ConvertUsing(new NullStringConverter());
            CreateMap<Invoice, InvoiceViewModel>();
            CreateMap<InvoiceViewModel, Invoice>();
            
        }

        public class NullStringConverter : ITypeConverter<string, string>
        {

            public string Convert(string source, string destination, ResolutionContext context)
            {
                if (String.IsNullOrEmpty(source))
                {
                    return String.Empty;
                }
                else
                {
                    return source;
                }


            }
        }

    }
}
