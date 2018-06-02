using System;
using IMDBSearchApp.Domain.Model;

namespace IMDBSearchApp.Data.Entity.Mapper
{
    public class MovieSummaryMapper : BaseMapper<MovieSummary, MovieSummaryEntity>
    {
        public override MovieSummary Transform(MovieSummaryEntity entity)
        {
            var movieSummary = new MovieSummary
            {
                imdbID = entity.imdbID,
                Title = entity.Title,
                Year = entity.Year,
                Type = entity.Type,
                Poster = entity.Poster
            };

            return movieSummary;
        }
    }
}
