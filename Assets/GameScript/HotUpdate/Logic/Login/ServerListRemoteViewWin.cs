using FairyGUI;
using Login;

public class ServerListRemoteViewWin : Window
{
    private ServerListRemoteView mView;

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = ServerListRemoteView.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as ServerListRemoteView;
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        this.CloseWindowExpand();
    }

    public void SetData() { }
}