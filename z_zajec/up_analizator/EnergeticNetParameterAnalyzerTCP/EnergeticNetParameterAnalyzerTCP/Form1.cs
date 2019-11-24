using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace EnergeticNetParameterAnalyzerTCP
{
    public partial class Form1 : Form
    {
        private const string endPointIpv4Address = "192.168.1.1";
        private const int endPointTCPPort = 502;
        private TcpClient tcpClient;
        private NetworkStream ns;

        bool isLogStarted = false;
        bool isLogFinished = false;

        List<List<string>> loggedData = new List<List<string>>();

        public Form1()
        {
            InitializeComponent();

            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(endPointIpv4Address), endPointTCPPort);
                ns = tcpClient.GetStream();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Task loopTask = new Task(() =>
            {
                while (true)
                {
                    Task voltageL1LNRefreshTask = new Task(() =>
                    {
                        this.VoltageL1TextBox.Invoke(new Action(() =>
                        {
                            this.VoltageL1TextBox.Text = getVoltageL1LN();
                        }));

                    });
                    voltageL1LNRefreshTask.Start();


                    Task currentL1RefreshTask = new Task(() =>
                    {
                        this.currentL1TextBox.Invoke(new Action(() =>
                        {
                            this.currentL1TextBox.Text = getCurrentL1();
                        }));

                    });
                    currentL1RefreshTask.Start();

                    Task cosPhiL1RefreshTask = new Task(() =>
                    {
                        this.cosPhiL1TextBox.Invoke(new Action(() =>
                        {
                            this.cosPhiL1TextBox.Text = getCosPhiL1();
                        }));

                    });
                    cosPhiL1RefreshTask.Start();

                    Task activePowerL1RefreshTask = new Task(() =>
                    {
                        this.activePowerL1TexBox.Invoke(new Action(() =>
                        {
                            this.activePowerL1TexBox.Text = getActivePowerL1();
                        }));

                    });
                    activePowerL1RefreshTask.Start();

                    voltageL1LNRefreshTask.Wait();
                    currentL1RefreshTask.Wait();
                    cosPhiL1RefreshTask.Wait();
                    activePowerL1RefreshTask.Wait();

                    this.calculatedActivePowerL1TextBox.Invoke(new Action(() =>
                    {
                        this.calculatedActivePowerL1TextBox.Text = getCalculatedActivePowerL1();
                    }));
                    
                    if (isLogStarted)
                    {
                        List<string> row = new List<string>();
                        row.Add(this.VoltageL1TextBox.Text);
                        row.Add(this.currentL1TextBox.Text);
                        row.Add(this.cosPhiL1TextBox.Text);
                        row.Add(this.activePowerL1TexBox.Text);
                        loggedData.Add(row);
                    }

                    Thread.Sleep(1000);
                }
            });
            loopTask.Start();


        }

        string getVoltageL1LN()
        {
            byte[] request =
            {
                0x00, 0x01, // Transaction ID
                0x00, 0x00, // Protocol ID
                0x00, 0x06, // Length
                0x01,       // Unit ID
                0x03,       // Function ID
                0x10, 0x02, // Start Address (Register)
                0x00, 0x02  // Number of registers
                };
            ns.Write(request, 0, request.Length);

            byte[] response = new byte[15];
            ns.Read(response, 0, response.Length);
            Console.WriteLine(BitConverter.ToString(response));

            byte[] voltageL1LNHex = new byte[4];
            Array.ConstrainedCopy(response, 9, voltageL1LNHex, 0, voltageL1LNHex.Length);
            Array.Reverse(voltageL1LNHex);
            return (BitConverter.ToUInt32(voltageL1LNHex, 0) / 1000f).ToString();
        }

        string getCurrentL1()
        {
            byte[] request =
            {
                0x00, 0x01, // Transaction ID
                0x00, 0x00, // Protocol ID
                0x00, 0x06, // Length
                0x01,       // Unit ID
                0x03,       // Function ID
                0x10, 0x10, // Start Address (Register)
                0x00, 0x02  // Number of registers
                };
            ns.Write(request, 0, request.Length);

            byte[] response = new byte[15];
            ns.Read(response, 0, response.Length);
            Console.WriteLine(BitConverter.ToString(response));

            byte[] voltageL1LNHex = new byte[4];
            Array.ConstrainedCopy(response, 9, voltageL1LNHex, 0, voltageL1LNHex.Length);
            Array.Reverse(voltageL1LNHex);
            return (BitConverter.ToUInt32(voltageL1LNHex, 0) / 1000f).ToString();
        }
        string getCosPhiL1()
        {
            byte[] request =
            {
                0x00, 0x01, // Transaction ID
                0x00, 0x00, // Protocol ID
                0x00, 0x06, // Length
                0x01,       // Unit ID
                0x03,       // Function ID
                0x10, 0x20, // Start Address (Register)
                0x00, 0x02  // Number of registers
                };
            ns.Write(request, 0, request.Length);

            byte[] response = new byte[15];
            ns.Read(response, 0, response.Length);
            Console.WriteLine(BitConverter.ToString(response));

            byte[] voltageL1LNHex = new byte[4];
            Array.ConstrainedCopy(response, 9, voltageL1LNHex, 0, voltageL1LNHex.Length);
            Array.Reverse(voltageL1LNHex);
            return (BitConverter.ToInt32(voltageL1LNHex, 0) / 1000f).ToString();
        }

        string getActivePowerL1()
        {
            byte[] request =
            {
                0x00, 0x01, // Transaction ID
                0x00, 0x00, // Protocol ID
                0x00, 0x06, // Length
                0x01,       // Unit ID
                0x03,       // Function ID
                0x10, 0x30, // Start Address (Register)
                0x00, 0x02  // Number of registers
                };
            ns.Write(request, 0, request.Length);

            byte[] response = new byte[15];
            ns.Read(response, 0, response.Length);
            Console.WriteLine(BitConverter.ToString(response));

            byte[] voltageL1LNHex = new byte[4];
            Array.ConstrainedCopy(response, 9, voltageL1LNHex, 0, voltageL1LNHex.Length);
            Array.Reverse(voltageL1LNHex);
            return (BitConverter.ToInt32(voltageL1LNHex, 0)).ToString();
        }

        string getCalculatedActivePowerL1()
        {
            double activePower = Convert.ToDouble(this.VoltageL1TextBox.Text) * Convert.ToDouble(this.currentL1TextBox.Text) * Convert.ToDouble(this.cosPhiL1TextBox.Text);
            return Math.Round(activePower, 2).ToString();
        }

        private void startLoggingButton_Click(object sender, EventArgs e)
        {
            loggedData.Clear();
            isLogStarted = true;
            isLogFinished = false;
        }

        private void stopLoggingButton_Click(object sender, EventArgs e)
        {
            isLogFinished = true;
            using (var streamWriter = File.CreateText("data.csv")) {
                foreach (var row in loggedData)
                {
                    foreach (var el in row)
                    {
                        streamWriter.Write(el + ", ");
                    }
                    streamWriter.Write("\r\n");
                }
            }
        }
    }
}
