using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1;

namespace Rasterization
{
    internal class Polygon : Element
    {
        List<Line> lines;
        int numoflines;
        public Polygon(List<Line> lines, int thickness, Color col)
        {
            this.lines = new List<Line>(lines);
            this.thickness = thickness;
            this.type = 2;
            this.color = col;
            this.numoflines = lines.Count();
            foreach (var line in lines)
            {
                line.Thick = thickness;
                line.Color = col;
            }
        }

        public List<Line> Lines
        {
            get { return lines; }
            set { lines = value; }
        }

        public int NumOfLines
        {
            get { return numoflines; }
            set { numoflines = value; }
        }

        public override void Draw(DirectBitmap bitmap)
        {
            foreach (var line in lines) { 
                line.Draw(bitmap);
            }
        }
        public override void AntiAlias(DirectBitmap bitmap, Color back)
        {
            foreach (var line in lines)
            {
                line.AntiAlias(bitmap, color);
            }
        }

    }
    
}
