using System;

namespace SimpleMapper.Configuration
{
    internal struct TypesPair
    {
        public Type TIn { get; }
        public Type TOut { get; }

        public TypesPair(Type tin, Type tout)
        {
            TIn = tin;
            TOut = tout;
        }

        public static TypesPair Create<TIn, TOut>()
        {
            return new TypesPair(typeof(TIn), typeof(TOut));
        }
    }
}