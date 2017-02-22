using System;
using System.Collections.Generic;
using SimpleMapper.Configuration;

namespace SimpleMapper
{
    public class MapperComparer<TIn, TOut>: IEqualityComparer<MappingConfiguration<TIn, TOut>>
    {
        private static readonly MapperComparer<TIn, TOut> instance = new MapperComparer<TIn, TOut>();

        private MapperComparer()
        {
           
        }

        public static MapperComparer<TIn, TOut> Instance { get { return instance; } }

        public bool Equals(MappingConfiguration<TIn, TOut> x, MappingConfiguration<TIn, TOut> y)
        {
            return x.Value == y.Value;
        }

        public int GetHashCode(MappingConfiguration<TIn, TOut> obj)
        {
            return obj.GetHashCode();
        }
    }
}