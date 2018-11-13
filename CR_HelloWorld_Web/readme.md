水晶报表 Web 项目.


# 前置准备操作


### 安装 SAP Crystal Reports, developer version for Visual Studio

http://www.crystalreports.com/crvs/confirm/
在上面的网站， 下载 SAP Crystal Reports, developer version for Visual Studio

https://wiki.scn.sap.com/wiki/display/BOBJ/Crystal+Reports%2C+Developer+for+Visual+Studio+Downloads
上面的页面，详细说明了，你使用的那个版本的 Visual Studio，至少需要下载哪个版本的 开发包。

Support Packs for “SAP Crystal Reports, developer version for Microsoft Visual Studio” (SAP Crystal Reports for Visual Studio) are scheduled on a quarterly bases and support the following versions of Visual Studio:
VS 2010 – original release and higher
VS 2012 – SP 7 and higher
VS 2013 – SP 9 and higher
VS 2015RC – SP14
VS 2015 – SP 15 and higher
VS 2017 - SP 21 and higher

对于首次安装的来说，那是直接安装最新版本的即可.


### 配置 ODBC 
创建一个  系统DSN  
类型选择 SQL Server.
名称为 TEST
服务器设置为  localhost\SQLEXPRESS





# 项目开发

### 创建 Web 项目. 选择 WinForm 与 Mvc 的选项。

### 添加引用
CrystalDecisions.CrystalReports.Engine
CrystalDecisions.Enterprise.Viewing.ReportSource
CrystalDecisions.ReportSource
CrystalDecisions.Shared
CrystalDecisions.Web


### 创建报表.
这里不创建临时测试表，简单的查询 数据字典表完成查询操作.

test.rpt : 只是简单的 select * from sys.tables
testImage.rpt : 只是简单的 select * from sys.columns



### 创建 WinForm 页面，用于加载水晶报表.
页面为 
ReportViewer/ReportViewer1.aspx
ReportViewer/ReportViewer2.aspx
ReportViewer/ReportViewer3.aspx


### 图表的额外的配置.
图表的情况下，控制台上将看到这样的访问.
http://localhost:48521/ReportViewer/CrystalImageHandler.aspx?dynamicimage=......

而实际情况下，ReportViewer 目录下， 是没有 CrystalImageHandler.aspx 这个页面的。
需要额外配置相关的路由，让 CrystalDecisions.Web.CrystalImageHandler 来处理.


# 测试运行

### 开发环境运行.
运行的时候，浏览报表的时候，会显示空白.
F12，查看控制台日志，可能会显示， /aspnet_client/system_web/.../crystalreportviewers13/... 相关的文件不存在。
这些文件，是安装开发包的时候，安装的网站需要的文件。
从 C:\inetpub\wwwroot 目录下， 将 aspnet_client 复制到 项目的目录下.
再次运行，控制台应该不会显示有 文件不存在 的错误了。



### 服务器运行.
服务器需要去 https://www.crystalreports.com/crvs/confirm/
下载 SAP Crystal Reports Runtime

注意事项：
开发环境不区分 32位/64位
服务器区分 32位/64位

也就是说
如果下载安装的是 32位的， 那么， 在 iis 里面，需要将网站设置为 32 位运行方式.
如果下载安装的是 64位的， 那么， 在 iis 里面，需要将网站设置为 64 位运行方式.

服务器上的创建水晶报表的作业程序也是一样。
如果在项目的 生成选项卡上，指定了 x86 或者 x64，那么就不要选择错误。



