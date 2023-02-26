using Authentication.Backend.Domain.Referentials;

namespace Authentication.Backend.Domain.Interfaces
{
    public interface IDelete<TEntity, TEntityID>
    {
        /// <summary>
        /// The Delete entity
        /// </summary>
        /// <param name="entityID"></param>
        /// <returns>
        /// TransactionResponse<TEntity>
        /// </returns>
        TransactionResponse<TEntity> Delete(TEntityID entityID);
    }
}
