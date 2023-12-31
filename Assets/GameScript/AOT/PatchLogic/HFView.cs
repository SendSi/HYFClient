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
                System.Action callback = () => { UserEventDefine.UserTryInitialize.SendEventMessage(); };
                ShowMessageBox($"Failed to initialize package !", callback);
            }
            else if (message is PatchEventDefine.PatchStatesChange)
            {
                var msg = message as PatchEventDefine.PatchStatesChange;
                _tips.text = msg.Tips;
            }
            else if (message is PatchEventDefine.FoundUpdateFiles)
            {
                var msg = message as PatchEventDefine.FoundUpdateFiles;
                System.Action callback = () => { UserEventDefine.UserBeginDownloadWebFiles.SendEventMessage(); };
                float sizeMB = msg.TotalSizeBytes / 1048576f;
                sizeMB = Mathf.Clamp(sizeMB, 0.1f, float.MaxValue);
                string totalSizeMB = sizeMB.ToString("f1");
                ShowMessageBox($"Found update patch files, Total count {msg.TotalCount} Total szie {totalSizeMB}MB",
                    callback);
            }
            else if (message is PatchEventDefine.DownloadProgressUpdate)
            {
                var msg = message as PatchEventDefine.DownloadProgressUpdate;
                _slider.max = msg.TotalDownloadCount;
                _slider.value =msg.CurrentDownloadCount;
                //var tmp=msg.CurrentDownloadCount / msg.TotalDownloadCount;
                // Debug.LogError($"max:{msg.TotalDownloadCount},CurrentDownloadCount:{msg.CurrentDownloadCount},value:{tmp}");
                string currentSizeMB = (msg.CurrentDownloadSizeBytes / 1048576f).ToString("f1");
                string totalSizeMB = (msg.TotalDownloadSizeBytes / 1048576f).ToString("f1");
                _tips.text = $"{msg.CurrentDownloadCount}/{msg.TotalDownloadCount} {currentSizeMB}MB/{totalSizeMB}MB";
            }
            else if (message is PatchEventDefine.PackageVersionUpdateFailed)
            {
                System.Action callback = () => { UserEventDefine.UserTryUpdatePackageVersion.SendEventMessage(); };
                ShowMessageBox($"Failed to update static version, please check the network status.", callback);
            }
            else if (message is PatchEventDefine.PatchManifestUpdateFailed)
            {
                System.Action callback = () => { UserEventDefine.UserTryUpdatePatchManifest.SendEventMessage(); };
                ShowMessageBox($"Failed to update patch manifest, please check the network status.", callback);
            }
            else if (message is PatchEventDefine.WebFileDownloadFailed)
            {
                var msg = message as PatchEventDefine.WebFileDownloadFailed;
                System.Action callback = () => { UserEventDefine.UserTryDownloadWebFiles.SendEventMessage(); };
                ShowMessageBox($"Failed to download file : {msg.FileName}", callback);
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
            if (mClickSure!=null)
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