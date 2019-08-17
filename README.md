# SensorDots Port MuxR Tool

A GUI application to aid with the control and operation of Port MuxR boards. Multiple boards can be controlled and chained together using this tool.

## Installation

Requires .NET 4.0

## Mono Instructions

The compiled exe (in the [Release](https://github.com/SensorDots/PortMuxRTool/tree/master/PortMuxRTool/bin/Release) directory) runs out of the box with mono (you might need to run as sudo or change ownership of the serial port):
```
mono PortMuxRTool.exe
```
Alternatively you can compile from source (just run xbuild in the same directory as the PortMuxRTool.sln file). If compiling with the latest version of mono, you might need to run the following:
```
xbuild /p:TargetFrameworkVersion="v4.5"
```
As the 4.0 target doesn't get installed.

You may need to run as sudo or give rw access to the serial port (sudo chmod 666 /dev/ttyUSB0 or setup some udev rules to do this). To create some udev rules, make a new file in /etc/udev/rules.d/50-portmuxr.rules and place the following inside:
```
ATTRS{idVendor}=="10c4", ATTRS{idProduct}=="ea60", MODE="0666"
```
When running under mono, it shows all serial ports (rather than just ones found active). You might need to "arrow down" to reach the last item on the dropdown list, as the scrollbar doesn't move all the way to the bottom of the list under mono.

If you get an "Error getting board state" message, this is because the DTR pin is being toggled on port open, which resets the board. Some Linux distributions allow you to disable this with the "stty -F /dev/ttyUSB0 -hupcl -clocal" command. However, if this doesn't work, you can cut the trace between the DTR pins. You will need to resolder these pins together when you want to update the firmware (or hit the reset button during the Arduino programming process).

The alternative to this requires a modification to the usb-serial module. The quick and short of it is to remove [this line](https://github.com/torvalds/linux/blob/master/drivers/usb/serial/usb-serial.c#L712) and recompile that module.

In Ubuntu, there is some information on doing this here - https://wiki.ubuntu.com/Kernel/BuildYourOwnKernel (if you get an error about putting source URIs in your sources list, see here - https://askubuntu.com/questions/496549/error-you-must-put-some-source-uris-in-your-sources-list). Use the git method, as it downloads all sources correctly. Once you get to the "Modifying the configuration" stop, change to the sources directory then run:
```
make menuconfig
```
Then save and exit. Then run:

make drivers/usb/serial/usbserial.ko

Now just copy the usbserial.ko to 
```
/lib/modules/`uname -r`/kernel/drivers/usb/serial/
```
Then unplug the PortMuxR and run:
```
sudo rmmod cp210x
sudo rmmod usbserial
```
Now reconnect the PortMuxR and you should be ready to go.

