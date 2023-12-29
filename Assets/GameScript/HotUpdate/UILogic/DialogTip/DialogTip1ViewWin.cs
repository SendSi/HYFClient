using System;
using DialogTip;
using FairyGUI;

public class DialogTip1ViewWin : Window
{
    private DialogTip1View mView;

    private GRichTextField _contentChild;

    private Action _sureCB;

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = DialogTip1View.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as DialogTip1View;
        _contentChild =(GRichTextField)mView._contentTxt.GetChild("contentTxt");
        mView._btnCenter.onClick.Set(OnClickBtnCenter);
    }

    private void OnClickBtnCenter()
    {
        _sureCB?.Invoke();
        closeEventHandler(null);
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        this.CloseWindowExpand();
    }

    public void SetData(string title, string content, string btnTitle, Action sureCB)
    {
        mView._frame.title = title;
        _contentChild.text = content;
        mView._btnCenter.title = btnTitle;
        _sureCB = sureCB;
    }
}
