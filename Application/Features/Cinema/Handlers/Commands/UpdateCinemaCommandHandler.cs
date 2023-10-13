using AutoMapper;
using FluentValidation;
using MovieAPI.Application.DTOs.Cinema;
using MovieAPI.Application.Exceptions;
using MovieAPI.Application.Features.Cinemas.Requests.Commands;
using MovieAPI.Application.Persistence.Contracts;
using MovieAPI.Application.Responses;
using MovieAPI.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Cinemas.Handlers.Commands
{
    public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public UpdateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateCinemaCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var cinema = await _cinemaRepository.GetById(request.Id);
            if (cinema == null)
            {
                throw new NotFoundException("Cinema", request.Id);
            }

            _mapper.Map(request.UpdateCinemaDto, cinema);
            await _cinemaRepository.Update(cinema);

            response.Success = true;
            response.Message = "Cinema updated successfully";
            response.Id = cinema.Id;

            return response;
        }
    }

    public class UpdateCinemaCommandValidator : AbstractValidator<UpdateCinemaCommand>
    {
        public UpdateCinemaCommandValidator()
        {
            RuleFor(command => command.UpdateCinemaDto.Name).NotEmpty().MaximumLength(100);
            RuleFor(command => command.UpdateCinemaDto.Location).NotEmpty().MaximumLength(100);
            // Add additional validation rules as per your requirements
        }
    }
}