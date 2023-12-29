/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Emoji
{
    public partial class EmojiSelectUI : GComponent
    {
        public GList _list;
        public const string URL = "ui://y768eypaiy2u24";

        public static EmojiSelectUI CreateInstance()
        {
            return (EmojiSelectUI)UIPackage.CreateObject("Emoji", "EmojiSelectUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _list = (GList)GetChild("list");
        }
    }
}