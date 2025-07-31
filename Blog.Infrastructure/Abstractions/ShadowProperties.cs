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
                if (entity.FindProperty("CreatedDate") == null)
                    entity.AddProperty("CreatedDate", typeof(DateTime));

                if (entity.FindProperty("UpdatedDate") == null)
                    entity.AddProperty("UpdatedDate", typeof(DateTime));

                if (entity.FindProperty("DeletedDate") == null)
                    entity.AddProperty("DeletedDate", typeof(DateTime?));
            }
        }

    }
}

