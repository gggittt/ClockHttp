namespace _Project.Extensions
{
public static class IntExtensions
{
    public static int SetToZeroIfLower( this int self )
    {
        if ( self < 0 )
        {
            self = 0;
        }
        return self;
    }

}
}