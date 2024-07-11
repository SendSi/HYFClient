using System;
using FairyGUI;
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

            EventCenter.Instance.Bind((int)EventEnum.EE_InitializeFailed, OnEventInitializeFailed);
            EventCenter.Instance.Bind<string>((int)EventEnum.EE_PatchStatesChange, OnEeventPatchStatesChange);
            EventCenter.Instance.Bind<int, long>((int)EventEnum.EE_FoundUpdateFiles, OnEventFoundUpdateFiles);
            EventCenter.Instance.Bind<int, int, long, long>((int)EventEnum.EE_DownloadProgressUpdate, OnEventDownloadProgressUpdate); 
            EventCenter.Instance.Bind((int)EventEnum.EE_PackageVersionUpdateFailed, OnEventPackageVersionUpdateFailed);
            EventCenter.Instance.Bind((int)EventEnum.EE_PatchManifestUpdateFailed, OnEventPatchManifestUpdateFailed);
            EventCenter.Instance.Bind<string, string>((int)EventEnum.EE_WebFileDownloadFailed, OnEventWebFileDownloadFailed); 
        }

 

        private void OnEventPatchManifestUpdateFailed()
        {
            System.Action callback = () => { EventCenter.Instance.Fire((int)EventEnum.EE_UserTryUpdatePatchManifest); };
            ShowMessageBox($"无法更新修补程序清单，请检查网络状态。", callback);
        }

        private void OnEventFoundUpdateFiles(int arg0, long arg1)
        {
            EventCenter.Instance.Fire((int)EventEnum.EE_UserBeginDownloadWebFiles); //直接 发送 事件  不给弹框了
            // Action callback = () => { UserEventDefine.UserBeginDownloadWebFiles.SendEventMessage(); };
            // float sizeMB = arg1 / 1048576f;
            // sizeMB = Mathf.Clamp(sizeMB, 0.1f, float.MaxValue);
            // string totalSizeMB = sizeMB.ToString("f1");
            // ShowMessageBox($"找到个更新修补程序文件，总数{arg0} 总的大小 {totalSizeMB}MB", callback); //      ShowMessageBox($"Found update patch files, Total count {arg0} Total szie {totalSizeMB}MB",callback);
        }

        private void OnEeventPatchStatesChange(string strs)
        {
            _tips.text = strs;
        }

        private void OnEventInitializeFailed()
        {
            Action callback = () => { EventCenter.Instance.Fire((int)EventEnum.EE_UserTryInitialize); };
            ShowMessageBox($"未能初始化包！", callback); //ShowMessageBox($"Failed to initialize package !", callback);
        }

        private void OnEventPackageVersionUpdateFailed()
        {
            System.Action callback = () => { EventCenter.Instance.Fire((int)EventEnum.EE_UserTryUpdatePackageVersion); };
            ShowMessageBox($"无法更新资源版本，请检查网络状态。", callback); //  ShowMessageBox($"Failed to update static version, please check the network status.", callback);
        }

        private void OnEventWebFileDownloadFailed(string fileName,string arg2)
        {
            System.Action callback = () => { EventCenter.Instance.Fire((int)EventEnum.EE_UserTryDownloadWebFiles); };
            ShowMessageBox($"未能下载文件：{fileName}", callback); //ShowMessageBox($"Failed to download file : {msg.FileName}", callback);
        }
        private void OnEventDownloadProgressUpdate(int TotalDownloadCount, int CurrentDownloadCount, long TotalDownloadSizeBytes, long CurrentDownloadSizeBytes)
        {
            _slider.max = TotalDownloadCount;
            _slider.value = CurrentDownloadCount;
            string currentSizeMB = (CurrentDownloadSizeBytes / 1048576f).ToString("f1");
            string totalSizeMB = (TotalDownloadSizeBytes / 1048576f).ToString("f1");
            _tips.text = $"{CurrentDownloadCount}/{TotalDownloadCount} {currentSizeMB}MB/{totalSizeMB}MB";
        }
        void DisposeEventss()
        {
            EventCenter.Instance.UnBind((int)EventEnum.EE_InitializeFailed, OnEventInitializeFailed);
            EventCenter.Instance.UnBind<string>((int)EventEnum.EE_PatchStatesChange, OnEeventPatchStatesChange);
            EventCenter.Instance.UnBind<int, long>((int)EventEnum.EE_FoundUpdateFiles, OnEventFoundUpdateFiles);
            EventCenter.Instance.UnBind<int, int, long, long>((int)EventEnum.EE_DownloadProgressUpdate, OnEventDownloadProgressUpdate);
            EventCenter.Instance.UnBind((int)EventEnum.EE_PackageVersionUpdateFailed, OnEventPackageVersionUpdateFailed);
            EventCenter.Instance.UnBind((int)EventEnum.EE_PatchManifestUpdateFailed, OnEventPatchManifestUpdateFailed);
            EventCenter.Instance.UnBind<string,string>((int)EventEnum.EE_WebFileDownloadFailed, OnEventWebFileDownloadFailed);
        }

        /// <summary>
        /// 接收事件
        /// </summary>
        private void OnHandleEventMessage(IEventMessage message)
        {
            if (message is PatchEventDefine.DownloadProgressUpdate)
            {
                var msg = message as PatchEventDefine.DownloadProgressUpdate;
                _slider.max = msg.TotalDownloadCount;
                _slider.value = msg.CurrentDownloadCount;
                string currentSizeMB = (msg.CurrentDownloadSizeBytes / 1048576f).ToString("f1");
                string totalSizeMB = (msg.TotalDownloadSizeBytes / 1048576f).ToString("f1");
                _tips.text = $"{msg.CurrentDownloadCount}/{msg.TotalDownloadCount} {currentSizeMB}MB/{totalSizeMB}MB";
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
            DisposeEventss();
            base.Dispose();
        }

        public void SetData(string value)
        {
        }
    }
}