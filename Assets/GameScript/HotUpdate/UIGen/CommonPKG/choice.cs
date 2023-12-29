/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace CommonPKG
{
    public partial class choice : GComponent
    {
        public Controller _button;
        public const string URL = "ui://2r331opvqj9zz9cls";

        public static choice CreateInstance()
        {
            return (choice)UIPackage.CreateObject("CommonPKG", "choice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _button = GetController("button");
        }
    }
}