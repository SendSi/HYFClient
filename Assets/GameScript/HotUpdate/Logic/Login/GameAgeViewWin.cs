using System;
using FairyGUI;
using Login;


public class GameAgeViewWin : Window
{
    private GameAgeView mView;
    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane= GameAgeView.CreateInstance();
        this.Center();
        this.modal = true;

        mView=this.contentPane as GameAgeView;
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        this.CloseWindowExpand();
        Console.WriteLine();
    }

    public void SetData()
    {

    }






}
