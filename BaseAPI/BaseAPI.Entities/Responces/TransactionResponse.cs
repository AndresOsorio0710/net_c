using BaseAPI.Entities.Results;

namespace BaseAPI.Entities.Responces
{
    public class TransactionResponse<TEntity>
    {
        public ResultAuthorization ResultAuthorization { get; set; }
        public ICollection<TEntity> ResultData { get; set; }
        public ResultTransaction ResultTransaction { get; set; }
    }
}
