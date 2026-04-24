using System;
using FairyGUI;
using Login;

public class GameAgeViewWin : Window
{
    private GameAgeView mView;
    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = GameAgeView.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as GameAgeView;
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        this.CloseWindowExpand();
        Console.WriteLine();
    }

    public void SetData()
    {
        SetTestHotUpdate();
    }

    private void SetTestHotUpdate()
    {
        Debuger.LogError("测试 SetTestHotUpdate1.1  start");
        var iV = 0;
        for (int i = 0; i < 1000000; i++)
        {
            iV += i;
        }
        Debuger.LogError($"测试 SetTestHotUpdate     end {iV}");
    }


}
