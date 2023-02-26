using Authentication.Backend.Domain.Referentials;

namespace Authentication.Backend.Domain.Interfaces
{
    public interface IAdd<TEntity>
    {
        /// <summary>
        /// The Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// TransactionResponse<TEntity>
        /// </returns>
        TransactionResponse<TEntity> Add(TEntity entity);
    }
}
