yooAsset学习_hybridCLR学习_fairyGUI学习

#### https://hybridclr.doc.code-philosophy.com/docs/beginner/quickstart 官方文档
#### https://www.yooasset.com/docs/guide-editor/QuickStart  官方文档
#### https://fairygui.com/docs/editor 官方文档 
#### https://www.bilibili.com/video/BV1rc411Q73Q/?spm_id_from=333.999.0.0&vd_source=20561b00f1debfa5611eef8023c64796  看别人B站视频学习
#### https://www.bilibili.com/video/BV1G5411z7d1/?spm_id_from=333.999.0.0  自己录的视频记录


##### AOT目录下的脚本是不能热更的
##### Init场景挂了GameMain.cs脚本 若要在UnityEditor下测试CDN更新流程,看Start()方法,有注解的
##### 菜单栏HybridCLR YooAsset添加了copy 打包时 可能使其精准copy
##### AppConfig.lua 有打包的参数
##### 导表,在根目录的Excel与excel2json_tool,使用导出DictObject类型的json文件,使用var cfg=ConfigMgr.GetInstance().LoadConfigOne<ItemConfig>("id");取得一行数据

##### UI模块
	一个包 对应 一个UI模块 
	目录结构 (eg:ProxyAAAModule  AAAManager  可以有n个页面  n个弹窗win  要在UIGenBinder.cs绑定下模块)
    ProxyAAAModule  添加CheckLoad方法下,打开(页面弹窗)都需检测下

    页面.脚本默认起成Fgui的名字的部分类,继承GComponent-->public partial class *A*:GComponent
        打开UIMgr.GetInstance().OpenUIViewCom<*A*>(pkgName)
        关闭UIMgr.GetInstance().CloseUIViewCom<*A**>();

    弹窗.脚本默认起成Fgui名字的Win,继承Window-->public class *A*Win:Window  
        打开UIMgr.GetInstance().OpenWindow<*A*>()
        关闭UIMgr.GetInstance().CloseWindow<*A*>();
