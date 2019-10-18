using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using InTheHand.Net.Sockets;

namespace Bluetooth
{
    public partial class BluetoothForm : Form
    {
        private readonly BluetoothManager bluetoothManager;

        public BluetoothForm()
        {
            InitializeComponent();

            bluetoothManager = new BluetoothManager();

            this.foundDevicesListBox.DisplayMember = "DeviceName";
            this.foundDevicesListBox.ValueMember = null;

            this.pairedDevicesListBox.DisplayMember = "DeviceName";
            this.pairedDevicesListBox.ValueMember = null;
        }

        #region Callback methods
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.searchButton.Enabled = false;
            Log("Scanning area for Bluetooth devices...");

            Task<int> task = new Task<int>(() => bluetoothManager.DiscoverDevices(64, true, true, true, false));
            task.ContinueWith(searchTask =>
            {
                this.foundDevicesListBox.DataSource = bluetoothManager.Devices;
                Log("completed!", true);
                Log("Found " + searchTask.Result + " device(s)", true);
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
            string deviceName = ((BluetoothDeviceInfo)foundDevicesListBox.SelectedItem).DeviceName;
            Log("Pairing with device \"" + deviceName + "\"...");

            Task<bool> task = new Task<bool>(() => bluetoothManager.PairDevice(deviceName));
            task.ContinueWith(pairDeviceTask =>
            {
                this.pairedDevicesListBox.DataSource = bluetoothManager.Devices.Where(deviceInfo => deviceInfo.Authenticated).ToArray();
                Log(((pairDeviceTask.Result) ? "completed" : "failed") + "!", true);
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

            Task<bool> task = new Task<bool>(() => bluetoothManager.UnpairDevice(deviceName));
            task.ContinueWith(unpairDeviceTask =>
            {
                this.pairedDevicesListBox.DataSource = bluetoothManager.Devices.Where(deviceInfo => deviceInfo.Authenticated).ToArray();
                Log(((unpairDeviceTask.Result) ? "completed" : "failed") + "!", true);
                this.unpairButton.Enabled = true;

            }, TaskScheduler.FromCurrentSynchronizationContext());
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
