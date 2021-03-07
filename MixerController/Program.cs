using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace MixerController
{
    public class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MixerController());
        }
        private void test()
        {
            SerialPort port = new SerialPort("COM6", 9600, Parity.None, 8, StopBits.One);
            String app = "Spotify";
            port.Open();
            while (true)
            {
                Console.Write(port.ReadLine());
                CoreAudioController audioController = new CoreAudioController();
                foreach (CoreAudioDevice d in audioController.GetDevices())
                {

                    if ((d.IsDefaultDevice || d.IsDefaultCommunicationsDevice) && d.IsPlaybackDevice)
                    {
                        foreach (IAudioSession s in d.SessionController.ActiveSessions())
                        {
                            if (s.DisplayName.Equals(app))
                            {
                                //s.Volume = Int32.Parse(port.ReadLine());
                                Console.Write(s.DisplayName + ": " + s.Volume);
                            }
                        }
                    }

                }
            }
        }
    }
   
}