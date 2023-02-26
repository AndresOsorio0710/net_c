namespace Authentication.Backend.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity, TEntityID>:
        IAdd<TEntity>, IDelete<TEntity, TEntityID>, IEdit<TEntity, TEntityID>, IGet<TEntity, TEntityID>, ITransaction
    {
    }
}
