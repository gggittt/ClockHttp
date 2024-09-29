using UnityEngine;

namespace _Project.Extensions.UnityTypes
{
public static class ColorExtensions
{
    /// <summary>
    /// Convert string to Color (if defined as a static property of Color)
    /// </summary>
    /// <param name="colorName"></param>
    /// <returns></returns>
    public static Color ToColor( this string colorName )
    {
        string lowerInvariant = colorName.ToLowerInvariant();
        object color = typeof( Color )
           .GetProperty( lowerInvariant )?
           .GetValue( null, null );

        return (Color) color;
    }

    //https://answers.unity.com/questions/323079/convert-string-to-color.html +внизу и др способы
    public static Color ToColor( this string colorName, out Color myColour )
    {
        //myColour = Color.clear;
        ColorUtility.TryParseHtmlString( colorName, out myColour );
        return myColour;
    }
}
}