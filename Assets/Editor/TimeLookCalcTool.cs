using System;
using UnityEditor;
using UnityEngine;

namespace MEditor
{
    public class TimeLookCalcEdtitor : EditorWindow
    {

        [MenuItem("Tools/辅助工具/显示时间戳 %T")]
        public static void ShowTime()
        {
            EditorWindow.GetWindow(typeof(TimeLookCalcEdtitor)); //>(false,"",true);
        }

        private string mTimeFormat;
        private long mNumFormat;
        private long mLastNum;
        private string mLastTime;
        private long mCurZeroTime;
        private long mOtherNums;
        void OnGUI()
        {
            EditorGUILayout.LongField("当前时间戳(单位为毫秒):", GetNowTime());
            EditorGUILayout.BeginVertical("Box");
            {
                mNumFormat = EditorGUILayout.LongField("时间戳(毫秒):", mNumFormat);
                mTimeFormat = EditorGUILayout.TextField("时间格式", mTimeFormat);
                if (GUILayout.Button("转换", GUILayout.Height(27)))
                {
                    if (mNumFormat != 0 && mNumFormat != mLastNum)
                    {
                        mTimeFormat = ShowTimeFormat(mNumFormat);
                    }
                    else if (string.IsNullOrEmpty(mTimeFormat) == false && mTimeFormat.Equals(mLastTime) == false)
                    {
                        mNumFormat = ShowNumFormat(mTimeFormat);
                    }
                    else
                    {
                        Debug.Log("当前=" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "," + GetNowLong());
                    }
                    mLastNum = mNumFormat;
                    mLastTime = mTimeFormat;
                }
                GUILayout.Space(12);
                if (mNumFormat != 0)
                {
                    if (GUILayout.Button("当天0点0分的时间戳", GUILayout.Height(27)))
                    {
                        mCurZeroTime = 0;
                        mCurZeroTime = ShowZeroTime(mNumFormat);
                    }
                    if (mCurZeroTime != 0)
                    {
                        mCurZeroTime = EditorGUILayout.LongField("当天0点0分时间戳:", mCurZeroTime);
                    }
                    GUILayout.Space(12);
                    mOtherNums = EditorGUILayout.LongField("此时间戳第几天", mOtherNums);
                    if (GUILayout.Button("当天是第几天", GUILayout.Height(27)))
                    {
                        ShowSortDay(mNumFormat, mOtherNums);
                    }
                }
            }
            this.Repaint();
            EditorGUILayout.EndVertical();

            GUILayout.Space(12);
            EditorGUILayout.BeginVertical("Box");
            {
                mSecond = EditorGUILayout.LongField("时间戳(秒):", mSecond);
                if (GUILayout.Button("转换", GUILayout.Height(27)))
                {
                    mSecondMsg = ShowSecondFormat(mSecond);
                }
                if (mSecondMsg != null)
                {
                    mSecondMsg = EditorGUILayout.TextField("时间格式", mSecondMsg);
                }
            }
            EditorGUILayout.EndVertical();


            GUILayout.Space(20);
            EditorGUILayout.BeginVertical("Box");
            {
                mSecond2Minute = EditorGUILayout.IntField("时间(秒):", mSecond2Minute);
                if (GUILayout.Button("转换为时间", GUILayout.Height(27)))
                {
                    if (mSecond2Minute <= 60)
                    {
                        return;
                    }
                    mSecond2Minute_result = "";
                    int remainTime = mSecond2Minute;
                    if (mSecond2Minute / 86400 >= 1)
                    {
                        mSecond2Minute_result = ((int)(mSecond2Minute / 86400)).ToString() + "天";
                        remainTime = mSecond2Minute - ((int)(mSecond2Minute / 86400) * 86400);
                    }
                    if (mSecond2Minute / 3600 >= 1)
                    {
                        mSecond2Minute_result = mSecond2Minute_result + ((int)(remainTime / 3600)).ToString() + "小时";
                        remainTime = remainTime - ((int)(remainTime / 3600) * 3600);
                    }
                    if (remainTime / 60 >= 1)
                    {
                        mSecond2Minute_result = mSecond2Minute_result + (int)(remainTime / 60) + "分钟";
                        remainTime = remainTime - ((int)(remainTime / 60) * 60);
                    }
                    if (remainTime > 0)
                    {
                        mSecond2Minute_result = mSecond2Minute_result + remainTime + "秒";
                    }
                }
                if (string.IsNullOrEmpty(mSecond2Minute_result) == false)
                {
                    mSecond2Minute_result = EditorGUILayout.TextField("多少分多少秒", mSecond2Minute_result);
                }
            }
            EditorGUILayout.EndVertical();
        }

        int mSecond2Minute = 0;
        string mSecond2Minute_result;

        long mSecond;
        string mSecondMsg;

        /// <summary> 当天0点0分  若算毫秒,自行*1000</summary>
        private long ShowZeroTime(long pNum)
        {
            var tStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            var tDT = tStart.AddMilliseconds(pNum);
            var tH = tDT.Hour;
            var tM = tDT.Minute;
            var tS = tDT.Second;
            var tSs = tDT.Millisecond;
            var tZero = pNum - (3600000 * tH + 60000 * tM + 1000 * tS + tSs);
            return tZero;
        }
        /// <summary> 当天0点0分  若算毫秒,自行*1000</summary>
        private string ShowSortDay(long pStart, long pEnd)
        {
            var tStart = ShowZeroTime(pStart);
            var tSp = pEnd - tStart;
            var t = (tSp / 86400000) + 1;
            Debug.Log("第" + t + "天");
            return (t).ToString();//第几天要加上1
        }

        private long ShowNumFormat(string pTime)
        {
            var tTime = DateTime.Parse(pTime);
            TimeSpan cha = (tTime - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)));
            long t = (long)cha.TotalMilliseconds;
            return t;
        }

        string ShowTimeFormat(long pNum)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(pNum);
            var t = dt.ToString("yyyy/MM/dd HH:mm:ss");
            return t;
        }
        string ShowSecondFormat(long pNum)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddSeconds(pNum);
            var t = dt.ToString("yyyy/MM/dd HH:mm:ss");
            return t;
        }

        string GetNowLong()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ((long)ts.TotalMilliseconds).ToString();
        }
        long GetNowTime()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return ((long)ts.TotalMilliseconds);
        }
    }
}