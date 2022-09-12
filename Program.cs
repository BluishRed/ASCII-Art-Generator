using System;
using System.Drawing;

namespace ASCII_Art_Generator
{
    internal class Program
    {
        static void Main(string[] filename)
        {
            Console.WriteLine(GenerateAscii(filename[0]));
        }

        private static string GenerateAscii(string filename)
        {
            char[] chars = { ' ', '.', ',', '+', '*', '?', '%', '&', '@' };

            Bitmap bitmap = new Bitmap(filename);

            Console.SetBufferSize(Math.Max(bitmap.Width, Console.LargestWindowWidth), Math.Max(bitmap.Height, Console.LargestWindowHeight));

            Color[,] data = new Color[bitmap.Width, bitmap.Height];

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    data[x, y] = bitmap.GetPixel(x, y);
                }
            }

            char[,] ascii = new char[data.GetLength(0), data.GetLength(1)];

            for (int y = 0; y < data.GetLength(1); y++)
            {
                for (int x = 0; x < data.GetLength(0); x++)
                {
                    float brightness = data[x, y].GetBrightness();
                    ascii[x, y] = chars[(int)(brightness * (chars.Length - 1))];
                }
            }

            string output = "";

            for (int y = 0; y < ascii.GetLength(1); y++)
            {
                for (int x = 0; x < ascii.GetLength(0); x++)
                {
                    output += ascii[x, y];
                    output += ascii[x, y];
                }

                output += "\n";
            }

            return output;
        }
    }
}