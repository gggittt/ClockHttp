namespace _Project.Extensions
{
public static class StringExtensions
{
    public static string[] ToStringArray( this string self, int substringsLength = 1 )
    {
        string[] result = new string[self.Length];

        for ( int i = 0; i < self.Length; i += substringsLength )
        {
            result[ i ] = self[ i ].ToString();
        }

        return result;
    }

}
}