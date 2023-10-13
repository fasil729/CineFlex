using AutoMapper;
using FluentValidation;
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

            var validator = new UpdateCinemaDTOValidator();
            var validationResult = await validator.ValidateAsync(request.updateCinemaDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var cinema = await _cinemaRepository.GetDetail(request.updateCinemaDTO.CinemaId);
            if (cinema == null)
            {
                throw new NotFoundException("Cinema", request.updateCinemaDTO.CinemaId);
            }

            _mapper.Map(request.updateCinemaDTO, cinema);
            await _cinemaRepository.Update(cinema);

            response.Success = true;
            response.Message = "Cinema updated successfully";
            response.Id = cinema.Id;

            return response;
        }
    }

   
    
}