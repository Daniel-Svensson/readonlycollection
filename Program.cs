// See https://aka.ms/new-console-template for more information
using @base;
using lib;


Console.WriteLine("Hello, World!");


PrintItem(new Problematic());

PrintItem(new CustomMutable());
PrintItem(new CustomCombined());
PrintItem(new CustomCombined2());


void PrintItem(IEnum item)
{
    Console.WriteLine($"'{item.GetType(),20}' \treadonly '{(item as IReadOnly)?.Count,20}' \tmutable '{(item as IMutable)?.Count,20}'\t {item.EnumProp}");
}

