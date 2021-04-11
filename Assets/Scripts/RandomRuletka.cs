using System.Linq;
using UnityEngine;

public class RandomRuletka
{
    private int[] buffer;

    public RandomRuletka(int len)
    {
        if (len > 0)
            buffer = new int[len];
    }

    public int[] GetArrayRandomNumerics()
    {
        GetNumeric();
        return buffer;
    }

    private void GetNumeric()
    {
        for (var i = 0; i < buffer.Length; i++)
        {
            int result = NumberSearch();
            buffer[i] = result;
        }
    }

    private int NumberSearch()
    {
        int temp = Random.Range(10, 1000);
        temp *= 100;
        bool isSmallDiaposon = false;
        for (int i = 0; i < buffer.Length; i++)
        {
            int t = buffer[i];
            if (t != 0)
            {
                if (System.Math.Abs(t - temp) < 1000)
                    isSmallDiaposon = true;
            }
        }
        if (!buffer.Contains(temp) && !isSmallDiaposon)
        {
            return temp;
        }
        return NumberSearch();
    }
}
