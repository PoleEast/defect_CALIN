using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace defect_CALIN.src
{
    internal class Img_Processing
    {
        /// <summary>
        /// 均質化
        /// </summary>
        /// <param name="files"></param>
        public static async Task<Bitmap> ImageEH(Bitmap bitmap)
        {
            // 開始執行緒
            Task<Bitmap> t = Task.Run(() =>
            {
                int[] histogram = getGrayHistogram(bitmap);
                bitmap = EqualizeImage(bitmap, histogram);
                return bitmap;
            });
      
            return await t;
        }
        private static int[] getGrayHistogram(Bitmap image)
        {
            int[] histogram = new int[256]; // 建立直方圖

            // 計算像素值的直方圖
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image.GetPixel(x, y);
                    int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11); // 轉換成灰度值
                    histogram[grayValue]++;
                }
            }
            Console.WriteLine("直方圖完成");
            return histogram;
        }
        private static Bitmap EqualizeImage(Bitmap image, int[] histogram)
        {
            // 計算累積分佈函數
            int totalPixels = image.Width * image.Height;
            int cumulative = 0;
            int[] mapping = new int[256];

            for (int i = 0; i < 256; i++)
            {
                cumulative += histogram[i];
                mapping[i] = (int)(((float)cumulative / totalPixels) * 255);
            }

            // 對每個像素進行均質化
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11); // 轉換成灰度值
                    int newGrayValue = mapping[grayValue];
                    Color newPixel = Color.FromArgb(newGrayValue, newGrayValue, newGrayValue);
                    image.SetPixel(x, y, newPixel);
                }
            }
            Console.WriteLine("圖片均質化完成");
            return image;
        }
    }
}