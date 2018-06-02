using System;
using System.Collections.Generic;

namespace IMDBSearchApp.Data.Entity.Mapper
{
    public abstract class BaseMapper<Model, Entity>
    {
        public abstract Model Transform(Entity entity);

        public List<Model> TransformList(IList<Entity> entities)
        {
            var results = new List<Model>();
            foreach (var entity in entities)
            {
                results.Add(Transform(entity));
            }
            return results;
        }
    }
}
