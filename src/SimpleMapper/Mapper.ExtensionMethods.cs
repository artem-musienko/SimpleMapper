using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleMapper.Configuration;

namespace SimpleMapper
{
    /// <summary>
    /// Extension methods to map one object into another
    /// </summary>
    public static partial class Mapper
    {
        /// <summary>
        /// Map object of type TIn into object of type TOut
        /// </summary>
        /// <typeparam name="TIn">Input object type</typeparam>
        /// <typeparam name="TOut">Output object type</typeparam>
        /// <param name="input">Input object</param>
        /// <returns>Mapped output object</returns>
        public static TOut Map<TIn, TOut>(this TIn input)
        {
            return InternalMapFor<TIn, TOut>()(input);
        }

        /// <summary>
        /// Map object of type TIn into object of type TOut
        /// </summary>
        /// <typeparam name="TIn">Input object type</typeparam>
        /// <typeparam name="TOut">Output object type</typeparam>
        /// <param name="input">Input object</param>
        /// <param name="output">Mapped output object</param>
        public static void Map<TIn, TOut>(this TIn input, out TOut output)
        {
            output = InternalMapFor<TIn, TOut>()(input);
        }

        #region custom config

        /// <summary>
        /// Map object of type TIn into object of type TOut using custom mapping configuration
        /// </summary>
        /// <typeparam name="TIn">Input object type</typeparam>
        /// <typeparam name="TOut">Output object type</typeparam>
        /// <param name="input">Input object</param>
        /// <param name="config">Mapping configuration</param>
        /// <returns>Mapped output object</returns>
        public static TOut Map<TIn, TOut>(this TIn input, MappingConfiguration<TIn, TOut> config)
        {
            return InternalMapFor<TIn, TOut>(config)(input);
        }


        #endregion

    }
}
