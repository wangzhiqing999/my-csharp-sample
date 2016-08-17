Python 脚本， 调用  C#  的 DLL


操作步骤

1.创建一个类库程序. O0111_PythonCallDotNet.

2.简单在 C# 中，定一个 静态方法的，与 非静态方法的处理逻辑。

3.编写 Python 代码， 调用 O0111_PythonCallDotNet.dll






注意：需要去 http://ironpython.codeplex.com/ 下载 IronPython.   然后再运行那个 Python 脚本。

C# 调用 Python 的话， 只需要 Nuget 程序包，搜索 IronPython ， 然后安装就可以了。
Python 调用 C# 的话， 直接使用  Nuget 程序包的里面的 packages\IronPython.2.7.5\tools 里面的 exe ， 会报 Microsoft.Dynamic 相关的报错。
