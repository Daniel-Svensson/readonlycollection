namespace @base;

// "IEnumerable" base class
public interface IEnum
{
}

// IReadOnlyCollection
public interface IReadOnly : IEnum
{
    public string Count { get; }
}

// Simulate adding Readonly collections to the mutable collections in a new .NET version
#if NET7_0_OR_GREATER
public interface IMutable : IEnum, IReadOnly
{
    public new string Count { get; }

    string IReadOnly.Count
    {
        [System.Runtime.CompilerServices.Internal.FallbackInterfaceMethod]
        get => this.Count;
    }
#else
public interface IMutable  : IEnum
{
    public string Count { get; }
#endif
    public bool Add(object o) => false;
    public bool Remove(object o) => false;
}
