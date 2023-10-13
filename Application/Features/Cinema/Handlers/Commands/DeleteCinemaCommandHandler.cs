using AutoMapper;
using Application.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using Application.Contracts;
using Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Commands
{
    public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public DeleteCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var cinema = await _cinemaRepository.GetDetail(request.Id);
            if (cinema == null)
            {
                throw new NotFoundException("Cinema", request.Id);
            }

            await _cinemaRepository.Delete(cinema);

            response.Success = true;
            response.Message = "Cinema deleted successfully";

            return response;
        }
    }
}