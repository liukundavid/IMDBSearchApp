using System;
using System.Reactive.Linq;
using System.Collections.Generic;
using IMDBSearchApp.Data.Cache;
using IMDBSearchApp.Data.Entity;

namespace IMDBSearchApp.Data.Net
{
    public class IMDBRestApiClient : IIMDBRestApi
    {
        Serializer<SearchResultEntity> searchResultSerializer = new Serializer<SearchResultEntity>();
        Serializer<MovieEntity> movieSerializer = new Serializer<MovieEntity>();

        public IObservable<MovieEntity> GetMovieById(string imdbId)
        {
            return Observable.Create<MovieEntity>((emitter) =>
            {
                var json = GetMovieDetail(imdbId);

                if(!String.IsNullOrEmpty(json))
                {
                    var movie = movieSerializer.FromJson(json);
                    MovieCache.mainCache.Put(movie);
                    emitter.OnNext(movie);
                    emitter.OnCompleted();
                }
                else
                {
                    emitter.OnError(new Exception("The movie was not found"));
                }

                return () => { };
            });
        }

        public IObservable<List<MovieSummaryEntity>> searchMoviesByKeyword(string keyword)
        {
            return Observable.Create<List<MovieSummaryEntity>>((emitter) =>
            {
                var json = GetSearchResults(keyword);

                if(!String.IsNullOrEmpty(json))
                {
                    var results = searchResultSerializer.FromJson(json).SearchResults;
                    MovieCache.mainCache.PutAll(results);
                    emitter.OnNext(results);
                    emitter.OnCompleted();
                }
                else
                {
                    emitter.OnError(new Exception("Movies were not found"));
                }

                return () => { };
            });
        }

        private string GetSearchResults(string keyword)
        {
            var url = IMDBApiConnection.HostUrl + "&s=" + keyword;
            return IMDBApiConnection.DoGet(url).Result;
        }

        private string GetMovieDetail(string imdbId)
        {
            var url = IMDBApiConnection.HostUrl + "&i=" + imdbId;
            return IMDBApiConnection.DoGet(url).Result;
        }
    }
}
