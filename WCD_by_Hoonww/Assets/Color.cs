using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct CMYK
{
    public double c, m, y, k;
};

struct RGB
{
    public double r, g, b;
};

struct HSV
{
    public double h, s, v;
}

public class Color{
    RGB CtoR(CMYK x)
    {
        RGB ans;

        ans.r = 255 * (1 - x.c) * (1 - x.k);

        return ans;
    }
}
