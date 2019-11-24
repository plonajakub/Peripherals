using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace Bluetooth
{
    /// <summary>
    /// 32feet.Net library wrapper for common Bluetooth actions
    /// </summary>
    class BluetoothManager
    {
        private BluetoothDeviceInfo[] devices;
        public BluetoothDeviceInfo[] Devices
        {
            get
            {
                foreach (var device in devices)
                {
                    device.Refresh();
                }
                return devices;
            }
            set
            {
                devices = value;
            }
        }
        private readonly BluetoothClient bluetoothClient;

        public BluetoothManager()
        {
            bluetoothClient = new BluetoothClient();
            devices = new BluetoothDeviceInfo[0];
        }

        ~BluetoothManager()
        {
            bluetoothClient.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxDevices"></param>
        /// <param name="authenticated"></param>
        /// <param name="remembered"></param>
        /// <param name="unknown"></param>
        /// <param name="discoverableOnly"></param>
        /// <returns>Array of BluetoothDeviceInfo objects ready to link to the UI element</returns>
        public BluetoothDeviceInfo[] DiscoverDevices(int maxDevices, bool authenticated, bool remembered,
            bool unknown, bool discoverableOnly = false)
        {
            Devices = bluetoothClient.DiscoverDevices(maxDevices, authenticated, remembered, unknown, discoverableOnly);
            return Devices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pin"></param>
        /// <returns>True if pairing was successful, otherwise false</returns>
        public bool PairDevice(string name, string pin = "0000")
        {
            BluetoothDeviceInfo deviceInfo = Devices.Where(bluetoothDeviceInfo => bluetoothDeviceInfo.DeviceName.Equals(name)).First();
            return BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, pin);
        }

        public bool PairDevice(BluetoothAddress deviceAdress, string pin = "0000")
        {
            return BluetoothSecurity.PairRequest(deviceAdress, pin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True if unpairing was successful, otherwise false</returns>
        public bool UnpairDevice(string name)
        {
            BluetoothDeviceInfo deviceInfo = Devices.Where(bluetoothDeviceInfo => bluetoothDeviceInfo.DeviceName.Equals(name)).First();
            return BluetoothSecurity.RemoveDevice(deviceInfo.DeviceAddress);
        }

        public bool UnpairDevice(BluetoothAddress deviceAdress)
        {
            return BluetoothSecurity.RemoveDevice(deviceAdress);
        }

        public ObexStatusCode SendFile(BluetoothAddress deviceAddress, string filePath)
        {
            BluetoothDeviceInfo device = Devices.Where((_device) => _device.DeviceAddress == deviceAddress).First();
            device.SetServiceState(BluetoothService.ObexObjectPush, true);

            Uri uri = new Uri("obex://" + deviceAddress + "//" + filePath);
            ObexWebRequest request = new ObexWebRequest(uri);
            request.ReadFile(filePath);
            ObexWebResponse response = (ObexWebResponse)request.GetResponse();
            response.Close();

            device.SetServiceState(BluetoothService.ObexObjectPush, false);
            return response.StatusCode;
        }

        public ObexStatusCode SendFile(BluetoothAddress deviceAddress, string filePath, ProgressBar progressBar)
        {
            BluetoothDeviceInfo device = Devices.Where((_device) => _device.DeviceAddress == deviceAddress).First();
            device.SetServiceState(BluetoothService.ObexObjectPush, true);

            int fileSize = 0;
            FileStream fs = File.OpenRead(filePath);
            byte[] buffer = new byte[1024];
            int readBytes = 1;
            while (readBytes != 0)
            {
                readBytes = fs.Read(buffer, 0, buffer.Length);
                fileSize += readBytes;
            }
            fs.Close();

            progressBar.Invoke(new Action(() =>
            {
                // Set Minimum to 1 to represent the first file being copied.
                progressBar.Minimum = 0;
                // Set Maximum to the total number of files to copy.
                progressBar.Maximum = fileSize;
                // Set the initial value of the ProgressBar.
                progressBar.Value = 0;
            }));
            

            System.Uri uri = new Uri("obex://" + deviceAddress + "/" + System.IO.Path.GetFileName(filePath));
            ObexWebRequest request = new ObexWebRequest(uri);
            Stream requestStream = request.GetRequestStream();
            

            fs = File.OpenRead(filePath);
            buffer = new byte[1024];
            readBytes = 1;
            while (readBytes != 0)
            {
                readBytes = fs.Read(buffer, 0, buffer.Length);
                requestStream.Write(buffer, 0, readBytes);
                progressBar.Invoke(new Action (() => progressBar.Increment(readBytes)));
                
            }
            requestStream.Close();
            fs.Close();

            request.ContentLength = fileSize;

            ObexWebResponse response = (ObexWebResponse)request.GetResponse();
            response.Close();

            device.SetServiceState(BluetoothService.ObexObjectPush, false);
            return response.StatusCode;
        }

        //TODO Split server functionalities into distinguishable methods
        public void ReciveFile()
        {
            ObexListener listener = new ObexListener(ObexTransport.Bluetooth);
            listener.Start();
            ObexListenerContext ctx = listener.GetContext();
            ObexListenerRequest req = ctx.Request;
            String[] pathSplits = req.RawUrl.Split('/');
            String file = pathSplits[pathSplits.Length - 1];
            req.WriteFile(file);
            listener.Stop();
        }
    }
}
