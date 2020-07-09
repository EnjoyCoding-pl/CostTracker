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
    /// <summary>
    /// Building controller
    /// </summary>
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Mediator instance</param>
        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get building by id
        /// </summary>
        /// <param name="id">Building id</param>
        /// <returns>Building object with notes and parts</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDetailDTO>> Get(string id)
        {
            var dto = await _mediator.Send(new GetBuildingByIdQuery { ExternalId = id });

            return Ok(dto);
        }

        /// <summary>
        /// Get list of all buildings
        /// </summary>
        /// <returns>List of all building</returns>
        [HttpGet]
        public async Task<ActionResult<List<BuildingDTO>>> GetAll()
        {
            var dtos = await _mediator.Send(new GetAllBuildingsQuery());

            return Ok(dtos);
        }

        /// <summary>
        /// Add new building
        /// </summary>
        /// <param name="building">Building object</param>
        /// <returns>Http status</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BuildingDTO building)
        {
            await _mediator.Send(new CreateBuildingCommand
            {
                Name = building.Name,
                Budget = building.Budget
            });

            return Ok();
        }

        /// <summary>
        /// Update existing building
        /// </summary>
        /// <param name="id">Building id from url</param>
        /// <param name="building">New building data</param>
        /// <returns>Http status</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromQuery] string id, [FromBody] BuildingDTO building)
        {
            await _mediator.Send(new UpdateBuildingCommand
            {
                BuildingExternalId = id,
                Name = building.Name,
                Budget = building.Budget
            });

            return Ok();
        }

        /// <summary>
        /// Delete building
        /// </summary>
        /// <param name="id">Building id from url</param>
        /// <returns>Http status</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteBuildingCommand { BuildingExternalId = id });

            return Ok();
        }
    }
}