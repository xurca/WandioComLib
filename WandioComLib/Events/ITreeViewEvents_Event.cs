using System.Runtime.InteropServices;
using WandioComLib.Interfaces;
using WandioComLib.Providers;

namespace WandioComLib.Events
{
    [ComEventInterface(typeof(ITreeViewEvents), typeof(ITreeViewEvents_EventProvider))]
    [ComVisible(false)]
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    public interface ITreeViewEvents_Event
    {
    }
}
