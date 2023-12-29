# HYFClient_学习哦
yooAsset学习_hybridCLR学习_fairyGUI学习

## https://hybridclr.doc.code-philosophy.com/docs/beginner/quickstart 官方文档

## https://www.yooasset.com/docs/guide-editor/QuickStart  官方文档

## https://www.bilibili.com/video/BV1rc411Q73Q/?spm_id_from=333.999.0.0&vd_source=20561b00f1debfa5611eef8023c64796  看B站视频学习

### A.看官方文档
### B.代码分离
	1.增加AOT文件夹.AssemblyDefinition.引用程序集.YooAsset.UniFramework._,HyBridCLR.Runtime,,,增加脚本CoreUtil.cs.增加单例.把原PatchLogic.StreamingAssetsHelper....等引用拖到AOT中来Boot也要拖在AOT中去
	2.其余就作为HotUpdate咯.增加HotUpdate.AssemblyDefinition 引用程序集*
	3.解决各报错
	4.Boot_FGUI.cs增加代码,把AOT代码加入
	5.增加GameResHotFix热更的dll.bytes文件夹.
	6.YooAsset新建一个包
### C.HybridCLR生成All与目标平台.把 AOTGenericReferences.cs指示中的dll copy到此文件夹.源文件在 HybridCLRData\AssembliesPostIl2CppStrip\StandaloneWindows64 目标文件是GameResHotFix 
### D.YooAsset打出资源		

### E.拼通了fairyGUI(fgui)
### F.cdn服务器暂用 node.js与git右键的(git bash Here)    http-server --port 80 -b --cors     注意80端口 代码(GetHostServerURL())
