using FairyGUI;
using System;

public static class CountDownTime
{
    public static TimerCallback SetStart(int pCountTime, GTextField pUITxt, string pFormatTxt, bool isHour, Action actComplete)
    {
        UpdateUIText(pCountTime, pUITxt, pFormatTxt, isHour);

        TimerCallback timeCB = (callback) =>
        {
            pCountTime--;
            UpdateUIText(pCountTime, pUITxt, pFormatTxt, isHour);

            if (actComplete != null && pCountTime <= 0)
                actComplete();
        };

        // 添加计时器，并返回回调函数
        FairyGUI.Timers.inst.Add(1, pCountTime, timeCB);
        return timeCB;
    }

    public static void Remove(TimerCallback callback)
    {
        Timers.inst.Remove(callback);
    }

    //提取为方法
    private static void UpdateUIText(int pCountTime, GTextField pUITxt, string pFormatTxt, bool isHour)
    {
        string str = TimeFormatUtils.SetTimeShowStr(pCountTime, isHour);
        if (!string.IsNullOrEmpty(pFormatTxt))
            pUITxt.text = string.Format(pFormatTxt, str);
        else
            pUITxt.text = str;
    }
}

public static class TimeFormatUtils
{
    public static string SetTimeShowStr(int timeSecond, bool isHour)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeSecond);
        if (timeSpan.Days > 0)
        {
           var h = (int)((timeSecond - timeSpan.Days * 86400) / 3600);
            return string.Format("{0}天:{1:D2}:{2:D2}:{3:D2}", timeSpan.Days, h, timeSpan.Minutes, timeSpan.Seconds);
        }
        else if (timeSpan.TotalHours > 0 || isHour)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, timeSpan.Minutes, timeSpan.Seconds);
        }
        else
        {
            return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
    }

    public static string SetTimeShowStr_old(int timeSecond, bool isHour)
    {
        if (timeSecond <= 0) timeSecond = 0;
        string timerStr = "";
        int h = (int)(timeSecond / 3600);
        int m = (int)((timeSecond - h * 3600) / 60);
        int s = (int)(timeSecond - h * 3600 - m * 60);
        int today = (int)(timeSecond / 86400);
        if (today > 0)
        {
            h = (int)((timeSecond - today * 86400) / 3600);
            var hStr = (h >= 10) ? ($"{h}:") : ($"0{h}:");
            timerStr = $"{today}天:{hStr}:";
        }
        else if (h > 0 || isHour)
        {
            timerStr = (h >= 10) ? ($"{h}:") : ($"0{h}:");
        }

        timerStr = (m >= 10) ? ($"{timerStr}{m}:") : ($"{timerStr}0{m}:");
        timerStr = (s >= 10) ? ($"{timerStr}{s}") : ($"{timerStr}0{s}");

        return timerStr;
    }
}