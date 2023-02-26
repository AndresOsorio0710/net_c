using Authentication.Backend.Domain.Enums;
using System.Globalization;

namespace Authentication.Backend.Domain.Referentials
{
    public class ResponseManager
    {
        public static TransactionResponse<T> ResponseValidation<T>(string message)
        {
            return new TransactionResponse<T>
            {
                ResultTransaction = new Response()
                {
                    Code = ResponseCode.Conflict,
                    IdTransactionCode = "0",
                    RowsAffected = 0,
                    Message = message.ToString(new CultureInfo("es-CO")),
                },
                ResultData = null
            };
        }
        /// <summary>
        /// Logic for response switching protocols function
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static TransactionResponse<TEntity> ResponseSwitchingProtocols<TEntity>(string message)
        {
            return new TransactionResponse<TEntity>
            {
                ResultTransaction = new Response()
                {
                    Code = ResponseCode.SwitchingProtocols,
                    IdTransactionCode = "0",
                    RowsAffected = 0,
                    Message = message.ToString(new CultureInfo("es-CO")),
                },
                ResultData = null
            };
        }

        /// <summary>
        /// Logic for response ok function
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="message"></param>
        /// <param name="resultData"></param>
        /// <returns></returns>
        public static TransactionResponse<TEntity> ResponseOk<TEntity>(string message, ICollection<TEntity> resultData = null)
        {
            return new TransactionResponse<TEntity>
            {
                ResultTransaction = new Response()
                {
                    Code = ResponseCode.Ok,
                    IdTransactionCode = "0",
                    RowsAffected = 0,
                    Message = message.ToString(new CultureInfo("es-CO")),
                },
                ResultData = resultData
            };
        }

        /// <summary>
        /// Logic for response internal server error function
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static TransactionResponse<TEntity> ResponseInternalServerError<TEntity>(string message)
        {
            return new TransactionResponse<TEntity>
            {
                ResultTransaction = new Response()
                {
                    Code = ResponseCode.InternalServerError,
                    IdTransactionCode = "0",
                    RowsAffected = 0,
                    Message = message.ToString(new CultureInfo("es-CO")),
                },
                ResultData = null
            };
        }
    }
}
