# MicroMonitor
Personal networking monitor. Small-scale monitoring of a few machines on a local network

MicroMonitor is still in very early stages of development.

# Usage

Open up `App.config` (or `MicroMonitor.exe.config`) and specify a comma-delimited list of computers for the `Computers` app setting. For example:

- `<add key="Computers" value="inspiron-660" />` tracks one computer
- `<add key="Computers" value="inspiron-660, media-laptop" />` tracks two computers

Run `MicroMonitor.exe`. 

By default, it runs in the system-tray. You can double-click (or right-click) to show the app. To quit, right-click the tray icon and pick `Close`.

Currently, MicroMonitor will ping (and only ping) each of your machines once per minute.
