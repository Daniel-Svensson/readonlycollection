using System.Runtime.InteropServices;
using @base;
using lib;

Console.WriteLine($"Running on runtime: {RuntimeInformation.FrameworkDescription}");
Console.WriteLine($"Does IMutable implement IReadonly and have problematic DIM: {typeof(IMutable).IsAssignableTo(typeof(IReadOnly))}");

Console.WriteLine();

Console.WriteLine($"{"Type",-30} \t {"readonly",-25} \t {"mutable",-20}");

PrintItem(new MutableOnlyCollection());
PrintItem(new CustomCombined());
PrintItem(new Problematic());


void PrintItem(IEnum item)
{
    Console.WriteLine($"{item.GetType(),-30} \t {(item as IReadOnly)?.Count,-25} \t {(item as IMutable)?.Count,-20}");
}

