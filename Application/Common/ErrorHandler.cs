
using static Application.Common.shared;

namespace Application.Common
{
    internal class ErrorHandler
    {

        public static string GetErrorMessage(ErrorType errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound: return "The requested resource was not found.";
                case ErrorType.BadRequest: return "The request was invalid or cannot be served.";
                case ErrorType.Unauthorized: return "You are not authorized to access this resource.";
                case ErrorType.Forbidden: return "Access to this resource is forbidden.";
                case ErrorType.Conflict: return "There was a conflict with the current state of the resource.";
                case ErrorType.InternalServerError: return "An unexpected error occurred on the server.";
                case ErrorType.succseeded:return "Deleted successfully.";
                default: return "Unknown error.";
            }
        }    }    
}
