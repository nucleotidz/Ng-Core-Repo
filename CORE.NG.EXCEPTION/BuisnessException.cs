using System;

namespace CORE.NG.EXCEPTION
{

    [Serializable]
    public class BuisnessException : Exception
    {
        public BuisnessException(string message) : base(message) { }
       
    }
}
