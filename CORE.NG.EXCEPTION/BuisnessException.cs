using System;

namespace CORE.NG.EXCEPTION
{

    [Serializable]
    public class BuisnessException : BaseException
    {
        public BuisnessException(string message) : base(message) { }
       
    }
}
