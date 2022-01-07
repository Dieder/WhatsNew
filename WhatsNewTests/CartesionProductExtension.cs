using System.Collections.Generic;
using System.Linq;

namespace WhantsNewTests;

internal static class CartesionProductExtension
{
    public static IEnumerable<Tuple<T, T2, T3>> CartesianProduct<T, T2, T3>
    (this IEnumerable<T> list, IEnumerable<T2>? anotherList, IEnumerable<T3> anotherList2)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(anotherList);
        ArgumentNullException.ThrowIfNull(anotherList2);

        return from item in list
               from anotherItem in anotherList
               from anotherItem2 in anotherList2
               select new Tuple<T, T2, T3>(item, anotherItem, anotherItem2);
    }
}
