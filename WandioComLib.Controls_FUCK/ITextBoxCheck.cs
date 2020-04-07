using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WandioComLib.Controls
{
    [Guid("3AF22B4A-A941-4DBF-8ED5-EB6DAFF538E5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ITextBoxCheck
    {
        [DispId(1)]
        string PlaceHolder { get; set; }
    }
}
