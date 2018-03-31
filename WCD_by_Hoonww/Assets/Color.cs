using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMYK
{
    public float c, m, y, k;

    public CMYK(float c, float m, float y, float k)
    {
        this.c = c;
        this.m = m;
        this.y = y;
        this.k = k;
    }

    CMYK RGBtoCMYK(UnityEngine.Color c)
    {
        CMYK res = new CMYK(0, 0, 0, 0);
        UnityEngine.Color cp = c / 255;

        float max = (cp.r<cp.g) ? cp.r : cp.g;
        max = (max < cp.b) ? max : cp.b;

        res.k = 1 - max;
        res.c = (1 - cp.r - res.k) / (1 - res.k);
        res.m = (1 - cp.g - res.k) / (1 - res.k);
        res.y = (1 - cp.b - res.k) / (1 - res.k);

        return res;
    }

    UnityEngine.Color CMYKtoRGB(CMYK c)
    {
        UnityEngine.Color res = new UnityEngine.Color();

        res.r = 255 * (1 - c.c) * (1 - c.k);
        res.g = 255 * (1 - c.m) * (1 - c.k);
        res.b = 255 * (1 - c.y) * (1 - c.k);

        return res;
    }
};


public class HSV
{
    public float h, s, v;

    public HSV(float h, float s, float v)
    {
        this.h = h;
        this.s = s;
        this.v = v;
    }

    HSV RGBtoHSV(UnityEngine.Color c)
    {
        HSV res = new HSV(0, 0, 0);
        UnityEngine.Color cp = c / 255;

        float max, min, delta;
        max = (cp.r < cp.g) ? cp.r : cp.g;
        max = (max < cp.b) ? max : cp.b;
        min = (cp.r > cp.g) ? cp.g : cp.r;
        min = (min > cp.b) ? cp.b : min;
        delta = max - min;

        res.v = max;
        res.s = (max == 0) ? 0 : delta / max;
        if (delta == 0) res.h = 0;
        else if (max == cp.r) res.h = 60 * (((cp.g - cp.b) / delta) % 6);
        else if (max == cp.g) res.h = 60 * ((cp.b - cp.r) / delta + 2);
        else if (max == cp.b) res.h = 60 * ((cp.r - cp.g) / delta + 4);

        return res;
    }

    UnityEngine.Color HSVtoRGB(HSV c)
    {
        UnityEngine.Color res = new UnityEngine.Color();

        float cc, x, m;

        cc = c.v * c.s;
        x = cc * (1 - Mathf.Abs((h / 60) % 2 - 1));
        m = c.v - cc;

        if (h >= 0 && h < 60) { res.r = cc; res.g = x; res.b = 0; }
        else if (h >= 60 && h < 120) { res.r = x; res.g = cc; res.b = 0; }
        else if(h>=120 && h<180) { res.r = 0; res.g = cc; res.b = x; }
        else if(h>=180 && h<240) { res.r = 0; res.g = x; res.b = cc; }
        else if(h>=240 && h < 300) { res.r = x; res.g = 0; res.b = cc; }
        else { res.r = cc; res.g = 0; res.b = x; }

        res.r = (res.r + m) * 255;
        res.g = (res.g + m) * 255;
        res.b = (res.b + m) * 255;
 
        return res;
    }
}