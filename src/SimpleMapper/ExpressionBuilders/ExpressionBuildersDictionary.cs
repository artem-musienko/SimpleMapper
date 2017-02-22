using System;
using System.Collections.Generic;
using System.Diagnostics;
using te = SimpleMapper.TypeEnum;
using System.Linq;

namespace SimpleMapper.ExpressionBuilders
{
    internal static class ExpressionBuildersDictionary
    {
        #region debug

        [DebuggerDisplay("Rank = {Rank}")]
        [DebuggerTypeProxy(typeof(DebugView))]
        internal class ConversionMatrix
        {
            public int Rank { get; private set; }
            private static IExpressionBuilder[,] _matrix;

            public ConversionMatrix()
            {
                Rank = (int)Enum.GetValues(typeof(TypeEnum)).Cast<TypeEnum>().Max() + 1;
                _matrix = new IExpressionBuilder[Rank, Rank];
            }

            public IExpressionBuilder this[TypeEnum tin, TypeEnum tout]
            {
                get { return _matrix[(int)tin, (int)tout]; }
                set { _matrix[(int)tin, (int)tout] = value; }
            }

            public IExpressionBuilder this[int tin, int tout]
            {
                get { return _matrix[tin, tout]; }
                set { _matrix[tin, tout] = value; }
            }
        }

        [DebuggerDisplay("{From} => {To} = {Builder}")]
        internal class ConversionMatrixItem
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Builder { get; set; }
        }

        internal class DebugView
        {
            private readonly ConversionMatrix _matrix;

            public DebugView(ConversionMatrix matrix)
            {
                _matrix = matrix;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public ConversionMatrixItem[] Items
            {
                get
                {
                    var result = new ConversionMatrixItem[_matrix.Rank * _matrix.Rank];
                    for (int i = 0; i < _matrix.Rank; i++)
                    {
                        for (int j = 0; j < _matrix.Rank; j++)
                        {
                            var item = _matrix[i, j];
                            result[i * _matrix.Rank + j] = new ConversionMatrixItem
                                {
                                    Builder = item == null ?
                                        "Not supported" :
                                        item.GetType().ToString().Replace("SimpleMapper.ExpressionBuilders.", string.Empty),
                                    From = ((TypeEnum)i).ToString(),
                                    To = ((TypeEnum)j).ToString()
                                };
                        }
                    }
                    return result;
                }
            }
        }

        #endregion

        private static readonly ConversionMatrix buildersMatrix = new ConversionMatrix();

        #region Helpers

        private static void AddBuildersTo(this TypeEnum tin, IExpressionBuilder builder, params TypeEnum[] types)
        {
            foreach (var tout in types)
            {
                buildersMatrix[tin, tout] = builder;
            }
        }

        private static void AddBuildersTo(this IEnumerable<TypeEnum> toTypes, IExpressionBuilder builder,
                                            TypeEnum fromType)
        {
            foreach (var toType in toTypes)
            {
                buildersMatrix[fromType, toType] = builder;
            }
        }

        private static void AddBuildersFrom(this IEnumerable<TypeEnum> fromTypes, IExpressionBuilder builder,
                                        TypeEnum toType)
        {
            foreach (var fromType in fromTypes)
            {
                buildersMatrix[fromType, toType] = builder;
            }
        }

        #endregion

        static ExpressionBuildersDictionary()
        {
            RegisterAssignmentConversion();
            RegisterImplicitNumericConversion();
            RegisterExplicitNumericConversion();
            RegisterToStringConversion();
            RegisterFromStringUsingParseConversion();
            RegisterBoxingConversion();
            RegisterUnboxingConversion();
            RegisterEnumMapping();
            RegisterCollectionsMapping();
            RegisterCustomClassMapping();
            RegisterNameValueObjectCollection();
        }

        #region Registration

        private static void RegisterNameValueObjectCollection()
        {
            var builder = new FromNameValueObjectCollectionBuilder();
            TypeEnum.NameValueObjectCollection.AddBuildersTo(builder, te.Class);
        }

        /// <summary>
        /// From Array to Array
        /// </summary>
        private static void RegisterCollectionsMapping()
        {
            var arrayToArrayBuilder = new ArrayToArrayBuilder();
            TypeEnum.Array.AddBuildersTo(arrayToArrayBuilder, te.Array);

            var listToArrayListBuilder = new GenericListToArrayListBuilder();
            TypeEnum.GenericList.AddBuildersTo(listToArrayListBuilder, te.ArrayList);

            var listToArrayBuilder = new GenericListToArrayBuilder();
            TypeEnum.GenericList.AddBuildersTo(listToArrayBuilder, te.Array);

            var arrayToListBuilder = new ArrayToGenericListBuilder();
            TypeEnum.Array.AddBuildersTo(arrayToListBuilder, te.GenericList);

            var arrayListToListBuilder = new ArrayListToGenericListBuilder();
            TypeEnum.ArrayList.AddBuildersTo(arrayListToListBuilder, te.GenericList);

            var listToList = new GenericListToGenericListBuilder();
            TypeEnum.GenericList.AddBuildersTo(listToList, te.GenericList);

            var enumerableToListBuilder = new EnumerableToListBuilder();
            TypeEnum.GenericEnumerable.AddBuildersTo(enumerableToListBuilder, te.GenericList);

            var enumerableToEnumerableBuilder = new EnumerableToEnumerableBuilder();
            TypeEnum.GenericEnumerable.AddBuildersTo(enumerableToEnumerableBuilder, te.GenericEnumerable);
        }

        /// <summary>
        /// From enums to numeric
        /// </summary>
        private static void RegisterEnumMapping()
        {
            var builder = new ExplicitBuilder();
            TypeEnum.Enum.AddBuildersTo(builder, te.Enum, te.Byte, te.SByte, te.Int16, te.Int32, te.Int64,
                                      te.UInt16, te.UInt32, te.UInt64, te.Char);
            new[]
                {
                    te.Byte, te.SByte, te.Int16, te.Int32, te.Int64,
                    te.UInt16, te.UInt32, te.UInt64, te.Char
                }.AddBuildersFrom(builder, te.Enum);
        }

        /// <summary>
        /// Name-to-name class properties binding
        /// </summary>
        private static void RegisterCustomClassMapping()
        {
            var builder = new CustomClassBuilder();
            te.Class.AddBuildersTo(builder, te.Class);
        }

        /// <summary>
        /// Unboxing with try-catch, calling Convert.To_ on catch if unboxing failed
        /// </summary>
        private static void RegisterUnboxingConversion()
        {
            var builder = new UnboxingBuilder();
            new[]
                {
                    te.Boolean, te.Byte, te.Char, te.Decimal, te.Double, te.Int16, te.Int32, te.Int64,
                    te.SByte, te.Single, te.UInt16, te.UInt32, te.UInt64
                }.AddBuildersTo(builder, te.Object);
        }

        /// <summary>
        /// Boxing of built-in numeric types
        /// </summary>
        private static void RegisterBoxingConversion()
        {
            var builder = new BoxingBuilder();
            new[]
                {
                    te.Boolean, te.Byte, te.Char, te.Decimal, te.Double, te.Int16, te.Int32, te.Int64,
                    te.SByte, te.Single, te.UInt16, te.UInt32, te.UInt64
                }.AddBuildersFrom(builder, te.Object);
        }

        /// <summary>
        /// Types that support Parse-method for strings
        /// </summary>
        private static void RegisterFromStringUsingParseConversion()
        {
            var builder = new FromStringUsingParseBuilder();
            new[]
                {
                    te.Boolean, te.Byte, te.Char, te.Decimal, te.Double, te.Int16, te.Int32, te.Int64,
                    te.SByte, te.Single, te.UInt16, te.UInt32, te.UInt64, te.DateTime
                }.AddBuildersTo(builder, te.String);
        }

        /// <summary>
        /// Call ToString() on any object when converting to string
        /// </summary>
        private static void RegisterToStringConversion()
        {
            const int index = (int) te.String;
            var toStringBuilder = new ToStringBuilder();
            for (int i = 0; i < buildersMatrix.Rank; i++)
            {
                if (index != i)
                {
                    buildersMatrix[i, index] = toStringBuilder;
                }
            }
        }

        /// <summary>
        /// Types are the same
        /// </summary>
        private static void RegisterAssignmentConversion()
        {
            var @explicit = new ExplicitBuilder();
            for (int i = 0; i < buildersMatrix.Rank; i++)
            {
                if (((TypeEnum) i).In(te.Class, te.Enum, te.Array))
                {
                    continue;
                }
                buildersMatrix[i, i] = @explicit;
            }
        }

        /// <summary>
        /// Explicit Numeric Conversions Table: <see cref="http://msdn.microsoft.com/en-us/library/yht2cx7b.aspx"/>
        /// </summary>
        private static void RegisterExplicitNumericConversion()
        {
            var explicitBuilder = new ExplicitBuilder();
            TypeEnum.SByte.AddBuildersTo(explicitBuilder, te.Byte, te.UInt16, te.UInt32, te.UInt64, te.Char);
            TypeEnum.Byte.AddBuildersTo(explicitBuilder, te.SByte, te.Char);
            TypeEnum.Int16.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.UInt16, te.UInt32, te.UInt64, te.Char);
            TypeEnum.UInt16.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.Char);
            TypeEnum.Int32.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.UInt16, te.UInt32,
                                       te.UInt64, te.Char);
            TypeEnum.UInt32.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.UInt16, te.Int32, te.Char);
            TypeEnum.Int64.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.UInt16, te.Int32, te.UInt32,
                                       te.UInt64, te.Char);
            TypeEnum.UInt64.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.UInt16, te.Int32, te.UInt32,
                                        te.Int64, te.Char);
            TypeEnum.Char.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16);
            TypeEnum.Single.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.UInt16, te.Int32, te.UInt32,
                                        te.Int64, te.UInt64, te.Char, te.Decimal);
            TypeEnum.Double.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.UInt16, te.Int32, te.UInt32,
                                        te.Int64, te.UInt64, te.Char, te.Single, te.Decimal);
            TypeEnum.Decimal.AddBuildersTo(explicitBuilder, te.SByte, te.Byte, te.Int16, te.UInt16, te.Int32, te.UInt32,
                                         te.Int64, te.UInt64, te.Char, te.Single, te.Double);
        }

        /// <summary>
        /// Implicit Numeric Conversions Table: <see cref="http://msdn.microsoft.com/en-us/library/y5b434w4.aspx"/>
        /// </summary>
        private static void RegisterImplicitNumericConversion()
        {
            var implicitBuilder = new ImplicitBuilder();
            TypeEnum.SByte.AddBuildersTo(implicitBuilder, te.Int16, te.Int32, te.Int64,
                                       te.Single, te.Double, te.Decimal);
            TypeEnum.Byte.AddBuildersTo(implicitBuilder, te.Int16, te.UInt16, te.Int32, te.UInt32, te.Int64,
                                      te.UInt64, te.Single, te.Double, te.Decimal);
            TypeEnum.Int16.AddBuildersTo(implicitBuilder, te.Int32, te.Int64, te.Single, te.Double, te.Decimal);
            TypeEnum.UInt16.AddBuildersTo(implicitBuilder, te.Int32, te.UInt32, te.Int64, te.UInt64,
                                        te.Single, te.Double, te.Decimal);
            TypeEnum.Int32.AddBuildersTo(implicitBuilder, te.Int64, te.Single, te.Double, te.Decimal);
            TypeEnum.UInt32.AddBuildersTo(implicitBuilder, te.Int64, te.UInt64, te.Single, te.Double, te.Decimal);
            TypeEnum.Int64.AddBuildersTo(implicitBuilder, te.Single, te.Double, te.Decimal);
            TypeEnum.Char.AddBuildersTo(implicitBuilder, te.UInt16, te.Int32, te.UInt32, te.Int64, te.UInt64,
                                      te.Single, te.Double, te.Decimal);
            TypeEnum.Single.AddBuildersTo(implicitBuilder, te.Double);
            TypeEnum.UInt64.AddBuildersTo(implicitBuilder, te.Single, te.Double, te.Decimal);
        }

        #endregion

        /// <summary>
        /// Get ExpressionBuilder for specified types pair
        /// </summary>
        /// <param name="tin"></param>
        /// <param name="tout"></param>
        /// <returns></returns>
        public static IExpressionBuilder Get(TypeEnum tin, TypeEnum tout)
        {
            return buildersMatrix[(int)tin, (int)tout];
        }

        public static bool UsesRecursion(TypeEnum tin, TypeEnum tout)
        {
            var builder = buildersMatrix[(int) tin, (int) tout];
            return builder != null && builder.UsesRecursion;
        }
    }
}
