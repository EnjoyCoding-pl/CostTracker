using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Commands.Cost.Create;
using CostTracker.Core.Models;
using CostTracker.Core.Queries.Cost.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CostDTO>>> GetAll([FromQuery] string partId)
        {
            var dtos = await _mediator.Send(new GetAllCostsQuery { PartExternalId = partId });

            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] string partId, [FromForm] CostDTO cost, IFormFile invoice)
        {
            await _mediator.Send(new CreateCostCommand
            {
                Amount = cost.Amount,
                Name = cost.Name,
                VatRate = cost.VatRate,
                PartExternalId = partId,
                File = invoice.OpenReadStream(),
                FileName = Path.GetInvalidFileNameChars().Aggregate(invoice.FileName, (currentFileName, invalidCharacter) => currentFileName.Replace(invalidCharacter.ToString(), ""))
            });

            return Ok();
        }
    }
}