using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1;

namespace Rasterization
{
    abstract class Element
    {
        public int x0;
        public int y0;
        public int x1;
        public int y1;
        public int thickness;
        public int type;
        public Color color;

        public int X0
        {
            get { return x0; }
            set { x0 = value; }
        }

        public int Y0
        {
            get { return y0; }
            set { y0 = value; }
        }

        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        public int Thick
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        abstract public void AntiAlias(DirectBitmap bitmap, Color back);
        abstract public void Draw(DirectBitmap bitmap);
    }
}
