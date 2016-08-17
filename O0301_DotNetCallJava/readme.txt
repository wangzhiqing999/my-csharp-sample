环境准备。


http://www.ikvm.net/

https://sourceforge.net/projects/ikvm/files/ikvm/


下载 ikvmbin-7.2.4630.5.zip
注：写这个文档的时候， 能下载到的最新版本， 就是这个版本了。

在本例子中， ikvm 被解压缩在 C:\ikvm-7.2.4630.5 目录下。





自行安装 Java SDK。
与 Java 源代码。

在本例子中， JDK 安装在  D:\Program Files\Java\jdk1.7.0_71\bin\
Java 源代码， 在 Java\src 目录下。





操作步骤。

1. 使用 JDK 的 javac，  编译 Java 源代码。   *.java  --> *.class
2. 使用 ikvm 的 ikvmc， 将 *.class ， 转换为  *.dll


3. 创建 C# 项目.  O0301_DotNetCallJava
在 程序包管理器控制台中， 输入
Install-Package IKVM -Version 7.2.4630.5  -ProjectName O0301_DotNetCallJava

注意： 这里的版本， 与环境准备 中的那个  ikvm 版本一致。

4. C# 项目中，添加引用， 浏览， 选择第2步生成的 dll 文件。

5. 在 C# 代码中， 引用 Java 类的处理.
 
 






