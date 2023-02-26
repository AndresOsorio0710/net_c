using Authentication.Backend.Domain.Enums;

namespace Authentication.Backend.Domain.Referentials
{
    public class Response
    {
        /// <summary>
        /// get or set, code
        /// </summary>
        /// <value>
        /// Code, ResponseCode
        /// </value>
        public ResponseCode Code { get; set; }

        /// <summary>
        /// get or set, response message
        /// </summary>
        /// <value>
        /// Message, string
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// get or set, rows affected
        /// </summary>
        /// <value>
        /// RowsAffected, int
        /// </value>
        public int RowsAffected { get; set; }

        /// <summary>
        /// get or set, id transaction code
        /// </summary>
        /// <value>
        /// IdTransactionCode, string
        /// </value>
        public string IdTransactionCode { get; set; }
    }
}
