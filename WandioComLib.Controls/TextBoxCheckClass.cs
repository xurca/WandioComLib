using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WandioComLib.Controls
{
    [ComVisible(false)]
    public delegate void OnCheckBoxClickEventHandler(string val);

    [Guid("E9AA42CD-73DB-4FC2-BF29-AC7ED05D6D3F")]
    [ProgId("WandioComLib.Controls.TextBoxCheck")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComSourceInterfaces(typeof(ITextBoxCheckEvents))]
    public partial class TextBoxCheckClass : UserControl, TextBoxCheck, ITextBoxCheck, ITextBoxCheckEvents_Event
    {
        public string PlaceHolder
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        public TextBoxCheckClass()
        {
            InitializeComponent();
        }

        public event OnCheckBoxClickEventHandler OnCheckBoxClick;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = checkBox1.Checked;
            OnCheckBoxClick?.Invoke(textBox1.Text);
        }

        private void TextBoxCheck_Load(object sender, EventArgs e)
        {
            textBox1.Text = PlaceHolder;
        }

        [ComRegisterFunction()]
        private static void RegisterClass(string key)
        {
            Registrar.RegisterClass(key, "WandioComLib.Controls.TextBoxCheck");
        }

        [ComUnregisterFunction()]
        private static void UnregisterClass(string key)
        {
            Registrar.UnregisterClass(key);
        }
    }
}
