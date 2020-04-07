using System;
using System.Runtime.InteropServices;

namespace WandioComLib.Controls
{
    [Guid("64C6CEC1-B855-4B7C-B2C8-31F7879DEA4E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ITextBoxCheckEvents
    {
        [DispId(1)]
        void OnCheckBoxClick(string val);
    }
}
