using AutoMapper;
using FluentValidation;
using Application.DTOs.Movie;
using Application.DTOs.Cinema;
using Application.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using Application.Contracts;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Cinema.Validators;

namespace Application.Features.Cinemas.Handlers.Commands
{
    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public CreateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateCinemaDTOValidator();
            var validationResult = await validator.ValidateAsync(request.createCinemaDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var cinema = _mapper.Map<Cinema>(request);
            cinema = await _cinemaRepository.Add(cinema);

            response.Success = true;
            response.Message = "Cinema created successfully";
            response.Id = cinema.Id;

            return response;
        }
    }
}