using System;
using IMDBSearchApp.Domain.Model;

namespace IMDBSearchApp.Data.Entity.Mapper
{
    public class MovieMapper : BaseMapper<Movie, MovieEntity>
    {
        public override Movie Transform(MovieEntity entity)
        {
            var movie = new Movie
            {
                imdbID = entity.imdbID,
                Title = entity.Title,
                Year = entity.Year,
                Type = entity.Type,
                Rated = entity.Rated,
                Released = entity.Released,
                Runtime = entity.Runtime,
                Genre = entity.Genre,
                Director = entity.Director,
                Actors = entity.Actors,
                Writer = entity.Writer,
                Poster = entity.Poster,
                Plot = entity.Plot,
                imdbRating = entity.imdbRating,
                Production = entity.Production,
                Website = entity.Website,
                Ratings = new RatingMapper().TransformList(entity.Ratings)
            };

            return movie;
        }
    }
}
