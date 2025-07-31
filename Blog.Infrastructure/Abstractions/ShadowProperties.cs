using Microsoft.EntityFrameworkCore;

namespace Blog.External.Infrastructures.Persistences.Abstractions
{
    public static class ShadowProperties
    {

        public static void Apply(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();

            foreach (var entity in allEntities)
            {
                entity.AddProperty("CreatedDate", typeof(DateTime));
                entity.AddProperty("UpdatedDate", typeof(DateTime));
                entity.AddProperty("DeletedDate", typeof(DateTime?));
            }
        }
    }
}

