/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Welfare
{
    public partial class LimitShop_box : GComponent
    {
        public GProgressBar _pbr;
        public LimitShopRewBtn _rewBtn0;
        public LimitShopRewBtn _rewBtn1;
        public LimitShopRewBtn _rewBtn2;
        public LimitShopRewBtn _rewBtn3;
        public LimitShopRewBtn _rewBtn4;
        public GGroup _num1;
        public GTextField _title1;
        public GGroup _num2;
        public GTextField _title2;
        public GGroup _num3;
        public GTextField _title5;
        public GGroup _num5;
        public GGroup _num4;
        public GTextField _title4;
        public GTextField _title3;
        public const string URL = "ui://340eighfcmbvhz9cy9";

        public static LimitShop_box CreateInstance()
        {
            return (LimitShop_box)UIPackage.CreateObject("Welfare", "LimitShop_box");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _pbr = (GProgressBar)GetChild("pbr");
            _rewBtn0 = (LimitShopRewBtn)GetChild("rewBtn0");
            _rewBtn1 = (LimitShopRewBtn)GetChild("rewBtn1");
            _rewBtn2 = (LimitShopRewBtn)GetChild("rewBtn2");
            _rewBtn3 = (LimitShopRewBtn)GetChild("rewBtn3");
            _rewBtn4 = (LimitShopRewBtn)GetChild("rewBtn4");
            _num1 = (GGroup)GetChild("num1");
            _title1 = (GTextField)GetChild("title1");
            _num2 = (GGroup)GetChild("num2");
            _title2 = (GTextField)GetChild("title2");
            _num3 = (GGroup)GetChild("num3");
            _title5 = (GTextField)GetChild("title5");
            _num5 = (GGroup)GetChild("num5");
            _num4 = (GGroup)GetChild("num4");
            _title4 = (GTextField)GetChild("title4");
            _title3 = (GTextField)GetChild("title3");
        }
    }
}