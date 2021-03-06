﻿/*
 * DomesticShifter
 * Alternative (Unofficial) Windows Toolset for the MagicShifter: http://magicshifter.net/
 * -------------------------------------------------------------------------------------------
 * 
 * MagicPaint
 * Magic Bitmap Editor
 *   
 * by DomesticHacks
 * http://www.domestichacks.info/
 * http://www.youtube.com/DomesticHacks
 *
 * Author: Johannes Zinnau (johannes@johnimedia.de)
 * 
 * License:
 * GNU GENERAL PUBLIC LICENSE Version 3
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MagicPaint
{
    public partial class MagicPixler : UserControl
    {
        private Bitmap image;
        private Bitmap buffer;
        private Pen penHelpingLines;
        private Pen penCursor;
        private Tool currentTool;

        private Point cursorPosition;
        private bool cursorEnabled;
        private bool mouseDown;

        private int pixelSize = 16;

        public event EventHandler<Color> OnColorChoose;
        public event EventHandler OnChanged;

        public Boolean EditEnabled { get; set; }
        public Tool CurrentTool {
            get
            {
                return currentTool;
            }
            set
            {
                currentTool = value;

                switch (currentTool)
                {
                    case Tool.Brush:
                        Cursor = GetCursor("brush");
                        break;
                    case Tool.ColorPicker:
                        Cursor = GetCursor("pipette");
                        break;
                    case Tool.Fill:
                        Cursor = GetCursor("fill");
                        break;
                }
            } 
        }
        public Color CurrentColor { get; set; }
        public int PixelSize
        {
            get
            {
                return (pixelSize);
            }

            set
            {
                pixelSize = value;
                RefreshEditor();
            }
        }

        public enum Tool
        {
            Brush = 0,
            ColorPicker = 1,
            Fill = 2
        }

        public MagicPixler()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint,
                true
            );

            penHelpingLines = new Pen(Color.FromArgb(204, 204, 204));
            penCursor = new Pen(Color.Blue);
            cursorPosition = new Point();
            cursorEnabled = false;
            mouseDown = false;
            CurrentTool = Tool.Brush;
            CurrentColor = Color.White;
            EditEnabled = true;
        }

        public void LoadImage(Bitmap image)
        {
            this.image = image;
            RefreshEditor();
        }

        public Bitmap GetImage()
        {
            return (this.image);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void RefreshEditor()
        {
            if (image != null && Width > 0 && Height > 0)
            {
                buffer = new Bitmap(Width, Height);
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    PaintImage(g);
                    if (pixelSize > 5) { 
                        PaintHelpingLines(g);
                    }
                    PaintCursor(g);
                }
                BackgroundImage = buffer;
            }
        }

        private void PaintImage(Graphics g)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    g.FillRectangle(new SolidBrush(image.GetPixel(x, y)), x * pixelSize, y * pixelSize, pixelSize, pixelSize);
                }
            }
        }

        private void PaintHelpingLines(Graphics g)
        {
            for (int a = 0; a <= image.Width; a++)
            {
                g.DrawLine(penHelpingLines, a * pixelSize, 0, a * pixelSize, image.Height * pixelSize);
            }
            for (int a = 0; a <= image.Height; a++)
            {
                g.DrawLine(penHelpingLines, 0, a * pixelSize, image.Width * pixelSize, a * pixelSize);
            }
        }

        private void PaintCursor(Graphics g)
        {
            if (cursorEnabled)
            {
                int startX = (int)Math.Floor((double)cursorPosition.X / (double)pixelSize) * pixelSize;
                int startY = (int)Math.Floor((double)cursorPosition.Y / (double)pixelSize) * pixelSize;
                g.DrawRectangle(penCursor, startX, startY, pixelSize, pixelSize);
            }
        }

        private void UseTool(int x, int y)
        {
            if (x >= 0 && x < image.Width && y >= 0 && y < image.Height && EditEnabled == true)
            {
                if (CurrentTool == Tool.Brush)
                {
                    image.SetPixel(x, y, CurrentColor);
                    if (OnChanged != null)
                    {
                        OnChanged(this, null);
                    }
                }
                else if (CurrentTool == Tool.ColorPicker)
                {
                    Color color = image.GetPixel(x, y);
                    if (OnColorChoose != null)
                    {
                        OnColorChoose(this, color);
                    }
                }
                else if (CurrentTool == Tool.Fill)
                {
                    FloodFill(x, y, image.GetPixel(x, y), CurrentColor);
                }
            }
        }

        private void FloodFill(int x, int y, Color oldColor, Color newColor)
        {
            Stack<Point> floodFillStack = new Stack<Point>();
            floodFillStack.Push(new Point(x, y));

            while (floodFillStack.Count > 0)
            {
                Point currentPoint = floodFillStack.Pop();
                Color currentColor = image.GetPixel(currentPoint.X, currentPoint.Y);

                if (EqualColor(currentColor, oldColor) && !EqualColor(currentColor, newColor))
                {
                    image.SetPixel(currentPoint.X, currentPoint.Y, newColor);
                    if (currentPoint.X > 0)
                    {
                        floodFillStack.Push(new Point(currentPoint.X - 1, currentPoint.Y));
                    }
                    if (currentPoint.Y > 0)
                    {
                        floodFillStack.Push(new Point(currentPoint.X, currentPoint.Y - 1));
                    }
                    if ((currentPoint.X + 1) < image.Width)
                    {
                        floodFillStack.Push(new Point(currentPoint.X + 1, currentPoint.Y));
                    }
                    if ((currentPoint.Y + 1) < image.Height)
                    {
                        floodFillStack.Push(new Point(currentPoint.X, currentPoint.Y + 1));
                    }
                }
            }
        }

        private Boolean EqualColor(Color color1, Color color2)
        {
            return (color1.ToArgb() == color2.ToArgb());
        }

        private Cursor GetCursor(string cursorName)
        {
            var buffer = Properties.Resources.ResourceManager.GetObject(cursorName) as byte[];

            using (var m = new MemoryStream(buffer))
            {
                return new Cursor(m);
            }
        }

        private void MagicPixler_Resize(object sender, EventArgs e)
        {
            RefreshEditor();
        }

        private void MagicPixler_MouseMove(object sender, MouseEventArgs e)
        {
            if (image != null) {
                cursorPosition.X = e.X > ((image.Width - 1) * pixelSize) ? ((image.Width - 1) * pixelSize) : e.X;
                cursorPosition.Y = e.Y > ((image.Height - 1) * pixelSize) ? ((image.Height - 1) * pixelSize) : e.Y;

                if (mouseDown)
                {
                    int pixelX = (int)Math.Floor((double)cursorPosition.X / (double)pixelSize);
                    int pixelY = (int)Math.Floor((double)cursorPosition.Y / (double)pixelSize);
                    UseTool(pixelX, pixelY);
                }

                RefreshEditor();
            }
        }

        private void MagicPixler_MouseEnter(object sender, EventArgs e)
        {
            if (image != null) {
                cursorEnabled = true;
                RefreshEditor();
            }
        }

        private void MagicPixler_MouseLeave(object sender, EventArgs e)
        {
            if (image != null) {
                cursorEnabled = false;
                RefreshEditor();
            }
        }

        private void MagicPixler_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                int pixelX = (int)Math.Floor((double)cursorPosition.X / (double)pixelSize);
                int pixelY = (int)Math.Floor((double)cursorPosition.Y / (double)pixelSize);
                UseTool(pixelX, pixelY);
                RefreshEditor();
            }
        }

        private void MagicPixler_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void MagicPixler_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
