using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Bloq
{
    [Serializable]
    public class Data
    {
        public int Width { get; }
        public int height { get; }
        public List<Block> Bloqs { get; }
        public List<Node> Nodes { get; }

        public Data(int W, int H, List<Block> bloqs, List<Node> nodes)
        {
            Width = W;
            height = H;
            Bloqs = bloqs;
            Nodes = nodes;
        }
    }

    [Serializable]
    public abstract class Block
    {
        protected Node[] nodes;
        protected Point center;
        protected bool isDashed = false;
        protected readonly int blockWidth, blockHeight;

        public virtual Point Center { get => center; set => center = value; }
        public virtual string Text { get; set; }
        public Node[] Nodes { get => nodes; }
        public bool IsDashed { get => isDashed; set => isDashed = value; }

        public Block(Point p, int A, int B)
        {
            center = p;
            blockWidth = A;
            blockHeight = B;
        }

        public abstract void Draw(Bitmap drawArea, int a, int b);
    }

    [Serializable]
    public class BloqD : Block
    {
        private const string name = "decision block";
        private const string trueText = "T";
        private const string falseText = "F";
        private Node nodeTrue, nodeFalse, nodeUp;

        public override Point Center
        {
            get => center;
            set
            {
                center = value;
                nodeTrue.Center = new Point(center.X - blockWidth / 2, center.Y);
                nodeFalse.Center = new Point(center.X + blockWidth / 2, center.Y);
                nodeUp.Center = new Point(center.X, center.Y - blockHeight / 2);
            }
        }

        public BloqD(Point p, Node NT, Node NF, Node NU, int A, int B) : base(p, A, B)
        {
            Text = name;
            nodeTrue = NT;
            nodeFalse = NF;
            nodeUp = NU;
            nodes = new Node[3];
            nodes[0] = NT;
            nodes[1] = NF;
            nodes[2] = NU;
        }

        public override void Draw(Bitmap drawArea, int a, int b)
        {
            using (Font font = new Font("Arial", 8, FontStyle.Regular))
            {
                using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                {
                    int x = center.X, y = center.Y;

                    using (Graphics g = Graphics.FromImage(drawArea))
                    {
                        using (Pen pen = new Pen(Brushes.Black, 2))
                        {
                            if (isDashed)
                            {
                                pen.DashPattern = new float[] { 2, 1 };
                            }
                            Point[] p =
                            {
                            new Point(x, y - b/2),
                            new Point(x + a/2, y),
                            new Point(x, y + b/2),
                            new Point(x - a/2, y)
                            };

                            g.FillPolygon(Brushes.White, p);
                            g.DrawPolygon(pen, p);
                        }


                        nodeUp.Draw(drawArea);

                        SizeF Textsize = new SizeF();
                        nodeTrue.Draw(drawArea);
                        Textsize = g.MeasureString(trueText, font);
                        g.DrawString(trueText, font, drawBrush, x - a / 2 - Textsize.Width / 2, y - 20);

                        nodeFalse.Draw(drawArea);
                        Textsize = g.MeasureString(trueText, font);
                        g.DrawString(falseText, font, drawBrush, x + a / 2 - Textsize.Width / 2, y - 20);

                        StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
                        format1.Alignment = StringAlignment.Center;
                        format1.LineAlignment = StringAlignment.Center;
                        RectangleF rect = new RectangleF(x - a / 4, y - b / 4, a / 2, b / 2);
                        g.DrawString(Text, font, drawBrush, rect, format1);
                        format1.Dispose();
                    }
                }
            }


        }
    }

    [Serializable]
    public class BloqO : Block
    {
        private const string name = "operation block";
        Node nodeUp, nodeDown;

        public override Point Center
        {
            get => center;
            set
            {
                center = value;
                nodeUp.Center = new Point(center.X, center.Y - blockHeight / 2);
                nodeDown.Center = new Point(center.X, center.Y + blockHeight / 2);
            }
        }

        public BloqO(Point p, Node NU, Node ND, int A, int B) : base(p, A, B)
        {
            Text = name;
            nodeUp = NU;
            nodeDown = ND;
            nodes = new Node[2];
            nodes[0] = NU;
            nodes[1] = ND;
        }

        public override void Draw(Bitmap drawArea, int a, int b)
        {
            Font f = new Font("Arial", 8, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int x = center.X, y = center.Y;

            using (Graphics g = Graphics.FromImage(drawArea))
            {
                Pen pen = new Pen(Brushes.Black, 2);
                if (isDashed)
                {
                    pen.DashPattern = new float[] { 2, 1 };
                }
                Rectangle rect = new Rectangle(x - a / 2, y - b / 2, a, b);
                g.FillRectangle(Brushes.White, rect);
                g.DrawRectangle(pen, rect);

                nodeUp.Draw(drawArea);
                nodeDown.Draw(drawArea);

                StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
                format1.Alignment = StringAlignment.Center;
                format1.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, f, drawBrush, (RectangleF)rect, format1);
                pen.Dispose();
                format1.Dispose();
            }
            f.Dispose();
            drawBrush.Dispose();
        }
    }
    [Serializable]
    public class BloqStart : Block
    {
        private const string name = "START";
        Node node;
        public override Point Center
        {
            get => center;
            set
            {
                center = value;
                node.Center = new Point(center.X, center.Y + blockHeight / 2);
            }
        }
        public new string Text { get; }
        public BloqStart(Point p, Node n, int A, int B) : base(p, A, B)
        {
            Text = name;
            node = n;
            nodes = new Node[1];
            nodes[0] = n;
        }
        public override void Draw(Bitmap drawArea, int a, int b)
        {
            Font f = new Font("Arial", 8, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int x = center.X, y = center.Y;

            using (Graphics g = Graphics.FromImage(drawArea))
            {
                Pen pen = new Pen(Brushes.LimeGreen, 2);
                if (isDashed)
                {
                    pen.DashPattern = new float[] { 2, 1 };
                }

                Rectangle rect = new Rectangle(x - a / 2, y - b / 2, a, b);
                g.FillEllipse(Brushes.White, rect);
                g.DrawEllipse(pen, rect);
                node.Draw(drawArea);

                rect = new Rectangle(x - a / 2, y - b / 2, a, b);
                StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
                format1.Alignment = StringAlignment.Center;
                format1.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, f, drawBrush, (RectangleF)rect, format1);
                pen.Dispose();
                format1.Dispose();
            }
            f.Dispose();
            drawBrush.Dispose();
        }
    }
    [Serializable]
    public class BloqStop : Block
    {
        private const string name = "STOP";
        Node node;

        public override Point Center
        {
            get => center;
            set
            {
                center = value;
                node.Center = new Point(center.X, center.Y - blockHeight / 2);
            }
        }
        public new string Text { get; }

        public BloqStop(Point p, Node n, int A, int B) : base(p, A, B)
        {
            Text = name;
            node = n;
            nodes = new Node[1];
            nodes[0] = n;
        }

        public override void Draw(Bitmap drawArea, int a, int b)
        {
            Font f = new Font("Arial", 8, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            int x = center.X, y = center.Y;

            using (Graphics g = Graphics.FromImage(drawArea))
            {
                Pen pen = new Pen(Brushes.Red, 2);
                if (isDashed)
                {
                    pen.DashPattern = new float[] { 2, 1 };
                }

                Rectangle rect = new Rectangle(x - a / 2, y - b / 2, a, b);
                g.FillEllipse(Brushes.White, rect);
                g.DrawEllipse(pen, rect);
                node.Draw(drawArea);

                rect = new Rectangle(x - a / 2, y - b / 2, a, b);
                StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
                format1.Alignment = StringAlignment.Center;
                format1.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, f, drawBrush, (RectangleF)rect, format1);
                pen.Dispose();
                format1.Dispose();
            }
            f.Dispose();
            drawBrush.Dispose();
        }
    }
}

