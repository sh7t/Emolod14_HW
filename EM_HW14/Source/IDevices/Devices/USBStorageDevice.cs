using System;

namespace EM_HW14.Source.IDevices.Devices
{
    public class USBStorageDevice : Program.IConnectableDevice
    {
        public void Connect()
        {
            Console.WriteLine("Connecting via USB...");
        }

        public void Disconnect()
        {
            Console.WriteLine("Safely removing the USB device...");
        }
    }
}