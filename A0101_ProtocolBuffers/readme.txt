***** 步骤一：
项目 --> 引用 --> 管理 NuGet 程序包。
添加  Google.ProtocolBuffers
添加之后， protos 目录下会有几个  proto 的例子。

本项目就简单使用这几个例子， 不另外去写 proto 文件了.


添加之后，在解决方案的 packages 目录下， 有 Google.ProtocolBuffers.2.4.1.521 这样的目录， 这个目录下，  tools 目录中， 有用于生成代码的相关工具。





***** 步骤二：
由 proto 生成 protobin
运行 cmd, 进入命令行.

进入到 项目所在目录。
E:\my-csharp-sample\A0101_ProtocolBuffers\protos>

运行：
..\..\packages\Google.ProtocolBuffers.2.4.1.521\tools\protoc.exe --descriptor_set_out=addressbook.protobin --include_imports tutorial\addressbook.proto


执行结束后，
E:\my-csharp-sample\A0101_ProtocolBuffers\protos  目录下， 有了一个 addressbook.protobin 文件。





***** 步骤三：
由 protobin 生成 C# 代码

还是在步骤二的命令行.
E:\my-csharp-sample\A0101_ProtocolBuffers\protos>

运行：
..\..\packages\Google.ProtocolBuffers.2.4.1.521\tools\protogen addressbook.protobin

执行结束后，
E:\my-csharp-sample\A0101_ProtocolBuffers\protos  目录下， 有 AddressBookProtos.cs, CSharpOptions.cs, DescriptorProtoFile.cs 文件。





***** 步骤四：
将生成的 DescriptorProtoFile.cs 代码， 包含到项目中.

编写C#代码，调用相关的方法进行  序列化/反序列化.


