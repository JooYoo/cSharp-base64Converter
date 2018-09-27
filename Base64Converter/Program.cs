using System;
using System.Collections.Generic;
using System.Text;

namespace Base64Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> masterbase64Dec = new List<string>();


            while (true)
            {
                Console.Write("input>");
                var userInput = Console.ReadLine();

                byte[] bytes = Encoding.UTF8.GetBytes(userInput);
                for (int i = 0; i < bytes.Length; i += 3)
                {


                    List<string> subBase64 = ThreeBytesToString(bytes[i], bytes[i + 1], bytes[i + 2]);
                    masterbase64Dec.AddRange(subBase64);

                }

                // Decimal => Base64
                Console.WriteLine();
                Console.Write("Result>");
                foreach (var zeichen in masterbase64Dec)
                {
                    Console.Write(IndexToBaseString(Convert.ToInt32(zeichen)));
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[Press to continue ...]");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static List<string> ThreeBytesToString(byte one, byte two, byte three)
        {
            // get byte in Binary
            var utf1Binary = Convert.ToString(one, 2).PadLeft(8, '0');
            var utf2Binary = Convert.ToString(two, 2).PadLeft(8, '0');
            var utf3Binary = Convert.ToString(three, 2).PadLeft(8, '0');

            // combine
            var masterUtfBinary = utf1Binary + utf2Binary + utf3Binary;

            // get Base64 Binary
            string[] base64Binary = new string[4];
            var counter = 0;
            for (int i = 0; i < masterUtfBinary.Length; i++)
            {
                if (i % 6 != 0 || i == 0)
                {
                    base64Binary[counter] = base64Binary[counter] + masterUtfBinary[i];
                }
                else
                {
                    counter++;
                    base64Binary[counter] = base64Binary[counter] + masterUtfBinary[i];
                }
            }

            // Binary => Decimal
            List<string> base64Dec = new List<string>();
            for (int i = 0; i < base64Binary.Length; i++)
            {
                base64Dec.Add(Convert.ToInt32(base64Binary[i], 2).ToString());
            }

            return base64Dec;
        }

        static string IndexToBaseString(int index)
        {
            string[] base64 = new string[64]
            {
                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                "0","1","2","3","4","5","6","7","8","9",
                "+","/"
            };

            if (base64[index] != null)
            {
                return base64[index];
            }

            return ".";


            //// "A" to "Z"
            //if (index > 64 && index < 91)
            //{

            //  //  return ((char)index).ToString();
            //}

            //// "a" to "z"
            //if (index > 96 && index < 123)
            //{
            //    //return ((char)index).ToString();
            //}

            //// "0" to "9"
            //if (index > 47 && index < 58)
            //{
            //   // return ((char) index).ToString();
            //}

            //// "+"
            //if (index == 43)
            //{
            //   // return "+";
            //}

            //// "/"
            //if (index == 47)
            //{
            //   // return "/";
            //}


            //return ".";
        }
    }
}
