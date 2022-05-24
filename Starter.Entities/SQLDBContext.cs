using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Starter.Entities
{
    public class SQLDBContext : DbContext
    {
        private readonly IConfiguration configuration;

        public SQLDBContext([NotNullAttribute] DbContextOptions options, IConfiguration configuration) 
            : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("SqlServer"));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Intent> Intents { get; set; }

        public DbSet<TemplateCulturalName> TemplateCulturalNames { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<AttributeConfiguration> AttributeConfigurations { get; set; }

        public DbSet<Entity> Entities { get; set; }

        public DbSet<EntityValue> EntityValues { get; set; }

        public DbSet<EntityCulturalName> EntityCulturalName { get; set; }

        public DbSet<Sample> Samples { get; set; }

        public DbSet<SampleLabel> SampleLabels { get; set; }

        public DbSet<AttributeDataType> AttributeDataTypes { get; set; }
    }
}
