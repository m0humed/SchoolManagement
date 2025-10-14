using Schoolmanagement.Domain.Enums;

namespace Schoolmanagement.Domain.Common
{
    public class ServiceResult
    {
        public bool Success { get; set; }

        public string Message { get; set; } = null!;

        public ServiceErrorEnum ServiceError { get; set; }
    }
}
