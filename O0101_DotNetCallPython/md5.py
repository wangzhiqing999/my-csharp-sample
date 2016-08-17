#coding=utf-8
# 注意：这里与 hello.py 的区别在于， 这里告诉系统，外部的库， 在哪个目录下。
# 如果没有前面2行，将会提示， No module named  hashlib


import sys
sys.path.append("C:\Python27\Lib")



import hashlib


def md5(s):
    m = hashlib.md5(s)
    return m.hexdigest()
