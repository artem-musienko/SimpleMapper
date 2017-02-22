using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper.Exceptions
{
    /// <summary>
    /// Mapping exception, exception details are logging with Debug.Write()
    /// </summary>
    public class SimpleMapperException : Exception
    {
        public SimpleMapperException(Exception exception, string message, params object[] parameters)
            : base(string.Format(message, parameters), exception)
        {
            this.DebugException();
        }
    }
}
