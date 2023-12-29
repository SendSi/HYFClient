using FairyGUI;
using Login;


public class GameNoticeViewWin : Window
{
    private GameNoticeView mView;

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = GameNoticeView.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as GameNoticeView;
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


