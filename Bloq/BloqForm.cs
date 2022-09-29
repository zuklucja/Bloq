using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bloq;

namespace WinFormsLab
{
    public partial class BloqForm : Form
    {
        #region Fields
        private const int areaWidth = 1000;
        private const int areaHeight = 1000;
        const int blockWidth = 100, blockHeight = 50;

        Mode bloqMode;
        private Bitmap drawArea;
        private bool isStartbloq;
        private bool toBeDeleted;
        private bool toBeConnected;
        private int dashedBloq;
        // isCanvasMouseDown
        private bool isCMB;
        int x, y;

        Node connectFirst = null;
        List<Block> blocks = new List<Block>();
        List<Node> nodes = new List<Node>();
        #endregion

        public BloqForm()
        {
            InitializeComponent();
            drawArea = new Bitmap(areaWidth, areaHeight);
            Canvas.Image = drawArea;
            buttonStart.Select();
            buttonStart.BackColor = Color.LightSteelBlue;
            bloqMode = Mode.Start;
            dashedBloq = -1;
            isCMB = false;
            toBeDeleted = false;
            toBeConnected = false;
        }

        #region EventHandlers
        private void buttonDecisionBlock_Click(object sender, EventArgs e)
        {
            repaintBackground();
            buttonDecisionBlock.BackColor = Color.LightSteelBlue;
            bloqMode = Mode.Decision;
            toBeDeleted = false;
            toBeConnected = false;
        }
        private void buttonOperationBlock_Click(object sender, EventArgs e)
        {
            repaintBackground();
            buttonOperationBlock.BackColor = Color.LightSteelBlue;
            bloqMode = Mode.Operation;
            toBeDeleted = false;
            toBeConnected = false;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            repaintBackground();
            buttonStart.BackColor = Color.LightSteelBlue;
            bloqMode = Mode.Start;
            toBeDeleted = false;
            toBeConnected = false;
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            repaintBackground();
            buttonStop.BackColor = Color.LightSteelBlue;
            bloqMode = Mode.Stop;
            toBeDeleted = false;
            toBeConnected = false;
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            repaintBackground();
            buttonConnect.BackColor = Color.LightSteelBlue;
            bloqMode = Mode.Connect;
            toBeConnected = true;
            toBeDeleted = false;
        }
        private void buttonErase_Click(object sender, EventArgs e)
        {
            toBeConnected = false;
            toBeDeleted = true;
            repaintBackground();
            buttonErase.BackColor = Color.LightSteelBlue;
            bloqMode = Mode.Erase;
        }

        private void buttonNewDiag_Click(object sender, EventArgs e)
        {
            NewDiagramWindow F = new NewDiagramWindow();
            F.ShowDialog();
            if (F.Change == true)
            {
                NewDiag(F.CanvasWidth, F.CanvasHeight);
            }
            F.Dispose();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCMB) return;
            if (e.Button == MouseButtons.Left)
            {
                if (toBeDeleted)
                {
                    var pp = check(e.X, e.Y);
                    if (pp != -1)
                    {
                        if (dashedBloq == pp)
                        {
                            dashedBloq = -1;
                            textBox.Enabled = false;
                            textBox.Text = "";
                        }
                        if (blocks[pp].GetType() == typeof(BloqStart))
                            isStartbloq = false;
                        foreach (Node i in blocks[pp].Nodes)
                        {
                            i.DisConnect();
                            nodes.Remove(i);
                        }
                        blocks.RemoveAt(pp);
                    }
                    paint();
                    return;
                }
                else if (toBeConnected)
                {
                    int k = checkNode(e.X, e.Y);
                    if (k != -1)
                    {
                        if (nodes[k].GetType() == typeof(NodeFull) && !nodes[k].IsConnected)
                            connectFirst = nodes[k];
                    }
                    return;
                }

                switch (bloqMode)
                {
                    case Mode.Decision:
                        {
                            Node NodeT = new NodeFull(new Point(e.X - blockWidth / 2, e.Y));
                            Node NodeF = new NodeFull(new Point(e.X + blockWidth / 2, e.Y));
                            Node NodeU = new NodeEmpty(new Point(e.X, e.Y - blockHeight / 2));
                            nodes.Add(NodeT);
                            nodes.Add(NodeF);
                            nodes.Add(NodeU);
                            blocks.Add(new BloqD(new Point(e.X, e.Y), NodeT, NodeF, NodeU, blockWidth, blockHeight));
                        }
                        break;
                    case Mode.Operation:
                        {
                            Node nodeU = new NodeEmpty(new Point(e.X, e.Y - blockHeight / 2));
                            Node nodeD = new NodeFull(new Point(e.X, e.Y + blockHeight / 2));
                            nodes.Add(nodeU);
                            nodes.Add(nodeD);
                            blocks.Add(new BloqO(new Point(e.X, e.Y), nodeU, nodeD, blockWidth, blockHeight));
                        }
                        break;
                    case Mode.Start:
                        {
                            if (!isStartbloq)
                            {
                                Node n = new NodeFull(new Point(e.X, e.Y + blockHeight / 2));
                                nodes.Add(n);
                                blocks.Add(new BloqStart(new Point(e.X, e.Y), n, blockWidth, blockHeight));
                                isStartbloq = true;
                            }
                            else
                            {
                                MessageBox.Show("Diagram has already got start block", "", MessageBoxButtons.OK);
                            }
                        }
                        break;
                    case Mode.Stop:
                        Node node = new NodeEmpty(new Point(e.X, e.Y - blockHeight / 2));
                        nodes.Add(node);
                        blocks.Add(new BloqStop(new Point(e.X, e.Y), node, blockWidth, blockHeight));
                        break;
                    default:
                        break;
                }
                paint();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (dashedBloq == -1)
                {
                    var pp = check(e.X, e.Y);
                    if (pp != -1)
                    {
                        blocks[pp].IsDashed = true;
                        dashedBloq = pp;
                        paint();
                        textBox.Text = blocks[pp].Text;
                        if (blocks[pp].GetType() == typeof(BloqD) || blocks[pp].GetType() == typeof(BloqO))
                        {
                            textBox.Enabled = true;
                        }
                    }
                }
                else if (check(e.X, e.Y) != dashedBloq)
                {
                    blocks[dashedBloq].IsDashed = false;
                    dashedBloq = -1;
                    textBox.Enabled = false;
                    textBox.Text = "";
                    paint();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if (dashedBloq != -1)
                {
                    x = e.X - blocks[dashedBloq].Center.X;
                    y = e.Y - blocks[dashedBloq].Center.Y;
                    isCMB = true;
                }
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && dashedBloq != -1)
            {
                int X = blocks[dashedBloq].Center.X, Y = blocks[dashedBloq].Center.Y;
                if (X < 0 && Y < 0)
                    blocks[dashedBloq].Center = new Point(0, 0);
                else if (X < 0 && Y > drawArea.Height)
                    blocks[dashedBloq].Center = new Point(0, drawArea.Height);
                else if (X < 0)
                    blocks[dashedBloq].Center = new Point(0, Y);
                else if (X > drawArea.Width && Y > drawArea.Height)
                    blocks[dashedBloq].Center = new Point(drawArea.Width, drawArea.Height);
                else if (Y < 0 && X > drawArea.Width)
                    blocks[dashedBloq].Center = new Point(drawArea.Width, 0);
                else if (Y < 0)
                    blocks[dashedBloq].Center = new Point(X, 0);
                else if (Y > drawArea.Height)
                    blocks[dashedBloq].Center = new Point(X, drawArea.Height);
                else if (X > drawArea.Width)
                    blocks[dashedBloq].Center = new Point(drawArea.Width, Y);
                else
                    blocks[dashedBloq].Center = new Point(X, Y);
                isCMB = false;
            }
            else if (e.Button == MouseButtons.Left && toBeConnected && connectFirst != null)
            {
                int k = checkNode(e.X, e.Y);
                if (k != -1)
                {
                    if (nodes[k].GetType() == typeof(NodeEmpty) && !nodes[k].IsConnected)
                    {
                        nodes[k].Connect(connectFirst);
                        connectFirst.Connect(nodes[k]);
                    }
                }
                connectFirst = null;
            }
            paint();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && dashedBloq != -1)
            {
                blocks[dashedBloq].Center = new Point(e.X - x, e.Y - y);
                paint();
            }
            else if (e.Button == MouseButtons.Left && toBeConnected && connectFirst != null)
            {
                paint();
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    using (Pen pen = new Pen(Color.Black, 1))
                    {
                        g.DrawLine(pen, connectFirst.Center.X, connectFirst.Center.Y, e.X, e.Y);

                    }
                }
                Canvas.Refresh();
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Enabled == true)
            {
                blocks[dashedBloq].Text = textBox.Text;
                paint();
            }
        }

        private void buttonLoadDiag_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var file = (FileStream)openFileDialog.OpenFile())
                {
                    Data d;
                    var binarnyser = new BinaryFormatter();
                    try
                    {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                        d = (Data)binarnyser.Deserialize(file);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                        NewDiag(d.Width, d.height);
                        blocks = d.Bloqs;
                        nodes = d.Nodes;
                        foreach (Bloq.Block b in blocks)
                        {
                            if (b.GetType() == typeof(BloqStart))
                                isStartbloq = true;
                            b.IsDashed = false;
                        }
                        paint();
                    }
                    catch
                    {
                        MessageBox.Show("We couldn't load your diagram. Try again.", "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            openFileDialog.Dispose();
        }

        private void buttonSaveDiag_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Data d = new Data(drawArea.Width, drawArea.Height, blocks, nodes);
                using (var file = (FileStream)saveFileDialog.OpenFile())
                {
                    var binarnyser = new BinaryFormatter();
                    binarnyser.Serialize(file, d);
                }
            }
            saveFileDialog.Dispose();
        }
        #endregion

        #region Private Methods
        private void repaintBackground()
        {
            buttonDecisionBlock.BackColor = Color.Transparent;
            buttonOperationBlock.BackColor = Color.Transparent;
            buttonStart.BackColor = Color.Transparent;
            buttonStop.BackColor = Color.Transparent;
            buttonConnect.BackColor = Color.Transparent;
            buttonErase.BackColor = Color.Transparent;
        }

        private void NewDiag(int width, int height)
        {
            drawArea.Dispose();
            drawArea = new Bitmap(width, height);
            Canvas.Image = drawArea;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }
            textBox.Text = "";
            textBox.Enabled = false;
            dashedBloq = -1;
            isCMB = false;
            connectFirst = null;
            blocks.Clear();
            nodes.Clear();
            isStartbloq = false;
        }

        private void paint()
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }
            foreach (var i in blocks)
            {
                i.Draw(drawArea, blockWidth, blockHeight);
            }
            if (connectFirst == null) Canvas.Refresh();
        }

        /// <summary>
        /// Checks if a point (X,Y) is on block from <see cref="blocks"/>
        /// </summary>
        /// <returns>index of a block from <see cref="blocks"/></returns>
        private int check(int X, int Y)
        {
            for (int j = blocks.Count() - 1; j >= 0; j--)
            {
                var i = blocks[j];
                int x = i.Center.X, y = i.Center.Y;
                if (i.GetType() == typeof(BloqO))
                {
                    Rectangle rect = new Rectangle(x - blockWidth / 2, y - blockHeight / 2, blockWidth, blockHeight);
                    if (rect.Contains(X, Y))
                    {
                        return j;
                    }
                }
                else if ((x - X) * (x - X) / ((blockWidth / 2) * (blockWidth / 2)) + (y - Y) * (y - Y) / ((blockHeight / 2) * (blockHeight / 2)) <= 1)
                {
                    return j;
                }
            }
            return -1;
        }

        /// <summary>
        /// Checks if a point (X,Y) is a node
        /// </summary>
        /// <returns>index of a node from <see cref="nodes"/></returns>
        private int checkNode(int X, int Y)
        {
            int r = 4;
            for (int j = nodes.Count() - 1; j >= 0; j--)
            {
                var i = nodes[j];
                int x = i.Center.X, y = i.Center.Y;
                if (((x - X) * (x - X) + (y - Y) * (y - Y)) <= r * r)
                {
                    return j;
                }
            }
            return -1;
        }

        #endregion
    }

    public enum Mode
    {
        Decision,
        Operation,
        Start,
        Stop,
        Connect,
        Erase,
    }
}
