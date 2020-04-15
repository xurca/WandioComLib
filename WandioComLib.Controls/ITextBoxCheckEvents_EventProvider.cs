using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WandioComLib.Controls
{
    internal sealed class ITextBoxCheckEvents_EventProvider : ITextBoxCheckEvents_Event, IDisposable
    {
        private WeakReference m_wkConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private IConnectionPoint m_ConnectionPoint;

        public event OnCheckBoxClickEventHandler OnCheckBoxClick
        {
            add
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(this, ref lockTaken);
                    if (m_ConnectionPoint == null)
                        Init();
                    var eventsSinkHelper = new ITextBoxCheckEvents_SinkHelper();
                    int pdwCookie = 0;
                    m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
                    eventsSinkHelper.m_dwCookie = pdwCookie;
                    eventsSinkHelper.m_OnCheckBoxClick = value;
                    m_aEventSinkHelpers.Add(eventsSinkHelper);
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(this);
                }
            }
            remove
            {
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(this, ref lockTaken);
                    if (m_aEventSinkHelpers == null)
                        return;
                    int count = m_aEventSinkHelpers.Count;
                    int index = 0;
                    if (0 >= count)
                        return;
                    do
                    {
                        var aEventSinkHelper = (ITextBoxCheckEvents_SinkHelper)m_aEventSinkHelpers[index];
                        if (aEventSinkHelper.m_OnCheckBoxClick != null && 
                            ((aEventSinkHelper.m_OnCheckBoxClick.Equals(value) ? 1 : 0) & (int)byte.MaxValue) != 0)
                        {
                            m_aEventSinkHelpers.RemoveAt(index);
                            m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(m_ConnectionPoint);
                                m_ConnectionPoint = null;
                                m_aEventSinkHelpers = null;
                                return;
                            }
                            goto label_11;
                        }
                        else
                            ++index;
                    }
                    while (index < count);
                    goto label_12;
                label_11:
                    return;
                label_12:;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(this);
                }
            }
        }

        private void Init()
        {
            IConnectionPoint connectionPoint = null;
            Guid guid = new Guid("64C6CEC1-B855-4B7C-B2C8-31F7879DEA4E");
            ((IConnectionPointContainer)this.m_wkConnectionPointContainer.Target).FindConnectionPoint(ref guid, out connectionPoint);
            m_ConnectionPoint = connectionPoint;
            m_aEventSinkHelpers = new ArrayList();
        }

        public ITextBoxCheckEvents_EventProvider(object obj)
        {
            m_wkConnectionPointContainer = new WeakReference((IConnectionPointContainer)obj, false);
        }

        ~ITextBoxCheckEvents_EventProvider()
        {
            bool lockTaken = false;
            try
            {
                Monitor.Enter(this, ref lockTaken);
                if (m_ConnectionPoint == null)
                    return;
                int count = m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    do
                    {
                        m_ConnectionPoint.Unadvise(((ITextBoxCheckEvents_SinkHelper)m_aEventSinkHelpers[index]).m_dwCookie);
                        ++index;
                    }
                    while (index < count);
                }
                Marshal.ReleaseComObject(m_ConnectionPoint);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(this);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
