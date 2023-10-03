namespace lib;
using @base;

// This simulates a library written against an old .NET framework without
// the proposed changes to collection interfaces
public interface ICustomReadOnly : IReadOnly
{
    string IReadOnly.Count => "DIM: Overriden by library";
}

public class Problematic : IMutable, ICustomReadOnly
{
    string IMutable.Count => "Existing implementation";
}

public class MutableOnlyCollection : IMutable
{
    string IMutable.Count => nameof(MutableOnlyCollection);
}

public class CustomCombined : IMutable, IReadOnly
{
    string IMutable.Count => nameof(CustomCombined) + " mutable";
    string IReadOnly.Count => nameof(CustomCombined) + " readonly";
}