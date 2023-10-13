using Application.DTOs.Cinema;
using Application.Features.Cinemas.Requests.Commands;
using Application.Features.Cinemas.Requests.Queries;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CinemasController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        // GET: api/<CinemasController>
        [HttpGet]
        public async Task<ActionResult<Cinema>> Get()
        {
            var Cinemas = await _mediator.Send(new GetCinemaListQuery());
            return Ok(Cinemas);   
        }

        // GET api/<CinemasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> Get(int id)
        {
            var Cinema = await _mediator.Send(new GetCinemaDetailQuery { Id = id});
            return Ok(Cinema);
        }
        // Cinema api/<CinemasController>
        [HttpPost]
        public async Task<ActionResult> Cinema([FromBody] CreateCinemaDTO Cinema)
        {
            var command = new CreateCinemaCommand { createCinemaDTO = Cinema };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CinemasController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDTO Cinema)
        {
            var command = new UpdateCinemaCommand { updateCinemaDTO = Cinema };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CinemasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(CinemaDTO Cinema)
        {
            var command = new DeleteCinemaCommand { Id = Cinema.Id};
            await _mediator.Send(command);  
            return NoContent();
        }
    }

    
}