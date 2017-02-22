using System;
using SimpleMapper.Configuration;
using SimpleMapper.Exceptions;

namespace SimpleMapper
{
    public static partial class Mapper
    {
        public static void Create<TIn, TOut>(MappingConfiguration<TIn, TOut> mappingConfiguration = null)
        {
            // TODO do something with the result, seems like can be thrown away by JIT
            InternalMapFor(mappingConfiguration);
        }

        private static Func<TIn, TOut> InternalMapFor<TIn, TOut>(MappingConfiguration<TIn, TOut> mappingConfiguration = null)
        {
            var func = MappersCache<TIn, TOut>.Get(mappingConfiguration);
            if (func == null)
            {
                try
                {
                    // should run once for each types pair and specified config
                    MapperFactory.Create(mappingConfiguration);
                }
                catch (Exception e)
                {
                    throw new SimpleMapperException(e, 
                        "Exception occured when creating mapper for types {0} and {1}", typeof(TIn), typeof(TOut));
                }
            }
            return MappersCache<TIn, TOut>.Get(mappingConfiguration);
        }
    }
}