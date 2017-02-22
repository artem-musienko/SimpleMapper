using System;
using System.Collections.Concurrent;
using SimpleMapper.Configuration;

namespace SimpleMapper
{
    /// <summary>
    /// Mappers cache for specified types pair
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    internal static class MappersCache<TIn, TOut>
    {
        /// <summary>
        /// Default mapper for no config specified
        /// </summary>
        private static Func<TIn, TOut> _default;
// ReSharper disable StaticFieldInGenericType
        private static bool _defaultIsInit;
// ReSharper restore StaticFieldInGenericType
        private static readonly ConcurrentDictionary<MappingConfiguration<TIn, TOut>, Func<TIn, TOut>> cache =
            new ConcurrentDictionary<MappingConfiguration<TIn, TOut>, Func<TIn, TOut>>(MapperComparer<TIn, TOut>.Instance);

        public static bool IsInit(MappingConfiguration<TIn, TOut> config = null)
        {
            return config == null ? _defaultIsInit : cache.ContainsKey(config);
        }

        public static void Init(MappingConfiguration<TIn, TOut> config = null)
        {
            if (config == null) { _defaultIsInit = true; }
            else
            {
                cache.AddOrUpdate(config, @in => null, (configuration, func) => func);
            }          
        }

        public static Func<TIn, TOut> Get(MappingConfiguration<TIn, TOut> config = null)
        {
            if (config == null) { return _default; }
            Func<TIn, TOut> result;
            cache.TryGetValue(config, out result);
            return result;
        }

        public static void Add(Func<TIn, TOut> func, MappingConfiguration<TIn, TOut> config = null)
        {
            if (config == null)
            {
                _default = func;
                return;
            }
            cache.AddOrUpdate(config, mapper => func, (mapper, func1) => func);
        }

#if DEBUG
        public static MapperInfo<TIn, TOut>[] Info
        {
            get { return new[] { MapperInfo<TIn, TOut>.Default }; }
        }
#endif
    }
}