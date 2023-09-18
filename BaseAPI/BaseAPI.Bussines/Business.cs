using System.Collections.ObjectModel;
using BaseAPI.Entities.Enums;
using BaseAPI.Entities.Responces;
using BaseAPI.Entities.Results;

namespace BaseAPI.Business
{
	public class Business<TEntity>
	{
		protected TransactionResponse<TEntity> transactionResponse;
        public Business()
		{
			this.transactionResponse = new TransactionResponse<TEntity>
			{
				ResultTransaction = new ResultTransaction
				{ },
				ResultData = new Collection<TEntity>()
            };
		}

		public TransactionResponse<TEntity> TransactionOk()
        {
			this.transactionResponse.ResultTransaction.Code = ResponceCode.Ok;
			this.transactionResponse.ResultTransaction.Message = "Ok";
			return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionOk(string message)
        {
            this.transactionResponse.ResultTransaction.Code = ResponceCode.Ok;
            this.transactionResponse.ResultTransaction.Message = message;
            return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionOk(ResponceCode code, string message)
        {
            this.transactionResponse.ResultTransaction.Code = code;
            this.transactionResponse.ResultTransaction.Message = message;
            return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionOk(ResponceCode code, string message, Collection<TEntity> data)
        {
            this.transactionResponse.ResultTransaction.Code = code;
            this.transactionResponse.ResultTransaction.Message = message;
            this.transactionResponse.ResultData = data;
            return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionOk(Collection<TEntity> data)
        {
            this.transactionResponse.ResultTransaction.Code = ResponceCode.Ok;
            this.transactionResponse.ResultTransaction.Message = "Ok";
			this.transactionResponse.ResultData = data;
            return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionFail()
        {
            this.transactionResponse.ResultTransaction.Code = ResponceCode.InternalServerError;
            this.transactionResponse.ResultTransaction.Message = "";
            return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionFail(ResponceCode code)
        {
            this.transactionResponse.ResultTransaction.Code = code;
            this.transactionResponse.ResultTransaction.Message = "";
            return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionFail(string message)
        {
            this.transactionResponse.ResultTransaction.Code = ResponceCode.InternalServerError;
            this.transactionResponse.ResultTransaction.Message = message;
            return this.transactionResponse;
        }

        public TransactionResponse<TEntity> TransactionFail(ResponceCode code,string message)
        {
            this.transactionResponse.ResultTransaction.Code = code;
            this.transactionResponse.ResultTransaction.Message = message;
            return this.transactionResponse;
        }
    }
}

