using System.Runtime.InteropServices;

namespace WandioComLib.Controls
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class ITextBoxCheckEvents_SinkHelper : ITextBoxCheckEvents
    {
        public int m_dwCookie;

        public OnCheckBoxClickEventHandler m_OnCheckBoxClick;

        public ITextBoxCheckEvents_SinkHelper()
        {
            m_dwCookie = 0;
            m_OnCheckBoxClick = null;
        }

        public void OnCheckBoxClick(string val)
        {
            this.m_OnCheckBoxClick?.Invoke(val);
        }
    }
}
