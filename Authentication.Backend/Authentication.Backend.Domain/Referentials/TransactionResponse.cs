namespace Authentication.Backend.Domain.Referentials
{
    public class TransactionResponse<TEntity>
    {
        /// <summary>
        /// Get or Set, result transaction
        /// </summary>
        /// <value>
        /// ResultTransaction, ResponseStructure
        /// </value>
        public Response ResultTransaction { get; set; }

        /// <summary>
        /// Get or Set, authorization
        /// </summary>
        /// <value>
        /// Authorization, AuthorizationToken
        /// </value>
        public AuthorizationToken Authorization { get; set; }

        /// <summary>
        /// Get or Set, result data
        /// </summary>
        public ICollection<TEntity> ResultData;
    }
}
