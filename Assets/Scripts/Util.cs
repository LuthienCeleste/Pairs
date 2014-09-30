using UnityEngine;
using System.Collections;

public class Util {
    public static Color HSVtoRGB( float hue, float saturation, float value)
    {
        hue *= 360f;

        int hi = (int) (Mathf.Floor(hue / 60)) % 6;
        float f = hue / 60 - Mathf.Floor(hue / 60);
        
        float v = (value);
        float p = (value * (1f - saturation));
        float q = (value * (1f - f * saturation));
        float t = (value * (1f - (1f - f) * saturation));
        
        if (hi == 0)
            return new Color( v, t, p);
        else if (hi == 1)
            return new Color( q, v, p);
        else if (hi == 2)
            return new Color( p, v, t);
        else if (hi == 3)
            return new Color( p, q, v);
        else if (hi == 4)
            return new Color( t, p, v);
        else
            return new Color( v, p, q);
    }
}
