/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_chat_item2_2 : GComponent
    {
        public Controller _channel;
        public GRichTextField _title_name;
        public GGraph _bg_1;
        public GTextField _title_1;
        public GGroup _1;
        public GGraph _bg_2;
        public GTextField _title_2;
        public GGroup _2;
        public GGraph _bg_3;
        public GTextField _title_3;
        public GGroup _3;
        public GGraph _bg_4;
        public GTextField _title_4;
        public GGroup _4;
        public GGraph _bg_5;
        public GTextField _title_5;
        public GGroup _5;
        public GGraph _bg_6;
        public GTextField _title_6;
        public GGroup _6;
        public const string URL = "ui://4ni413lahfih8u";

        public static main_chat_item2_2 CreateInstance()
        {
            return (main_chat_item2_2)UIPackage.CreateObject("MainCenter", "main_chat_item2_2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _channel = GetController("channel");
            _title_name = (GRichTextField)GetChild("title_name");
            _bg_1 = (GGraph)GetChild("bg_1");
            _title_1 = (GTextField)GetChild("title_1");
            _1 = (GGroup)GetChild("1");
            _bg_2 = (GGraph)GetChild("bg_2");
            _title_2 = (GTextField)GetChild("title_2");
            _2 = (GGroup)GetChild("2");
            _bg_3 = (GGraph)GetChild("bg_3");
            _title_3 = (GTextField)GetChild("title_3");
            _3 = (GGroup)GetChild("3");
            _bg_4 = (GGraph)GetChild("bg_4");
            _title_4 = (GTextField)GetChild("title_4");
            _4 = (GGroup)GetChild("4");
            _bg_5 = (GGraph)GetChild("bg_5");
            _title_5 = (GTextField)GetChild("title_5");
            _5 = (GGroup)GetChild("5");
            _bg_6 = (GGraph)GetChild("bg_6");
            _title_6 = (GTextField)GetChild("title_6");
            _6 = (GGroup)GetChild("6");
        }
    }
}