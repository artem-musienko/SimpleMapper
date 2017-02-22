#if DEBUG
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleMapper
{
    public class MapperInfo<TIn, TOut>
    {
        private static Expression<Func<TIn, TOut>> _expression;
        public Expression<Func<TIn, TOut>> Expression { get { return _expression; } }

        public string DebugView { get; private set; }

        public static MapperInfo<TIn, TOut> Default { get; set; }

        public MapperInfo(Expression<Func<TIn, TOut>> expression)
        {
            _expression = expression;
            var debugView = typeof(Expression).GetProperty("DebugView",
                BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            DebugView = debugView.GetValue(_expression.Body, null).ToString();
        }
    }
}
#endif
