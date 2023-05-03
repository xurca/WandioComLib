# WandioComLib
```
C:\Windows\SysWOW64
C:\Windows\System32

regsvr32 MSCOMCTL.OCX
-----------------------------------------

cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
regasm /codebase C:\Windows\SysWOW64\WandioComLib.Controls.dll
regasm /u C:\Windows\SysWOW64\WandioComLib.Controls.dll
gacutil /if "\Projects\WandioComLib\WandioComLib.Controls\bin\Debug\WandioComLib.Controls.dll"
tlbimp WandioComLib.Controls.dll /primary /keyfile:key.snk /namespace:Interop.WandioComLib.Controls /out:Interop.WandioComLib.Controls.dll /asmversion:1.0.0.0 /verbose
tlbimp WandioComLib.Controls.dll /keyfile:key.snk /out:Interop.WandioComLib.Controls.dll
regsvr32 WandioComLib.Controls.dll
tlbimp WandioComLib.Controls.dll namespace:Interop.WandioComLib.Controls /out:Interop.WandioComLib.Controls.dll /asmversion:1.0.0.0 /verbose


x86
cd C:\Windows\Microsoft.NET\Framework\v4.0.30319 
regasm /tlb /codebase \Projects\WandioComLib\WandioComLib.Controls\bin\x86\Debug\WandioComLib.Controls.dll
x64
cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
regasm /tlb /codebase \Projects\WandioComLib\WandioComLib.Controls\bin\x64\Debug\WandioComLib.Controls.dll


cd \Projects\WandioComLib\WandioComLib.Controls\bin\x86\Debug\
sn -k key.snk

tlbimp WandioComLib.Controls.dll  /primary /keyfile:key.snk /namespace:Interop.WandioComLib.Controls /out:Interop.WandioComLib.Controls.dll /asmversion:1.0.0.0 /verbose
```
