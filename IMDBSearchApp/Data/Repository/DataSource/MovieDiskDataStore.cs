using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using IMDBSearchApp.Data.Cache;
using IMDBSearchApp.Data.Entity;

namespace IMDBSearchApp.Data.Repository.DataSource
{
    public class MovieDiskDataStore : IMovieDataStore
    {
        public IObservable<MovieEntity> GetMovieById(string imdbId)
        {
            return Observable.Create<MovieEntity>((emitter) => 
            {

                var movie = MovieCache.mainCache.GetMovieById(imdbId);
                emitter.OnNext(movie);
                emitter.OnCompleted();
                return () => { };
            });
        }

        public IObservable<List<MovieSummaryEntity>> searchMoviesByKeyword(string keyword)
        {
            return Observable.Create<List<MovieSummaryEntity>>((emitter) =>
            {
                var results = MovieCache.mainCache.GetMoviesSummaryByKeyword(keyword);

                emitter.OnNext(results);
                emitter.OnCompleted();

                return () => { };
            });
        }
    }
}
