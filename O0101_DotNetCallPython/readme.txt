C# 代码， 调用  Python 脚本.


操作步骤

1.创建一个控制台程序. O0101_DotNetCallPython.


2.管理 Nuget 程序包，搜索 IronPython ， 然后安装。

此操作会自动完成下列操作。
已将引用“IronPython”添加到项目“O0101_CallPython”
已将引用“IronPython.Modules”添加到项目“O0101_CallPython”
已将引用“IronPython.SQLite”添加到项目“O0101_CallPython”
已将引用“IronPython.Wpf”添加到项目“O0101_CallPython”
已将引用“Microsoft.Dynamic”添加到项目“O0101_CallPython”
已将引用“Microsoft.Scripting.AspNet”添加到项目“O0101_CallPython”
已将引用“Microsoft.Scripting”添加到项目“O0101_CallPython”
已将引用“Microsoft.Scripting.Metadata”添加到项目“O0101_CallPython”




3.添加Python文件到当前的项目中

创建一个文本文件命名为：hello.py, 编辑如下
def welcome(name):
    return "hello" + name
把该文件添加的当前的项目中。

在 Visual Studio 中，将该文件包含在项目中
复制到输出目录：如果较新则复制
生成操作：无


4. 编写C# 代码， 调用 hello.py 脚本文件中定义的方法 



--------------------------------------------------------------------------------

关于加载 Python 标准模块 的注意事项。

例如，在 py 文件中。
有 
import hashlib

那么， 可能 代码， 在 Python 那里运行， 一点问题没有。
用 C# 的 IronPython 调用的时候， 提示   No module named  hashlib


处理办法。
在 py 文件中，增加下面的代码

import sys
sys.path.append("C:\Python27\Lib")

注： 这里的 C:\Python27\Lib，  是目标机器的 Pythond 安装的目录。





--------------------------------------------------------------------------------

关于加载 Python 第三方模块 的注意事项。

例如，在 py 文件中。
有 
import requests


这种情况下， 首先， 在 Python 那里， 要安装这个  第三方模块。
然后，需要在 Python 那里。 
输入 import sys;print sys.path 观察 当前环境的 sys.path 


然后， 在 py 文件中， 根据上面的 sys.path ， 做相应的修改。
（注：因为是第三方模块， 有时候， 只加 C:\\Python27\\Lib  是不够的。 ）

import sys
sys.path.append('C:\\Python27\\Lib')
sys.path.append('C:\\Python27\\lib\\site-packages\\setuptools-6.0.2-py2.7.egg')
sys.path.append('C:\\Python27\\lib\\site-packages\\requests-2.9.1-py2.7.egg')



