using AutoMapper;
using FluentValidation;
using MovieAPI.Application.DTOs.Cinema;
using MovieAPI.Application.Exceptions;
using MovieAPI.Application.Features.Cinemas.Requests.Queries;
using MovieAPI.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Cinemas.Handlers.Queries
{
    public class GetCinemaDetailQueryHandler : IRequestHandler<GetCinemaDetailQuery, CinemaDto>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public GetCinemaDetailQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<CinemaDto> Handle(GetCinemaDetailQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCinemaDetailQueryValidator();
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

            var cinemaDto = _mapper.Map<CinemaDto>(cinema);

            return cinemaDto;
        }
    }

    public class GetCinemaDetailQueryValidator : AbstractValidator<GetCinemaDetailQuery>
    {
        public GetCinemaDetailQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}