using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SimpleMapper.Configuration
{
    internal struct InternalMapperConfig : IMappingConfiguration
    {
        private IFormatProvider _formatProvider;
        public IFormatProvider FormatProvider
        {
            get { return _formatProvider ?? (_formatProvider = CultureInfo.CurrentCulture); }
            set
            {
                _formatProvider = value ?? CultureInfo.CurrentCulture;
                _isChanged = true;
            }
        }

        private Dictionary<TypesPair, IMappingConfiguration> _mappingConfigurations;

        public void AddMappingConfiguration<TIn, TOut>(MappingConfiguration<TIn, TOut> configuration)
        {
            (_mappingConfigurations = _mappingConfigurations ?? new Dictionary<TypesPair, IMappingConfiguration>())
                .Add(TypesPair.Create<TIn, TOut>(), configuration);
        }
        
        public static InternalMapperConfig Init<TIn, TOut>(MappingConfiguration<TIn, TOut> configuration)
        {
            var result = new InternalMapperConfig();
            result.AddMappingConfiguration(configuration);
            return result;
        }

        public InternalMapperConfig NextDepthLevel()
        {
            var @this = this;
            @this.CurrentDepthLevel++;
            return @this;
        }

        private bool _isChanged;
        public bool Empty => !_isChanged;
        public int CurrentDepthLevel { get; private set; }

        public IEnumerable<string> Ignores(Type forType)
        {
            return _mappingConfigurations?.Where(c =>c.Value != null).SelectMany(c => c.Value.Ignores(forType)) ?? Enumerable.Empty<string>();
        }

        public Delegate Custom(Type forType, string forProperty)
        {
            return _mappingConfigurations?.Where(c => c.Value != null)
                .Select(c => c.Value.Custom(forType, forProperty))
                .FirstOrDefault();
        }

        public IEnumerable<string> CustomProperties(Type forType)
        {
            return _mappingConfigurations?.Where(c => c.Value != null)
                       .Select(c => c.Value)
                       .SelectMany(v => v.CustomProperties(forType))
                       .Distinct() ?? Enumerable.Empty<string>();
        }
    }
}