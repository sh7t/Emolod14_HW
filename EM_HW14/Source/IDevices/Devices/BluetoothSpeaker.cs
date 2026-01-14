using System;

namespace EM_HW14.Source.IDevices.Devices
{
    public class BluetoothSpeaker : Program.IConnectableDevice
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to a device via Bluetooth...");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from a device via Bluetooth...");
        }
    }
}