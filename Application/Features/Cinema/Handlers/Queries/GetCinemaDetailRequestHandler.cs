using AutoMapper;
using FluentValidation;
using Application.DTOs.Cinema;
using Application.Exceptions;
using Application.Features.Cinemas.Requests.Queries;
using Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Queries
{
    public class GetCinemaDetailQueryHandler : IRequestHandler<GetCinemaDetailQuery, CinemaDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public GetCinemaDetailQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<CinemaDTO> Handle(GetCinemaDetailQuery request, CancellationToken cancellationToken)
        {
           

            var cinema = await _cinemaRepository.GetDetail(request.Id);
            if (cinema == null)
            {
                throw new NotFoundException("Cinema", request.Id);
            }

            var cinemaDTO = _mapper.Map<CinemaDTO>(cinema);

            return cinemaDTO;
        }
    }

   
}