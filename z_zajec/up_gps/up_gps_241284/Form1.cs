using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace up_gps_241284
{
    public partial class Form1 : Form
    {
        static BluetoothClient bluetoothClient = new BluetoothClient();
        BluetoothDeviceInfo gpsDevice = null;

        static int[] latitiude = new int[3];
        static int[] longitiude = new int[3];
        static int[] npm = new int[3];
        static char[] dir = new char[2];

        public Form1()
        {
            InitializeComponent();

            mySplitCont.Panel1.Controls.Add(latitiudeLabel);
            mySplitCont.Panel1.Controls.Add(latitiudeText);
            mySplitCont.Panel1.Controls.Add(longitiudeText);
            mySplitCont.Panel1.Controls.Add(logitiudeLabel1);


            // Discover
            var devices = bluetoothClient.DiscoverDevices();
            gpsDevice = devices.Where(x => x.DeviceName.Equals("PENTA-GPS")).FirstOrDefault();
            if (gpsDevice == null)
            {
                System.Console.WriteLine("Device not found!");
                throw new Exception();
            }
            else
            {
                System.Console.WriteLine("Device has been found!");
                Console.WriteLine("Urzadzenie, z ktorym sie parujemy:");
                string blueToothInfo =
                    String.Format(
                    "- DeviceName: {0}{1}  Connected: {2}{1}  Address: {3}{1}  Last seen: {4}{1}  Last used: {5}{1}",
                    gpsDevice.DeviceName, Environment.NewLine, gpsDevice.Connected, gpsDevice.DeviceAddress, gpsDevice.LastSeen,
                    gpsDevice.LastUsed);
                blueToothInfo += string.Format("  Class of device{0}   Device: {1}{0}   Major Device: {2}{0}   Service: {3}",
                    Environment.NewLine, gpsDevice.ClassOfDevice.Device, gpsDevice.ClassOfDevice.MajorDevice, gpsDevice.ClassOfDevice.Service);
                Console.WriteLine(blueToothInfo);
                Console.WriteLine();
            }

            // Pair
            bool isPaired = BluetoothSecurity.PairRequest(gpsDevice.DeviceAddress, "0000");
            if (isPaired)
            {
                Console.WriteLine("Pair successful");
                bluetoothClient.BeginConnect(gpsDevice.DeviceAddress, BluetoothService.SerialPort, new AsyncCallback(HandleRecivedData), gpsDevice);
            }
            else
            {
                Console.WriteLine("Pair unsuccessful");
                throw new Exception();
            }
            gpsDevice.SetServiceState(BluetoothService.ObexObjectPush, true);
            gpsDevice.Update();
            gpsDevice.Refresh();


            latitiudeLabel.Text = latitiude[0] + "\u00b0" + latitiude[1] + "\'" + latitiude[2] + "\"" + dir[0];
            logitiudeLabel1.Text = longitiude[0] + "\u00b0" + longitiude[1] + "\'" + longitiude[2] + "\"" + dir[1];
            //Task task = new Task(() =>
            //{
            //    latitiudeLabel.Text = latitiude[0] + "\u00b0" + latitiude[1] + "\'" + latitiude[2] + "\"" + dir[0];
            //    logitiudeLabel1.Text = longitiude[0] + "\u00b0" + longitiude[1] + "\'" + longitiude[2] + "\"" + dir[1];

            //}, TaskScheduler.FromCurrentSynchronizationContext()).Start();
        }

        private static void HandleRecivedData(IAsyncResult result)
        {
            if (result.IsCompleted)
            {
                bool readExceptionOccured = false;
                var myNetworkStream = bluetoothClient.GetStream();
                while (!readExceptionOccured)
                {
                    if (myNetworkStream.CanRead)
                    {
                        byte[] myReadBuffer = new byte[8192];
                        StringBuilder message = new StringBuilder();
                        int readBytes = 0;

                        do
                        {
                            readBytes = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                            message.Append(Encoding.ASCII.GetString(myReadBuffer, 0, readBytes));

                        }
                        while (myNetworkStream.DataAvailable);

                        String fullMsg = message.ToString();
                        //Console.WriteLine("Read sentence: " + fullMsg);

                        MatchCollection matches = Regex.Matches(fullMsg, "\\$GP...(,.*)+\r\n");
                        List<string> msgList = new List<string>();
                        foreach (var match in matches)
                        {
                            msgList.Add(match.ToString());
                        }

                        convertGPSData(msgList);
                    }
                    else
                    {
                        Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
                    }
                   
                }
            }
        }

        static void convertGPSData(List<string> gpsMessages)
        {
            string[] splittedMsg = new string[20];
            foreach (var msg in gpsMessages)
            {
                if (!msg.Substring(1, 5).Equals("GPGGA"))
                {
                    continue;
                }
                Console.WriteLine("Parsed msg: " + msg);
                splittedMsg =  msg.Split(',');
                // Convert
                latitiude[0] = Convert.ToInt32(splittedMsg[2].Substring(0, 2));
                latitiude[1] = Convert.ToInt32(Convert.ToDouble(splittedMsg[2].Substring(2, 7).Replace('.', ',')));
                latitiude[2] = Convert.ToInt32(Convert.ToDouble(splittedMsg[2].Substring(2, 7).Replace('.', ','))  * 60);
                dir[0] = splittedMsg[3].ToCharArray()[0];

                longitiude[0] = Convert.ToInt32(splittedMsg[4].Substring(0, 3));
                longitiude[1] = Convert.ToInt32(Convert.ToDouble(splittedMsg[4].Substring(3, 7).Replace('.', ',')));
                longitiude[2] = Convert.ToInt32(Convert.ToDouble(splittedMsg[4].Substring(3, 7).Replace('.', ',')) * 60);
                dir[1] = splittedMsg[5].ToCharArray()[0]
                    ;
                Console.WriteLine("Converted msg: " + latitiude[0] + "\u00b0" + latitiude[1] + "\'" + latitiude[2] + "\"" + splittedMsg[3]);
                Console.WriteLine("Converted msg: " + longitiude[0] + "\u00b0" + longitiude[1] + "\'" + longitiude[2] + "\"" + splittedMsg[5]);
            }
           
        }
    }
}
