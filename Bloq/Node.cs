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
    public abstract class Node
    {
        protected const int radius = 4;
        protected Node connectedTo;

        public Point Center { get; set; }
        public bool IsConnected { get; set; }

        public Node(Point Center)
        {
            this.Center = Center;
            connectedTo = null;
            IsConnected = false;
        }

        public abstract void Draw(Bitmap drawArea);

        public void Connect(Node connect)
        {
            if (!IsConnected)
            {
                connectedTo = connect;
                IsConnected = true;
            }
        }

        public void DisConnect()
        {
            if (IsConnected)
            {
                connectedTo.IsConnected = false;
                connectedTo.connectedTo = null;
                connectedTo = null;
                IsConnected = false;
            }
        }
    }

    [Serializable]
    public class NodeEmpty : Node
    {
        public NodeEmpty(Point Center) : base(Center) { }

        public override void Draw(Bitmap drawArea)
        {
            int x = Center.X, y = Center.Y;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                if (!IsConnected)
                {
                    Rectangle prect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
                    g.FillEllipse(Brushes.White, prect);
                    g.DrawEllipse(Pens.Black, prect);
                }
            }
        }
    }

    [Serializable]
    public class NodeFull : Node
    {
        public NodeFull(Point Center) : base(Center) { }

        public override void Draw(Bitmap drawArea)
        {
            int x = Center.X, y = Center.Y;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                if (!IsConnected)
                {
                    Rectangle prect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
                    g.FillEllipse(Brushes.Black, prect);
                    g.DrawEllipse(Pens.Black, prect);
                }
                else
                {
                    using (Pen pen = new Pen(Color.Black, 1))
                    {
                        using (AdjustableArrowCap a = new AdjustableArrowCap(5, 5))
                        {
                            pen.CustomEndCap = a;
                            g.DrawLine(pen, x, y, connectedTo.Center.X, connectedTo.Center.Y);
                        }
                    }
                }

            }
        }
    }
}
