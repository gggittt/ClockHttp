using System;
using System.Collections.Generic;

namespace _Project.Extensions.Enumerable
{

public static class ListExtensions
{
    public static List<T> CombineWith<T>( this List<T> self, IEnumerable<T> other ) //уже же есть AddRange
    {
        if ( self is null || other is null )
        {
            return self;
        }

        self.AddRange( other );
        return self;
    }

    public static HashSet<T> CombineWith<T>( this HashSet<T> self, IEnumerable<T> other )
    {
        if ( self is null )
        {
            return other as HashSet<T>;
        }

        if ( other is null )
        {
            return self;
        }

        self.UnionWith( other );
        return self;
    }

    public static bool Remove<T>( this List<T> list, Func<T, bool> selector )
    {
        if ( list.Find( selector ) is { } index )
        {
            list.RemoveAt(index);
            return true ;
        }
        return false ;
    }
    public static int? Find<T>( this List<T> list, Func<T, bool> selector )
    {
        for ( int i = 0; i < list.Count; i++ )
        {
            if ( selector(list[i]) )
            {
                return i;
            }
        }
        return null ;
    }

}
}