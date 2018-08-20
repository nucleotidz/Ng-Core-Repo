using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.NG.EXCEPTION
{
    [Serializable]
    public class ValidationException : BaseException
    {
        public ValidationException(string message) : base(message) { }

    }
}
