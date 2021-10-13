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
            Application.Exit();
        }
    } 
}