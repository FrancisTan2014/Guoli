using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guoli.Admin.Utilities
{
    public sealed class Rational
    {
        public Rational(int num)
        {
          
        }

        public int ToInt32()
        {
            return 0;
        }

        // 隐式转换时调用此方法，如 Rational r = 3;
        public static implicit operator Rational(int num)
        {
            return new Rational(num);
        }

        // 显示转换时调用此方法，如：int a = (int) r;
        public static explicit operator int(Rational r)
        {
            return r.ToInt32();
        }
    }
}