using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using System.IO;

namespace lab_bluetooth
{
    public partial class Form1 : Form
    {
        List<BluetoothDeviceInfo> devices;
        BluetoothClient bluetoothClient;
        List<BluetoothRadio> adapters;
        string UserFilePath { get; set; }

        public Form1()
        {
            InitializeComponent();

            bluetoothClient = new BluetoothClient();
            devices = new List<BluetoothDeviceInfo>();
            adapters = new List<BluetoothRadio>();

            this.discoveryListBox.DisplayMember = "DeviceName";
            this.discoveryListBox.ValueMember = null;

            this.pairedListBox.DisplayMember = "DeviceName";
            this.pairedListBox.ValueMember = null;

            adapters.AddRange(BluetoothRadio.AllRadios);

            //this.sendFileProgressBar.Increment(1);

            Log("Available adapters: ", true);
            foreach (var adapter in adapters)
            {
                Log("Name: " + adapter.Name + "\r\naddress: " + adapter.LocalAddress + "\r\nclass of device: " + adapter.ClassOfDevice, true);
            }

        }

        private void discoverButton_Click(object sender, EventArgs e)
        {
            this.discoverButton.Enabled = false;
            Task task = new Task(() =>
            {
                devices.AddRange(bluetoothClient.DiscoverDevices(256, true, true, true, false).ToArray());
            });

            task.ContinueWith(t =>
            {
                foreach (var device in devices)
                {
                    Log("Device found: deviceName = " + device.DeviceName + ", DeviceAddress = " + device.DeviceAddress + ", Authenticated = " + device.Authenticated, true);
                }
                this.discoverButton.Enabled = true;
                this.discoveryListBox.DataSource = devices;

            }, TaskScheduler.FromCurrentSynchronizationContext());

            task.Start();
        }

        private void pairButton_Click(object sender, EventArgs e)
        {
            BluetoothDeviceInfo selectedDevice = devices.Where((device => device.DeviceName.Equals(((BluetoothDeviceInfo)this.discoveryListBox.SelectedItem).DeviceName))).Last();
            Task<bool> task = new Task<bool>(() => BluetoothSecurity.PairRequest(selectedDevice.DeviceAddress, "0000"));

            task.ContinueWith(t =>
            {
                if (task.Result)
                {
                    Log("Connected with :" + selectedDevice.DeviceName, true);
                }
                foreach (var device in devices)
                {
                    device.Refresh();
                }
                this.pairedListBox.DataSource = devices.Where((device) => device.Authenticated).ToArray();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            task.Start();
        }

        private void Log(string logLine, bool isEndLine)
        {
            this.logRichTextBox.Text += logLine;
            if (isEndLine)
            {
                this.logRichTextBox.Text += "\r\n";
            }
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\lab\\Desktop\\bluetooth_files";
                openFileDialog.Filter = "Image files (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UserFilePath = openFileDialog.FileName;
                    this.selectedFileLabel.Text = openFileDialog.FileName.Split('\\').Last();
                }
                else
                {
                    UserFilePath = string.Empty;
                    this.selectedFileLabel.Text = "No file selected";
                }
            }
        }

        //private void sendfileButton_Click(object sender, EventArgs e)
        //{
        //    BluetoothDeviceInfo selectedDevice = devices.Where((device => device.DeviceName.Equals(((BluetoothDeviceInfo)this.pairedListBox.SelectedItem).DeviceName))).Last();
        //    Task<ObexStatusCode> task = new Task<ObexStatusCode>(() => 
        //    {
        //        selectedDevice.SetServiceState(BluetoothService.ObexObjectPush, true);

        //        Uri uri = new Uri("obex://" + selectedDevice.DeviceAddress + "//" + UserFilePath);
        //        ObexWebRequest request = new ObexWebRequest(uri);
        //        request.ReadFile(UserFilePath);
        //        ObexWebResponse response = (ObexWebResponse)request.GetResponse();
        //        response.Close();

        //        selectedDevice.SetServiceState(BluetoothService.ObexObjectPush, false);
        //        return response.StatusCode;


        //    });

        //    task.ContinueWith(t =>
        //    {
        //        Log("File sent. StatusCode = [" + t.Result + "]", true);
        //    }, TaskScheduler.FromCurrentSynchronizationContext());

        //    task.Start();

        //}

        private void sendfileButton_Click(object sender, EventArgs e)
        {
            BluetoothDeviceInfo selectedDevice = devices.Where((device => device.DeviceName.Equals(((BluetoothDeviceInfo)this.pairedListBox.SelectedItem).DeviceName))).Last();
            Task<ObexStatusCode> task = new Task<ObexStatusCode>(() =>
            {
                int fileBytes = 0;
                FileStream fs = File.OpenRead(UserFilePath);

                byte[] buffer = new byte[1024];
                int temp = 1;
                while (temp != 0)
                {
                    temp = fs.Read(buffer, 0, buffer.Length);
                    fileBytes += temp;
                }
                fs.Close();


                selectedDevice.SetServiceState(BluetoothService.RFCommProtocol, true);
                selectedDevice.SetServiceState(BluetoothService.ObexFileTransfer, true);
                selectedDevice.SetServiceState(BluetoothService.ObexProtocol, true);
                Uri uri = new Uri("obex://" + selectedDevice.DeviceAddress + "//" + UserFilePath);
                ObexWebRequest request = new ObexWebRequest(uri);

                Stream requestStream = request.GetRequestStream();
                fs = File.OpenRead(UserFilePath);

                buffer = new byte[1024];
                int sentBytes = 0;
                temp = 1;
                while (temp != 0)
                {
                    temp = fs.Read(buffer, 0, buffer.Length);
                    sentBytes += temp;
                    requestStream.Write(buffer, 0, temp);
                    this.sendFileProgressBar.Invoke(new Action(() => sendFileProgressBar.Increment(sentBytes / fileBytes)));
                }
                requestStream.Close();
                ObexWebResponse response = (ObexWebResponse)request.GetResponse();
                response.Close();
                return response.StatusCode;

            });


            task.ContinueWith(t =>
            {
                Log("File sent. StatusCode = [" + t.Result + "]", true);
            }, TaskScheduler.FromCurrentSynchronizationContext());

            task.Start();

        }


    }

}
