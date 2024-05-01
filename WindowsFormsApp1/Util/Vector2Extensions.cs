using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Util
{
    public static class Vector2Extensions
    {
        public static Vector2 Normalized(this Vector2 vector)
        {
            var len = vector.Length();
            if (len == 0) return Vector2.Zero;
            return vector / len;
        }
    }
}
