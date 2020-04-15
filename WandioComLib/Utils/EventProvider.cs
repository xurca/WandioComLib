using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WandioComLib.Utils
{
    internal class EventProvider : IDisposable
    {
        internal WeakReference m_wkConnectionPointContainer;
        internal ArrayList m_aEventSinkHelpers;
        internal IConnectionPoint m_ConnectionPoint;
        internal Guid m_riid;

        internal EventProvider(object obj)
        {
            m_wkConnectionPointContainer = new WeakReference((IConnectionPointContainer)obj, false);
        }

        ~EventProvider()
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
                        m_ConnectionPoint.Unadvise(((SinkHelper)m_aEventSinkHelpers[index]).m_dwCookie);
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

        internal void Init()
        {
            IConnectionPoint connectionPoint;
            ((IConnectionPointContainer)m_wkConnectionPointContainer.Target)
                .FindConnectionPoint(ref m_riid, out connectionPoint);
            m_ConnectionPoint = connectionPoint;
            m_aEventSinkHelpers = new ArrayList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
