using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Commands.Note.Create;
using CostTracker.Core.Commands.Note.Delete;
using CostTracker.Core.Commands.Note.Update;
using CostTracker.Core.Models;
using CostTracker.Core.Queries.Note.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteDTO>>> GetAll([FromQuery] string buildingId)
        {
            var dtos = await _mediator.Send(new GetAllNotesQuery { BuildingExternalId = buildingId });

            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] string buildingId, [FromBody] NoteDTO request)
        {
            await _mediator.Send(new CreateNoteCommand
            {
                BuildingExternalId = buildingId,
                Text = request.Text
            });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] NoteDTO request)
        {

            await _mediator.Send(new UpdateNoteCommand
            {
                NoteExternalId = id,
                Text = request.Text
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteNoteCommand { NoteExternalId = id });

            return Ok();
        }
    }
}