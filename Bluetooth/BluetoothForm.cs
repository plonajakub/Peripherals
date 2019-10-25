using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;

namespace Bluetooth
{
    public partial class BluetoothForm : Form
    {
        private readonly BluetoothManager bluetoothManager;
        private string UserFilePath { get; set; }

        public BluetoothForm()
        {
            InitializeComponent();

            bluetoothManager = new BluetoothManager();

            UserFilePath = string.Empty;

            this.foundDevicesListBox.DisplayMember = "DeviceName";
            this.foundDevicesListBox.ValueMember = "DeviceAddress";

            this.pairedDevicesListBox.DisplayMember = "DeviceName";
            this.pairedDevicesListBox.ValueMember = "DeviceAddress";
        }

        #region Callback methods
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.searchButton.Enabled = false;
            Log("Scanning area for Bluetooth devices...");

            Task<BluetoothDeviceInfo[]> task = new Task<BluetoothDeviceInfo[]>(() => bluetoothManager.DiscoverDevices(64, true, true, true, false));
            task.ContinueWith(searchTask =>
            {
                this.foundDevicesListBox.DataSource = searchTask.Result;
                Log("completed!", true);
                Log("Found " + searchTask.Result.Length + " device(s)", true);
                this.searchButton.Enabled = true;
            },
            TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();
        }

        private void PairButton_Click(object sender, EventArgs e)
        {
            this.pairButton.Enabled = false;
            if (foundDevicesListBox.SelectedItem == null)
            {
                Log("Device to pair not selected. Select a device and try again.", true);
                this.pairButton.Enabled = true;
                return;
            }
            BluetoothDeviceInfo device = (BluetoothDeviceInfo)foundDevicesListBox.SelectedItem;
            Log("Pairing with device \"" + device.DeviceName + "\"...");

            Task<bool> task = new Task<bool>(() => bluetoothManager.PairDevice(device.DeviceAddress));
            task.ContinueWith(pairDeviceTask =>
            {
                this.pairedDevicesListBox.DataSource = bluetoothManager.Devices.Where(deviceInfo => deviceInfo.Authenticated).ToArray();
                Log(((pairDeviceTask.Result) ? "completed" : "failed") + "!", true);
                Log("Available services: ", true);
                device.Refresh();
                foreach (var service in device.InstalledServices)
                {
                    Log(" * ");
                    string serviceName = BluetoothService.GetName(service);
                    if (serviceName != null && !serviceName.Equals(string.Empty))
                    {
                        Log(serviceName, true);
                    } else
                    {
                        Log(service.ToString(), true);
                    }
                }
                this.pairButton.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();
        }

        private void UnpairButton_Click(object sender, EventArgs e)
        {
            this.unpairButton.Enabled = false;
            if (pairedDevicesListBox.SelectedItem == null)
            {
                Log("Device to unpair not selected. Select a device and try again.", true);
                this.unpairButton.Enabled = true;
                return;
            }
            string deviceName = ((BluetoothDeviceInfo)pairedDevicesListBox.SelectedItem).DeviceName;
            Log("Unpairing device \"" + deviceName + "\"...");
            BluetoothAddress deviceAddress = (BluetoothAddress)pairedDevicesListBox.SelectedValue;

            Task<bool> task = new Task<bool>(() => bluetoothManager.UnpairDevice(deviceAddress));
            task.ContinueWith(unpairDeviceTask =>
            {
                this.pairedDevicesListBox.DataSource = bluetoothManager.Devices.Where(deviceInfo => deviceInfo.Authenticated).ToArray();
                Log(((unpairDeviceTask.Result) ? "completed" : "failed") + "!", true);
                this.unpairButton.Enabled = true;

            }, TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();
        }

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\plona\\Desktop\\BluetoothTest";
                openFileDialog.Filter = "Image files (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UserFilePath = openFileDialog.FileName;
                    this.filePathLabel.Text = openFileDialog.FileName.Split('\\').Last();
                }
                else
                {
                    UserFilePath = string.Empty;
                    this.filePathLabel.Text = "No file selected";
                }
            }
        }

        // Version without ProgressBar update

        //private void SendFileButton_Click(object sender, EventArgs e)
        //{
        //    this.sendFileButton.Enabled = false;
        //    if (UserFilePath.Equals(string.Empty))
        //    {
        //        MessageBox.Show("Please choose a file to send.", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.sendFileButton.Enabled = true;
        //        return;
        //    }
        //    if (pairedDevicesListBox.SelectedItem == null)
        //    {
        //        MessageBox.Show("Select a device and try again.", "No device selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.sendFileButton.Enabled = true;
        //        return;
        //    }
        //    Log("Sending " + UserFilePath.Split('\\').Last() + " to device " +
        //        ((BluetoothDeviceInfo)this.pairedDevicesListBox.SelectedItem).DeviceName + "...");

        //    BluetoothAddress deviceAddress = (BluetoothAddress)this.pairedDevicesListBox.SelectedValue;
        //    Task<ObexStatusCode> task = new Task<ObexStatusCode>(() =>
        //       bluetoothManager.SendFile(deviceAddress, UserFilePath));
        //    task.ContinueWith(sendFileTask =>
        //    {
        //        if ((int)sendFileTask.Result == (int)ObexStatusCode.OK + (int)ObexStatusCode.Final
        //        || sendFileTask.Result == ObexStatusCode.OK || sendFileTask.Result == ObexStatusCode.Final)
        //        {
        //            Log("completed");
        //        }
        //        else
        //        {
        //            Log("failed");
        //        }
        //        Log("! [Status code: " + sendFileTask.Result + "]", true);
        //        this.sendFileButton.Enabled = true;
        //    }, TaskScheduler.FromCurrentSynchronizationContext());
        //    task.Start();

        //}

        private void SendFileButton_Click(object sender, EventArgs e)
        {
            this.sendFileButton.Enabled = false;
            if (UserFilePath.Equals(string.Empty))
            {
                MessageBox.Show("Please choose a file to send.", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.sendFileButton.Enabled = true;
                return;
            }
            if (pairedDevicesListBox.SelectedItem == null)
            {
                MessageBox.Show("Select a device and try again.", "No device selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.sendFileButton.Enabled = true;
                return;
            }
            Log("Sending " + UserFilePath.Split('\\').Last() + " to device " +
                ((BluetoothDeviceInfo)this.pairedDevicesListBox.SelectedItem).DeviceName + "...");

            BluetoothAddress deviceAddress = (BluetoothAddress)this.pairedDevicesListBox.SelectedValue;
            Task<ObexStatusCode> task = new Task<ObexStatusCode>(() =>
               bluetoothManager.SendFile(deviceAddress, UserFilePath, this.sendFileProgressBar));
            task.ContinueWith(sendFileTask =>
            {
                Log("finished [Status: " + sendFileTask.Result + "]", true);
                this.sendFileButton.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();

        }

        // TODO Rework button to be able to start and stop a Bluetooth server
        private void ReciveFileButton_Click(object sender, EventArgs e)
        {
            Task task = new Task(() =>
            {
                bluetoothManager.ReciveFile();
            });
            task.Start();
        }

        #endregion

        #region Helpers
        private void Log(string logMessage, bool endLine = false)
        {
            this.logRichTextBox.Text += logMessage;
            if (endLine)
            {
                this.logRichTextBox.Text += "\r\n";
            }

        }

        #endregion
    }
}
