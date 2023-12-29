/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Bag
{
    public partial class warePbr : GProgressBar
    {
        public Controller _isMax;
        public GImage _max;
        public const string URL = "ui://b7676vbqixhoko";

        public static warePbr CreateInstance()
        {
            return (warePbr)UIPackage.CreateObject("Bag", "warePbr");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _isMax = GetController("isMax");
            _max = (GImage)GetChild("max");
        }
    }
}