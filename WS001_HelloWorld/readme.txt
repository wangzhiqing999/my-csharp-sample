步骤一. 
	创建一个项目， 类型为 Windows服务


步骤二.
	Service1.cs 文件重命名为一个有意义的文件， 例如本项目的 HelloWorldService.cs
	然后编写服务的相关代码.

步骤三.
	右键 HelloWorldService.cs  (也就是本文件) 选择 [视图设计器]
    再到View Desiger [视图设计器] 视图中右键, 选择 [添加安装程序]
    Installer 就添加好了。
    此操作完成后， 项目中会产生一组 ProjectInstaller.cs 的文件。


步骤四.
	双击上一步骤新生成的 ProjectInstaller.cs， 会显示设计画面。
	选择 serviceProcessInstaller1
	到属性窗口中， 修改 Account 属性为  LocalSystem

注：Account 属性的可设置数值如下
LocalService 充当本地计算机上非特权用户的帐户，该帐户将匿名凭据提供给所有远程服务器。 
NetworkService 提供广泛的本地特权的帐户，该帐户将计算机的凭据提供给所有远程服务器。 
LocalSystem 服务控制管理员使用的帐户，它具有本地计算机上的许多权限并作为网络上的计算机。 
User 由网络上特定的用户定义的帐户。 如果为 ServiceProcessInstaller.Account 成员指定 User，则会使系统在安装服务时提示输入有效的用户名和密码，除非您为 ServiceProcessInstaller 实例的 Username 和 Password 这两个属性设置值。  

	


步骤五.
	选择 serviceInstaller1
	到属性窗口中， 修改 ServiceName 为有意义的服务名， 例如本项目的  HelloWorldService
	

步骤六.
	编译、安装、测试运行、卸载服务。