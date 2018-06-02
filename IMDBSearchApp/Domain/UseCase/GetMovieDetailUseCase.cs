using System;
using IMDBSearchApp.Data.Repository;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Domain.Repository;

namespace IMDBSearchApp.Domain.UseCase
{
    public class GetMovieDetailUseCase : BaseUseCase<Movie, string>
    {
        IMovieRepository repository = new MovieRepository();

        public override IObservable<Movie> CreateUseCaseObservable(string imdbId)
        {
            return repository.GetMovieById(imdbId);
        }
    }
}
