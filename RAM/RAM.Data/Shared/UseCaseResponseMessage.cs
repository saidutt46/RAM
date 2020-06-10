using System;
namespace RAM.Data.Shared
{
    public abstract class UseCaseResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }

        protected UseCaseResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
