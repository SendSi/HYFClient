using System;
using FairyGUI;
using UnityEngine;
using UniFramework.Event;

namespace HotPKG
{
    public partial class HFView : GComponent
    {
        private readonly EventGroup _eventGroup = new EventGroup();

        public override void OnInit()
        {
            base.OnInit();
            _btnSure.onClick.Add(OnClickBtnSure);

            _eventGroup.AddListener<PatchEventDefine.InitializeFailed>(OnHandleEventMessage);
            _eventGroup.AddListener<PatchEventDefine.PatchStatesChange>(OnHandleEventMessage);
            _eventGroup.AddListener<PatchEventDefine.FoundUpdateFiles>(OnHandleEventMessage);
            _eventGroup.AddListener<PatchEventDefine.DownloadProgressUpdate>(OnHandleEventMessage);
            _eventGroup.AddListener<PatchEventDefine.PackageVersionUpdateFailed>(OnHandleEventMessage);
            _eventGroup.AddListener<PatchEventDefine.PatchManifestUpdateFailed>(OnHandleEventMessage);
            _eventGroup.AddListener<PatchEventDefine.WebFileDownloadFailed>(OnHandleEventMessage);
        }


        /// <summary>
        /// 接收事件
        /// </summary>
        private void OnHandleEventMessage(IEventMessage message)
        {
            if (message is PatchEventDefine.InitializeFailed)
            {
                Action callback = () => { UserEventDefine.UserTryInitialize.SendEventMessage(); };
                ShowMessageBox($"未能初始化包！", callback); //ShowMessageBox($"Failed to initialize package !", callback);
            }
            else if (message is PatchEventDefine.PatchStatesChange)
            {
                var msg = message as PatchEventDefine.PatchStatesChange;
                _tips.text = msg.Tips;
            }
            else if (message is PatchEventDefine.FoundUpdateFiles)
            {
                UserEventDefine.UserBeginDownloadWebFiles.SendEventMessage(); //直接 发送 事件  不给弹框了
                // var msg = message as PatchEventDefine.FoundUpdateFiles;  //别删 留着
                // Action callback = () => { UserEventDefine.UserBeginDownloadWebFiles.SendEventMessage(); };
                // float sizeMB = msg.TotalSizeBytes / 1048576f;
                // sizeMB = Mathf.Clamp(sizeMB, 0.1f, float.MaxValue);
                // string totalSizeMB = sizeMB.ToString("f1");
                // ShowMessageBox($"找到个更新修补程序文件，总数{msg.TotalCount} 总的大小 {totalSizeMB}MB", callback); //      ShowMessageBox($"Found update patch files, Total count {msg.TotalCount} Total szie {totalSizeMB}MB",callback);
            }
            else if (message is PatchEventDefine.DownloadProgressUpdate)
            {
                var msg = message as PatchEventDefine.DownloadProgressUpdate;
                _slider.max = msg.TotalDownloadCount;
                _slider.value = msg.CurrentDownloadCount;
                string currentSizeMB = (msg.CurrentDownloadSizeBytes / 1048576f).ToString("f1");
                string totalSizeMB = (msg.TotalDownloadSizeBytes / 1048576f).ToString("f1");
                _tips.text = $"{msg.CurrentDownloadCount}/{msg.TotalDownloadCount} {currentSizeMB}MB/{totalSizeMB}MB";
            }
            else if (message is PatchEventDefine.PackageVersionUpdateFailed)
            {
                System.Action callback = () => { UserEventDefine.UserTryUpdatePackageVersion.SendEventMessage(); };
                ShowMessageBox($"无法更新资源版本，请检查网络状态。", callback);//  ShowMessageBox($"Failed to update static version, please check the network status.", callback);
            }
            else if (message is PatchEventDefine.PatchManifestUpdateFailed)
            {
                System.Action callback = () => { UserEventDefine.UserTryUpdatePatchManifest.SendEventMessage(); };
                ShowMessageBox($"无法更新修补程序清单，请检查网络状态。", callback); //ShowMessageBox($"Failed to update patch manifest, please check the network status.", callback);
            }
            else if (message is PatchEventDefine.WebFileDownloadFailed)
            {
                var msg = message as PatchEventDefine.WebFileDownloadFailed;
                System.Action callback = () => { UserEventDefine.UserTryDownloadWebFiles.SendEventMessage(); };
                ShowMessageBox($"未能下载文件：{msg.FileName}", callback); //ShowMessageBox($"Failed to download file : {msg.FileName}", callback);
            }
            else
            {
                throw new System.NotImplementedException($"{message.GetType()}");
            }
        }


        private Action mClickSure;

        /// <summary> 显示对话框 </summary>
        private void ShowMessageBox(string content, System.Action ok)
        {
            _dialogCtrl.selectedIndex = 1;
            _diaContentTxt.text = content;
            mClickSure = ok;
        }

        private void OnClickBtnSure()
        {
            if (mClickSure != null)
            {
                mClickSure.Invoke();
                _dialogCtrl.selectedIndex = 0;
                mClickSure = null;
            }
        }


        public override void Dispose()
        {
            _eventGroup.RemoveAllListener();
            base.Dispose();
        }

        public void SetData(string value)
        {
        }
    }
}