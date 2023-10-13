using AutoMapper;
using Application.Exceptions;
using Application.Features.Movies.Requests.Commands;
using Application.Contracts;
using Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var movie = await _movieRepository.GetDetail(request.Id);
            if (movie == null)
            {
                throw new NotFoundException("Movie", request.Id);
            }

            await _movieRepository.Delete(movie);

            response.Success = true;
            response.Message = "Movie deleted successfully";

            return response;
        }
    }
}