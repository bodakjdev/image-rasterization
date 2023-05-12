using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using task1;

namespace Rasterization
{
    internal class Line : Element
    {

        public Line(int x0, int y0, int x1, int y1, int thickness, Color col)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x1 = x1;
            this.y1 = y1;
            this.thickness = thickness;
            this.type = 0;
            this.color = col;
        }

        void swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        int iPartOfNumber(float x)
        {
            return (int)x;
            
        }

        float fPartOfNumber(float x)
        {
            return x - iPartOfNumber(x);
        }
        public override void AntiAlias(DirectBitmap bitmap, Color back)
        {
            Color L = Color;
            Color B = back;
            int absDY = Math.Abs(y1 - y0);
            int absDX = Math.Abs(x1 - x0);
            if (absDY < absDX)
            {
                if (x0 > x1)
                {
                    int tempx = x0;
                    int tempy = y0;
                    y0 = y1;
                    x0 = x1;
                }
                else
                {

                }
            }
            else
            {
                if (y0 > y1)
                {
                    int tempx = x0;
                    int tempy = y0;
                    y0 = y1;
                    x0 = x1;
                }
            }
            
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            if (dx == 0.0)
                gradient = 1;

            int xb = x0;
            int xf = x1;
            float intersectY = y0;

            if (absDY > absDX)
            {
                
                for (int x = xb; x <= xf; x++)
                {
                    Color c1 = Color.FromArgb((int)(L.R * (1 - (float)fPartOfNumber(intersectY)) + B.R * (float)fPartOfNumber(intersectY)), (int)(L.G * (1 - (float)fPartOfNumber(intersectY)) + B.G * (float)fPartOfNumber(intersectY)), (int)(L.B * (1 - (float)fPartOfNumber(intersectY)) + B.B * (float)fPartOfNumber(intersectY)));
                    Color c2 = Color.FromArgb((int)(L.R * (float)fPartOfNumber(intersectY) + B.R * (1 - (float)fPartOfNumber(intersectY))), (int)(L.G * (float)fPartOfNumber(intersectY) + B.G * (1 - (float)fPartOfNumber(intersectY))), (int)(L.B * (float)fPartOfNumber(intersectY) + B.B * (1 - (float)fPartOfNumber(intersectY))));
                    bitmap.SetPixel(iPartOfNumber(intersectY), x,  c1);
                    bitmap.SetPixel(iPartOfNumber(intersectY) - 1, x,  c2);
                    intersectY += gradient;
                }
            }
            else
            {
                
                for (int x = xb; x <= xf; x++)
                {
                    Color c1 = Color.FromArgb((int)(L.R * (1 - (float)fPartOfNumber(intersectY)) + B.R * (float)fPartOfNumber(intersectY)), (int)(L.G * (1 - (float)fPartOfNumber(intersectY)) + B.G * (float)fPartOfNumber(intersectY)), (int)(L.B * (1 - (float)fPartOfNumber(intersectY)) + B.B * (float)fPartOfNumber(intersectY)));
                    Color c2 = Color.FromArgb((int)(L.R * (float)fPartOfNumber(intersectY) + B.R * (1 - (float)fPartOfNumber(intersectY))), (int)(L.G * (float)fPartOfNumber(intersectY) + B.G * (1 - (float)fPartOfNumber(intersectY))), (int)(L.B * (float)fPartOfNumber(intersectY) + B.B * (1 - (float)fPartOfNumber(intersectY))));
                    bitmap.SetPixel(x, iPartOfNumber(intersectY), c1);
                    bitmap.SetPixel(x, iPartOfNumber(intersectY) - 1, c2);
                    intersectY += gradient;
                }
            }
        }

        public override void Draw(DirectBitmap bitmap)
        {
            int absDY = Math.Abs(y1 - y0);
            int absDX = Math.Abs(x1 - x0);
            if (absDY < absDX)
            {

                if (x0 > x1)
                {
                    plotLineLow(x1, y1, x0, y0, thickness, color, bitmap);
                }
                else
                {
                    plotLineLow(x0, y0, x1, y1, thickness, color, bitmap);
                }
            }
            else
            {
                if (y0 > y1)
                {
                    plotLineHigh(x1, y1, x0, y0, thickness, color, bitmap);
                }
                else
                {
                    plotLineHigh(x0, y0, x1, y1, thickness, color, bitmap);
                }
            }

        }

        public static void plotLineLow(int x0, int y0, int x1, int y1, int t, Color col, DirectBitmap bitmap)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            int D = 2 * dy - dx;
            int yb = y0;
            int yf = y1;
            int xb = x0;
            int xf = x1;

            for (int i = 0; i < t; i++)
            {
                bitmap.SetPixel(xf, yf + i, col);
                bitmap.SetPixel(xb, yb + i, col);
                bitmap.SetPixel(xf, yf - i, col);
                bitmap.SetPixel(xb, yb - i, col);
            }
            

            while (xb < xf)
            {
                xb++;
                xf--;
                if (D > 0)
                {
                    yb = yb + yi;
                    yf = yf - yi;
                    D = D + (2 * (dy - dx));
                }
                else
                {
                    D = D + 2 * dy;
                }
                for (int i = 0; i < t; i++)
                {
                    bitmap.SetPixel(xf, yf + i, col);
                    bitmap.SetPixel(xb, yb + i, col);
                    bitmap.SetPixel(xf, yf - i, col);
                    bitmap.SetPixel(xb, yb - i, col);
                }
            }
        }
        public static void plotLineHigh(int x0, int y0, int x1, int y1, int t, Color col, DirectBitmap bitmap)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            int D = 2 * dx - dy;
            int xb = x0;
            int xf = x1;
            int yb = y0;
            int yf = y1;

            for (int i = 0; i < t; i++)
            {
                bitmap.SetPixel(xf + i, yf, col);
                bitmap.SetPixel(xb + i, yb, col);
                bitmap.SetPixel(xf - i, yf, col);
                bitmap.SetPixel(xb - i, yb, col);
            }
            while (yb < yf)
            {
                yb++;
                yf--;
                if (D > 0)
                {
                    xb = xb + xi;
                    xf = xf - xi;
                    D = D + (2 * (dx - dy));
                }
                else
                {
                    D = D + 2 * dx;
                }
                for (int i = 0; i < t; i++)
                {
                    bitmap.SetPixel(xf + i, yf, col);
                    bitmap.SetPixel(xb + i, yb, col);   
                    bitmap.SetPixel(xf - i, yf, col);
                    bitmap.SetPixel(xb - i, yb, col);
                }
            }
        }
    }
}
