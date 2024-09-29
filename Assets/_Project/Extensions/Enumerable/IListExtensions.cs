using System.Collections.Generic;

namespace _Project.Extensions.Enumerable
{
public static class IListExtensions
{
    public static T Cut<T>( this IList<T> self, int index )
    {
        T element = self[ index ];
        self.RemoveAt( index );
        return element;
    }
}
}