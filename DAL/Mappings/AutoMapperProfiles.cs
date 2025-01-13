using AutoMapper;
using DAL.Models.Domain;
using DAL.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Users
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            // PostalCode
            CreateMap<PostalCode, PostalCodeDto>().ReverseMap();

            // Genre
            CreateMap<Genre, GenreDto>().ReverseMap();

            // Movie
            CreateMap<AddMovieRequestDto, Movie>()
                 .ForMember(dest => dest.CinemaHall, opt => opt.Ignore()) // Ignorer CinemaHall navigation
                 .ForMember(dest => dest.Genres, opt => opt.Ignore()); // Ignorer Genres navigation

            // Mapping for Movie -> MovieDto
            CreateMap<Movie, MovieDto>();

            CreateMap<CinemaHall, CinemaHallDto>();
            CreateMap<AddCinemaHallDto, CinemaHall>();
        }
    }
}
