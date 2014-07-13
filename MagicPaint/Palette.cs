using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicPaint
{
    public partial class Palette : UserControl
    {
        private Bitmap buffer;
        private ColorType type;
        private Pen penCursor;
        private double currentHue;
        private int hueBarWidth;

        public event EventHandler<Color> OnColorPicked;

        public ColorType Type {
            get
            {
                return type;
            }
            set
            {
                type = value;
                RefreshPalette();
            }
        }

        public enum ColorType
        {
            Type1bit = 1,
            Type8bit = 8,
            Type24bit = 24
        }

        public Palette()
        {
            InitializeComponent();

            currentHue = 0;
            hueBarWidth = 25;
            penCursor = new Pen(Color.White);
        }

        private void Palette_Load(object sender, EventArgs e)
        {
            Type = ColorType.Type24bit;
        }

        private void RefreshPalette()
        {
            buffer = new Bitmap(Width, Height);

            switch (Type)
            {
                case ColorType.Type1bit:
                    Draw1BitPalette(buffer);
                    break;
                case ColorType.Type8bit:
                    Draw8BitPalette(buffer);
                    break;
                case ColorType.Type24bit:
                    Draw24BitPalette(buffer);
                    break;
            }

            BackgroundImage = buffer;
        }

        private void Draw1BitPalette(Bitmap buffer)
        {
            
            int xSplit = (int)Math.Round((double)Width / 2);
            Brush blackBrush = Brushes.Black;
            Brush whiteBrush = Brushes.White;
            using (Graphics g = Graphics.FromImage(buffer))
            {
                g.FillRectangle(whiteBrush, 0, 0, xSplit, Height);
                g.FillRectangle(blackBrush, xSplit + 1, 0, Width, Height);
            }
        }

        private void Draw8BitPalette(Bitmap buffer)
        {
            int xSplit = (int)Math.Round((double)Width / 2);
            for (int x = 0; x < Width; x++)
            {
                int colorPart = (int)Math.Round(255 / (double)Width * (double)x);
                Color currentColor = Color.FromArgb(colorPart, colorPart, colorPart);
                for (int y = 0; y < Height; y++)
                {
                    buffer.SetPixel(x, y, currentColor);
                }
            }
        }

        private void Draw24BitPalette(Bitmap buffer)
        {
            int startHueBar = Width - hueBarWidth;
            int pickerWidth = startHueBar - 1;

            for (int y = 0; y < Height; y++)
            {
                int val = 100 - (int)Math.Round(100.0 / (double)Height * (double)y);

                for (int x = 0; x <= pickerWidth; x++)
                {
                    int sat = (int)Math.Round(100.0 / (double)pickerWidth * (double)x);
                    buffer.SetPixel(x, y, ColorFromHSV(currentHue, (double)sat * 0.01, (double)val * 0.01));
                }

                double hue = 359.0 / (double)Height * (double)y;
                Color currentColor = ColorFromHSV(hue, 1.0, 1.0);

                for (int x = 0; x < hueBarWidth; x++)
                {
                    buffer.SetPixel(startHueBar + x, y, currentColor);
                }
            }
        }

        private void Palette_MouseClick(object sender, MouseEventArgs e)
        {
            Color color = ((Bitmap)BackgroundImage).GetPixel(e.X, e.Y);
            if (OnColorPicked != null)
            {
                PickColor(e.X, e.Y);
            }
        }

        private void Palette_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PickColor(e.X, e.Y);
            }
        }

        private void PickColor(int x, int y)
        {
            if (x > 0 && y > 0 && x < Width && y < Height)
            {
                Color color = ((Bitmap)BackgroundImage).GetPixel(x, y);

                int startHueBar = Width - hueBarWidth;
                if (Type == ColorType.Type24bit && x >= startHueBar)
                {
                    currentHue = 359.0 / (double)Height * (double)y;
                    RefreshPalette();
                }
                else
                {
                    if (OnColorPicked != null)
                    {
                        OnColorPicked(this, color);
                    }
                }
            }
        }

        private Boolean EqualColor(Color color1, Color color2)
        {
            return (color1.ToArgb() == color2.ToArgb());
        }

        // Thanks to: http://stackoverflow.com/a/1626232/894982
        private Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }
}
