/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace Bag
{
    public class BagBinder
    {
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(BagComposeView.URL, typeof(BagComposeView));
            UIObjectFactory.SetPackageItemExtension(bagComposeItem.URL, typeof(bagComposeItem));
            UIObjectFactory.SetPackageItemExtension(warePbr.URL, typeof(warePbr));
            UIObjectFactory.SetPackageItemExtension(FightOrderBuyView.URL, typeof(FightOrderBuyView));
            UIObjectFactory.SetPackageItemExtension(BagMainView.URL, typeof(BagMainView));
        }
    }
}