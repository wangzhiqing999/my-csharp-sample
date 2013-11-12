此项目是从 W0204_WCF_Scurity_BaseHttp 复制粘贴过来的。

本项目主要目的是用于测试 

使用BasicHttpBing绑定的服务指定传输安全  以及 Windows 操作系统认证的功能。




================================================================================
环境设置


1. 在本计算机上，新增一个用户 testwcf， 密码为 testwcf12345， 选择 用户不能更改密码 与 密码永不过期。
2. 修改 testwcf 的用户组， 为 Guests.  




================================================================================
MyWCFService.Web 项目
修改 绑定的安全性部分
mode 修改为 TransportWithMessageCredential
clientCredentialType 修改为 Windows

================================================================================
MyWCFService.Client 项目
修改 绑定的安全性部分
mode 修改为 TransportWithMessageCredential
clientCredentialType 修改为 Windows



================================================================================
简单测试运行一下， 结果为：

未提供用户名。请在 ClientCredential 中指定用户名。

符合预期结果， 因为客户端确实没有传 用户名、密码的代码。


================================================================================
MyWCFService.Client 项目
修改 CalculatorClient.cs

构造函数处，增加相应代码：

public CalculatorClient()
	: base()
{
	this.ClientCredentials.UserName.UserName = "testwcf";
	this.ClientCredentials.UserName.Password = "testwcf12345";
}

测试运行通过。


================================================================================
MyWCFService.Client_ByAuto 项目

刷新一次 服务引用
手动修改 app.config
修改成：
<security mode="TransportWithMessageCredential">
<transport clientCredentialType="Windows"



修改 Program.cs

using (ServiceReference1.CalculatorClient service = new ServiceReference1.CalculatorClient("BasicHttpBinding_ICalculator"))
{
	service.ClientCredentials.UserName.UserName = "testwcf";
	service.ClientCredentials.UserName.Password = "testwcf12345";
	...
}

测试运行通过。


================================================================================
MyWCFService.Web 项目

设置属性

Windows 身份验证 --> 已启用
匿名 身份验证 --> 已禁用

在 MyWCFService.Web 项目 的 Web.config 的 <system.web> 中，增加下列配置：


<!--  Windows 验证. -->
<authentication mode="Windows">
</authentication>

<authorization>
  <deny users="?"/>
</authorization>    



================================================================================
将这个 Web 项目， 发布到另外一台计算机上去进行测试

目标计算机 Win7.  
IP 地址 192.168.56.101


首先安装 .NET 4.0

然后 安装 IIS 7.5
控制面板--程序和功能
打开或关闭 Windows 功能
Internet 信息服务
-- 万维网服务
---- 安全性 （全部打勾）

----------------------------------------

然后
管理员身份运行 cmd.exe

C:\Windows\Microsoft.NET\Framework\v4.0.30319>aspnet_regiis.exe /iru
开始安装 ASP.NET (4.0.30319)。
.................
ASP.NET (4.0.30319)安装完毕。

C:\Windows\Microsoft.NET\Framework\v4.0.30319>


----------------------------------------

IIS 管理器
选择网站
右边操作的  编辑网站下面的 “绑定...”
网站绑定窗口中， 按 “添加” 按钮。
选择 https  ( 后面2个使用默认值)
手动选择一个 SSL 证书  ( 如偷懒， 可安装一个  IIS Express 7.5  )


选择网站。 点击 SSL 设置， 选择， 要求 SSL

注意核对一下， IIS 使用的 应用程序池里面的  .NET 的版本， 有没有 .NET 4.0 的了。
同时查看当前网站使用的 程序池，是否是 .NET 4.0 的。

----------------------------------------



修改 前面几个项目中的 配置文件。  
也就是  Web.Config  与  App.Config

把 
https://localhost:44300/MyWCFService.svc
修改为
https://192.168.56.101:443/MyWCFService.svc


然后 Web 项目发布到 192.168.56.101 这台测试计算机上去。

本机分别运行  MyWCFService.Client 与  MyWCFService.Client_ByAuto
运行成功。


然后测试 输入错误的 密码， 运行显示验证失败。
