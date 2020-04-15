using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WandioComLib.Controls
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [Guid("64C6CEC1-B855-4B7C-B2C8-31F7879DEA4E")]
    public interface ITextBoxCheckEvents
    {
        [DispId(1)]
        void OnCheckBoxClick(string val);
    }
}
