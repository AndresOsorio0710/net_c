using Authentication.Backend.Domain.Interfaces;

namespace Authentication.Backend.Aplications.Interfaces
{
    public interface IServiceBase<TEntity, TEntityID> :
        IAdd<TEntity>, IDelete<TEntity, TEntityID>, IEdit<TEntity, TEntityID>, IGet<TEntity, TEntityID>
    {
    }
}
