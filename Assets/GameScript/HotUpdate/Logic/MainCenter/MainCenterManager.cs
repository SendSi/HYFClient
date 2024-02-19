using System;

public class MainCenterManager
{
}

public class FuncBtnData
{
    public int fId { get; set; } //1001英雄  1002联盟 1003背包 1004邮件 1005部队             2001功能预告  2002活动  2003福利
    public string iconURL { get; set; }
    public string titleTxt { get; set; }
    public Action clikcAct { get; set; }

    public FuncBtnData(string iconURL, string titleTxt)
    {
        this.iconURL = iconURL;
        this.titleTxt = titleTxt;
    }

    public FuncBtnData(int id, string iconURL, string titleTxt, Action clickAct)
    {
        this.fId = id;
        this.iconURL = iconURL;
        this.titleTxt = titleTxt;
        this.clikcAct = clickAct;
    }
}