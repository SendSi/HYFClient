using System;
using DialogTip;
using FairyGUI;


public class DialogTip2ViewWin : Window
{
    private DialogTip2View mView;

    private GRichTextField _contentChild;

    private Action _leftCB; //默认左边取消
    private Action _rightCB; //默认右边确定

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = DialogTip2View.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as DialogTip2View;
        _contentChild = (GRichTextField)mView._contentTxt.GetChild("contentTxt");
        mView._btnLeft.onClick.Set(OnClickBtnLeft);
        mView._btnRight.onClick.Set(OnClickBtnRight);
    }

//默认左边取消
    private void OnClickBtnLeft()
    {
        _leftCB?.Invoke();
        closeEventHandler(null);
    }

//默认右边确定
    private void OnClickBtnRight()
    {
        _rightCB?.Invoke();
        closeEventHandler(null);
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        this.CloseWindowExpand();
    }

    public void SetData(string title, string content, string leftBtnTitle, Action leftCB, string rightBtnTitle,
        Action rightCB)
    {
        mView._frame.title = title;
        _contentChild.text = content;
        mView._btnLeft.title = leftBtnTitle;
        mView._btnRight.title = rightBtnTitle;
        _leftCB = leftCB;
        _rightCB = rightCB;
    }
}
