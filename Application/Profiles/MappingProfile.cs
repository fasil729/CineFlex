using AutoMapper;
using Application.DTOs.Movie;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Cinema;

namespace MovieAPI.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Cinema, CreateCinemaDTO>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaDTO>().ReverseMap();
            CreateMap<Cinema, CinemaDTO>().ReverseMap();
        }
    }
}