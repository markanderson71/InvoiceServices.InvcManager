using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InvoiceServices.InvcManager.ViewModel;
using InvoiceServices.InvcManager.Core.Services;
using InvoiceServices.InvcManager.Core;
using AutoMapper;
using InvoiceServices.InvcManager.Core.Model;

namespace InvoiceServices.InvcManager.Controllers
{
    [Produces("application/json")]
    [Route("api/Invoices")]
    public class InvoicesController : Controller
    {
        private InvoiceFactory invoicefactory;
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly ILoggerFactory loggerFactory;
        private ILogger logger;
        private InvoiceManager invoiceManager;

        public InvoicesController(InvoiceFactory invoicefactory, IRepository repository, IMapper mapper, ILoggerFactory loggerFactory, ILogger<InvoicesController> logger)
        {
            this.invoicefactory = invoicefactory;
            this.repository = repository;
            this.mapper = mapper;
            this.loggerFactory = loggerFactory;
            this.logger = logger;
            this.invoiceManager = new InvoiceManager(repository, null, loggerFactory.CreateLogger<InvoiceManager>());
        }

        public InvoiceFactory Invoicefactory { get; }

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody]InvoicePostModel invoicePost)
        {
            logger.LogInformation("AddInvoice");
            Invoice newInvoice = CreateInvoiceFromPost(invoicePost);

            try
            {
                await invoiceManager.AddInvoice(newInvoice);
                return CreatedAtRoute("GetInvoice", new { id = newInvoice.Id }, newInvoice.Id);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest();
            }
            //newInvoice = mapper.Map<Invoice>(invoicePost);
            logger.LogInformation("Did something else cool");
            //convert the from view model to model
            //Create and invoice 
            //AddInvoice
            //return the id           
            
            
        }

        private Invoice CreateInvoiceFromPost(InvoicePostModel invoicePost)
        {
            Invoice newInvoice = invoicefactory.CreateInvoice();
            newInvoice.CustomerId = invoicePost.CustomerId;
            return newInvoice;
        }

        [HttpGet("{id}", Name = "GetInvoice")]
        
        public IActionResult GetInvoice(string id)
        {
            logger.LogInformation("GetInvoice");

            // Invoice newInvoice = invoicefactory.CreateInvoice();


            //convert the from view model to model
            //Create and invoice 
            //AddInvoice
            //return the id

            return null; ;
        }
    }
}