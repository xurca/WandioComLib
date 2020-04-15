using System.Runtime.InteropServices;
using WandioComLib.Utils;

namespace WandioComLib.Interfaces
{
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [Guid(Constants.TreeViewGuid)]
    [ComVisible(true)]
    public interface ITreeViewEvents
    {

    }

    [TypeLibType(TypeLibTypeFlags.FHidden), ClassInterface(ClassInterfaceType.None)]
    internal sealed class ITreeViewEvents_SinkHelper : SinkHelper, ITreeViewEvents
    {
        public ITreeViewEvents_SinkHelper() : base()
        {

        }
    }
}
