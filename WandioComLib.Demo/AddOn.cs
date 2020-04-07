using SAPbouiCOM;
using System;
using System.Globalization;
//using WandioComLib.Controls;

namespace WandioComLib.Demo
{
    class AddOn
    {
        private static readonly string _debugConnectionString = "0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056";
        private static string _addonName = "ActiveXDemo";
        private static Application SapApp;
        private static string Language_Georgian = "100001";

        private static void Connect()
        {
            var guiApi = new SboGuiApi();

            var cmdArgs = Environment.GetCommandLineArgs();

            guiApi.Connect(cmdArgs.Length > 1 ? cmdArgs[1] : _debugConnectionString);

            SapApp = guiApi.GetApplication();

            SapApp.StatusBar.SetSystemMessage($"Addon {_addonName} connected successfully.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
        }

        private static void Initialize()
        {
            // Set app language:
            UpdateAppLanguage();

            SapApp.ItemEvent += SapApp_ItemEvent;
        }

        private static void UpdateAppLanguage()
        {
            string lang;

            if (SapApp.Language == BoLanguages.ln_Russian) lang = "ru-RU";
            else if (SapApp.Language.ToString() == Language_Georgian) lang = "ka-KA";
            else lang = "en-US";

            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(lang);
        }

        public AddOn()
        {
            Connect();
            Initialize();
        }

        static void SapApp_ItemEvent(string formUID, ref ItemEvent data, out bool bubbleEvent)
        {
            bubbleEvent = true;
            if (data.FormTypeEx == "60100")
                switch (data.EventType)
                {
                    case BoEventTypes.et_FORM_LOAD:
                        if (data.BeforeAction)
                        {
                            var sapForm = SapApp.Forms.GetForm(data.FormTypeEx, data.FormTypeCount);

                            try
                            {
                                sapForm.Freeze(true);

                                OpenSystemForm(sapForm);

                                sapForm.Freeze(false);
                            }
                            catch (Exception ex)
                            {
                                sapForm.Close();

                                SapApp.StatusBar.SetSystemMessage($"{_addonName} | SapApp_ItemEvent",
BoMessageTime.bmt_Short,
BoStatusBarMessageType.smt_Error,
"",
"",
$"Error occurred during form initialization: " + $"{sapForm.Title}. " + ex.ToString());
                            }
                        }
                        break;
                    case BoEventTypes.et_FORM_UNLOAD:
                        break;
                }
        }

        private static void OpenSystemForm(Form form)
        {
            var item = form.Items.Item("38");

            var classId = "WandioComLib.Controls.TextBoxCheck";
            var newItem = form.Items.Add("ActiveX1", BoFormItemTypes.it_ACTIVE_X);

            newItem.TextStyle = item.TextStyle;
            newItem.FontSize = item.FontSize;
            newItem.Height = 50;
            newItem.Width = 200;

            newItem.Top = item.Top;
            newItem.Left = item.Left + item.Width + 20;

            var activeXControl = newItem.Specific as ActiveX;
            activeXControl.ClassID = classId;

            //var myItem1 = activeXControl.Object as TextBoxCheck;
            //var myItem2 = activeXControl.Object as ITextBoxCheck;
            //var myItem3 = activeXControl.Object as ITextBoxCheckEvents;
            //var myItem4 = activeXControl.Object as ITextBoxCheckEvents_Event;
            //var myItem5 = activeXControl.Object as TextBoxCheckClass;

            //myItem2.PlaceHolder = "test1";
            //myItem2.OnCheckBoxClick += (val) =>
            //{

            //};

        }
    }
}
