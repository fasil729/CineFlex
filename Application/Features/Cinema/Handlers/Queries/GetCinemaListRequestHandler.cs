using AutoMapper;
using MovieAPI.Application.DTOs.Cinema;
using MovieAPI.Application.Features.Cinemas.Requests.Queries;
using MovieAPI.Application.Persistence.Contracts;
using MovieAPI.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.Cinemas.Handlers.Queries
{
    public class GetCinemaListQueryHandler : IRequestHandler<GetCinemaListQuery, IList<CinemaDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public GetCinemaListQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<IList<CinemaDto>> Handle(GetCinemaListQuery request, CancellationToken cancellationToken)
        {
            var cinemas = await _cinemaRepository.GetAll();
            var cinemaDtos = _mapper.Map<IList<CinemaDto>>(cinemas);

            return cinemaDtos;
        }
    }
}