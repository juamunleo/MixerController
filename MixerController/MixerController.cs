using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixerController
{
    public partial class MixerController : Form
    {
        private CoreAudioController audioController;
        private String default_app_1 = "Spotify";
        private String default_app_2 = "Discord";
        private IAudioSession s0 = null;
        private IAudioSession s1 = null;
        private IAudioSession s2 = null;
        private IAudioSession s3 = null;
        private CoreAudioDevice d0 = null;
        private CoreAudioDevice d1 = null;
        private CoreAudioDevice d2 = null;
        private CoreAudioDevice d3 = null;
        private SerialPort port;
        private Boolean started;
        private RadioButton app_0;
        private RadioButton app_1;
        private RadioButton app_2;
        private RadioButton app_3;
        private RadioButton dev_0;
        private RadioButton dev_1;
        private RadioButton dev_2;
        private RadioButton dev_3;
        private String line = "";
        Thread t;
        public MixerController()
        {
            InitializeComponent();
        }

        private void MixerController_Load(object sender, EventArgs e)
        {
            audioController = new CoreAudioController();
            List<String> com_ports_list = SerialPort.GetPortNames().ToList();
            com_ports.Items.Clear();
            foreach (String port in com_ports_list)
            {
                com_ports.Items.Add(port);
            }
            foreach (CoreAudioDevice d in audioController.GetDevices())
            {
                if ((d.IsDefaultDevice || d.IsDefaultCommunicationsDevice) && d.IsPlaybackDevice)
                {
                    if (d.IsDefaultDevice)
                    {
                        list_0.Items.Add(d.Name);
                        list_0.SelectedItem = d.Name;
                        d0 = d;
                    }
                    foreach (IAudioSession s in d.SessionController.ActiveSessions())
                    {
                        list_1.Items.Add(s.DisplayName);
                        list_2.Items.Add(s.DisplayName);
                        list_3.Items.Add(s.DisplayName);
                        if (s.DisplayName.Equals(default_app_1))
                        {
                            s1 = s;
                            list_1.SelectedItem = s1.DisplayName;
                        }
                        else if (s.DisplayName.Equals(default_app_2))
                        {
                            s2 = s;
                            list_2.SelectedItem = s2.DisplayName;
                        }
                    }
                }
            }
        }
        private void refresh_com_ports_Click(object sender, EventArgs e)
        {
            List<String> com_ports_list = SerialPort.GetPortNames().ToList();
            com_ports.Items.Clear();
            foreach (String p in com_ports_list)
            {
                com_ports.Items.Add(p);
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                app_0 = select_app_0;
                app_1 = select_app_1;
                app_2 = select_app_2;
                app_3 = select_app_3;
                dev_0 = select_device_0;
                dev_1 = select_device_1;
                dev_2 = select_device_2;
                dev_3 = select_device_3;
                if (com_ports.SelectedItem != null)
                {
                    port = new SerialPort(com_ports.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
                    port.Open();
                    start.Text = "Stop";
                    started = true;
                }
                t = new Thread(Listen);
                t.Start();
            }
            else
            {
                started = false;
                port.Close();
                port.Dispose();
                start.Text = "Start";
            }
        }

        private void Listen()
        {
            while (started) {
                try
                {
                    line = port.ReadLine();
                }catch(Exception){ }
                if (line.StartsWith("0"))
                {
                    if (app_0.Checked)
                    {
                        if (s0 != null)
                        {
                            s0.Volume = int.Parse(line.Substring(1));
                        }
                    }
                    else if (dev_0.Checked)
                    {
                        if (d0 != null)
                        {
                            d0.Volume = int.Parse(line.Substring(1));
                        }
                    }
                }
                if (line.StartsWith("1"))
                {
                    if (app_1.Checked)
                    {
                        if (s1 != null)
                        {
                            s1.Volume = int.Parse(line.Substring(1));
                        }
                    }
                    else if (dev_1.Checked)
                    {
                        if (d1 != null)
                        {
                            d1.Volume = int.Parse(line.Substring(1));
                        }
                    }
                }
                if (line.StartsWith("2"))
                {
                    if (app_2.Checked)
                    {
                        if (s2 != null)
                        {
                            s2.Volume = int.Parse(line.Substring(1));
                        }
                    }
                    else if (dev_2.Checked)
                    {
                        if (d2 != null)
                        {
                            d2.Volume = int.Parse(line.Substring(1));
                        }
                    }
                }
                if (line.StartsWith("3"))
                {
                    if (app_3.Checked)
                    {
                        if (s3 != null)
                        {
                            s3.Volume = int.Parse(line.Substring(1));
                        }
                    }
                    else if (dev_3.Checked)
                    {
                        if (d3 != null)
                        {
                            d3.Volume = int.Parse(line.Substring(1));
                        }
                    }
                }
            }
        }

        private void refresh_0_Click(object sender, EventArgs e)
        {
            if (select_device_0.Checked)
            {
                Refresh_List_Device(list_0);
            }
            else if (select_app_0.Checked)
            {
                Refresh_List_App(list_0);
            }
        }



        private void refresh_1_Click(object sender, EventArgs e)
        {
            if (select_device_1.Checked)
            {
                Refresh_List_Device(list_1);
            }
            else if (select_app_1.Checked)
            {
                Refresh_List_App(list_1);
            }
        }

        private void refresh_2_Click(object sender, EventArgs e)
        {
            if (select_device_2.Checked)
            {
                Refresh_List_Device(list_2);
            }
            else if (select_app_2.Checked)
            {
                Refresh_List_App(list_2);
            }
        }

        private void refresh_3_Click(object sender, EventArgs e)
        {
            if (select_device_3.Checked)
            {
                Refresh_List_Device(list_3);
            }
            else if (select_app_3.Checked)
            {
                Refresh_List_App(list_3);
            }
        }

        private void Refresh_List_App(ComboBox list)
        {
            list.Items.Clear();
            foreach (CoreAudioDevice d in audioController.GetDevices())
            {
                if ((d.IsDefaultDevice || d.IsDefaultCommunicationsDevice) && d.IsPlaybackDevice)
                {
                    foreach (IAudioSession s in d.SessionController.ActiveSessions())
                    {
                        list.Items.Add(s.DisplayName);
                    }
                }
            }
            if (list.Items.Count > 0)
            {
                list.SelectedIndex = 0;
            }
        }

        private void Refresh_List_Device(ComboBox list)
        {
            list.Items.Clear();
            foreach (CoreAudioDevice d in audioController.GetDevices())
            {
                if (d.IsPlaybackDevice)
                {
                    list.Items.Add(d.Name);
                }
            }
            if (list.Items.Count > 0)
            {
                list.SelectedIndex = 0;
            }
        }

        private void list_0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (select_device_0.Checked)
            {
                SetDevice(list_0, 0);
            }
            else if (select_app_0.Checked)
            {
                SetSession(list_0, 0);
            }
        }

        private void list_1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (select_device_1.Checked)
            {
                SetDevice(list_1, 1);
            }
            else if (select_app_1.Checked)
            {
                SetSession(list_1, 1);
            }
        }
        private void list_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (select_device_2.Checked)
            {
                SetDevice(list_2, 2);
            }
            else if (select_app_2.Checked)
            {
                SetSession(list_2, 2);
            }
        }

        private void list_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (select_device_3.Checked)
            {
                SetDevice(list_3, 3);
            }
            else if (select_app_3.Checked)
            {
                SetSession(list_3, 3);
            }
        }

        private void SetDevice(ComboBox list, int d)
        {
            foreach (CoreAudioDevice dev in audioController.GetDevices())
            {
                if (dev.Name.Equals(list.SelectedItem.ToString()))
                {
                    if (d == 0)
                    {
                        d0 = dev;
                    }
                    else if (d == 1)
                    {
                        d1 = dev;
                    }
                    else if (d == 2)
                    {
                        d2 = dev;
                    }
                    else if (d == 3)
                    {
                        d3 = dev;
                    }
                }
            }
        }

        private void SetSession(ComboBox list, int ses)
        {
            foreach (CoreAudioDevice d in audioController.GetDevices())
            {
                if ((d.IsDefaultDevice || d.IsDefaultCommunicationsDevice) && d.IsPlaybackDevice)
                {
                    foreach (IAudioSession s in d.SessionController.ActiveSessions())
                    {
                        if (s.DisplayName.Equals(list.SelectedItem.ToString()))
                        {
                            if (ses == 0)
                            {
                                s0 = s;
                            }else if(ses == 1)
                            {
                                s1 = s;
                            }else if(ses == 2)
                            {
                                s2 = s;
                            }else if(ses == 3)
                            {
                                s3 = s;
                            }
                        }
                    }
                }
            }
        }

        private void select_app_0_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_App(list_0);
        }

        private void select_device_0_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_Device(list_0);
        }

        private void select_app_1_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_App(list_1);
        }

        private void select_device_1_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_Device(list_1);
        }

        private void select_app_2_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_App(list_2);
        }

        private void select_device_2_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_Device(list_2);
        }

        private void select_app_3_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_App(list_3);
        }

        private void select_device_3_CheckedChanged(object sender, EventArgs e)
        {
            Refresh_List_Device(list_3);
        }
    }
}
