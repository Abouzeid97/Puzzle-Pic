using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace assignment_22__puzzle_
{
    public class pics
    {
        public Bitmap img;
        public Rectangle srs;
        public Rectangle dst;
    };

    public partial class Form1 : Form
    {
        Bitmap off;
        List<pics> p = new List<pics>();
        List<pics> h = new List<pics>();
        int ismove = 0;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        void randomize()
        {
            Random rr = new Random();
            int r1;
            int x = 20 + 375;
            int y = 20 + 250;
            int a;
            int b;
            for (int i = 0; i < 50; i++)
            {
                r1 = rr.Next(0, 11);
                a = p[r1].dst.X;
                b = p[r1].dst.Y;
                p[r1].dst = new Rectangle(x, y, 125, 125);
                x = a;
                y = b;
            }
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (e.X > p[i].dst.X && e.X < p[i].dst.X + p[i].dst.Width)
                {
                    if (e.Y > p[i].dst.Y && e.Y < p[i].dst.Y + p[i].dst.Height)
                    {
                        ismove = 0;
                        if (ismove == 0)
                        {
                            for (int k = 0; k < p.Count; k++)
                            {
                                if (p[k].dst.X == p[i].dst.X + 125 && p[i].dst.Y == p[k].dst.Y)
                                {
                                    ismove = 0;
                                    break;
                                }
                                else
                                {
                                    if ( p[i].dst.X + 125 != 520 )
                                    ismove = 1;
                                }
                            }
                        }
                        if (ismove == 0)
                        {
                            for (int k = 0; k < p.Count; k++)
                            {
                                if (p[k].dst.X + 125 == p[i].dst.X && p[i].dst.Y == p[k].dst.Y)
                                {
                                    ismove = 0;
                                    break;
                                }
                                else
                                {
                                    if (p[i].dst.X != 20)
                                    ismove = 2;
                                }
                            }
                        }
                        if (ismove == 0)
                        {
                            for (int k = 0; k < p.Count; k++)
                            {
                                if (p[k].dst.Y == p[i].dst.Y + 125 && p[i].dst.X == p[k].dst.X) 
                                {
                                    ismove = 0;
                                    break;
                                }
                                else
                                {
                                    if ( p[i].dst.Y+125 != 395)
                                    ismove = 3;
                                }
                            }
                        }
                        if (ismove == 0)
                        {
                            for (int k = 0; k < p.Count; k++)
                            {
                                if (p[k].dst.Y + 125 == p[i].dst.Y && p[i].dst.X == p[k].dst.X)
                                {
                                    ismove = 0;
                                    break;
                                }
                                else
                                {
                                    if ( p[i].dst.Y != 20 )
                                    ismove = 4;
                                }
                            }
                        }
                    }
                }
                if (ismove == 1)
                {
                    p[i].dst = new Rectangle(p[i].dst.X+125, p[i].dst.Y, 125, 125);
                    ismove = 0;
                }
                if (ismove == 2)
                {
                    p[i].dst = new Rectangle(p[i].dst.X - 125, p[i].dst.Y, 125, 125);
                    ismove = 0;
                }
                if (ismove == 3)
                {
                    p[i].dst = new Rectangle(p[i].dst.X, p[i].dst.Y + 125, 125, 125);
                    ismove = 0;
                }
                if (ismove == 4)
                {
                    p[i].dst = new Rectangle(p[i].dst.X, p[i].dst.Y - 125, 125, 125);
                    ismove = 0;
                }
            }
            drawdubb(this.CreateGraphics());    
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.drawdubb(this.CreateGraphics());
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            for (int i = 0; i < 500; i+= 125)
            {
                for (int k = 0; k < 375; k+= 125)
                {
                    pics pnn = new pics();
                    pnn.img = new Bitmap("dog.jpg");
                    pnn.srs = new Rectangle(i, k, 125, 125);
                    pnn.dst = new Rectangle(20 + i, 20+k,125, 125);
                    p.Add(pnn);
                }
            }
            p.RemoveAt(p.Count - 1);
            randomize();
            pics pnm = new pics();
            pnm.img = new Bitmap("dog.jpg");
            pnm.srs = new Rectangle(0, 0, pnm.img.Width, pnm.img.Height);
            pnm.dst = new Rectangle(600, 20, pnm.img.Width, pnm.img.Height);
            h.Add(pnm);
        }   

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void drawscene(Graphics g)
        {
            g.Clear(Color.Black);
            SolidBrush bb = new SolidBrush(Color.Red);
            g.FillRectangle(bb, 20, 20, 500, 375);
            for (int i = 0; i < p.Count; i++)
            {
                g.DrawImage(p[i].img, p[i].dst, p[i].srs, GraphicsUnit.Pixel);
            }
            g.DrawImage(h[0].img, h[0].dst, h[0].srs, GraphicsUnit.Pixel);
        }
    }
}
