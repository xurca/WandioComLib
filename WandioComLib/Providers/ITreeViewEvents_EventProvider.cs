using System;
using WandioComLib.Events;
using WandioComLib.Utils;

namespace WandioComLib.Providers
{
    internal sealed class ITreeViewEvents_EventProvider : EventProvider, ITreeViewEvents_Event
    {
        public ITreeViewEvents_EventProvider(object obj) : base(obj)
        {
            m_riid = new Guid(Constants.TreeViewGuid);
        }
    }
}
