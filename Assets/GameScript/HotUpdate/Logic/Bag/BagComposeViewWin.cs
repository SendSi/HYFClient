using Bag;
using FairyGUI;


public class BagComposeViewWin : Window
{
    private BagComposeView mView;

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = BagComposeView.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as BagComposeView;
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        this.CloseWindowExpand();
    }

    public void SetData()
    {
    }
}
