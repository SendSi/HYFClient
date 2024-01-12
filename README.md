yooAsset学习_hybridCLR学习_fairyGUI学习

##### https://hybridclr.doc.code-philosophy.com/docs/beginner/quickstart 官方文档
##### https://www.yooasset.com/docs/guide-editor/QuickStart  官方文档
##### https://fairygui.com/docs/editor 官方文档 
##### https://www.bilibili.com/video/BV1rc411Q73Q/?spm_id_from=333.999.0.0&vd_source=20561b00f1debfa5611eef8023c64796  看别人B站视频学习
##### https://www.bilibili.com/video/BV1G5411z7d1/?spm_id_from=333.999.0.0  自己录的视频记录


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
        关闭UIMgr.Instance.CloseUIViewCom<*A**>();
    弹窗*.*脚本默认起成Fgui名字的Win,继承Window-->public class *A*Win:Window  
        打开UIMgr.Instance.OpenWindow<*A*>()
        关闭UIMgr.Instance.CloseWindow<*A*>();
#### 其它
    红点使用 RedDotManager.cs  在模块的初始化加入监听,在UI页面(或组件)RedPoint.SetData(类型),估计后续得扩展,可看背包示例
    特效使用 EffectLoader.cs 加载UI特效使用LoadUIEffect()或LoadUIEffectEPos(),加载场景特效使用LoadSceneEffectSimple()或LoadSceneEffect(),,非auto的记得释放,估计后续得扩展,得用传入导表id的形式进行加载吧
    导表使用 在根目录处有Excel与excel2json_tool,导出时用DictObject类型的json文件,使用ConfigMgr.cs的LoadConfigOne<ItemConfig>("id")取得一行数据
    浏海屏幕 SafeAreaUtils.cs处理了左右横屏,制作fgui工程时需注意一下大背景得左右两边往外伸一点即可
	多国语言 LanguageUtils.cs可查看文件头部注释.导表映射.fgui内置字..切换语言时,会退出应用.重启生效
	声音播放 AudioMgr.cs 播放背景PlayBGM(),播放音效PlayMusic() 后续做成导表形式吧

####  服务端
    使用gRPC进行通信协议 测试了exe是正常热更的,,,,无需服务端,则使用另一分支noServer
    HYFServer要与HYFClient同一个文件夹下 (Toolkit\ProtoGen.bat有定义路径)
    在UnityEditor下有菜单栏.直接使用proto即可生成客户端用的代码