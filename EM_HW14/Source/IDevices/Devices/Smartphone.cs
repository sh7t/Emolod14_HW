using System;

namespace EM_HW14.Source.IDevices.Devices
{
    public class Smartphone : Program.IConnectableDevice
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to a mobile network...");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from mobile network...");
        }
    }
}