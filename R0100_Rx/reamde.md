#开发时需要引用的包
管理 NuGet 程序包
安装 System.Reactive



#可观测对象的相关操作.

1. 创建操作
Create — 创建一个被观察对象
Defer — 每次订阅时，创建一个新的被观察对象
Empty/Never/Throw— 创建精确的有限制行为的被观察对象
From（FromAsyncPattern FromEvent FromEventPattern ToObservable） — 将一些其他的对象或数据结构转换成被观察对象
Interval — 创建一个特定时间间隔序列的被观察对象
Just（Return） — 将一个或一组对象转换成一个被观察对象
Range — 通过一个范围整数创建被观察对象
Repeat — 创建一个特定可重复序列的被观察对象
Start — 创建一个返回值为函数的被观察对象
Timer — 在给定延迟时间后创建一个单例被观察对象


2. 转化操作
Buffer — 定期从被观察对象收集条目，并以集合推出条目，而不是已单项推出条目
FlatMap（SelectMany） — 转换被观察对象的条目，然后形成持有条目的单例被观察对象
GroupBy（GroupBy GroupByUntil） — 从被观察对象分成一组或几组不同的被观察对象， 通过key组织
Map（Cast Select） — 通过转换被观察对象的条目，将函数应用到每个条目
Scan — 通过转换被观察对象的条目，将函数应用到每个条目，按顺序计算后面每一个条目的连续值
Window — 定期细分一个被观察对象的条目到新的被观察对象，而不是一次发射一个，类似buffer


3. 过滤操作
Debounce（Throttle） — 在特定的时间，从被观察对象发射一个条目，passed另一个条目，类似阀门。
Distinct（Distinct DistinctUntilChanged） — 抑制被观察对象发射的重复条目
ElementAt（ElementAt ElementAtOrDefault） — 仅从被观察对象几个发射点发射条目
Filter（OfType Where） — 从被观察对象仅发射一些通过条件测试的条目
First（First FirstOrDefault Latest Next Single SingleOrDefault） — 从被观察对象发射第一条目，或者满足条件的第一条目
IgnoreElements — 从被观察对象不发射任何条目但是镜像它的终止通知
Last（Last LastOrDefault） — 从被观察对象发射第后条目
Sample — 从被观察对象发出周期性时间间隔内最新项目
Skip — 从被观察对象抑制最初的n个条目
SkipLast — 从被观察对象抑制最后的n个条目
Take — 从被观察对象发射最初的n个条目
TakeLast — 从被观察对象发射最后的n个条目


4. 结合操作
And/Then/When — 通过Pattern and Plan，结合两个或更过的被观察对象条目集合
CombineLatest — 通过指定函数结合各被观察对象发射的最新条目，被基于函数计算结果
Join — 结合两个被观察对象的发射
Merge — 合并多个被观察对象
StartWith — 从原被观察对象发射条目之前，发出一个指定的条目序列
Switch — 转换一个被观察对象到最近发射的被观察对象上，形成一条单例被观察对象
Zip — 通过指定的函数结合多个被观察对象，并且每一个条目基于函数计算


5. 异常回调操作
Catch（Catch OnErrorResumeNext） — 通过不出错的继续序列从一个onError通知发送
Retry — 如果一个被观察对象发送onError通知, 重新订阅，希望它没有错误的完成


6. 被观察对象通用操作
Delay（Delay DelaySubscription） — 延迟一定量的时间
Do — 注册一个行动，以采取各种被观察对象生命周期事件，回调监听
Materialize/Dematerialize — 将发出的条目和发送的通知都表示为发出的条目，或扭转此过程
ObserveOn（ObserveOn ObserveOnDispatcher） — 指定观察者将观察被观察对象的调度程序
Serialize（Synchronize） — 强制一个被观察对象的calls序列化
Subscribe — 被观察对象的通知操作起作用，也就是订阅被观察对象
SubscribeOn（SubscribeOn SubscribeOnDispatcher） — 指定一个被观察对象被订阅时的调度程序
TimeInterval — 转换一个被观察对象中条目的时间量
Timeout — 镜像原被观察对象, 但是如果一个特定的时间没有任何发射条目发出错误通知
Timestamp — 在被观察对象每一个条目附加一个时间戳
Using — 创建一个销毁，保证被观察对象一次性寿命


7. 条件和布尔操作
All — 确定被观察对象的所有项目是否符合一定的标准
Amb — 给定两个或多个源被观察对象，发出所有的条目从只观测发出的第一项
Contains — 确定被观察对象是否包含特定条目
DefaultIfEmpty — 从原被观察对象发射一个条目，或者如果原被观察对象的条目为空
SequenceEqual — 判断两个被观察对象发出相同序列
SkipUntil — 丢弃一个被观察对象发射条目，直到第二个被观察对象发射条目
SkipWhile — 丢弃一个被观察对象发射条目，直到一个指定的条件变为假
TakeUntil — 丢弃第二个被观察对象的一个条目或终止后的被观察对象的项目
TakeWhile — 在指定条件变为假后，丢弃被观察对象的条目


8. 数学操作
Average — 计算平均值
Concat —
Count — 计算条目数量
Max — 最大值
Min — 最小值
Reduce — 将一个函数应用到一个被观察对象，按顺序发出的每一个条目，并发出最后的值
Sum — 计算和


9. 连接被观察对象操作
Connect —
Publish —
RefCount —
Replay —


10. 操作转换
To（GetEnumerator ToArray ToDictionary ToEnumerable ToEvent ToEventPattern ToList ToLookup ToTask） — 将被观察对象转换成另一个对象或数据结构

