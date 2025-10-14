namespace Schoolmanagement.Domain.Enums
{
    public enum ServiceErrorEnum : byte
    {
        None = 0,
        CanNotCreateUrl = 1,
        CanNotSendUrl = 2,
        FalseCode = 3,
        TrueCode = 4,
        NotValidUserId = 5,
    }
}
