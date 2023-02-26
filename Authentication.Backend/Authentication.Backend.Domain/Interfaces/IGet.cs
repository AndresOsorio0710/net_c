using Authentication.Backend.Domain.Referentials;

namespace Authentication.Backend.Domain.Interfaces
{
    public interface IGet<TEntity, TEntityID>
    {
        /// <summary>
        /// The Get entity
        /// </summary>
        /// <param name="entityID"></param>
        /// <returns>
        /// TransactionResponse<TEntity>
        /// </returns>
        TransactionResponse<TEntity> Get(TEntityID entityID);

        /// <summary>
        /// The Get All entity
        /// </summary>
        /// <returns>
        /// TransactionResponse<TEntity>
        /// </returns>
        TransactionResponse<TEntity> GetAll();
    }
}
