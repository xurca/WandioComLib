using System.Runtime.InteropServices;
using System.Windows.Forms;
using WandioComLib.Events;

namespace WandioComLib.Interfaces
{
    [TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable)]
    [ComVisible(true)]
    public interface ITreeView
    {
        [DispId(0)]
        void AddNode(string node);
        [DispId(1)]
        void AddNodes(string[] nodes);
    }
}
