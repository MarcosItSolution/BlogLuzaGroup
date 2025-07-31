using Microsoft.EntityFrameworkCore;

namespace Blog.External.Infrastructures.Persistences.Abstractions
{
    public static class ConvectionDataType
    {
        public static void Apply(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?))) property.SetColumnType("decimal(18,4)");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(float) || p.ClrType == typeof(float?))) property.SetColumnType("real");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(double) || p.ClrType == typeof(double?))) property.SetColumnType("float");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(byte) || p.ClrType == typeof(byte?))) property.SetColumnType("tynint");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(bool) || p.ClrType == typeof(bool?))) property.SetColumnType("boolean");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
             .SelectMany(t => t.GetProperties())
             .Where(p => p.ClrType == typeof(long) || p.ClrType == typeof(long?))) property.SetColumnType("bigint");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
             .SelectMany(t => t.GetProperties())
             .Where(p => p.ClrType == typeof(int) || p.ClrType == typeof(int?))) property.SetColumnType("int");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(short) || p.ClrType == typeof(short?))) property.SetColumnType("smallint");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(string))) property.SetColumnType("varchar");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
             .SelectMany(t => t.GetProperties())
             .Where(p => p.ClrType == typeof(byte[]))) property.SetColumnType("varbinary");

             foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))) property.SetColumnType("timestamptz");
        }
    }
}

