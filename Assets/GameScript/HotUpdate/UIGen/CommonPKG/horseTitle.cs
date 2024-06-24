/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class horseTitle : GComponent
    {
        public GRichTextField _title;
        public const string URL = "ui://2r331opvlg2o1ygcgrv";

        public static horseTitle CreateInstance()
        {
            return (horseTitle)UIPackage.CreateObject("CommonPKG", "horseTitle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _title = (GRichTextField)GetChild("title");
        }
    }
}