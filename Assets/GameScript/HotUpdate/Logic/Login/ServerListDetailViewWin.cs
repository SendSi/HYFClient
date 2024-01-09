using FairyGUI;
using Login;


public  class ServerListDetailViewWin : Window
{
     private ServerListDetailView mView;

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = ServerListDetailView.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as ServerListDetailView;
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
