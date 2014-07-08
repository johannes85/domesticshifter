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
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace MagicShifter
{
    public class Device : IDisposable
    {
        private SerialPort port;

        public String PortName
        {
            get
            {
                return port.PortName;
            }
        }

        public Device(string portName)
        {
            bool noError = false;
            try
            {
                port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                port.Handshake = Handshake.RequestToSend;
                port.RtsEnable = true;
                port.DtrEnable = true;
                port.ReadTimeout = 3000;
                port.NewLine = "\r\n";
                port.Open();

                if (!IsMagicShifter())
                {
                    throw new DeviceException("Device isn't a MagicShifter");
                }

                noError = true;
            }
            catch (ArgumentException ex)
            {
                throw new DeviceException("Couldn't open device: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new DeviceException("Couldn't access device: " + ex.Message);
            }
            finally
            {
                if (noError == false)
                {
                    port.Dispose();
                }
            }
        }


        public String RawPing() {
            return (RequestAnswerSync("MAGIC_PING"));
        }

        public String RawUpload(int sector, Stream stream)
        {
            try
            {
                String ret = "";

                byte[] header = {
                    (byte)sector,
                    (byte)(stream.Length >> 8),
                    (byte)(stream.Length %256)
                };
                byte[] data;
                using (MemoryStream mstream = new MemoryStream()) {
                    stream.CopyTo(mstream); 
                    data = mstream.ToArray();
                }

                port.Write("MAGIC_UPLOAD");
                Thread.Sleep(100);
                port.Write(header, 0, header.Length);
                Thread.Sleep(1500);
                WriteInBlocks(data, 32, 3);
                
                ret = port.ReadLine();
                if (!ret.Contains("READBACK @sector"))
                {
                    throw new DeviceException("Invalid answer: " + ret);
                }

                return (ret);
            }
            catch (TimeoutException)
            {
                throw new DeviceException("Upload timed out");
            }
            catch (InvalidOperationException ex)
            {
                throw new DeviceException(ex.Message);
            }
        }

        private void WriteInBlocks(byte[] data, int blockSize, int delay)
        {
            int blocks = (int)Math.Ceiling((double)data.Length / (double)blockSize);

            for (int a = 0; a < blocks; a++)
            {
                int lenght = data.Length - (a * blockSize);
                if (lenght > blockSize) {
                    lenght = blockSize;
                }
                port.Write(data, a * blockSize, lenght);
                Thread.Sleep(delay);
            }

        }

        private String RequestAnswerSync(String command)
        {
            String ret = "";
            port.Write(command);
            ret = port.ReadLine();
            return (ret);
        }

        private bool IsMagicShifter()
        {
            try
            {
                String result = RequestAnswerSync("MAGIC_PING");

                Boolean isOldVersion = result.Contains("Ping Status now");
                Boolean isNewVersion = result.Contains("MAGIC_PONG");

                return (isNewVersion || isOldVersion);
            }
            catch (TimeoutException)
            {
                return (false);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (disposing == true)
            {
                port.Dispose();
            }
        }        

        ~Device()
        {
            Dispose(false);
        }
    }
}
