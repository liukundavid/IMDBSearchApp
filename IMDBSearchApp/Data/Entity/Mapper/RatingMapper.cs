using System;
using IMDBSearchApp.Domain.Model;

namespace IMDBSearchApp.Data.Entity.Mapper
{
    public class RatingMapper : BaseMapper<Rating, RatingEntity>
    {
        public override Rating Transform(RatingEntity entity)
        {
            var rating = new Rating
            {
                RatingSource = entity.RatingSource,
                RatingValue = entity.RatingValue
            };
            return rating;
        }
    }
}
