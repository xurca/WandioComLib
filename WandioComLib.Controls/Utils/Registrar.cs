using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WandioComLib.Controls
{
    internal static class Registrar
    {
        // register COM ActiveX object
        public static void RegisterClass(string key, string progId)
        {
            StringBuilder skey = new StringBuilder(key);
            skey.Replace(@"HKEY_CLASSES_ROOT\", "");

            //get guid from ProgID="CsharpWindowsActiveX.ActiveXUserControl"
            Type myType1 = Type.GetTypeFromProgID(progId);
            string write = $"ProgID={progId} GUID={myType1.GUID}.";
            Console.WriteLine(write);

            //write guid to a text file
            TextWriter tw;
            tw = File.CreateText("guid.txt");
            tw.WriteLine(skey.ToString());
            tw.WriteLine(myType1.GUID.ToString());
            tw.Close();

            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(skey.ToString(), true);
            RegistryKey ctrl = regKey.CreateSubKey("Control");
            ctrl.Close();
            RegistryKey inprocServer32 = regKey.OpenSubKey("InprocServer32", true);
            inprocServer32.SetValue("CodeBase", Assembly.GetExecutingAssembly().CodeBase);
            inprocServer32.Close();
            regKey.Close();
        }

        // Unregister COM ActiveX object
        public static void UnregisterClass(string key)
        {
            StringBuilder skey = new StringBuilder(key);
            skey.Replace(@"HKEY_CLASSES_ROOT\", "");
            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(skey.ToString(), true);
            regKey.DeleteSubKey("Control", false);
            RegistryKey inprocServer32 = regKey.OpenSubKey("InprocServer32", true);
            regKey.DeleteSubKey("CodeBase", false);
            regKey.Close();
        }
    }
}
