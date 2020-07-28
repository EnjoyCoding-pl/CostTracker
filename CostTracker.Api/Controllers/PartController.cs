using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Commands.Part.Create;
using CostTracker.Core.Commands.Part.Delete;
using CostTracker.Core.Commands.Part.Update;
using CostTracker.Core.Models;
using CostTracker.Core.Queries.Part.GetAll;
using CostTracker.Core.Queries.Part.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostTracker.Api.Controllers
{
    [Route("api/buildings/{buildingId}/parts")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartDetailDTO>> Get([FromRoute] string id)
        {
            var dto = await _mediator.Send(new GetPartByIdQuery { PartExternalId = id });

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<PartDTO>>> GetAll([FromRoute] string buildingId)
        {
            var dtos = await _mediator.Send(new GetAllPartsQuery { BuildingExternalId = buildingId });

            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] string buildingId, [FromBody] PartDTO request)
        {
            await _mediator.Send(new CreatePartCommand
            {
                BuildingExternalId = buildingId,
                Name = request.Name,
                Budget = request.Budget,
                EndDate = request.EndDate,
                StartDate = request.StartDate
            });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] PartDTO request)
        {
            await _mediator.Send(new UpdatePartCommand
            {
                EndDate = request.EndDate,
                Budget = request.Budget,
                Name = request.Name,
                PartExternalId = id,
                StartDate = request.StartDate
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _mediator.Send(new DeletePartCommand { PartExternalId = id });

            return Ok();
        }
    }
}