using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractal
{
    public static class ExtensionMethods
    {
        public static string ToJsonMatrix(this List<List<int>> matrix)
        {
            var sb = new StringBuilder("[");
            var isFirst = true;

            foreach(var row in matrix)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    sb.Append(",");
                }

                sb.Append("[");
                sb.AppendJoin(',', row);
                sb.Append("]");
            }
            sb.Append("]");

            return sb.ToString();
        }

    }
}