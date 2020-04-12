using System;
using System.Collections.Generic;
using System.Linq;

namespace Fractal
{
    public static class ExtensionMethods
    {
        public static string ToJsonArray(this List<int> list)
        {
            return $"[{String.Join(",", list.Select(i => i.ToString()))}]";
        }

        public static string ToJsonMatrix(this List<List<int>> matrix)
        {
            return $"[{String.Join(",", matrix.Select(m => m.ToJsonArray()))}]";
        }

    }
}