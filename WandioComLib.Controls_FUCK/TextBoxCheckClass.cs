using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WandioComLib.Controls
{
    [ComVisible(false)]
    public delegate void OnCheckBoxClickEventHandler(string val);

    [ProgId("WandioComLib.Controls.TextBoxCheck")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ITextBoxCheckEvents))]
    public partial class TextBoxCheckClass : UserControl, ITextBoxCheck
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

        //[ComRegisterFunction()]
        //private static void RegisterClass(string key)
        //{
        //    Registrar.RegisterClass(key, "WandioComLib.Controls.TextBoxCheck");
        //}

        //[ComUnregisterFunction()]
        //private static void UnregisterClass(string key)
        //{
        //    Registrar.UnregisterClass(key);
        //}
    }
}
