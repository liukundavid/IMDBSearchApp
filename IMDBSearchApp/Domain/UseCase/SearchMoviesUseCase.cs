using System;
using System.Collections.Generic;
using IMDBSearchApp.Data.Repository;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Domain.Repository;

namespace IMDBSearchApp.Domain.UseCase
{
    public class SearchMoviesUseCase : BaseUseCase<List<MovieSummary>, string>
    {
        IMovieRepository repository = new MovieRepository();

        public override IObservable<List<MovieSummary>> CreateUseCaseObservable(string keyword)
        {
            return repository.searchMoviesByKeyword(keyword);
        }
    }
}
