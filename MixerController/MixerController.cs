using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace MixerController
{
    public partial class MixerController : Form
    {
        private CoreAudioController audioController;
        private String s0 = null;
        private String s1 = null;
        private String s2 = null;
        private String s3 = null;
        private String saved0 = null;
        private String saved1 = null;
        private String saved2 = null;
        private String saved3 = null;
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
        Configuration configManager;

        public MixerController()
        {
            InitializeComponent();
        }

        private void MixerController_Load(object sender, EventArgs e)
        {
            audioController = new CoreAudioController();
            configManager = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            saved0 = ConfigurationManager.AppSettings["app0"];
            saved1 = ConfigurationManager.AppSettings["app1"];
            saved2 = ConfigurationManager.AppSettings["app2"];
            saved3 = ConfigurationManager.AppSettings["app3"];
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
                        list_1.Items.Add(Process.GetProcessById(s.ProcessId).ProcessName);
                        list_2.Items.Add(Process.GetProcessById(s.ProcessId).ProcessName);
                        list_3.Items.Add(Process.GetProcessById(s.ProcessId).ProcessName);
                    }
                }
            }
            if (ConfigurationManager.AppSettings["control_default"].Equals("true"))
            {
                controlDefault.Checked = true;
            }
            else if (saved0.Length > 0)
            {
                select_app_0.Select();
                if (!list_0.Items.Contains(saved0))
                {
                    list_0.Items.Add(saved0);
                }
                list_0.SelectedItem = saved0;
            }
            if (saved1.Length > 0)
            {
                if (!list_1.Items.Contains(saved1))
                {
                    list_1.Items.Add(saved1);
                }
                list_1.SelectedItem = saved1;
            }
            if (saved2.Length > 0)
            {
                if (!list_2.Items.Contains(saved2))
                {
                    list_2.Items.Add(saved2);
                }
                list_2.SelectedItem = saved2;
            }
            if (saved3.Length > 0)
            {
                if (!list_3.Items.Contains(saved3))
                {
                    list_3.Items.Add(saved3);
                    
                }
                list_3.SelectedItem = saved3;
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
            com_ports.SelectedIndex = 0;
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
                    try
                    {
                        port.Open();
                    }
                    catch(Exception) { }
                    if (port.IsOpen)
                    {
                        start.Text = "Stop";
                        started = true;
                        com_ports.Enabled = false;
                        refresh_com_ports.Enabled = false;
                        port.DataReceived += Listen;
                    }
                    else
                    {
                        MessageBox.Show("Check if the device is connected.", "Error");
                        this.Show();
                    }
                }
                
            }
            else
            {
                port.DataReceived -= Listen;
                started = false;
                com_ports.Enabled = true;
                refresh_com_ports.Enabled = true;
                port.Close();
                port.Dispose();
                start.Text = "Start";
            }
        }

        private void Listen(object sender, EventArgs e)
        {
            try
            {
                line = port.ReadLine();
            }catch(Exception){ }
            if (line.StartsWith("0"))
            {
                if (controlDefault.Checked)
                {
                    audioController.DefaultPlaybackDevice.Volume = int.Parse(line.Substring(1));
                }
                else
                { 
                    if (app_0.Checked)
                    {
                        if (s0 != null)
                        {
                            List<IAudioSession> l = audioController.DefaultPlaybackDevice.SessionController.ActiveSessions().Where(x => Process.GetProcessById(x.ProcessId).ProcessName.Equals(s0)).ToList();
                            if(l.Count > 0) { l.First().Volume = int.Parse(line.Substring(1)); }
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
            }
            if (line.StartsWith("1"))
            {
                if (app_1.Checked)
                {
                    if (s1 != null)
                    {
                        List<IAudioSession> l = audioController.DefaultPlaybackDevice.SessionController.ActiveSessions().Where(x => Process.GetProcessById(x.ProcessId).ProcessName.Equals(s1)).ToList();
                        if (l.Count > 0) { l.First().Volume = int.Parse(line.Substring(1)); }
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
                        List<IAudioSession> l = audioController.DefaultPlaybackDevice.SessionController.ActiveSessions().Where(x => Process.GetProcessById(x.ProcessId).ProcessName.Equals(s2)).ToList();
                        if (l.Count > 0) { l.First().Volume = int.Parse(line.Substring(1)); }
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
                        List<IAudioSession> l = audioController.DefaultPlaybackDevice.SessionController.ActiveSessions().Where(x => Process.GetProcessById(x.ProcessId).ProcessName.Equals(s3)).ToList();
                        if (l.Count > 0) { l.First().Volume = int.Parse(line.Substring(1)); }
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
                        list.Items.Add(Process.GetProcessById(s.ProcessId).ProcessName);
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
            if (ses == 0)
            {
                s0 = list.SelectedItem.ToString();
            }
            else if(ses == 1)
            {
                s1 = list.SelectedItem.ToString();
            }else if(ses == 2)
            {
                s2 = list.SelectedItem.ToString();
            }else if(ses == 3)
            {
                s3 = list.SelectedItem.ToString();
            }
            configManager.AppSettings.Settings.Remove("app" + ses);
            configManager.AppSettings.Settings.Add("app" + ses, list.SelectedItem.ToString());
            configManager.Save(ConfigurationSaveMode.Modified);
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

        private void MixerController_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.TopMost = true;
        }

        private void MixerController_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }

        private void controlDefault_CheckStateChanged(object sender, EventArgs e)
        {
            if (controlDefault.Checked)
            {
                select_device_0.Enabled = false;
                select_app_0.Enabled = false;
                list_0.Enabled = false;
                refresh_0.Enabled = false;
                configManager.AppSettings.Settings.Remove("app0");
                configManager.AppSettings.Settings.Add("app0", "");
                configManager.AppSettings.Settings.Remove("control_default");
                configManager.AppSettings.Settings.Add("control_default", "true");
                configManager.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                select_device_0.Enabled = true;
                select_app_0.Enabled = true;
                list_0.Enabled = true;
                refresh_0.Enabled = true;
                configManager.AppSettings.Settings.Add("control_default", "false");
                configManager.Save(ConfigurationSaveMode.Modified);
            }
        }
    }
}
