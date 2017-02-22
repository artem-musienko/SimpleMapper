namespace SimpleMapper
{
    /// <summary>
    /// Types enumeration, do not rename members
    /// </summary>
    internal enum TypeEnum
    {
        Unknown = -1,
        Object = 0,

        Boolean,
        Byte,
        SByte,
        Char,
        Decimal,
        Double,
        Single,
        Int32,
        UInt32,
        Int64,
        UInt64,
        Int16,
        UInt16,

        Array,
        ArrayList,
        GenericList,
        GenericEnumerable,
        NameValueObjectCollection,

        DateTime,
        String,

        Class,
        Enum
    }
}
