using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class shared
    {
        public enum ErrorType
        {
            NotFound,
            BadRequest,
            Unauthorized,
            Forbidden,
            Conflict,
            InternalServerError,
            succseeded
        }
    }
}
