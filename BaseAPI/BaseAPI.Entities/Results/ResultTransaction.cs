using BaseAPI.Entities.Enums;

namespace BaseAPI.Entities.Results
{
    public class ResultTransaction
    {
        public int AffectedRecords { get; set; }
        public ResponceCode Code { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
    }
}
