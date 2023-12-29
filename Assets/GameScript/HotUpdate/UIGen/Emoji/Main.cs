/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Emoji
{
    public partial class Main : GComponent
    {
        public GList _list;
        public GTextInput _input1;
        public GButton _btnSend1;
        public GButton _btnEmoji1;
        public GTextInput _input2;
        public GButton _btnSend2;
        public GButton _btnEmoji2;
        public const string URL = "ui://y768eypafvaib";

        public static Main CreateInstance()
        {
            return (Main)UIPackage.CreateObject("Emoji", "Main");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _list = (GList)GetChild("list");
            _input1 = (GTextInput)GetChild("input1");
            _btnSend1 = (GButton)GetChild("btnSend1");
            _btnEmoji1 = (GButton)GetChild("btnEmoji1");
            _input2 = (GTextInput)GetChild("input2");
            _btnSend2 = (GButton)GetChild("btnSend2");
            _btnEmoji2 = (GButton)GetChild("btnEmoji2");
        }
    }
}