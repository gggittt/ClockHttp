using System;
using System.Collections.Generic;
using System.Linq;

namespace _Project.Extensions.Enumerable
{
public static class CollectionExtensions
{
    static readonly System.Random _random = new System.Random();

    public static bool HasDuplicates<T>( this IEnumerable<T> self, out List<T> duplicates )
        where T : IComparable<T>
    {
        HashSet<T> set = new HashSet<T>();
        duplicates = new List<T>();

        foreach ( T item in self )
        {
            if ( !set.Add( item ) )
            {
                duplicates.Add( item );
            }
        }

        return duplicates.Count > 0;
    }

    public static bool IsNullOrEmpty<T>( this ICollection<T> self )
    {
        if ( self == null )
            return true;

        return self.Count == 0;
    }

    public static T CutRandom<T>( this ICollection<T> self ) //PopRandom()?
    {
        T element = self.GetRandom();
        self.Remove( element );
        return element;
    }

    public static T[] CutRandomRange<T>( this ICollection<T> self, int amount )
    {
        T[] result = new T [amount];

        for ( int i = 0; i < amount; i++ )
        {
            result[ i ] = self.GetRandom();
            self.Remove( result[ i ] );
        }

        return result;
    }

    public static T GetRandom<T>( this ICollection<T> self )
    {
        if ( self == null )
            throw new ArgumentNullException( nameof( self ) );

        if ( self.Count == 0 )
            throw new InvalidOperationException( "Collection is empty" );

        int index = _random.Next( self.Count );
        T element = self.ElementAt( index );
        return element;
    }

    public static T At<T>( this IList<T> self, int index )
    {
        if ( self == null )
            throw new ArgumentNullException( nameof( self ) );

        if ( self.Count == 0 )
            throw new InvalidOperationException( "Collection is empty" );

        return self[ index ];
    }

}
}