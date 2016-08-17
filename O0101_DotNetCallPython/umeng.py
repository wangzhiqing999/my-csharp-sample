#coding=utf-8


# 注意事项： 这里引用到了 Python 的第三方的包。

# 这个测试失败了。

# 引用 第三方的包的操作步骤如下：
# 1. 在 Pythond 那里， 安装好。
# 2. 在 Pythond 那里， 输入 import sys;print sys.path 观察 当前环境的 sys.path 
# 3. 在 py 文件里面，显示使用 sys.path.append， 来指定具体的路径。


# 本测试，是提示 'module' object has no attribute '_getframe'
# 也就是 import requests  已经成功了， 但是在其他操作中， 失败了。


import sys
sys.path.append('C:\\Python27\\Lib')
sys.path.append('C:\\Python27\\lib\\site-packages\\setuptools-6.0.2-py2.7.egg')
sys.path.append('C:\\Python27\\lib\\site-packages\\requests-2.9.1-py2.7.egg')


import time
import hashlib
import requests
import json
import urllib2

def md5(s):
    m = hashlib.md5(s)
    return m.hexdigest()



def push_unicast(appkey, app_master_secret, device_token):
    timestamp = int(time.time() * 1000 )
    method = 'POST'
    url = 'http://msg.umeng.com/api/send'
    params = {'appkey': appkey,
              'timestamp': timestamp,
              'type': 'broadcast',
              'payload': {'body': {'ticker': 'Hello World',
                                   'title':'你好',
                                   'text':'来自友盟推送',
                                   'after_open': 'go_app'},
                          'display_type': 'notification'
              }
    }
    post_body = json.dumps(params)
    print post_body
    sign = md5('%s%s%s%s' % (method,url,post_body,app_master_secret))
    try:
        r = urllib2.urlopen(url + '?sign='+sign, data=post_body)
        return r.read()
    except urllib2.HTTPError,e:
        return e.reason #,e.read()
    except urllib2.URLError,e:
        return e.reason

