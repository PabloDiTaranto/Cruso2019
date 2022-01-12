using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomExtentions
{
    public static class StringExtentions
    {
        public static void DebugExtent(this string str)
        {
            Debug.LogFormat("La palabra {0} tiene {1} caracteres",
                            str, str.Length);
        }
    }

    public static class IntegerExtentions
    {
        
    }
}
