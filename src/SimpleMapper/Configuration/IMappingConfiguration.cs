using System;
using System.Collections.Generic;

namespace SimpleMapper.Configuration
{
    public interface IMappingConfiguration
    {
        IEnumerable<string> Ignores(Type forType);
        Delegate Custom(Type forType, string forProperty);
        IEnumerable<string> CustomProperties(Type forType);
    }
}