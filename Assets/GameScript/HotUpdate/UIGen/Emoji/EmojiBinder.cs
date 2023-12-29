/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace Emoji
{
    public class EmojiBinder
    {
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(Main.URL, typeof(Main));
            UIObjectFactory.SetPackageItemExtension(EmojiSelectUI.URL, typeof(EmojiSelectUI));
            UIObjectFactory.SetPackageItemExtension(chatLeft.URL, typeof(chatLeft));
            UIObjectFactory.SetPackageItemExtension(chatRight.URL, typeof(chatRight));
            UIObjectFactory.SetPackageItemExtension(EmojiSelectUI_ios.URL, typeof(EmojiSelectUI_ios));
        }
    }
}