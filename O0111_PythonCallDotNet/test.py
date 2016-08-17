# -*- coding: utf-8 -*-
# 第一行的目的，是为了让代码里面，可以有中文注释信息. (否则要运行报错)
# 这个 Python 脚本， 用于调用 C# 的类库.

import clr
clr.AddReferenceByPartialName("System.Windows.Forms")
clr.AddReferenceByPartialName("System.Drawing")
from System.Windows.Forms import *
from System.Drawing import *


# 加载自己编写的 DLL文件
clr.AddReferenceToFile("O0111_PythonCallDotNet.dll")
# 导入命名空间
from O0111_PythonCallDotNet import *


a=12
b=6

# 静态方法可以直接调用
c=TestFunc.Add(a,b)
MessageBox.Show(c.ToString())


# 普通方法需要先定义类，再访问（和访问IronPython 自己本身的类没有任何区别）。
td=TestFunc2()
td.AAA=100
td.ShowAAA()


