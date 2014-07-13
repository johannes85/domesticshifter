/*
 * DomesticShifter
 * Alternative (Unofficial) Windows Toolset for the MagicShifter: http://magicshifter.net/
 * -------------------------------------------------------------------------------------------
 * 
 * MagicShifter C# Libraries
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace MagicShifter
{
    public class MagicBitmap
    {
        public string FilePath { get; set; }
        public BitTypes BitPerPixel { get; set; }
        public int FramesCount { get; set; }
        public int RealFramesCount
        {
            get
            {
                return (frames.Count);
            }
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public SubType Type { get; set; }
        public int FirstChar { get; set; }
        public int DelayMs { get; set; }
        public int FileSize { get; set; }

        private const int HEADER_SIZE = 16;
        private List<byte[]> frames;

        public enum SubType
        {
            Font = 0xF0,
            Bitmap = 0xBA,
            Text = 0xEE
        }

        public enum BitTypes
        {
            Type1bit = 1,
            Type8bit = 8,
            Type24bit = 24
        }

        public MagicBitmap(SubType type, int width, int height, BitTypes bitsPerPixel, int firstChar, int delayMs)
        {
            FilePath = null;
            FramesCount = 0;
            Width = width;
            if (height < 1 || height > 16)
            {
                throw new MagicBitmapException(String.Format("Invalid height: {0}", height));
            }
            Height = height;
            BitPerPixel = bitsPerPixel;
            Type = type;
            FirstChar = firstChar;
            DelayMs = delayMs;

            frames = new List<byte[]>();
            AddFrame(GenerateBlankFrame());
            FileSize = CalculateFileSize();
        }

        public MagicBitmap(String filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                FilePath = filePath;

                byte[] header = new byte[MagicBitmap.HEADER_SIZE];
                if (stream.Read(header, 0, header.Length) != MagicBitmap.HEADER_SIZE)
                {
                    throw new MagicBitmapException("Couldn't read file header (Invalid file size)");
                }

                if (header[0] != 0x23)
                {
                    throw new MagicBitmapException("Invalid file format");
                }
                FileSize = header[1] << 16 | header[2] << 8 | header[3];
                switch (header[4]) {
                    // Will be implemented later
                    //case 1:
                        //BitPerPixel = BitTypes.Type1bit;
                        //break;
                    case 8:
                        BitPerPixel = BitTypes.Type8bit;
                        break;
                    case 24:
                        BitPerPixel = BitTypes.Type24bit;
                        break;
                    default:
                        throw new MagicBitmapException(String.Format("Invalid number of bits per pixel: {0}", BitPerPixel));
                }
                FramesCount = header[5];
                Width = header[6];
                Height = header[7];
                if (Height < 1 || Height > 16)
                {
                    throw new MagicBitmapException(String.Format("Invalid height: {0}", Height));
                }
                switch (header[8]) {
                    case 0xF0:
                        Type = MagicBitmap.SubType.Font;
                        break;
                    case 0xBA:
                        Type = MagicBitmap.SubType.Bitmap;
                        break;
                    default:
                        throw new MagicBitmapException(String.Format("Unknown file type: {0:x2}", header[8]));
                }
                FirstChar = header[9];
                DelayMs = header[10] << 8 | header[11];
                
                long payloadSize = stream.Length - HEADER_SIZE;
                long frameSize = (Width * Height * BitPerPixel.GetHashCode()) / 8;
                frames = new List<byte[]>();
                int realFramesCount = FramesCount == 0 ? 1 : FramesCount;

                for (int a = 0; a < realFramesCount; a++)
                {
                    byte[] buff = new byte[frameSize];
                    stream.Read(buff, 0, (int)frameSize);
                    frames.Add(buff);
                }
            }
        }

        public void Save()
        {
            if (FilePath == null)
            {
                throw new MagicBitmapException("No file path set");
            }
            Save(FilePath);
        }

        public void Save(String filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                int fileSize = CalculateFileSize();
                byte[] header = new byte[MagicBitmap.HEADER_SIZE];
                header[0] = 0x23;
                header[1] = (byte)((fileSize & 0xFF0000) >> 16);
                header[2] = (byte)((fileSize & 0xFF00) >> 8);
                header[3] = (byte)(fileSize & 0xFF);
                header[4] = (byte)BitPerPixel.GetHashCode();
                header[5] = (byte)FramesCount;
                header[6] = (byte)Width;
                header[7] = (byte)Height;
                header[8] = (byte)Type.GetHashCode();
                header[9] = (byte)FirstChar;
                header[10] = (byte)((DelayMs & 0xFF00) >> 8);
                header[11] = (byte)(DelayMs & 0xFF);
                stream.Write(header, 0, header.Length);
                
                for (int a = 0; a < frames.Count; a++)
                {
                    stream.Write(frames[a], 0, frames[a].Length);
                }

                FilePath = filePath;
            }
        }

        public void AddFrame(Bitmap image)
        {
            frames.Add(FrameFromImage(image));
            if (frames.Count > 1) {
                FramesCount = frames.Count;
            }
            FileSize = CalculateFileSize();
        }

        public void RemoveFrame(int frameNumber)
        {
            if (frames.Count < 2)
            {
                throw new MagicBitmapException("There is only one frame left");
            }
            frames.RemoveAt(frameNumber);
            if (frames.Count > 1)
            {
                FramesCount = frames.Count;
            }
            else
            {
                FramesCount = 0;
            }
            FileSize = CalculateFileSize();
        }

        public void ReplaceFrame(int frameNumber ,Bitmap image)
        {
            frames[frameNumber] = FrameFromImage(image);
        }

        public Bitmap GetFrame(int frameNumber)
        {
            if (frameNumber >= frames.Count)
            {
                throw new MagicBitmapException("Frame number is too high");
            }

            byte[] imgBuffer = frames[frameNumber];
            Bitmap image = new Bitmap(Width, Height);


            if (BitPerPixel == BitTypes.Type24bit)
            {
                int index = 0;
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        Color pixelCol = Color.FromArgb(imgBuffer[index], imgBuffer[index + 1], imgBuffer[index + 2]);
                        image.SetPixel(x, y, pixelCol);
                        index += 3;
                    }
                }

            }
            else if (BitPerPixel == BitTypes.Type8bit)
            {
                int index = 0;
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        Color pixelCol = Color.FromArgb(imgBuffer[index], imgBuffer[index], imgBuffer[index]);
                        image.SetPixel(x, y, pixelCol);
                        index++;
                    }
                }

            }
            else if (BitPerPixel == BitTypes.Type1bit)
            {
                throw new MagicBitmapException("1 bit pixels aren't supported");
            }
            else
            {
                throw new MagicBitmapException("Invalid number ob bits per pixel");
            }

            return (image);
        }

        public Bitmap GenerateBlankFrame()
        {
            Bitmap blankFrame = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(blankFrame))
            {
                Brush brushBlack = Brushes.Black;
                g.FillRectangle(brushBlack, 0, 0, blankFrame.Width, blankFrame.Height);
            }
            return (blankFrame);
        }

        private int CalculateFileSize()
        {
            int fileSize = HEADER_SIZE;

            for (int a = 0; a < frames.Count; a++)
            {
                fileSize += frames[a].Length;
            }

            return (fileSize);
        }

        private byte[] FrameFromImage(Bitmap image)
        {
            int frameSize = (int)Math.Ceiling(image.Width * image.Height * BitPerPixel.GetHashCode() / 8.0);
            byte[] imgBuffer = new byte[frameSize];

            if (BitPerPixel == BitTypes.Type24bit)
            {
                int index = 0;
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color pixelCol = image.GetPixel(x, y);
                        imgBuffer[index] = pixelCol.R;
                        imgBuffer[index + 1] = pixelCol.G;
                        imgBuffer[index + 2] = pixelCol.B;
                        index += 3;
                    }
                }
            }
            else if (BitPerPixel == BitTypes.Type8bit)
            {
                int index = 0;
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color pixelCol = image.GetPixel(x, y);
                        imgBuffer[index] = (byte)Math.Round((pixelCol.R + pixelCol.G + pixelCol.B) / 3.0);
                        index++;
                    }
                }
            }
            else if (BitPerPixel == BitTypes.Type1bit)
            {
                throw new MagicBitmapException("1 bit pixels aren't supported");
            }
            else
            {
                throw new MagicBitmapException("Invalid number ob bits per pixel");
            }

            return (imgBuffer);
        }
    }
}
