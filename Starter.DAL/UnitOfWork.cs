using Starter.Contracts;
using Starter.Contracts.Repository;
using Starter.DAL.Repositories;
using Starter.Entities;
using System.Threading.Tasks;

namespace Starter.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SQLDBContext _repoContext;

        private IAttributeRepository _attributes;
        private IAttributeDataTypeRepository _attributeDataTypes;
        private IEntityRepository _entities;
        private IIntentRepository _intents;
        private ILanguageRepository _languages;
        private ISampleRepository _samples;
        private ITemplateRepository _templates;

        public IAttributeRepository Attributes
        {
            get
            {
                return _attributes ?? (_attributes = new AttributeRepository(_repoContext));
            }
        }

        public IAttributeDataTypeRepository AttributeDataTypes
        {
            get
            {
                return _attributeDataTypes ?? (_attributeDataTypes = new AttributeDataTypeRepository(_repoContext));
            }
        }

        public IEntityRepository Entities
        {
            get
            {
                return _entities ?? (_entities = new EntityRepository(_repoContext));
            }
        }

        public IIntentRepository Intents
        {
            get
            {
                return _intents ?? (_intents = new IntentRepository(_repoContext));
            }
        }

        public ILanguageRepository Languages
        {
            get
            {
                return _languages ?? (_languages = new LanguageRepository(_repoContext));
            }
        }

        public ISampleRepository Samples
        {
            get
            {
                return _samples ?? (_samples = new SampleRepository(_repoContext));
            }
        }

        public ITemplateRepository Templates
        {
            get
            {
                return _templates ?? (_templates = new TemplateRepository(_repoContext));
            }
        }



        public UnitOfWork(SQLDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Commit()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
