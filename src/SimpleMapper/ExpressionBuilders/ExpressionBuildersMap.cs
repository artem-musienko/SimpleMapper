using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper.ExpressionBuilders
{
    /// <summary>
    /// Dictionary to store ExpressionBuilders associated with two types
    /// </summary>
    internal class ExpressionBuildersMap
    {
        private static readonly ExpressionBuildersMap _default = new ExpressionBuildersMap();
        /// <summary>
        /// Default map for built-in conversions
        /// </summary>
        public static ExpressionBuildersMap Default { get { return _default; } }

        public IExpressionBuilder this[Types input, Types output] { get { return null; } }

    }
}
