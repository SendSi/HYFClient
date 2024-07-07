using FairyGUI;
using MainRole;
using UnityEngine;


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

    public async void SetData()
    {
        var info =await ProtocalRole.Instance.RoleUpLvRequest(101);
        Debuger.LogError($"RoleUpLvRequest 返回结果 : {info}");
        
        var info2 =await ProtocalRole.Instance.RoleAddVipRequest();
        Debuger.LogError($"RoleAddVipRequest 返回结果 : {info2}");
    }
}