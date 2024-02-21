/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class Child_WorldBossView : GComponent
    {
        public GLoader _bg;
        public GLoader _icon;
        public GTextField _title_name;
        public GTextField _describelbl;
        public GList _bossList;
        public activity_firstboss1 _server;
        public activity_firstboss2 _person;
        public Transition _quit;
        public Transition _in;
        public const string URL = "ui://340eighfg2er1ygcfm0";

        public static Child_WorldBossView CreateInstance()
        {
            return (Child_WorldBossView)UIPackage.CreateObject("Welfare", "Child_WorldBossView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _bg = (GLoader)GetChild("bg");
            _icon = (GLoader)GetChild("icon");
            _title_name = (GTextField)GetChild("title_name");
            _describelbl = (GTextField)GetChild("describelbl");
            _bossList = (GList)GetChild("bossList");
            _server = (activity_firstboss1)GetChild("server");
            _person = (activity_firstboss2)GetChild("person");
            _quit = GetTransition("quit");
            _in = GetTransition("in");
        }
    }
}