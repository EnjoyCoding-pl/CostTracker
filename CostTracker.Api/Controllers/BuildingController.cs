using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Commands.Building.Create;
using CostTracker.Core.Commands.Building.Delete;
using CostTracker.Core.Commands.Building.Update;
using CostTracker.Core.Models;
using CostTracker.Core.Queries.GetBuilding;
using CostTracker.Core.Queries.GetBuildings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostTracker.Api.Controllers
{
    [ApiController]
    [Route("api/buildings")]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDetailDTO>> Get([FromRoute] string id)
        {
            var dto = await _mediator.Send(new GetBuildingByIdQuery { ExternalId = id });

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<BuildingDTO>>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllBuildingsQuery());

            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BuildingDTO building)
        {
            await _mediator.Send(new CreateBuildingCommand
            {
                Name = building.Name
            });

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] BuildingDTO building)
        {
            await _mediator.Send(new UpdateBuildingCommand
            {
                BuildingExternalId = id,
                Name = building.Name
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _mediator.Send(new DeleteBuildingCommand { BuildingExternalId = id });

            return Ok();
        }
    }
}