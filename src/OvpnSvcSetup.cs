using System;

namespace OvpnSvcSetup
{
	public class OvpnSvcSetup
	{
		// Instance variables
		private bool is64Bit;
		
		// Instance variables and automated getters and setters
		public bool Is64Bit { get { return this.is64Bit; } }

		// Constructors
		public OvpnSvcSetup() {
			this.is64Bit = CheckIf64Bit();
		}
		
		// Auxiliary methods
		private static Boolean CheckIf64Bit() {
			// Detect if we're in 32-bit or 64-bit mode. For details see
			//
			// <https://msdn.microsoft.com/en-us/library/ms973190.aspx>
			//
			switch (IntPtr.Size)
			{
			case 4:	return false;
			case 8:	return true;
			default:
				Console.WriteLine ("ERROR: unable to determine runtime bitness!");
				Environment.Exit (1);
				return false;
			}
		}

		static public void Main()
		{
			OvpnSvcSetup mainProgram = new OvpnSvcSetup();
			OvpnConfig ovpnConfig = new OvpnConfig();
#if DEBUG
			Console.WriteLine ("System settings");
			Console.WriteLine ("    64-bit runtime: "+mainProgram.Is64Bit);
			Console.WriteLine ("    OS platform: "+System.Environment.OSVersion.Platform.ToString ());
			Console.WriteLine ("OpenVPN settings");
			Console.WriteLine ("    Config directory: "+ovpnConfig.ConfigDir);
			Console.WriteLine ("    Config extension: "+ovpnConfig.ConfigExt);
#endif
			Console.ReadLine ();
		}
	}
}

