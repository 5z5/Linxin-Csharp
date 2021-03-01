using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace accessPsychology.Utilities
{
    public class CharacterUtility
    {
        static Random _random = new Random();

        public static Char LowerAlpha
        {
            get
            {
                int num = _random.Next(0, 26);
                char c = (char)('a' + num);
                return c;
            }
        }

        public static Char UpperAlpha
        {
            get
            {
                int num = _random.Next(0, 26);
                char c = (char)('A' + num);
                return c;
            }
        }

        public static char Numeric
        {
            get
            {
                int num = _random.Next(0, 10);
                char c = (char)('0' + num);
                return c;
            }
        }

        public static string GenerateRandomString()
        {
            int length = 4;
            string randomString = "";
            char r;
            char r1;
            int len = 1;
            while (len <= length)
            {
                if (len == 1) //随机首字符只能为小或大写
                {
                    r = (char)('0' + _random.Next(0, 2));
                    if (r == '0')
                        randomString += LowerAlpha.ToString();
                    else
                        randomString += UpperAlpha.ToString();
                }
                else
                {
                    r1 = (char)('0' + _random.Next(0, 3));
                    if (r1 == '0')
                    {
                        randomString += LowerAlpha.ToString();
                    }
                    if (r1 == '1')
                        randomString += UpperAlpha.ToString();
                    if (r1 == '2')
                        randomString += Numeric.ToString();
                }
                len += 1;
            }
            return randomString;
        }
    }
}