#开发时需要引用的包
管理 NuGet 程序包
安装 System.Reactive

如果是开发 WinForm 下的程序， 那么还需要再安装  System.Reactive.Windows.Forms



#可观测对象的相关操作.

1. 创建操作
Create — 通过调用观察者的方法从头创建一个Observable
From — 将其它的对象或数据结构转换为Observable
Just — 将对象或者对象集合转换为一个会发射这些对象的Observable
Defer — 在观察者订阅之前不创建这个Observable，为每一个观察者创建一个新的Observable
Interval — 创建一个定时发射整数序列的Observable
Range — 创建发射指定范围的整数序列的Observable
Repeat — 创建重复发射特定的数据或数据序列的Observable
Empty/Never/Throw — 创建行为受限的特殊Observable
Start — 创建发射一个函数的返回值的Observable
Timer — 创建在一个指定的延迟之后发射单个数据的Observable



2. 转化操作
Map — 映射，通过对序列的每一项都应用一个函数变换Observable发射的数据，实质是对序列中的每一项执行一个函数，函数的参数就是这个数据项
Buffer — 缓存，可以简单的理解为缓存，它定期从Observable收集数据到一个集合，然后把这些数据集合打包发射，而不是一次发射一个。
FlatMap — 扁平映射，将Observable发射的数据变换为Observables集合，然后将这些Observable发射的数据平坦化的放进一个单独的Observable，可以认为是一个将嵌套的数据结构展开的过程。
ConcatMap — cancatMap操作符与flatMap操作符类似，都是把Observable产生的结果转换成多个Observable，然后把这多个。Observable“扁平化”成一个Observable，并依次提交产生的结果给订阅者。与flatMap操作符不同的是，concatMap操作符在处理产生的。Observable时，采用的是“连接(concat)”的方式，而不是“合并(merge)”的方式，这就能保证产生结果的顺序性，也就是说提交给订阅者的结果是按照顺序提交的，不会存在交叉的情况。
GroupBy — 分组，将原来的Observable分拆为Observable集合，将原始Observable发射的数据按Key分组，每一个Observable发射一组不同的数据。
Scan — 扫描，对Observable发射的每一项数据应用一个函数，然后按顺序依次发射这些值。
Window — 窗口，定期将来自Observable的数据分拆成一些Observable窗口，然后发射这些窗口，而不是每次发射一项。类似于Buffer，但Buffer发射的是数据，Window发射的是Observable，每一个Observable发射原始Observable的数据的一个子集。




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
And/Then/When — 通过模式(And条件)和计划(Then次序)组合两个或多个Observable发射的数据集
CombineLatest — 当两个Observables中的任何一个发射了一个数据时，通过一个指定的函数组合每个Observable发射的最新数据（一共两个数据），然后发射这个函数的结果
Join — 无论何时，如果一个Observable发射了一个数据项，只要在另一个Observable发射的数据项定义的时间窗口内，就将两个Observable发射的数据合并发射
Merge — 将两个Observable发射的数据组合并成一个
StartWith — 在发射原来的Observable的数据序列之前，先发射一个指定的数据序列或数据项
Switch — 将一个发射Observable序列的Observable转换为这样一个Observable：它逐个发射那些Observable最近发射的数据
Zip — 打包，使用一个指定的函数将多个Observable发射的数据组合在一起，然后将这个函数的结果作为单项数据发射



5. 异常回调操作
Catch — 捕获，继续序列操作，将错误替换为正常的数据，从onError通知中恢复
Retry — 重试，如果Observable发射了一个错误通知，重新订阅它，期待它正常终止
onErrorReturn - 方法 返回一个镜像原有Observable行为的新Observable。会忽略前者的onError调用，不会将错误传递给观察者，而是发射一个特殊的项并调用观察者的onCompleted方法。
onErrorResumeNext - onErrorResumeNext方法与onErrorReturn()方法类似，都是拦截原Observable的onError通知，不同的是拦截后的处理方式，onErrorReturn创建并返回一个特殊项，而onErrorResumeNext创建并返回一个新的Observabl，观察者会订阅它，并接收其发射的数据。
onExceptionResumeNext - onExceptionResumeNext方法与onErrorResumeNext方法类似创建并返回一个拥有类似原Observable的新Observable，，也使用这个备用的Observable。不同的是，如果onError收到的Throwable不是一个Exception，它会将错误传递给观察者的onError方法，不会使用备用的Observable。
retryWhen - retryWhen和retry类似，区别是，retryWhen将onError中的Throwable传递给一个函数，这个函数产生另一个Observable，retryWhen观察它的结果再决定是不是要重新订阅原始的Observable。如果这个Observable发射了一项数据，它就重新订阅，如果这个Observable发射的是onError通知，它就将这个通知传递给观察者然后终止。



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
All — 判断Observable发射的所有的数据项是否都满足某个条件
Amb — 给定多个Observable，只让第一个发射数据的Observable发射全部数据
Contains — 判断Observable是否会发射一个指定的数据项
DefaultIfEmpty — 发射来自原始Observable的数据，如果原始Observable没有发射数据，就发射一个默认数据
SequenceEqual — 判断两个Observable是否按相同的数据序列
SkipUntil — 丢弃原始Observable发射的数据，直到第二个Observable发射了一个数据，然后发射原始Observable的剩余数据
SkipWhile — 丢弃原始Observable发射的数据，直到一个特定的条件为假，然后发射原始Observable剩余的数据
TakeUntil — 发射来自原始Observable的数据，直到第二个Observable发射了一个数据或一个通知
TakeWhile — 发射原始Observable的数据，直到一个特定的条件为真，然后跳过剩余的数据



8. 数学操作
Average — 计算Observable发射的数据序列的平均值，然后发射这个结果
Concat — 不交错的连接多个Observable的数据
Count — 计算Observable发射的数据个数，然后发射这个结果
Max — 计算并发射数据序列的最大值
Min — 计算并发射数据序列的最小值
Reduce — 按顺序对数据序列的每一个应用某个函数，然后返回这个值
Sum — 计算并发射数据序列的和



9. 连接被观察对象操作
Connect — 指示一个可连接的Observable开始发射数据给订阅者
Publish — 将一个普通的Observable转换为可连接的
RefCount — 使一个可连接的Observable表现得像一个普通的Observable
Replay — 确保所有的观察者收到同样的数据序列，即使他们在Observable开始发射数据之后才订阅




10. 操作转换
To（GetEnumerator ToArray ToDictionary ToEnumerable ToEvent ToEventPattern ToList ToLookup ToTask） — 将被观察对象转换成另一个对象或数据结构

