
来源页面
http://www.cnblogs.com/instance/p/4863811.html



把C#程序（含多个Dll）合并成一个Exe的超简单方法

开发程序的时候经常会引用一些第三方的DLL，然后编译生成的exe文件就不能脱离这些DLL独立运行了。

但是，很多时候我们本想开发一款只需要一个exe就能完美运行的小工具。那该怎么办呢？

下文介绍一种超简单的方法，不用写一行代码就可轻松实现。

这里我们需要用到一款名为Fody.Costura的工具。Fody.Costura是一个Fody框架下的插件，可通过Nuget安装到VS工程中。安装之后，就可以将项目所依赖的DLL（甚至PDB）文件全部打包到EXE文件里。

使用方法
在VS中，通过Nuget为目标EXE工程安装Costura.Fody。
重新构建项目。 
构建完成后，到项目的输出目录下找到新生成的EXE文件，你同时会发现输出目录下仍然存在那些DLL。不过不用担心，这个EXE已经能够独立运行了。你可以把这些DLL全部删除后再运行EXE试试。

另外，Fody.Costura还支持一些进阶的特性，例如：

临时程序集文件：在运行EXE前自动，自动将DLL从EXE中解压到文件夹系统中，再通过常规的方式加载该DLL。
合并非托管的DLL：Fody.Costura可以合并非托管的DLL，但是不会自动合。如果你的程序涉及非托管DLL，那么你需要通过修改Fody.Costura的配置文件来显示地告诉它你想合并哪些非托管的DLL。
预加载DLL：Fody.Costura可以帮助你在程序启动时预先加载某些DLL，你甚至可以指定这些DLL的加载顺序。
以上这些进阶特性都需要你通过修改Fody.Costura的配置文件来实现，具体的操作步骤可以参考它的官方文档。

好了，Fody.Costura的使用方式已经介绍完了。如果你对Fody.Costura的实现原理感到好奇，可以接着往下看。

 

实现原理介绍
当CLR试图加载一个程序集但加载失败时，它会引发AppDomain.AssemblyResolve事件。我们的程序可以监听这个事件，并且在这个事件的处理函数中返回这个CLR试图加载的程序集，从而使程序得以继续正常运行。

Fody.Costura在构建项目时会把EXE引用到的DLL全部嵌入到EXE文件中。当程序在运行的过程中用到其中某个DLL的时候（此时由于CLR无法找到该DLL文件，导致AppDomain.AssemblyResolve事件被触发）再从EXE文件的嵌入资源中提取所需的DLL。

下面这两个函数就是Fody.Costura实现这部分逻辑的代码。

public static void Attach()
{
   var currentDomain = AppDomain.CurrentDomain;
   currentDomain.AssemblyResolve += (s, e) => ResolveAssembly(e.Name);
}
public static Assembly ResolveAssembly(string assemblyName)
{
   if (nullCache.ContainsKey(assemblyName))
   {
      return null;
   }    

   var requestedAssemblyName = new AssemblyName(assemblyName);    

   var assembly = Common.ReadExistingAssembly(requestedAssemblyName);
   if (assembly != null)
   {
      return assembly;
   }    

   Common.Log("Loading assembly '{0}' into the AppDomain", requestedAssemblyName);    

   assembly = Common.ReadFromEmbeddedResources(assemblyNames, symbolNames, requestedAssemblyName);
   if (assembly == null)
   {
      nullCache.Add(assemblyName, true);    

      // Handles retargeted assemblies like PCL
      if (requestedAssemblyName.Flags == AssemblyNameFlags.Retargetable)
      {
         assembly = Assembly.Load(requestedAssemblyName);
      }
   }
   return assembly;
}
 

可以看到，Attach方法监听了AppDomain.AssemblyResolve事件。当CLR无法成功加载某个程序集时， AssemblyResolve事件处理函数会被执行。AssemblyResolve会尝试通过Common.ReadFromEmbeddedResources方法从已加载的程序集的嵌入资源中获取目标程序集，并返回给CLR。

看到这里，你可能会问，Attach方法是在什么时候执行的呢？

其实是这样的，对于C#语言来说，CLR隐藏了一个大招——CLR可以在每个模块（每个程序集都含有一个或多个模块）加载之前执行一些初始化的代码。但是很遗憾，C#语言无法控制这部分代码。Fody.Costura则是在内部将IL代码直接注入到EXE程序集内部模块的初始化函数中，而这部分IL代码其实就是执行了Attach方法。这样一来，EXE程序集被加载后，Attach方法就能够立即得到调用了。

以上就是Fody.Costura实现原理的简单介绍。


