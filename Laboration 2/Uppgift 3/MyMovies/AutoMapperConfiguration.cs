using AutoMapper;
using MyMovies.Models;
using MyMovies.ViewModels;

namespace MyMovies
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigureCreateMovieViewModel();
            ConfigureDetailsMovieViewModel();
            ConfigureEditMovieViewModel();
            ConfigureIndexMovieViewModel();
            
            Mapper.AssertConfigurationIsValid();
        }
        
        private static void ConfigureCreateMovieViewModel()
        {
            Mapper.CreateMap<Movie, CreateMovieViewModel>()
                .ForMember(
                    movieViewModel => movieViewModel.SelectedGenreId,
                    options => options.MapFrom(movie => movie.GenreId))
                .ForMember(
                    movieViewModel => movieViewModel.Genre,
                    options => options.UseValue(GenreSelectListFactory.Create()));

            Mapper.CreateMap<CreateMovieViewModel, Movie>()
                .ForMember(
                    movie => movie.GenreId,
                    options => options.MapFrom(movieViewModel => movieViewModel.SelectedGenreId))
                .ForMember(
                    movie => movie.Genre,
                    options => options.Ignore());
        }

        private static void ConfigureDetailsMovieViewModel()
        {
            Mapper.CreateMap<Movie, DetailsMovieViewModel>()
                .ForMember(
                    movieViewModel => movieViewModel.Genre,
                    options => options.MapFrom(movie => movie.Genre.Name));
        }

        private static void ConfigureEditMovieViewModel()
        {
            Mapper.CreateMap<Movie, EditMovieViewModel>()
                .ForMember(
                    movieViewModel => movieViewModel.SelectedGenreId,
                    options => options.MapFrom(movie => movie.GenreId))
                .ForMember(
                    movieViewModel => movieViewModel.Genre,
                    options => options.UseValue(GenreSelectListFactory.Create()));
        }

        private static void ConfigureIndexMovieViewModel()
        {
            Mapper.CreateMap<Movie, IndexMovieViewModel>()
                .ForMember(
                    movieViewModel => movieViewModel.Genre,
                    options => options.MapFrom(movie => movie.Genre.Name));
        }
    }
}