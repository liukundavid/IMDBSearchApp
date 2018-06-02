using System;
using System.Collections.Generic;
using IMDBSearchApp.Data.Entity;

namespace IMDBSearchApp.Data.Net
{
    public interface IIMDBRestApi
    {
        IObservable<List<MovieSummaryEntity>> searchMoviesByKeyword(string keyword);

        IObservable<MovieEntity> GetMovieById(string imdbId);
    }
}
