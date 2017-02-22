using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleMapper.Tests
{
    
    public class Mapping_lists
    {
        public const int MAX_ARRAY_LENGTH = 125;

        [Test]
        public void Map_list_to_list()
        {
            var list = new List<int>(MAX_ARRAY_LENGTH.CreateArray(i => i));
            list.TestMapper<List<int>, List<object>>(
                (ints, arrayList) =>
                {
                    if (arrayList == null || ints.Count != arrayList.Count) { return false; }
                    for (int i = 0; i < ints.Count; i++)
                    {
                        try
                        {
                            if (ints[i] != (int)arrayList[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "List<> to List<>");
        }

        [Test]
        public void Map_list_to_arraylist()
        {
            var list = new List<int>(MAX_ARRAY_LENGTH.CreateArray(i => i));
            list.TestMapper<List<int>, ArrayList>(
                (ints, arrayList) =>
                {
                    if (arrayList == null || ints.Count != arrayList.Count) { return false; }
                    for (int i = 0; i < ints.Count; i++)
                    {
                        try
                        {
                            if (ints[i] != (int)arrayList[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "List<> to ArrayList");
        }

        [Test]
        public void Map_arraylist_to_list()
        {
            var list = new ArrayList(MAX_ARRAY_LENGTH.CreateArray(i => i));
            list.TestMapper<ArrayList, List<int>>(
                (ints, arrayList) =>
                {
                    if (arrayList == null || ints.Count != arrayList.Count) { return false; }
                    for (int i = 0; i < ints.Count; i++)
                    {
                        try
                        {
                            if ((int)ints[i] != arrayList[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "ArrayList to List<>");
        }

        [Test]
        public void Map_list_to_array()
        {
            var list = new List<int>(MAX_ARRAY_LENGTH.CreateArray(i => i));
            list.TestMapper<List<int>, int[]>(
                (ints, array) =>
                {
                    if (array == null || ints.Count != array.Length) { return false; }
                    for (int i = 0; i < ints.Count; i++)
                    {
                        try
                        {
                            if (ints[i] != array[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "List<> to typed Array");
        }

        [Test]
        public void Map_array_to_list()
        {
            var array = MAX_ARRAY_LENGTH.CreateArray(i => i);
            array.TestMapper<int[], List<int>>(
                (ints, list) =>
                {
                    if (list == null || ints.Length != list.Count) { return false; }
                    for (int i = 0; i < ints.Length; i++)
                    {
                        try
                        {
                            if (ints[i] != list[i]) { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return true;
                }, "typed Array to List<>");
        }
    }
}