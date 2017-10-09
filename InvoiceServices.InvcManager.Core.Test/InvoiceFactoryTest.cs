using System;
using Xunit;
using InvoiceServices.InvcManager.Core.Services;
using InvoiceServices.InvcManager.Core.Model;
using Moq;

namespace InvoiceServices.InvcManager.Core.Test
{
    public class InvoiceFactoryTest
    {
        [Fact]
        public void CreateInvoiceReturnsNotNullInvoice()
        {

            Mock<IIdGeneratorService> moqIdGenService = new Mock<IIdGeneratorService>();
            moqIdGenService.Setup(s => s.GetNewId()).Returns(new Guid().ToString());

            Mock<IInvoiceDateService> moqInvoiceDateService = new Mock<IInvoiceDateService>();
            DateTime expectedDate = DateTime.Now;
            moqInvoiceDateService.Setup(s => s.GetDateTime()).Returns(expectedDate);

            InvoiceFactory invFactory = new InvoiceFactory(moqIdGenService.Object, moqInvoiceDateService.Object, null);

            Invoice Actualinvoice = invFactory.CreateInvoice();

            Assert.NotNull(Actualinvoice);
        }

        [Fact]
        public void InvoiceFactoryReturnsInvoiceId()
        {
            Mock<IIdGeneratorService> moqIdGenService = new Mock<IIdGeneratorService>();
            moqIdGenService.Setup(s => s.GetNewId()).Returns(new Guid().ToString());

            Mock<IInvoiceDateService> moqInvoiceDateService = new Mock<IInvoiceDateService>();
            DateTime expectedDate = DateTime.Now;
            moqInvoiceDateService.Setup(s => s.GetDateTime()).Returns(expectedDate);

            InvoiceFactory invFactory = new InvoiceFactory(moqIdGenService.Object, moqInvoiceDateService.Object, null);

            Invoice actualinvoice = invFactory.CreateInvoice();

            Assert.Equal(false, String.IsNullOrEmpty(actualinvoice.Id));
        }

        [Fact]
        public void InvoiceFactoryDateTime()
        {
            Mock<IIdGeneratorService> moqIdGenService = new Mock<IIdGeneratorService>();
            moqIdGenService.Setup(s => s.GetNewId()).Returns(new Guid().ToString());

            Mock<IInvoiceDateService> moqInvoiceDateService = new Mock<IInvoiceDateService>();
            DateTime expectedDate = DateTime.Now;
            moqInvoiceDateService.Setup(s => s.GetDateTime()).Returns(expectedDate);

            InvoiceFactory invFactory = new InvoiceFactory(moqIdGenService.Object, moqInvoiceDateService.Object, null);

            Invoice actualinvoice = invFactory.CreateInvoice();

            Assert.Equal(true, DateTime.Equals(expectedDate, actualinvoice.Date));
        }




    }
}