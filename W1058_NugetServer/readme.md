

搭建自己的nuget服务器


1. 创建一个空的ASP.NET Web 应用程序
.NET Framework 版本选择 4.6



2.使用nuget管理器，添加 NuGet.Server 包
写这个文档的时候， 版本是 3.4.1 



3.测试运行.
如果没有问题的情况下，能够显示
You are running NuGet.Server v3.4.1.0
Click here to view your packages. 
......


4.发布
发布到 bin\Release\Publish 目录下.
本地的全路径，为
E:\My-GitHub\my-csharp-sample\W1058_NugetServer\bin\Release\Publish



5.IIS 添加网站。
本地端口 8090
测试浏览
http://localhost:8090/
如果没有问题的情况下，能够显示
You are running NuGet.Server v3.4.1.0
Click here to view your packages. 
......


6.尝试打包

https://www.nuget.org/downloads
下载 nuget.exe

项目 TestNuGet.DataAccess 目录下。
nuget.exe spec 
运行后，生成一个 TestNuGet.DataAccess.nuspec 文件
对其进行编辑，修改相关描述信息.

TestNuGet.DataAccess 项目，属性窗口，需要在生成 XML 文档那里打勾。
否则，客户端引用这个 NuGet 包，将看不到注释信息。

nuget.exe pack TestNuGet.DataAccess.csproj
运行后，得到文件 TestNuGet.DataAccess                                      .1.0.0.nupkg
将其复制到 网站的 \Packages 目录下。
本地的全路径，为
E:\My-GitHub\my-csharp-sample\W1058_NugetServer\bin\Release\Publish\Packages

测试浏览
http://localhost:8090/nuget/Packages

预期，能够看到 TestNuGet.DataAccess 的相关节点.




7.尝试在 Visual Studio 2019 中配置引用.
在 NuGet 管理器中。
点击 Package source / 程序包源 右边的那个小图标，进入设置的窗口。

添加一个 Package source / 程序包源
名称为 MyTest
源为 http://localhost:8090/nuget
按【更新】后，再按【确定】，关闭窗口。

回到 NuGet 管理器， Package source / 程序包源 右边的下拉列表
由 nuget.org 切换为 MyTest
观察 TestNuGet.DataAccess 是否存在，是否可安装.




8.项目依赖的管理.
第6步，单独打包了一个 TestNuGet.DataAccess
这里，先创建项目 TestNuGet.Service
然后，NuGet 引用 TestNuGet.DataAccess

项目 TestNuGet.Service 目录下。
nuget.exe spec 
运行后，生成一个 TestNuGet.Service.nuspec 文件
对其进行编辑，修改相关描述信息.

nuget.exe pack TestNuGet.Service.csproj
打包一个 TestNuGet.Service.1.0.0.nupkg

将其复制到 网站的 \Packages 目录下。
本地的全路径，为
E:\My-GitHub\my-csharp-sample\W1058_NugetServer\bin\Release\Publish\Packages

测试浏览
http://localhost:8090/nuget/Packages

预期，能够看到 TestNuGet.Service 的相关节点.



9.尝试在 Visual Studio 2019 中添加引用.

创建一个测试控制台项目 TestNuGet.Client
在 NuGet 管理器中
添加 TestNuGet.Service 的引用

预期，TestNuGet.Service 依赖 TestNuGet.DataAccess
也就是最终 安装 TestNuGet.Service 的时候， 自动安装 TestNuGet.DataAccess

安装完成后，查看 packages.config 文件
可以看到，TestNuGet.DataAccess 与 TestNuGet.Service 都被安装了.

