using System;
using System.Collections.Generic;

namespace SimpleMapper.Configuration
{
    public sealed partial class MappingConfiguration<TIn, TOut> : IMappingConfiguration
    {
        public IEnumerable<string> Ignores(Type forType)
        {
            throw new NotImplementedException();
        }

        public Delegate Custom(Type forType, string forProperty)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> CustomProperties(Type forType)
        {
            throw new NotImplementedException();
        }
    }

}
