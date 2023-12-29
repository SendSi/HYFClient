/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Emoji
{
    public partial class EmojiSelectUI_ios : GComponent
    {
        public GList _list;
        public const string URL = "ui://y768eypamwdy37";

        public static EmojiSelectUI_ios CreateInstance()
        {
            return (EmojiSelectUI_ios)UIPackage.CreateObject("Emoji", "EmojiSelectUI_ios");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _list = (GList)GetChild("list");
        }
    }
}