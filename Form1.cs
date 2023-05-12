using Microsoft.VisualBasic.Devices;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Xml.Linq;
using task1;
using static System.Formats.Asn1.AsnWriter;

namespace Rasterization
{
    public partial class Form1 : Form
    {
        List<Element> elements;
        List<Line> polilines;
        List<Circle> capsulecircles;
        List<Line> capsulelines;
        DirectBitmap bitmap;
        bool start = true;
        int action = 0;
        bool polyedit = false, antialias = false;
        int polywhich;
        Element currEl;
        double D = 60;
        public Form1()
        {
            InitializeComponent();
            elements = new List<Element>();
            polilines = new List<Line>();
            bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
            pictureBoxSheet.Image = bitmap.Bitmap;
        }

        private void pictureBoxSheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (!start)
            {
                if (action == 2)
                {
                    Line line = polilines.Last();
                    line.X1 = e.X;
                    line.Y1 = e.Y;
                    bitmap.Dispose();
                    bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                    for (int i = 0; i < polilines.Count(); i++)
                    {
                        polilines[i].Draw(bitmap);
                    }
                    for (int i = 0; i < elements.Count(); i++)
                    {
                        elements[i].Draw(bitmap);
                    }
                    pictureBoxSheet.Image = bitmap.Bitmap;
                }
                else if (action == 4)
                {
                    Element element = elements.Last();
                    if (element.Type == 2)
                    {
                        for (int j = 0; j < polilines.Count(); j++)
                        {
                            if (j == 0)
                            {
                                polilines[j].X1 = e.X + (polilines[j].X1 - polilines[j].X0);
                                polilines[j].Y1 = e.Y + (polilines[j].Y1 - polilines[j].Y0);
                                polilines[j].X0 = e.X;
                                polilines[j].Y0 = e.Y;
                            }
                            else
                            {
                                polilines[j].X1 = polilines[j - 1].X1 + (polilines[j].X1 - polilines[j].X0);
                                polilines[j].Y1 = polilines[j - 1].Y1 + (polilines[j].Y1 - polilines[j].Y0);
                                polilines[j].X0 = polilines[j - 1].X1;
                                polilines[j].Y0 = polilines[j - 1].Y1;
                            }
                        }
                        elements.Remove(element);
                        elements.Add(new Polygon(polilines, element.Thick, element.Color));
                        bitmap.Dispose();
                        bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                        for (int i = 0; i < polilines.Count(); i++)
                        {
                            polilines[i].Draw(bitmap);
                        }
                        for (int i = 0; i < elements.Count(); i++)
                        {
                            elements[i].Draw(bitmap);
                        }
                        pictureBoxSheet.Image = bitmap.Bitmap;
                    }
                    else
                    {
                        element.X1 = e.X + (element.X1 - element.X0);
                        element.Y1 = e.Y + (element.Y1 - element.Y0);
                        element.X0 = e.X;
                        element.Y0 = e.Y;
                        bitmap.Dispose();
                        bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                        for (int i = 0; i < elements.Count(); i++)
                        {
                            elements[i].Draw(bitmap);
                        }
                        pictureBoxSheet.Image = bitmap.Bitmap;
                    }
                }
                else if (action == 5)
                {

                }
                else if (polyedit)
                {
                    Element element = elements.Last();
                    Line currline = polilines[polilines.Count() - 1];
                    Line prevline = polilines[polilines.Count() - 2];
                    currline.X0 = e.X;
                    currline.Y0 = e.Y;
                    prevline.X1 = e.X;
                    prevline.Y1 = e.Y;
                    elements.Remove(element);
                    elements.Add(new Polygon(polilines, element.Thick, element.Color));
                    bitmap.Dispose();
                    bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                    for (int i = 0; i < polilines.Count(); i++)
                    {
                        polilines[i].Draw(bitmap);
                    }
                    for (int i = 0; i < elements.Count(); i++)
                    {
                        elements[i].Draw(bitmap);
                    }
                    pictureBoxSheet.Image = bitmap.Bitmap;
                }
                else
                {
                    Element element = elements.Last();
                    element.X1 = e.X;
                    element.Y1 = e.Y;
                    bitmap.Dispose();
                    bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                    for (int i = 0; i < elements.Count(); i++)
                    {
                        elements[i].Draw(bitmap);
                    }
                    pictureBoxSheet.Image = bitmap.Bitmap;
                }
            }
        }

        private bool IsClose(int Mx, int My, int Px, int Py)
        {
            if ((Math.Abs(Mx - Px) < 20) && (Math.Abs(My - Py) < 20))
            {
                return true;
            }
            return false;
        }

        private bool IsCloseCircle(int Mx, int My, int Px, int Py, int Cx, int Cy)
        {
            int R = (int)Math.Sqrt(Math.Pow(Math.Abs(Cx - Px), 2) + Math.Pow(Math.Abs(Cy - Py), 2));
            int d = (int)Math.Sqrt(Math.Pow(Math.Abs(Cx - Mx), 2) + Math.Pow(Math.Abs(Cy - My), 2));
            if (d < R + 20 && d > R - 20)
            {
                return true;
            }
            return false;
        }

        private void pictureBoxSheet_MouseClick(object sender, MouseEventArgs e)
        {
            switch (action)
            {
                case 0:
                    if (start)
                    {
                        elements.Add(new Line(e.X, e.Y, e.X, e.Y, (int)numericUpDownThickness.Value, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                        start = false;
                    }
                    else
                    {
                        start = true;
                    }
                    break;
                case 1:
                    if (start)
                    {
                        elements.Add(new Circle(e.X, e.Y, e.X, e.Y, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                        start = false;
                    }
                    else
                    {
                        start = true;
                    }
                    break;
                case 2:
                    if (start)
                    {
                        polilines.Add(new Line(e.X, e.Y, e.X, e.Y, (int)numericUpDownThickness.Value, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                        start = false;
                    }
                    else
                    {
                        Line line = polilines.First();
                        Line lastline = polilines.Last();
                        int t = (int)numericUpDownThickness.Value;
                        Color col = Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                        if (IsClose(e.X, e.Y, line.x0, line.y0))
                        {
                            start = true;
                            polilines.RemoveAt(polilines.Count - 1);
                            polilines.Add(new Line(lastline.X0, lastline.Y0, line.X0, line.Y0, t, col));
                            elements.Add(new Polygon(polilines, t, col));
                            bitmap.Dispose();
                            bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                            for (int i = 0; i < polilines.Count(); i++)
                            {
                                polilines[i].Draw(bitmap);
                            }
                            for (int i = 0; i < elements.Count(); i++)
                            {
                                elements[i].Draw(bitmap);
                            }
                            pictureBoxSheet.Image = bitmap.Bitmap;
                            polilines.RemoveRange(0, polilines.Count);
                        }
                        else
                        {
                            polilines.Add(new Line(e.X, e.Y, e.X, e.Y, (int)numericUpDownThickness.Value, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                        }
                    }
                    break;
                case 3:
                    if (start)
                    {
                        foreach (var element in elements)
                        {
                            if (element.Type == 0)
                            {
                                if (IsClose(e.X, e.Y, element.X0, element.Y0))
                                {

                                    start = false;
                                    elements.Remove(element);
                                    elements.Add(new Line(element.X1, element.Y1, e.X, e.Y, (int)numericUpDownThickness.Value, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                                    currEl = elements.Last();
                                    break;
                                }
                                else if (IsClose(e.X, e.Y, element.X1, element.Y1))
                                {
                                    //currEl = element;
                                    start = false;
                                    elements.Remove(element);
                                    elements.Add(new Line(element.X0, element.Y0, e.X, e.Y, (int)numericUpDownThickness.Value, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                                    currEl = elements.Last();
                                    break;
                                }
                            }
                            else if (element.Type == 1)
                            {
                                if (IsCloseCircle(e.X, e.Y, element.X1, element.Y1, element.X0, element.Y0))
                                {
                                    start = false;
                                    elements.Remove(element);
                                    elements.Add(new Circle(element.X0, element.Y0, e.X, e.Y, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                                    currEl = elements.Last();
                                    break;
                                }

                            }
                            else if (element.Type == 2)
                            {
                                Polygon poly = (Polygon)element;
                                polilines = new List<Line>(poly.Lines);
                                Line currline, nextline;
                                int t = (int)numericUpDownThickness.Value;
                                Color col = Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                                for (int i = 0; i < polilines.Count(); i++)
                                {
                                    polilines[i].thickness = t;
                                    if (IsClose(e.X, e.Y, polilines[i].X1, polilines[i].Y1))
                                    {
                                        start = false;
                                        polyedit = true;
                                        currline = polilines[i];
                                        polilines.RemoveAt(i);
                                        if (i > polilines.Count() - 2)
                                        {
                                            nextline = polilines[0];
                                            polilines.RemoveAt(0);
                                        }
                                        else
                                        {
                                            nextline = polilines[i];
                                            polilines.RemoveAt(i);
                                        }
                                        polilines.Add(new Line(currline.X0, currline.Y0, e.X, e.Y, t, col));
                                        polilines.Add(new Line(e.X, e.Y, nextline.X1, nextline.Y1, t, col));
                                        break;
                                    }
                                }
                                elements.Remove(element);
                                elements.Add(new Polygon(polilines, t, col));
                                currEl = elements.Last();
                                break;
                            }
                        }

                    }
                    else
                    {
                        polilines.RemoveRange(0, polilines.Count());
                        polyedit = false;
                        start = true;
                    }
                    break;
                case 4:
                    if (start)
                    {
                        foreach (var element in elements)
                        {
                            if (element.Type == 0)
                            {
                                if (IsClose(e.X, e.Y, element.X0, element.Y0))
                                {
                                    start = false;
                                    elements.Remove(element);
                                    elements.Add(new Line(e.X, e.Y, e.X + (element.X1 - element.X0), e.Y + (element.Y1 - element.Y0), element.thickness, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                                    currEl = elements.Last();
                                    break;
                                }
                                else if (IsClose(e.X, e.Y, element.X1, element.Y1))
                                {
                                    start = false;
                                    elements.Remove(element);
                                    elements.Add(new Line(e.X + (element.X1 - element.X0), e.Y + (element.Y1 - element.Y0), e.X, e.Y, element.thickness, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                                    currEl = elements.Last();
                                    break;
                                }
                            }
                            if (element.Type == 1)
                            {
                                if (IsCloseCircle(e.X, e.Y, element.X1, element.Y1, element.X0, element.Y0))
                                {
                                    start = false;
                                    elements.Remove(element);
                                    elements.Add(new Circle(e.X, e.Y, e.X + (element.X1 - element.X0), e.Y + (element.Y1 - element.Y0), Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                                    currEl = elements.Last();
                                    break;
                                }

                            }
                            else if (element.Type == 2)
                            {
                                Polygon poly = (Polygon)element;
                                for (int i = 0; i < poly.Lines.Count(); i++)
                                {
                                    if (IsClose(e.X, e.Y, poly.Lines[i].X1, poly.Lines[i].Y1))
                                    {
                                        polilines = new List<Line>();
                                        for (int j = 0; j < poly.Lines.Count(); j++)
                                        {
                                            if (j == 0)
                                            {
                                                polilines.Add(new Line(e.X, e.Y, e.X + (poly.Lines[j].X1 - poly.Lines[j].X0), e.Y + (poly.Lines[j].Y1 - poly.Lines[j].Y0), element.thickness, element.Color));
                                            }
                                            else
                                            {
                                                polilines.Add(new Line(poly.Lines[j - 1].X1, poly.Lines[j - 1].Y1, poly.Lines[j - 1].X1 + (poly.Lines[j].X1 - poly.Lines[j].X0), poly.Lines[j - 1].Y1 + (poly.Lines[j].Y1 - poly.Lines[j].Y0), element.thickness, element.Color));
                                            }
                                        }
                                        start = false;
                                        polilines.Add(new Line(e.X, e.Y, e.X + (element.X1 - element.X0), e.Y + (element.Y1 - element.Y0), element.thickness, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                                        currEl = elements.Last();
                                        break;
                                    }
                                }
                                elements.Remove(element);
                                elements.Add(new Polygon(polilines, element.Thick, element.Color));
                                currEl = elements.Last();
                                break;
                            }
                        }

                    }
                    else
                    {
                        polilines.RemoveRange(0, polilines.Count());
                        polyedit = false;
                        start = true;
                    }
                    break;
                case 5:
                    int R = (int)D / 2;
                    if (start)
                    {
                        capsulelines = new List<Line>();
                        capsulecircles = new List<Circle>();
                        capsulecircles.Add(new Circle(e.X, e.Y, e.X + R, e.Y + R, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                        start = false;
                    }
                    else
                    {

                        capsulecircles.Add(new Circle(e.X, e.Y, e.X + R, e.Y + R, Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text))));
                        double xd = capsulecircles[1].X0 - capsulecircles[0].X0;
                        double yd = capsulecircles[1].Y0 - capsulecircles[0].Y0;
                        double unitx = xd / Math.Sqrt(Math.Pow(xd, 2) + Math.Pow(yd, 2));
                        double unity = yd / Math.Sqrt(Math.Pow(xd, 2) + Math.Pow(yd, 2));
                        double newx1 = unity * capsulecircles[0].R;
                        double newy1 = -unitx * capsulecircles[0].R;
                        double newx2 = -newx1;
                        double newy2 = -newy1;
                        capsulelines.Add(new Line(capsulecircles[0].X0 + (int)newx1, capsulecircles[0].Y0 + (int)newy1, capsulecircles[1].X0 + (int)newx1, capsulecircles[1].Y0 + (int)newy1, 1, Color.Black));
                        capsulelines.Add(new Line(capsulecircles[0].X0 + (int)newx2, capsulecircles[0].Y0 + (int)newy2, capsulecircles[1].X0 + (int)newx2, capsulecircles[1].Y0 + (int)newy2, 1, Color.Black));
                        elements.Add(new Capsule(capsulecircles[0].X0, capsulecircles[0].Y0, capsulecircles[1].X0, capsulecircles[1].Y0, capsulecircles, capsulelines));
                        start = false;
                        bitmap.Dispose();
                        bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                        for (int i = 0; i < elements.Count(); i++)
                        {
                            elements[i].Draw(bitmap);
                        }
                        pictureBoxSheet.Image = bitmap.Bitmap;
                        start = true;
                    }
                    break;
                default: break;
            }
        }

        private void pictureBoxSheet_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            action = 0;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            action = 1;
        }

        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            action = 2;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            action = 3;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            elements.Remove(currEl);
            start = true;
            bitmap.Dispose();
            bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
            for (int i = 0; i < elements.Count(); i++)
            {
                elements[i].Draw(bitmap);
            }
            pictureBoxSheet.Image = bitmap.Bitmap;
        }

        private void numericUpDownThickness_ValueChanged(object sender, EventArgs e)
        {
            if (action == 3)
            {
                currEl.thickness = (int)numericUpDownThickness.Value;
                bitmap.Dispose();
                bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                for (int i = 0; i < elements.Count(); i++)
                {
                    elements[i].Draw(bitmap);
                }
                pictureBoxSheet.Image = bitmap.Bitmap;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ColorAdjust(TextBox tb)
        {
            int value = int.Parse(tb.Text);
            if (value < 0)
            {
                tb.Text = "0";
            }
            else if (value > 255)
            {
                tb.Text = "255";
            }
        }

        private void textBoxRed_TextChanged(object sender, EventArgs e)
        {
            ColorAdjust(textBoxRed);
        }

        private void textBoxGreen_TextChanged(object sender, EventArgs e)
        {
            ColorAdjust(textBoxGreen);
        }

        private void textBoxBlue_TextChanged(object sender, EventArgs e)
        {
            ColorAdjust(textBoxBlue);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            elements.Clear();
            bitmap.Dispose();
            bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
            for (int i = 0; i < elements.Count(); i++)
            {
                elements[i].Draw(bitmap);
            }
            pictureBoxSheet.Image = bitmap.Bitmap;
        }

        private void buttonAntiAl_Click(object sender, EventArgs e)
        {
            antialias = !antialias;
            bitmap.Dispose();
            bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
            if (antialias)
            {
                for (int i = 0; i < elements.Count(); i++)
                {
                    elements[i].AntiAlias(bitmap, pictureBoxSheet.BackColor);
                }
            }
            else
            {
                for (int i = 0; i < elements.Count(); i++)
                {
                    elements[i].Draw(bitmap);
                }
            }

            pictureBoxSheet.Image = bitmap.Bitmap;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt"; // Set filter for txt files
            saveFileDialog.Title = "Save shapes";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var element in elements)
                    {
                        writer.WriteLine($"type: {element.Type}");
                        writer.WriteLine($"thickness: {element.Thick}");
                        writer.WriteLine($"color: {element.Color.R}");
                        writer.WriteLine($"color: {element.Color.G}");
                        writer.WriteLine($"color: {element.Color.B}");
                        if (element.Type == 2)
                        {
                            Polygon poly = (Polygon)element;
                            writer.WriteLine($"Lines: {poly.NumOfLines}");
                            foreach (var line in poly.Lines)
                            {
                                writer.WriteLine($"x0: {line.X0}");
                                writer.WriteLine($"y0: {line.Y0}");
                                writer.WriteLine($"x1: {line.X1}");
                                writer.WriteLine($"y1: {line.Y1}");
                            }
                        }
                        else
                        {
                            writer.WriteLine($"x0: {element.X0}");
                            writer.WriteLine($"y0: {element.Y0}");
                            writer.WriteLine($"x1: {element.X1}");
                            writer.WriteLine($"y1: {element.Y1}");
                        }
                    }
                }
            }

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt"; // Set filter for txt files
            openFileDialog.Title = "Load shapes";
            DialogResult result = openFileDialog.ShowDialog();
            int type, x0, y0, x1, y1, thickness, numoflines, r, g, b;
            Color color;
            string read;
            if (result == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    while ((read = reader.ReadLine()) != null)
                    {
                        type = Convert.ToInt32(read.Split(':')[1].Trim());
                        thickness = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                        r = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                        g = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                        b = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                        color = Color.FromArgb(r, g, b);
                        if (type == 2)
                        {
                            numoflines = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                            List<Line> lines = new List<Line>();
                            for (int i = 0; i < numoflines; i++)
                            {
                                x0 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                                y0 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                                x1 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                                y1 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                                lines.Add(new Line(x0, y0, x1, y1, thickness, color));
                            }
                            elements.Add(new Polygon(lines, thickness, color));
                        }
                        else
                        {
                            x0 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                            y0 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                            x1 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                            y1 = Convert.ToInt32(reader.ReadLine().Split(':')[1].Trim());
                            if (type == 1)
                            {
                                elements.Add(new Circle(x0, y0, x1, y1, color));
                            }
                            else if (type == 0)
                            {
                                elements.Add(new Line(x0, y0, x1, y1, thickness, color));
                            }
                        }
                    }
                    bitmap.Dispose();
                    bitmap = new DirectBitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
                    for (int i = 0; i < elements.Count(); i++)
                    {
                        elements[i].Draw(bitmap);
                    }
                    pictureBoxSheet.Image = bitmap.Bitmap;

                }
            }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            action = 4;
        }

        private void buttonCapsule_Click(object sender, EventArgs e)
        {
            action = 5;
        }
    }
}