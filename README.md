# SensorDots Port MuxR Tool

A GUI application to aid with the control and operation of Port MuxR boards. Multiple boards can be controlled and chained together using this tool.

This tool always polls the state of the board after each command, so the tool itself is stateless (which means you always see the actual switch configuation in the GUI). The serial port is also opened and closed for each command run. This means you can unplug and plug boards in at any time, but your current state gets cleared if you unplug that board. If you reopen the application it will pick up the state of the boards once connected.

## Installation

Requires .NET 4.0

## Mono Instructions

The compiled exe (in the [Release](https://github.com/SensorDots/PortMuxRTool/tree/master/PortMuxRTool/bin/Release) directory) runs out of the box with [mono](https://www.mono-project.com/):
```
mono PortMuxRTool.exe
```
Alternatively you can compile from source (just run xbuild in the same directory as the PortMuxRTool.sln file). If compiling with the latest version of mono, you might need to run the following, as the 4.0 target doesn't get installed:
```
xbuild /p:TargetFrameworkVersion="v4.5"
```
You may need to run as sudo or give rw access to the serial port (sudo chmod 666 /dev/ttyUSB0 or setup some udev rules to do this). To create some udev rules, make a new file in /etc/udev/rules.d/50-portmuxr.rules and place the following inside:
```
ATTRS{idVendor}=="10c4", ATTRS{idProduct}=="ea60", MODE="0666"
```
When running under mono, it shows all serial ports (rather than just ones found active). You might need to "arrow down" to reach the last item on the dropdown list, as the scrollbar doesn't move all the way to the bottom of the list under mono.

### Error Getting Board State

If you get an "Error getting board state" message, this is because the DTR pin is being toggled on port open, which resets the board. Some Linux distributions allow you to disable this with the "stty -F /dev/ttyUSB0 -hupcl -clocal" command. However, if this doesn't work, you can cut the trace between the DTR pins. You will need to resolder these pins together when you want to update the firmware (or hit the reset button during the Arduino programming process).

The alternative to this requires a modification to the usb-serial Linux kernel module. The quick and short of it is to remove [this line in drivers/usb/serial/usb-serial.c](https://github.com/torvalds/linux/blob/fdb838efa31e1ed9a13ae6ad0b64e30fdbd00570/drivers/usb/serial/usb-serial.c#L709) and recompile the kernel:
```
.dtr_rts		= serial_port_dtr_rts,
```
In Ubuntu, there is some information on compiling the kernel here - https://wiki.ubuntu.com/Kernel/BuildYourOwnKernel (if you get an error about putting source URIs in your sources list, see here - https://askubuntu.com/questions/496549/error-you-must-put-some-source-uris-in-your-sources-list, you also might need to install gawk and libudev-dev). When obtaining the sources make sure you get the correct release codename for your installation.

### Alternative USBSerial Kernel Module Re-Build
An alternative (and much much quicker) build method is to get the (currently installed) kernel sources:
```
sudo apt install linux-source-`uname -r | cut -d'-' -f1` 
sudo apt install linux-image-$(uname -r)
```
Then extract it out (it should be located in /usr/src), then run the following (you will need sudo apt install build-dep libncurses-dev flex bison) in the source directory where you extracted it:

```
cp /boot/config-`uname -r` .config
```
Then save and exit. Then run (after editing the usb-serial.c file):
```
make drivers/usb/serial/usbserial.ko
```
Now just copy the usbserial.ko to (after backing up the old one):
```
/lib/modules/`uname -r`/kernel/drivers/usb/serial/
```
Then unplug the PortMuxR and run:
```
sudo rmmod cp210x
sudo rmmod usbserial
```
Now reconnect the PortMuxR and you should be ready to go.

If you get an error such as " usbserial: version magic '5.0.18 SMP mod_unload ' should be '5.0.0-25-generic SMP mod_unload '" (from dmesg), run the make command as follows to match the expected value:
```
 make VERSION=5 PATCHLEVEL=0 SUBLEVEL=0 LOCALVERSION="-25-generic" drivers/usb/serial/usbserial.ko
```
This is safe(ish) to do if the verison number is close to the same value. Do not do this if they wildly disagree.
