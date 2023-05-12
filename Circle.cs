using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using task1;
using static System.Windows.Forms.LinkLabel;

namespace Rasterization
{
    internal class Circle : Element
    {
        int r;
        public Circle(int x0, int y0, int x1, int y1, Color col)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x1 = x1;
            this.y1 = y1;
            this.r = (int)Math.Sqrt(Math.Pow(Math.Abs(x0 - x1), 2) + Math.Pow(Math.Abs(y0 - y1), 2));
            this.type = 1;
            this.color = col;
        }

        public int R
        {
            get { return r; }
            set { r = value; }
        }

        public void CircleDraw(int x, int y, DirectBitmap bitmap, Color col)
        {
            if (x0 + x < bitmap.Width && y0 + y < bitmap.Height)
            {
                bitmap.SetPixel(x0 + x, y0 + y, col);
            }
            if (x0 + x < bitmap.Width && y0 - y >= 0)
            {
                bitmap.SetPixel(x0 + x, y0 - y, col);
            }
            if (x0 - x >= 0 && y0 - y >= 0)
            {
                bitmap.SetPixel(x0 - x, y0 - y, col);
            }
            if (x0 - x >= 0 && y0 + y < bitmap.Height)
            {
                bitmap.SetPixel(x0 - x, y0 + y, col);
            }
            if (x0 + y < bitmap.Width && y0 + x < bitmap.Height)
            {
                bitmap.SetPixel(x0 + y, y0 + x, col);
            }
            if (x0 + y < bitmap.Width && y0 - x >= 0)
            {   
                bitmap.SetPixel(x0 + y, y0 - x, col);
            }
            if (x0 - y >= 0 && y0 - x >= 0)
            {
                bitmap.SetPixel(x0 - y, y0 - x, col);
            }
            if (x0 - y >= 0 && y0 + x < bitmap.Height)
            {
                bitmap.SetPixel(x0 - y, y0 + x, col);
            }
        }

        public override void AntiAlias(DirectBitmap bitmap, Color back)
        {
            Color L = Color;
            Color B = back;
            int x = R;
            int y = 0;
            CircleDraw(x, y, bitmap, L);
            while (x > y)
            {
                y++;
                x = (int)Math.Ceiling(Math.Sqrt(R * R - y * y));
                float T = (float)(Math.Ceiling(Math.Sqrt(R * R - y * y)) - Math.Sqrt(R * R - y * y));
                Color c2 = Color.FromArgb((int)(L.R * (1 - T) + B.R * T), (int)(L.G * (1 - T) + B.G * T), (int)(L.B * (1 - T) + B.B * T));
                Color c1 = Color.FromArgb((int)(L.R * T + B.R * (1 - T)), (int)(L.G * T + B.G * (1 - T)), (int)(L.B * T + B.B * (1 - T)));
                CircleDraw(x, y, bitmap, c2);
                CircleDraw(x - 1, y, bitmap, c1);
            }
        }

        public override void Draw(DirectBitmap bitmap)
        {
            r = (int)Math.Sqrt(Math.Pow(Math.Abs(x0 - x1), 2) + Math.Pow(Math.Abs(y0 - y1), 2));
            int d = 1 - r;
            int x = 0;
            int y = r;
            CircleDraw(x, y, bitmap, color);
            while (y > x)
            {
                if (d < 0)
                    d += 2 * x + 3;
                else
                {
                    d += 2 * x - 2 * y + 5;
                    y--;
                }
                x++;
                CircleDraw(x, y, bitmap, color);
            }
        }
    }
}
