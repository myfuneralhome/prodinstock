﻿using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Queries;
using BTech.Prodinstock.Products.Domain.UseCases;
using BTech.Prodinstock.Products.Domain.UseCases.Invoices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceCreation _invoiceCreation;
        private readonly InvoiceFileGenerator _invoiceFileGenerator;
        private readonly InvoiceValidation _invoiceValidation;
        private readonly IQueryHandler<ListInvoices, ExistingInvoice[]> _listInvoices;

        public InvoicesController(
            InvoiceCreation invoiceCreation,
            InvoiceFileGenerator invoiceFileGenerator,
            InvoiceValidation invoiceValidating,
            IQueryHandler<ListInvoices, ExistingInvoice[]> listInvoices)
        {
            _invoiceCreation = invoiceCreation;
            _invoiceFileGenerator = invoiceFileGenerator;
            _invoiceValidation = invoiceValidating;
            _listInvoices = listInvoices;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Required] NewInvoice newInvoice)
        {
            var commandResult = await _invoiceCreation.ExecuteAsync(newInvoice);

            if (commandResult.IsFullSuccess())
            {
                return Ok();
            }
            else
            {
                return BadRequest(commandResult.Errors);
            }
        }

        [HttpPost("{invoiceId}/validate")]
        public async Task<IActionResult> Validate(
            [Required] string invoiceId)
        {
            var commandResult = await _invoiceValidation.ValidateAsync(invoiceId);

            if (commandResult.IsFullSuccess())
            {
                return Ok();
            }
            else
            {
                return BadRequest(commandResult.Errors);
            }
        }

        [HttpGet("{invoiceId}/document")]
        public async Task<IActionResult> GetDocument(
            [Required] string invoiceId)
        {
            var memoryStream = new MemoryStream();
            
            if (await _invoiceFileGenerator.TryGetAsync(invoiceId, memoryStream))
            {
                memoryStream.Position = 0;
                return File(memoryStream, "application/pdf", invoiceId + ".pdf");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ExistingInvoice[]> List()
        {
            return await _listInvoices.HandleAsync(new ListInvoices());
        }
    }
}
