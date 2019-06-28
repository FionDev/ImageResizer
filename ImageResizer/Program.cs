using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        private static string SourcePath = Path.Combine(Environment.CurrentDirectory, "images");
        static void Main(string[] args)
        {

            TimingNotP();
            TimingP();


        }

        /// <summary>
        /// 計時圖片的縮放作業
        /// </summary>
        static void TimingNotP()
        {
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output-np");
            ImageProcess imageProcess = new ImageProcess();
            

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(SourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"並行花費時間: {sw.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// 計時圖片的縮放作業(平行)
        /// </summary>
        static void TimingP()
        {
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output-p");
            ImageProcess imageProcess = new ImageProcess();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages_Parallel(SourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"平行花費時間: {sw.ElapsedMilliseconds} ms");


        }
    }
}
