步骤一. 创建项目。

  创建一个 ASP.NET 空Web 应用程序。
  .NET  版本选择  4.5

  管理 NuGet 程序包
  添加 Microsoft.AspNet.SignalR



步骤二. 创建 Hub

  添加项目， 左边的树形列表中，选择 Web 下面的 SignalR。
  右边选择 SignalR 集线器类(v2)
  命名为  ChatHub.cs

  <写代码>


步骤三. 创建 OWIN Startup Class

  添加项目， 左边的树形列表中，选择 Web 下面的 常规。
  右边选择 OWIN Startup 类
  命名为 Startup.cs
  
  <写代码>
  
  
  
步骤四. 创建 测试 html 

  添加 HTML 页， 命名为 index.html
  鼠标选择该页面， 右键，将其设置为 起始页.

  <写代码>  

