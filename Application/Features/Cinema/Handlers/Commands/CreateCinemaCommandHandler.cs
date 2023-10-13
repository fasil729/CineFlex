using AutoMapper;
using FluentValidation;
using Application.DTOs.Cinema;
using Application.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using Application.Persistence.Contracts;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Cinemas.Handlers.Commands
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

            var validator = new CreateCinemaCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var cinema = _mapper.Map<Cinema>(request.CreateCinemaDto);
            cinema = await _cinemaRepository.Add(cinema);

            response.Success = true;
            response.Message = "Cinema created successfully";
            response.Id = cinema.Id;

            return response;
        }
    }

    public class CreateCinemaCommandValidator : AbstractValidator<CreateCinemaCommand>
    {
        public CreateCinemaCommandValidator()
        {
            RuleFor(command => command.CreateCinemaDto.Name).NotEmpty().MaximumLength(100);
            RuleFor(command => command.CreateCinemaDto.Location).NotEmpty().MaximumLength(100);
            // Add additional validation rules as per your requirements
        }
    }
}