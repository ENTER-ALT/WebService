using WebService.Enums;

namespace WebService.Structs
{
    public struct OperationResult
    {
        public readonly ResultStatus Status;
        public readonly string ErrorMessage;

        public OperationResult(ResultStatus status, string errorMessage)
        {
            Status = status;
            ErrorMessage = errorMessage;
        }
        public OperationResult(ResultStatus status):this(status, null)
        { 
        }
    }
}
