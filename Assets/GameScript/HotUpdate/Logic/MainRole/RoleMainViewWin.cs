using FairyGUI;
using MainRole;


public class RoleMainViewWin : Window
{
    private RoleMainView mView;

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = RoleMainView.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as RoleMainView;
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
