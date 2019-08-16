# SensorDots Port MuxR Tool

A GUI application to aid with the control and operation of Port MuxR boards. Multiple boards can be controlled and chained together using this tool.

## Installation

Requires .NET 4.0

## Mono Instructions

Runs out of the box with mono (you might need to run as sudo or change ownership of the serial port):

mono PortMuxRTool.exe

If compiling with the latest version of mono, you might need to run the following:

xbuild /p:TargetFrameworkVersion="v4.5"

As the 4.0 target doesn't get installed.

You may need to run as sudo or give rw access to the serial port (sudo chmod 666 /dev/ttyUSB0 or setup some udev rules to do this).

When running under mono, it shows all serial ports (rather than just ones found active). You might need to "arrow down" to reach the last item on the dropdown list, as the scrollbar doesn't move all the way to the bottom of the list under mono.

If you get an "Error getting board state" message, this is because the DTR pin is being toggled on port open, which resets the board. Some Linux distributions allow you to disable this with the "stty -F /dev/ttyUSB0 -hupcl" command. However, if this doesn't work, you can cut the trace between the DTR pins. You will need to resolder these pins together when you want to update the firmware (or hit the reset button during the Arduino programming process).
