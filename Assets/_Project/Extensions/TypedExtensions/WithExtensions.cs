using System;

//KSyndicate https://youtu.be/EvLJXE8TxCQ = примеры
namespace _Project.Extensions.TypedExtensions
{
public static class WithExtensions
{
    //todo call look like: xxx
    //todo расписать отличие от др Extensions: Vector3 With( this Vector3 self, float? x = null, float? y = null, float? z = null
    /// <summary>
    /// todo describe Invoke
    /// </summary>
    public static T With<T>( this T self, Action<T> set )
    {
        set.Invoke( self );
        return self;
    }

    public static T With<T>( this T self, Action<T> apply, Func<bool> when )
    {
        if ( when() )
            apply?.Invoke( self );

        return self;
    }

    // ReSharper disable once FlagArgument
    public static T With<T>( this T self, Action<T> apply, bool when )
    {
        if ( when )
            apply?.Invoke( self );

        return self;
    }
}
}