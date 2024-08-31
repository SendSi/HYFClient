using System;
using FairyGUI;
using CommonPKG;

public class InfoTipViewWin : Window
{
    private InfoTipView mView;
    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane= InfoTipView.CreateInstance();
        this.Center();
        this.modal = true;

        mView=this.contentPane as InfoTipView;
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        this.CloseWindowExpand();
        Console.WriteLine();
    }

    public void SetData(string contet)
    {
        mView._content._noticeContent.text = contet;
    }

}
