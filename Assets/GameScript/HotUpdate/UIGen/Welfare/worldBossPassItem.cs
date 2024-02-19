/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class worldBossPassItem : GButton
    {
        public Controller _lock;
        public Controller _pass;
        public Controller _quality;
        public GLoader _iconbg;
        public GTextField _level;
        public GImage _namebg;
        public GTextField _name;
        public GImage _label;
        public const string URL = "ui://340eighfsnky1ygcfhx";

        public static worldBossPassItem CreateInstance()
        {
            return (worldBossPassItem)UIPackage.CreateObject("Welfare", "worldBossPassItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _lock = GetController("lock");
            _pass = GetController("pass");
            _quality = GetController("quality");
            _iconbg = (GLoader)GetChild("iconbg");
            _level = (GTextField)GetChild("level");
            _namebg = (GImage)GetChild("namebg");
            _name = (GTextField)GetChild("name");
            _label = (GImage)GetChild("label");
        }
    }
}