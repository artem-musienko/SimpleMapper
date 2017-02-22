using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleMapper.ExpressionBuilders
{
    /// <summary>
    /// Extension methods for Epxression building with methods chaining
    /// </summary>
    internal static class ExpressionHelper
    {
        /// <summary>
        /// input = value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Expression Assign(this Expression input, Expression value)
        {
            return Expression.Assign(input, value);
        }

        public static Expression Constant(this object value)
        {
            return Expression.Constant(value);
        }

        /// <summary>
        /// array[index]
        /// </summary>
        /// <param name="array"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static Expression Access(this Expression array, params Expression[] indexes)
        {
            return Expression.ArrayAccess(array, indexes);
        }

        /// <summary>
        /// item[index]
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Expression IndexerAccess(this Expression item, Expression index)
        {
            return Expression.Property(item, "Item", index);
        }

        /// <summary>
        /// array[index]
        /// </summary>
        /// <param name="array"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static Expression Index(this Expression array, params Expression[] indexes)
        {
            return Expression.ArrayAccess(array, indexes);
        }

        /// <summary>
        /// expression(parameters)
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Expression InvokeFunc(this Expression expression, params Expression[] parameters)
        {
            return Expression.Invoke(expression, parameters);
        }

        /// <summary>
        /// instance.property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static Expression Property(this Expression instance, PropertyInfo property)
        {
            return Expression.Property(instance, property);
        }

        /// <summary>
        /// try { return (targetType)expression } catch(InvalidCastException) {return Convert.To_targetType_(expression)}
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static Expression SafeUnboxing(this Expression expression, Type targetType)
        {
            var exp = Expression.TryCatch(Expression.Convert(expression, targetType),
                                          Expression.Catch(typeof (InvalidCastException),
                                          expression.ConvertTo(typeof(object), targetType)));
            return exp;
        }

        /// <summary>
        /// Convert.To_type_(expression)
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static Expression ConvertTo(this Expression expression, Type type, Type targetType)
        {
            var method = type.GetConvertMethod(targetType);
            return Expression.Call(method, expression);
        }

        /// <summary>
        /// expression == null ? def : body
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static Expression NullCheck(this Expression expression, Type type, Expression def = null)
        {
            var result = Expression.Coalesce(expression, def ?? Expression.Default(type));
            return result;
        }

        /// <summary>
        /// (type)expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Expression ExplicitTo(this Expression expression, Type type)
        {
            return Expression.Convert(expression, type);
        }

        /// <summary>
        /// default(type)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Expression Default(this Type type)
        {
            return Expression.Default(type);
        }

        /// <summary>
        /// expression == null ? def : body
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="def"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static Expression TernaryNullCheck(this Expression expression, Expression def, Expression body)
        {
            var ternary = Expression.Condition(Expression.Equal(expression, Expression.Constant(null)), def, body);
            return ternary;
        }

#if DEBUG
        public static Expression ThrowCustomExceptionForNull(this Expression expression)
        {
            var @if = Expression.IfThen(Expression.Equal(expression, Expression.Constant(null)),
                Expression.Throw(Expression.New(typeof (Exception).GetConstructor(new[] {typeof (string)}),
                    Expression.Constant(string.Format("Expression {0} is null", expression)))));
            return @if;
        }

        public static Expression Output(this Expression expression)
        {
            var method = typeof (Trace)
                .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod).First(mi => mi.Name == "WriteLine" && mi.GetParameters().Count() == 1);
            var output = Expression.Call(method, Expression.Call(expression, "ToString", null, null));
            return output;
        }

#endif 
    }
}
