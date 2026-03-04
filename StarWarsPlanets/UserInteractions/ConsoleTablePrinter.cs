using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StarWarsPlanets.UserInteractions;

public static class ConsoleTablePrinter
{
    public static void PrintTable<T>(IEnumerable<T> tableData)
    {
        var list = tableData.ToList();
        if (!list.Any()) return;

        var columnsWidths = new Dictionary<PropertyInfo, int>();

        var properties = typeof(T).GetProperties()
            .Where(p => !p.Name.Contains("Double"));

        //column length
        foreach (var property in properties)
        {
            var maxColumnLength = property.Name.Length;

            foreach (var item in list)
            {
                var value = property.GetValue(item)?.ToString() ?? "";
                maxColumnLength = Math.Max(maxColumnLength, value.Length);
            }
            ;
            columnsWidths[property] = maxColumnLength + 2;
        }

        //separator line length
        var tableWidth = columnsWidths.Values.Sum() + columnsWidths.Count;

        //display table
        foreach (var p in properties)
        {
            Console.Write(p.Name.PadRight(columnsWidths[p]) + "|");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', tableWidth));

        foreach (var item in list)
        {
            foreach (var p in properties)
            {
                Console.Write((p.GetValue(item)?.ToString() ?? "").PadRight(columnsWidths[p]) + "|");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

