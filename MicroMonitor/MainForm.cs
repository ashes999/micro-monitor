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
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        private List<string> computerNames = new List<string>();
        private List<string> statuses = new List<string>();

        Timer refreshTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Restore", (s2, e2) => this.Show());
            trayMenu.MenuItems.Add("Exit", (s2, e2) => Application.Exit());

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Micro Monitor";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.DoubleClick += (s2, e2) => this.Show();

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            // Load the computers and refresh status
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

            // Update tray icon
            if (statuses.Any(s => s == "Offline"))
            {
                trayIcon.Icon = new Icon(SystemIcons.Error, 40, 40);
            }
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

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;                
            }

            this.Hide();
        }
    }
}
