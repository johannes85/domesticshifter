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
 * Creative Commons: Attribution-NonCommercial-ShareAlike 4.0 International (CC BY-NC-SA 4.0)
 * http://creativecommons.org/licenses/by-nc-sa/4.0/
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MagicShifter
{
    public class DeviceFinder
    {
        public String[] GetAllSerialDevices()
        {
            return (SerialPort.GetPortNames());
        }

        public Device Find()
        {
            Device ret = null;

            String[] portNames = SerialPort.GetPortNames();
            foreach (String portName in portNames)
            {
                try
                {
                    Device dev = GetByPort(portName);
                    ret = dev;
                } catch (DeviceException) {

                }
            }

            if (ret == null)
            {
                throw new DeviceFinderException("Couldn't found device");
            }

            return (ret);
        }

        public Device GetByPort(String portName)
        {
            Device dev = new Device(portName);
            return (dev);
        }
    }
}
