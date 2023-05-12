using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1;

namespace Rasterization
{
    internal class Capsule : Element
    {
        List<Circle> circles;
        List<Line> lines;
        public Capsule(int x0, int y0, int x1, int y1, List<Circle> c, List<Line> l)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x1 = x1;
            this.y1 = y1;
            this.type = 5;
            this.circles = c;
            this.lines = l;
        }
        public override void AntiAlias(DirectBitmap bitmap, Color back)
        {
           
        }

        public override void Draw(DirectBitmap bitmap)
        {
            foreach (var line in lines)
            {
                line.Draw(bitmap);
            }
            foreach (var circle in circles)
            {
                circle.Draw(bitmap);
            }

        }

   
    }
}
