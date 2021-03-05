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
        private static SerialPort port = new SerialPort("COM6", 9600, Parity.None, 8, StopBits.One);
        static String app = "Spotify";
        static void Main(string[] args)
        {
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