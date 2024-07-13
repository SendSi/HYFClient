yooAsset学习_hybridCLR学习_fairyGUI学习

   https://hybridclr.doc.code-philosophy.com/docs/beginner/quickstart 官方文档  
   https://www.yooasset.com/docs/guide-editor/QuickStart  官方文档  
 https://fairygui.com/docs/editor 官方文档   
 https://www.bilibili.com/video/BV1rc411Q73Q/?spm_id_from=333.999.0.0&vd_source=20561b00f1debfa5611eef8023c64796  看别人B站视频学习  
 https://www.bilibili.com/video/BV1G5411z7d1/?spm_id_from=333.999.0.0  自己录的  视频记录


#### AOT目录下的脚本是不能热更的
#### Init场景挂了GameMain.cs脚本 若要在UnityEditor下测试CDN更新流程,看Start()方法,有注解的
#### 菜单栏HybridCLR YooAsset添加了copy 打包时 可使其精准copy到localCDN中去
#### AppConfig.lua 有打包的参数,,使用node.js(在cdn目录上输入cmd,打开命令窗口),,http-server --port 80 -b --cors
#### 

#### UI模块
	一个FGUI包 对应 一个UI模块 
	目录结构 (eg:ProxyAAAModule  AAAManager  可以有n个页面  n个弹窗win  要在UIGenBinder.cs绑定下模块)
    ProxyAAAModule  添加CheckLoad方法下,打开(页面或弹窗)都需检测下
    页面*.*脚本默认起成Fgui的名字的部分类,继承GComponent-->public partial class *A*:GComponent
        打开UIMgr.Instance.OpenUIViewCom<*A*>(pkgName)  
        关闭UIMgr.Instance.CloseUIViewCom<*A*>();  
    弹窗*.*脚本默认起成Fgui名字的Win,继承Window-->public class *A*Win:Window  
        打开UIMgr.Instance.OpenWindow<*A*>()  
        关闭UIMgr.Instance.CloseWindow<*A*>();  
#### 功能
    红点使用 RedDotManager.cs  在模块的初始化加入监听,在UI页面(或组件)RedPoint.SetData(类型),估计后续得扩展,可看背包示例
    特效使用 EffectLoader.cs 可查看文件头部注释  LoadEffect_Id() LoadUIEffect() LoadSceneEffect()
    导表使用 在根目录处有Excel,使用方法看ConfigMgr.cs头文件注解,使用_init_.bat进行全部导出,默认使用字典形式的json文件,右键_init_.bat打开可以添加用List形式导出
    浏海屏幕 SafeAreaUtils.cs处理了左右横屏,制作fgui工程时需注意一下大背景得左右两边往外伸一点即可
	多国语言 LanguageUtils.cs可查看文件头部注释.导表映射.fgui内置字..切换语言时,会退出应用.重启生效
	声音播放 AudioMgr.cs 播放背景PlayBGM_Id(),播放音效PlayMusic_Id() 配合使用SoundConfig.xlsx
	GM页面 按F1(1.5秒),前端自己定义就含local字眼,以空隔号 切割.可查看GMConfig.xlsx,追加前端GM在LocalMethodGM()方法  
    游戏指引步骤看 GuidePKGManager.cs的StartGuideStepId(),导表看GuideTypeConfig.xlsx等文件 
    Spine引用 请看GLoader3DExtensions.cs的扩展方法,就使用时SetLoadSpine(),关闭时DisposeSpine()
    todo-->,HUD


####  download下来后
    1. HybridCLR/Installer  进行Install下
    2. Window/PackageManager   的MyRegistries中对YooAsset进行导入下
    3. YooAsset/AssetBundleCollector 进行Fix下
    

#### 出包
    首次出包  
    1.HyBridCLR/Generate/All    
    2.HybridCLR/CopyTo_GameResHotFix
    3.改对AppConfig.cs的resVersion字段与(YooAsset/AssetBundleBuilder的BuildVersion值相等),使用ClearAndCopyAll,然后build两个包   resVersion=v1.0
    4.执行.YooAsset/Copy到_WWW_hyfclient下,然后启动web服务器.http-server --port 80 -b --cors
    5.正常出apk或exe,启动打开游戏
    出增量包,即热更
    21.HyBridCLR/CompileDll/ActiveBuildTarget (好像改动太小,好像hotUpdate识别不了)
    22.HybridCLR/CopyTo_GameResHotFix (可利用文件修改时间看下有无新生成)
    23.改对AppConfig.cs的resVersion字段与(YooAsset/AssetBundleBuilder的BuildVersion值相等),使用None,然后build两个包            resVersion=v1.1继续热更+  别重复1.1哦
    24.执行.YooAsset/Copy到_WWW_hyfclient下,然后启动web服务器.http-server --port 80 -b --cors
    25.杀掉游戏进程,打开游戏