using System;
using System.Security;
using Microsoft.Win32;

namespace OvpnSvcSetup
{
	class OvpnConfig
	{
		private string regKey = "SOFTWARE\\OpenVPN";
		private string configDir;
		private string configExt;
		
		public string RegKey    { get { return this.regKey;    } }
		public string ConfigDir { get { return this.configDir; } }
		public string ConfigExt { get { return this.configExt; } }
		
		public OvpnConfig ()
		{
			switch (System.Environment.OSVersion.Platform.ToString ())
			{
			case "Unix":
				configDir = System.IO.Path.GetFullPath ("/etc/openvpn");
				configExt = "conf";
				break;
			case "Win32NT":
				configDir = this.GetRegistryData ("config_dir");
				configExt = this.GetRegistryData ("config_ext");
				break;
			default:
				Console.WriteLine ("ERROR: Unable to detect the operating system!");
				Environment.Exit(1);
				break;
			}
		}
		
		private string GetRegistryData (string value)
		{
			RegistryKey hklm;
			RegistryKey key;

			// Try getting OpenVPN's configuration from 32-bit registry. If nothing is found,
			// search the 64-bit registry. This should work even if 32-bit OpenVPN has been
			// installed on a 64-bit Windows.
			try {
				hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
				key = hklm.OpenSubKey(this.regKey);
				string retval = key.GetValue(value).ToString ();
				return retval;
			} catch (NullReferenceException nre32) {
				try {
					hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
					key = hklm.OpenSubKey(this.regKey);
					string retval = key.GetValue(value).ToString ();
					return retval;
				} catch (NullReferenceException nre64) {
					Console.WriteLine ("ERROR: OpenVPN registry settings not found. Is OpenVPN installed?");
					Environment.Exit(1);
					// TODO: figure out a cleaner way to do this
					return "";
				}
			}
		}
	}
}