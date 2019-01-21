# T4 Text Templates 学习代码.


参考页面：
https://docs.microsoft.com/zh-cn/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2017



# 模板文件说明

### 模板指令
<#@ template debug="false" hostspecific="false" language="C#" #>
意味着不可以调试，不提供host这个属性，使用的是 C# 语言。

### 程序集指令
<#@ assembly name="System.Core" #>
它的作用类似于在 Visual Studio 项目中添加程序集引用。

### 导入指令
<#@ import namespace="System.Linq"#>
它等效于 C# 中的 “using System.Linq;”

### 输出指令
<#@ output extension=".txt" #>
它就是告诉你，T4模板最终将生产.txt对应后缀的文件。


### 控制块
<# 标准控制块 #> 可以包含语句。
<#= 表达式控制块 #> 可以包含表达式。
<#+ 类特征控制块 #> 可以包含方法、字段和属性，就像一个类的内部






# 测试项目

### T4_0001_RunTimeT4_HelloWorld

主要操作：在项目中，添加一个 “运行时文本模板”，默认文件名是 “RuntimeTextTemplate1.tt” 这样的东西。

需要注意的是，添加之后，会创建一个 同名的 .cs 文件，相当于一个类的操作。
因此，这个 “运行时文本模板” 的名字，中间不要有空格与符号什么的字符。



### T4_1001_DesignTimeT4_HelloWorld

主要操作：在项目中，添加一个 “文本模板”，默认文件名是 “TextTemplate1.tt” 这样的东西。

由于这里，是 设计时文本模板， 不会在创建的时候，生成一个同名的类。
因此，不需要额外去 Program.cs 那里写代码运行, 让 模板来生成内容。
在设计环境下， 修改模板，保存后，就自己生成了。



