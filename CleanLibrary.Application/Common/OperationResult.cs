using System;

namespace CleanLibrary.Application.Common
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; }
        public T Data { get; }
        public string ErrorMessage { get; }

        private OperationResult(bool isSuccess, T data, string errorMessage)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static OperationResult<T> Success(T data) => new OperationResult<T>(true, data, null);

        public static OperationResult<T> Failure(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ArgumentException("Error message cannot be null or empty.", nameof(errorMessage));
            }

            return new OperationResult<T>(false, default, errorMessage);
        }
    }
}
