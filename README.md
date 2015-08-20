# OvpnSvcSetup

A simple OpenVPN service configuration tool written using C#.

This tool - once it's finished - can be used to view the status of OpenVPN 
connections running as services. It will also be possible to enable and disable 
OpenVPN connections on a per-connection basis.

While this tool is primarily aimed at adding OpenVPN connections to NSSM 
("Non-sucking service manager") on Windows, it can be easily adapted for use 
with *NIX service managers such as systemd.

# Why?

The traditional way to run OpenVPN as a service on Windows is to use the OpenVPN 
service wrapper (openvpnserv.exe). However, that tool has not been maintained in 
many, many years and it has begun crumbling into pieces. On Windows 10 it does 
not seem to work at all without some tinkering. Therefore the traditional 
service wrapper needs to be replaced with something else. For the actual service 
monitoring NSSM is an excellent candidate, but it's general purpose 
configuration GUI is too complex for our simple use-case.

# Contributing

This tool is the author's first C# project, so all contributions are most 
welcome! Development is done using MonoDevelop to ensure this tool's usefulness 
outside Windows. It may also be possible to use Visual Studio for development.

# TODO

Note that this tool is highly work in progress and does not yet do what it's 
supposed to do. There are several missing parts right now:

* Create a list OpenVPN connections
* Show status of an OpenVPN connection (enabled, disabled, active, inactive)
* Enable/disable OpenVPN connections in NSSM
* Add a simple text-based GUI (primarily for testing)
* ... and other stuff
