XXL-JOB 调度中心 与 C# 执行器



### 调度中心

从码云 https://gitee.com/xuxueli0323/xxl-job 克隆源码。

选择 TortoiseGit --> Switch/Checkout...
弹出窗口中，Switch To 的地方。
选择 Tag，  下拉列表中，选择  1.9.1


使用 1.9.1 的原因：
https://github.com/yuniansheng/xxl-job-dotnet
目前只支持xxl-job 1.9.1版本的调度器端



找到 doc/db/tables_xxl_job.sql 
修改一下库的名字，为 xxl_job191
在 mysql 下执行一次。




修改 xxl-job-admin/src/main/resources/xxl-job-admin.properties

测试期间，主要是修改
xxl.job.db.url=jdbc:mysql://localhost:3306/xxl_job191?useUnicode=true&characterEncoding=UTF-8
xxl.job.db.user=
xxl.job.db.password=


实际运行期间，则还需要修改
### xxl-job email
xxl.job.mail.host=
xxl.job.mail.port=
xxl.job.mail.username=
xxl.job.mail.password=
xxl.job.mail.sendNick=

### xxl-job login
xxl.job.login.username=
xxl.job.login.password=

### xxl-job, access token
xxl.job.accessToken=

之类的一堆配置。



Java环境：（JDK 1.8 可编译通过，  OpenJDK 1.11 编译不通过 ）

java -version
java version "1.8.0_151"
Java(TM) SE Runtime Environment (build 1.8.0_151-b12)
Java HotSpot(TM) 64-Bit Server VM (build 25.151-b12, mixed mode)



在 xxl-job-admin 下运行
mvn install


在 xxl-job-admin\target 目录下，运行
找到 xxl-job-admin-1.9.1.war

将其复制到本机的 
apache-tomcat-7.0.92\webapps 目录下。

重明名为 xxl-job-admin.war


在 apache-tomcat-7.0.92\bin 目录下，运行
catalina run


访问 http://127.0.0.1:8080/xxl-job-admin/
检查 调度中心 是否成功安装。





### C# 执行器端。
创建 ASP.net web api 项目  B3100_XxljobClient
.net framework 4.6.1



NuGet 引入 
XxlJob.WebApiHost


修改 Global.asax.cs 
针对 Application_Start 方法做修改。
初始化 XxlJobConfig

也就是这个 Web api 项目，最终只加载 xxl-job，并不做其他的 web api 或者 mvc 之类的操作。


编写任务处理代码
通过继承 IJobHandler 来实现。


例子代码中
在 B3100_XxljobClient.Jobs 创建了一个 HelloWorldJobHandler




### 配置运行

1.在调度中心 【执行器管理】-->【新增执行器】
主要是【注册方式】，需要变为“手动录入”
机器地址，这里填写 http://localhost:54075/


2.在调度中心 【任务管理】-->【执行器选择上一步创建的那个执行器】-->【新增任务】
【运行模式】保持默认的【Bean模式】
【cron】可简单填写一个 0 */1 * * * ?
主要是【JobHandler】，需要填写 C# 里面的那个 类名，测试的项目，填写的是 HelloWorldJobHandler
创建完成后，在操作那里，点【执行】
然后，去【调度日志】那里，查看作业的执行结果，是成功？还是失败？





### cron格式说明

cron时间表达式的格式为: <!-- s m h d m w(?) y(?) -->,   分别对应: 秒、分、小时、日、月、周、年。

1.每天什么时候执行
  每天23:59:00开始执行，cron表达式为：0 59 23 * * ?
  每天11:01,11:02,11:03; 12:01,12:02,12:03分执行任务，cron表达式为：0 1,2,3 11,12 * * ?

2.每隔多久执行
Cron表达式的时间字段，除允许设置数值外，还可使用一些特殊的字符，提供列表、范围、通配符等功能，具体如下：
●星号(*)：可用在所有字段中，表示对应时间域的每一个时刻。例如，*在分钟字段时，表示“每分钟”。
●问号（?）：该字符只在日期和星期字段中使用，但是不能在这两个域上同时使用。它通常指定为“无意义的值”，相当于点位符。
●减号(-)：表达一个范围。例如，在小时字段中使用“10-12”，则表示从10到12点，即10,11,12。
●逗号(,)：表达一个列表值。例如，在星期字段中使用“MON,WED,FRI”，则表示星期一，星期三和星期五。
●斜杠(/)：x/y表达一个等步长序列，x为起始值，y为增量步长值。如在分钟字段中使用0/15，则表示为0,15,30和45秒，而5/15在分钟字段中表示5,20,35,50，你也可以使用*/y，它等同于0/y。



### 执行器传递参数

在 B3100_XxljobClient.Jobs 创建一个 TestGetParamJobHandler
简单输出传入的参数
在【任务管理】-->【新增任务】中，
【JobHandler】 = TestGetParamJobHandler
【任务参数】= 123

测试执行后，在【调度日志】那里，查看【执行日志】
能够观察到
ReturnT:ReturnT [code=200, msg=Success, content=TestGetParamJobHandler 执行：参数=123]

在网站的日志中，能够观察到，获取到的参数。








### 注意事项.

当前这个测试项目，是在 VS 2019 里面， 创建了一个 Web 项目， 类型是 Web Api .
结果是 产生了一大堆的， 不必要的引用。


较好的操作， 是克隆
https://github.com/yuniansheng/xxl-job-dotnet
然后，找到 sample\WebApiSample\ 目录下的 packages.config
只安装这些包即可。

最终发布的时候， 可能会存在：
开发环境一切正常。
发布到服务器后，提示某个方法不存在的情况。
这种情况下，也是去找 sample\WebApiSample\ 目录下的 Web.config
复制 runtime 的配置， 粘贴到服务器的 Web.config 上。


