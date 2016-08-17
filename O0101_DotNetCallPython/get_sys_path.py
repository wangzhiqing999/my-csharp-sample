#coding=utf-8

# 本例子的作用， 是简单 返回 sys.path。
# 也就是 返回 当前的 可用的  Python 包的路径. 



import sys


# 注意：通过 注释/取消注释  下面这一行， 来观察执行结果。 看看， 是否会修改 sys.path
sys.path.append("C:\\Python27\\Lib")



def get_sys_path():
    return ';'.join(sys.path)
