using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageToClipboard
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Copies the image from the specified path to the clipboard.");
                Console.Error.WriteLine();
                Console.Error.WriteLine(@"Usage: ImageToClipboard.exe path\to\image.jpg");
                return 1;
            }

            var path = Path.GetFullPath(args[0]);
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File does not exist: {path}");
                return 2;
            }

            var image = Bitmap.FromFile(path);
            Clipboard.SetImage(image);
            return 0;
        }
    }
}
