using Starter.Contracts.Repository;
using System.Threading.Tasks;

namespace Starter.Contracts
{
    public interface IUnitOfWork
    {
        IAttributeRepository Attributes { get; }
        IAttributeDataTypeRepository AttributeDataTypes { get; }
        IEntityRepository Entities { get; }
        IIntentRepository Intents { get; }
        ILanguageRepository Languages { get; }
        ISampleRepository Samples { get; }
        ITemplateRepository Templates { get; }
        Task Commit();
    }
}
