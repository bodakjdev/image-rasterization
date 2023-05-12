using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }

        public static DirectBitmap Maker(PictureBox pictureBoxAfter)
        {
            DirectBitmap img = new DirectBitmap(pictureBoxAfter.Image.Width, pictureBoxAfter.Image.Height);
            using (Graphics g = Graphics.FromImage(img.Bitmap))
            {
                g.DrawImage(pictureBoxAfter.Image, 0, 0, img.Width, img.Height);
            }
            return img;
        }

        public static void ImageSet(DirectBitmap img, PictureBox pictureBoxAfter)
        {
            Bitmap final = (Bitmap)img.Bitmap.Clone();
            img.Dispose();
            pictureBoxAfter.Image = final;
        }

        public static implicit operator Image(DirectBitmap v)
        {
            throw new NotImplementedException();
        }
    }
}

