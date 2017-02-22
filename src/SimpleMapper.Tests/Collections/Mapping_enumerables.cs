using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    
    public class Mapping_enumerables
    {
        public const int MAX_ARRAY_LENGTH = 125;

        [Test]
        public void Mapping_generic_IEnumerable_of_builtins_to_list()
        {
            var array = MAX_ARRAY_LENGTH.CreateArray(i => i);
            array.AsEnumerable().TestMapper<IEnumerable<int>, List<string>>(
                (ints, list) =>
                {
                    if (list == null || array.Length != list.Count) { return false; }
                    for (int i = 0; i < array.Length; i++)
                    {
                        try
                        {
                            if (array[i].ToString(CultureInfo.InvariantCulture) != list[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "IEnumerable<int> to List<int>");
        }

        [Test]
        public void Mapping_generic_IEnumerable_of_nullable_builtins_to_list()
        {
            var array = new int?[MAX_ARRAY_LENGTH];
            array.AsEnumerable().TestMapper<IEnumerable<int?>, List<int?>>(
                (ints, list) =>
                {
                    if (list == null || array.Length != list.Count) { return false; }
                    for (int i = 0; i < array.Length; i++)
                    {
                        try
                        {
                            if (array[i] != list[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "IEnumerable<int> to List<int>");

            array.AsEnumerable().TestMapper<IEnumerable<int?>, List<int>>(
                (ints, list) =>
                {
                    if (list == null || array.Length != list.Count) { return false; }
                    for (int i = 0; i < array.Length; i++)
                    {
                        try
                        {
                            if (list[i] != 0) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "IEnumerable<int> to List<int>");
        }

        [Test]
        public void Mapping_generic_IEnumerable_to_enumerable()
        {
            var array = MAX_ARRAY_LENGTH.CreateArray(i => i);
            array.AsEnumerable().TestMapper<IEnumerable<int>, IEnumerable<string>>(
                (ints, output) =>
                {
                    var list1 = ints.Select(i=>i.ToString(CultureInfo.InvariantCulture)).ToList();
                    var list2 = output.ToList();
                    if (array.Length != list2.Count) { return false; }
                    for (int i = 0; i < list1.Count; i++)
                    {
                        try
                        {
                            if (list1[i] != list2[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "IEnumerable<int> to IEnumerable<string>");
        }
    }
}