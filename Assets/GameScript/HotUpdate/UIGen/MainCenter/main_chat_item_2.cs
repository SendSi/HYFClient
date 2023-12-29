/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainCenter
{
    public partial class main_chat_item_2 : GButton
    {
        public GList _list_chat;
        public chatBtn _inforBtn;
        public const string URL = "ui://4ni413lakah2a4";

        public static main_chat_item_2 CreateInstance()
        {
            return (main_chat_item_2)UIPackage.CreateObject("MainCenter", "main_chat_item_2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _list_chat = (GList)GetChild("list_chat");
            _inforBtn = (chatBtn)GetChild("inforBtn");
        }
    }
}