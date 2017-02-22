using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper
{
    internal static class ExtensionMethods
    {
        public static T[] ForEach<T>(this T[] array, Func<T, int, T> action)
        {
			// test
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = action(array[i], i);
            }
            return array;
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> enumerable, T element)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }
            yield return element;
        }

        public static bool NotIn<T>(this T element, IEnumerable<T> second)
        {
            if (second == null)
            {
                return true;
            }
            return !second.Contains(element);
        } 

        public static T[] CreateArray<T>(this int length, Func<int, T> elementCreator)
        {
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = elementCreator(i);
            }
            return result;
        }

        public static bool In<T>(this T input, params T[] array)
        {
            return array.Contains(input);
        }

        /// <summary>
        /// Method of Convert class to convert to from type to target type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static MethodInfo GetConvertMethod(this Type type, Type target)
        {
            return typeof(Convert).GetMethod(String.Format("To{0}", target.Name), new[] { type });
        }

        public static void DebugException(this Exception exception)
        {
            var stackTrace = exception.IfNotNullThen(e => e.StackTrace);
            while (exception != null)
            {
                Debug.WriteLine(exception.Message);
                exception = exception.InnerException;
            }
            if (stackTrace != null)
            {
                Debug.WriteLine(stackTrace);
            }     
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static TOut IfNotNullThen<T, TOut>(this T input, Func<T, TOut> output)
            where T : class 
            where TOut: class
        {
            return output == null ? null : output(input);
        }

        /// <summary>
        /// Check that type is nullable
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Returns underlying type of Nullable or the type itself otherwise
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type StripNullable(this Type type)
        {
            return type.IsNullable() ? Nullable.GetUnderlyingType(type) : type;
        }
    }
}
