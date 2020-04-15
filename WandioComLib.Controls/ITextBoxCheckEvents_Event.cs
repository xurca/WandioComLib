using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WandioComLib.Controls
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ComEventInterface(typeof(ITextBoxCheckEvents), typeof(ITextBoxCheckEvents_EventProvider))]
    [ComVisible(false)]
    public interface ITextBoxCheckEvents_Event
    {
        [DispId(1)]
        event OnCheckBoxClickEventHandler OnCheckBoxClick;
    }
}
