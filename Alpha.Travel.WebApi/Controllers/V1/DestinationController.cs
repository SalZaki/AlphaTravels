﻿namespace Alpha.Travel.WebApi.Controllers.V1
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Application.Categories.Models;
    using Application.Destinations.Queries;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/xml", "application/json")]
    public class DestinationController : Controller
    {
        private readonly IMediator _mediator;

        public DestinationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [HttpGet("{destinationId:int}", Name = nameof(GetByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DestinationPreviewDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetDestinationPreviewQuery query, CancellationToken ct)
        {
            if (query == null || query.Id <= 0)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(query, ct);

            if (result == null)
            {
                return new NotFoundObjectResult("The destination you were requesting could not be found");
            }

            return Ok(result);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(string id, [FromBody]UpdateCustomerCommand command)
        //{
        //    if (command == null || command.Id != id)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(await Mediator.Send(command));
        //}
    }
}