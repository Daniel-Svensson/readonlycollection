
Run "program" on NET6 to simulate the current state of .NET as of NET8 where IList does not implement IReadOnlyList

```
Running on runtime: .NET 6.0.22
Does IMutable implement IReadonly and have problematic DIM: False

Type                             readonly                        mutable
lib.MutableOnlyCollection                                        MutableOnlyCollection
lib.CustomCombined               CustomCombined readonly         CustomCombined mutable
lib.Problematic                  DIM: Overriden by library       Existing implementation
```

Run "program" on NET7 to simulate what happens if IList would implement IReadOnlyList using DIM (Default Interface Methods) 
When somebody else also use DIM to implement IReadOnlyList methods
- program will crash (throw exception) when using the type in question

```
Running on runtime: .NET 7.0.11
Does IMutable implement IReadonly and have problematic DIM: True

Type                             readonly                        mutable
lib.MutableOnlyCollection        MutableOnlyCollection           MutableOnlyCollection
lib.CustomCombined               CustomCombined readonly         CustomCombined mutable
Unhandled exception. System.Runtime.AmbiguousImplementationException: Could not call method 'base.IReadOnly.get_Count()' on interface 'base.IReadOnly' with type 'lib.Problematic' from assembly 'lib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' because there are multiple incompatible interface methods overriding this method.
   at base.IReadOnly.get_Count()
   at Program.<<Main>$>g__PrintItem|0_0(IEnum item) in F:\repos\readonlycollection\program\Program.cs:line 19
   at Program.<Main>$(String[] args) in F:\repos\readonlycollection\program\Program.cs:line 14
```


Run "program" with proposed POC and the program will succeed with expected output

```
Running on runtime: .NET 9.0.0-dev
Does IMutable implement IReadonly and have problematic DIM: True

Type                             readonly                        mutable
lib.MutableOnlyCollection        MutableOnlyCollection           MutableOnlyCollection
lib.CustomCombined               CustomCombined readonly         CustomCombined mutable
lib.Problematic                  DIM: Overriden by library       Existing implementation
```