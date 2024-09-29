using System.Collections.Generic;
using System.Linq;

namespace _Project.Extensions.TypedExtensions
{
public static class ElementToCollectionExtensions
{
    //https://youtu.be/SF_JTs30xEY?t=279 Nesteruk Нестерук Несколько трюков в C#
    //но code complition ломается - будет для всего предлагать
    //и будет чуть медленее - мб не заинлайнится

    public static T[] ElementToArray<T>( this T self )
    {
        T[] result = { self };
        return result;
    }

    public static List<T> ElementToList<T>( this T self )
    {
        List<T> result = new List<T>() { self };
        return result;
    }

    public static T AddTo<T>( this T self, ICollection<T> coll )
    {
        coll.Add( self );
        return self;
    }

    public static bool IsOneOf<T>( this T self, params T[] elements )
    {
        return elements.Contains( self );
    }

    // static void Demo( )
    // {
    //     List<int> myList = new List<int>();
    //     List<int> myList2 = new List<int>();
    //     2.AddTo( myList ).AddTo( myList2 );
    //
    //     int n = default;
    //     bool a = n.IsOneOf( 2, 3, 4 );
    // }
}
}