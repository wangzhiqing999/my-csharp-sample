此项目是从 W0201_WCF_Detail 复制粘贴过来的。

本项目主要目的是用于测试 为使用BasicHttpBing绑定的服务指定传输安全 

因此排除掉 MyWCFService.Hosting 项目， 以及 MyWCFService.Client 中的 关于 NetTcpBinding  的代码 与 配置信息。



为使用BasicHttpBing绑定的服务指定传输安全 


================================================================================

在 MyWCFService.Web 项目中


首先确保 Web 项目是使用 IIS Express 的， 然后在 Web 项目的属性中， 有个已启用 SSL ， 设置为 True.
设置完毕以后，复制只读属性 SSL URL 的地址，后面会使用上。
目前测试环境的地址是：
https://localhost:44300


1. 在Visual Studio，使用WCF配置管理工具，打开 Web.config
	并在WCF配置管理工具的左边面板中，点击Binding，然后点击右边的"创建一个新的绑定配置" 

2. 设置名称为 ServcieBasicHttpBindingConfig

3.切换到"安全"标签，设置模式为"Transport"。 

4. 转到服务-->主机-->终结点下
	确认Address为  https://localhost:44300/MyWCFService.svc
	并选择绑定配置为 "ServcieBasicHttpBindingConfig" 

5. 保存配置文件，退出WCF服务配置管理工具，然后编译该项目，确认没有警告和错误。 

6. 将 MyWCFService.Web 设置为  启动项目，  尝试访问  https://localhost:44300/MyWCFService.svc 。 查看是否存在异常。

如果抱下面这个错误

如果在配置中将“system.serviceModel/serviceHostingEnvironment/multipleSiteBindingsEnabled”设置为 true，
则需要终结点指定相对地址。如果在终结点上指定相对侦听 URI，则该地址可以是绝对地址。
若要解决此问题，请为终结点“https://localhost:44300/MyWCFService.svc”指定相对 URI。 
说明: 执行当前 Web 请求期间，出现未经处理的异常。请检查堆栈跟踪信息，以了解有关该错误以及代码中导致错误的出处的详细信息。 

可以修改 Web.config
<serviceHostingEnvironment multipleSiteBindingsEnabled="false" />



================================================================================

在 MyWCFService.Client 项目中

1. 选择 App.config 文件， 然后 鼠标右键， 在弹出菜单中选择 “编辑 WCF 配置”
    （如果鼠标右键后，没有这个菜单选项，那么尝试 点击主菜单中的 “工具” --> “WCF 服务配置编辑器”  ）

2. 选择好那个 BasicHttpBinding_ICalculator
	
3. 切换到"安全"标签，设置模式为"Transport"。 

4. 转到 客户端 --> 端点下的 BasicHttpBinding_ICalculator
	确认Address为 https://localhost:44300/MyWCFService.svc   (也就是 在 Web 项目中，设置的地址)
	并选择绑定配置为 "BasicHttpBinding_ICalculator" 

5. 保存配置文件，退出WCF服务配置管理工具 

6. 测试运行。



================================================================================

(这个区域的操作， 如果 服务器已经安装了  IIS Express ， 那么可以跳过)

如果没有意外
上面的客户端运行,将抱错

无法为 SSL/TLS 安全通道与颁发机构“localhost:44300”建立信任关系。
下面是 本机需要额外作的配置与设置操作!

1. 在命令行窗口下，运行 mmc  打开 “控制台” 程序。

2. 在“控制台” 窗口中，菜单中选择 "File—Add/Remove Snap-in"   中文是  "文件-添加/删除管理单元"

3. 在弹出的 “添加或删除管理单元”  窗口中，“可用的管理单元” 中选择  “证书”， 然后按 “添加” 按钮。

4. 在 “证书管理” 窗口中， 选择 “计算机帐户”

5. 在 “选择计算机” 窗口中， 选择 “本地计算机（运行此控制台的计算机）” ， 然后按 “完成” 按钮。

6. 回到 “添加或删除管理单元”  窗口， 观察 右边的 “所选管理单元” 中， 有 证书(本地计算机) 以后，按 “确定” 按钮关闭窗口。

7. 点击管理控制台左边面板的 “控制台根节点-证书(本地计算机)-个人”，然后选择 “证书”，你可以发现生成的证书已经出现在右边面板。双击该证书，以查看该证书的详细信息。 

8. 切换到该证书的 “详细信息” 标签页，拖动中间的滚动条至底部，你可以发现"Thumbprint"属性 （中文是 “指纹”），复制该属性的值。（每台计算机该值不一样），然后关闭证书窗口。 
   例如本测试机的指纹是： a2 ad 09 ab cf 53 03 cd d0 1c ae 90 7c 26 ba 7c 5f f5 e1 4b

9. 命令行方式下，执行以下命令：

C:\>sqlcmd -S "localhost\SQLEXPRESS"
1> use test
2> go
已将数据库上下文更改为 'Test'。
1> select newid()
2> go
------------------------------------
4081ABF7-FE0C-49A6-B9B5-135144B3A03B
(1 行受影响)
1> exit

注：以上操作是为了获取一个 GUID

然后再执行：

netsh http add sslcert ipport=0.0.0.0:44300 certhash=a2ad09abcf5303cdd01cae907c26ba7c5ff5e14b appid={4081ABF7-FE0C-49A6-B9B5-135144B3A03B}



C:\>netsh http add sslcert ipport=0.0.0.0:44300 certhash=a2ad09abcf5303cdd01cae9
07c26ba7c5ff5e14b appid={4081ABF7-FE0C-49A6-B9B5-135144B3A03B}

未能添加 SSL 证书，错误: 5
请求的操作需要提升(作为管理员运行)。

到 C:\Windows\System32 目录下， 找到  cmd.exe  鼠标右键，选择 “以管理员身份运行”


C:\>netsh http add sslcert ipport=0.0.0.0:44300 certhash=a2ad09abcf5303cdd01cae9
07c26ba7c5ff5e14b appid={4081ABF7-FE0C-49A6-B9B5-135144B3A03B}

未能添加 SSL 证书，错误: 183
当文件已存在时，无法创建该文件。


出这个错的原因，可能是这个证书，已经是 IIS Express 安装的时候，顺便一起安装好的了。
（如果没有安装 IIS Express， 那么需要通过  makecert  命令创建一个证书， 然后在通过上面的语句增加处理）


注：
关于 netsh 的使用，可以在命令行执行 
netsh ?
netsh http ?
netsh http add ?
netsh http add sslcert ?
依次获得各种帮助信息。



================================================================================


在 MyWCFService.Client 项目中

修改  Program.cs

增加引用：

using System.Security.Cryptography.X509Certificates;
using System.Net;


增加类：

class PermissionCertificatePolicy
{
	string subjectName;
	static PermissionCertificatePolicy currentPolicy;

	PermissionCertificatePolicy(string subjectName)
	{
		this.subjectName = subjectName;
		ServicePointManager.ServerCertificateValidationCallback +=
		new System.Net.Security.RemoteCertificateValidationCallback(RemoveCertValidate);
	}

	public static void Enact(string subjectName)
	{
		currentPolicy = new PermissionCertificatePolicy(subjectName);
	}

	bool RemoveCertValidate(object sender, X509Certificate cert,
	X509Chain chain, System.Net.Security.SslPolicyErrors error)
	{
		if (currentPolicy.subjectName == subjectName)
			return true;
		return false;
	}
}



在 调用  CalculatorClient service = new CalculatorClient(endpointConfigurationName) 以前。 先执行一句：

PermissionCertificatePolicy.Enact("CN=HTTPS-Server"); 






================================================================================

进一步简化测试：

创建一个 MyWCFService.Client_ByAuto 控制台项目。
添加一个 服务引用。 地址输入 https://localhost:44300/MyWCFService.svc
然后编写调用的代码。

结果也是同样抱错。

在加入 与上一步骤同样的 引用 与 类以后。 

先执行 
PermissionCertificatePolicy.Enact("CN=HTTPS-Server"); 

后面就能够正常地执行了。