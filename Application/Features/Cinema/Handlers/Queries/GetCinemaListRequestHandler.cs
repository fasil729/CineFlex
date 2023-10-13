using AutoMapper;
using Application.DTOs.Cinema;
using Application.Features.Cinemas.Requests.Queries;
using Application.Contracts;
using Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Queries
{
    public class GetCinemaListQueryHandler : IRequestHandler<GetCinemaListQuery, IList<CinemaDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public GetCinemaListQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<IList<CinemaDTO>> Handle(GetCinemaListQuery request, CancellationToken cancellationToken)
        {
            var cinemas = await _cinemaRepository.GetList();
            var cinemaDTOs = _mapper.Map<IList<CinemaDTO>>(cinemas);

            return cinemaDTOs;
        }
    }
}