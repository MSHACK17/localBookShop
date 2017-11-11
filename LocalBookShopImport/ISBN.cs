using System;
using System.Text;

namespace LocalBookShopImport
{
    public class ISBN
    {
        public static string ConvertIsbn10ToIsbn13(string isbn10)
        {
            if (isbn10.Contains("-"))
            {
                isbn10.Replace("-", string.Empty);
            }
            Char[] isbn10arr;
            UInt16[] isbn13;
            StringBuilder sb;

            isbn10arr = isbn10.ToCharArray();
            isbn13 = new UInt16[13];
            isbn13[0] = 9;
            isbn13[1] = 7;
            isbn13[2] = 8;
            for(UInt16 i = 0, j = 3; i < 9; i++, j++)
            {
                isbn13[j] = UInt16.Parse(isbn10arr[i].ToString());
            }
            isbn13[12] = (UInt16)((10 - ((isbn13[0] + isbn13[2] + isbn13[4] + isbn13[6]
                                          + isbn13[8] + isbn13[10] + (3 * (isbn13[1] + isbn13[3] + isbn13[5] + isbn13[7]
                                                                           + isbn13[9] + isbn13[11]))) % 10)) % 10);
            sb = new StringBuilder();
            for(UInt16 i = 0; i < 13; i++)
            {
                sb.Append(isbn13[i].ToString());
            }
            return (sb.ToString());
        }

        public static string ConvertIsbn13ToIsbn10(string isbn13)
        {
            if (isbn13.Contains("-"))
            {
                isbn13 = isbn13.Replace("-", string.Empty);
            }
            Char[] isbn13arr;
            UInt16[] isbn10;
            StringBuilder sb;
            Int32 checksum;

            isbn13arr = isbn13.ToCharArray();
            isbn10 = new UInt16[10];
            for(UInt16 i = 3, j = 0; i < 12; i++, j++)
            {
                isbn10[j] = UInt16.Parse(isbn13arr[i].ToString());
            }
            checksum = 0;
            sb = new StringBuilder();
            for(UInt16 i = 0; i < 9; i++)
            {
                checksum += isbn10[i] * (i + 1);
                sb.Append(isbn10[i].ToString());
            }
            checksum %= 11;
            if(checksum == 10)
            {
                sb.Append("X");
            }
            else
            {
                sb.Append(checksum.ToString());
            }
            return (sb.ToString());
        }
    }
}