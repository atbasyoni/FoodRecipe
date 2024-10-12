
using FoodRecipe.Common.Enums;

namespace FoodRecipe.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public BusinessException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
