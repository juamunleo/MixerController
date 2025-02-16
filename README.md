# MixerController
## Description
Simple application to control the Windows mixer using self-made hardware and software on the Arduino platform.

## Build the device
The code for the Arduino board can be found in *MixerController_Arduino*.

You can modify the ports where the potentiometers are connected. By default, they are connected to A0-A3.

## Download desktop software
[Here](https://github.com/juamunleo/MixerController/releases) you can download a `.zip` file containing the compiled application for Windows (tested only on Windows 10) and a basic configuration (`*.config` file).

## Features
* Control the output volume for specific devices.
* Control the output volume for specific applications.
* Up to 4 devices/applications at the same time.

## Notes
* There is a checkbox named *Control default*. This checkbox will make the MixerController control with the first potentiometer whichever is the default output device in that moment. If the default output device is changed in the Windows settings, MixerController will change automatically to control it.
* If the application doesn't show on the list, try to play some audio on that application and then click the *Refresh* button while the audio is playing.


## Demo
[Youtube](https://youtu.be/5Ogaj28Uj90)
