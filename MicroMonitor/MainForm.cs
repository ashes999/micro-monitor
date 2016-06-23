using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroMonitor
{
    public partial class MainForm : Form
    {
        List<string> computerNames = new List<string>();
        List<string> statuses = new List<string>();

        Timer refreshTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var names = ConfigurationManager.AppSettings["Computers"];
            if (!string.IsNullOrEmpty(names))
            {
                computerNames = names.Split(new char[] { ',' }).ToList();
                foreach (var computer in computerNames)
                {
                    statuses.Add("Loading ...");
                }

                RefreshDisplay();
            }

            refreshTimer.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
            refreshTimer.Tick += (innerSender, eventArgs) =>
            {
                PingAndUpdateStatuses();
            };

            refreshTimer.Start();
            // Do it immediately
            PingAndUpdateStatuses();
        }

        private void PingAndUpdateStatuses()
        {
            // Ping all
            this.statuses.Clear();

            foreach (var computer in computerNames)
            {
                var status = PingHost(computer);
                statuses.Add(StatusToMessage(status));
            }

            // Update status
            this.RefreshDisplay();
        }

        private string StatusToMessage(IPStatus status)
        {
            switch (status)
            {
                case IPStatus.Success:
                    return "Online";
                default:
                    return "Offline";
            }
        }

        public IPStatus PingHost(string host)
        {
            //string to hold our return messge
            string returnMessage = string.Empty;

            //IPAddress instance for holding the returned host
            //set the ping options, TTL 128
            PingOptions pingOptions = new PingOptions(128, true);

            //create a new ping instance
            Ping ping = new Ping();

            //32 byte buffer (create empty)
            byte[] buffer = new byte[32];

            try
            {
                PingReply pingReply = ping.Send(host, 1000, buffer, pingOptions);

                if (pingReply != null)
                {
                    return pingReply.Status;
                }
                else
                {
                    return IPStatus.Unknown;
                }
            }
            catch (PingException)
            {
                return IPStatus.Unknown;
            }
            catch (SocketException)
            {
                return IPStatus.Unknown;
            }
        }

        private void RefreshDisplay()
        {
            this.uxComputerList.Items.Clear();
            for (int i = 0; i < computerNames.Count; i++)
            {
                var computer = computerNames[i];
                var status = statuses[i];
                this.uxComputerList.Items.Add(new ListViewItem(new string[] { computer, status }));
            }
        }
    }
}
