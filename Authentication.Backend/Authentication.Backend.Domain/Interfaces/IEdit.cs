using Authentication.Backend.Domain.Referentials;

namespace Authentication.Backend.Domain.Interfaces
{
    public interface IEdit<TEntity, TEntityID>
    {
        /// <summary>
        /// The Edit entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityID"></param>
        /// <returns>
        /// TransactionResponse<TEntity>
        /// </returns>
        TransactionResponse<TEntity> Edit(TEntity entity, TEntityID entityID);
    }
}
