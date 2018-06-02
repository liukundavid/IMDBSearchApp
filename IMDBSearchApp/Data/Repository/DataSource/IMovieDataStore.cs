using System;
using System.Collections.Generic;
using IMDBSearchApp.Data.Entity;

namespace IMDBSearchApp.Data.Repository.DataSource
{
    public interface IMovieDataStore
    {
        IObservable<List<MovieSummaryEntity>> searchMoviesByKeyword(string keyword);

        IObservable<MovieEntity> GetMovieById(string imdbId);
    }
}
