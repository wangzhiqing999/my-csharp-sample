"use strict"


// 本 js 单纯的测试使用 Bundle 来打包压缩 js 的处理.
var myTestService = {
    
    // 是否是微信.
    isWeixin : function() {
        var ua = window.navigator.userAgent.toLowerCase();
        if (ua.match(/MicroMessenger/i) == 'micromessenger') {
            return true;
        } else {
            return false;
        }
    },

    // 是否是 IOS 设备.
    isIos : function() {
        var u = navigator.userAgent;
        var isIosResult = !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/); //ios终端
        return isIosResult;
    },

    // 是否是 AppleWebKit. 
    // 这个函数，Windows 10下， Microsoft Edge 浏览器也会返回 true.
    isAppleWebKit : function() {
        var u = navigator.userAgent;
        var isAppleWebKitResult = u.indexOf('AppleWebKit') > -1;
        return isAppleWebKitResult;
    },



    // 是否是 安卓设备.
    isAndroid : function() {
        var u = navigator.userAgent;
        var isAndroidResult = u.indexOf('Android') > -1 || u.indexOf('Linux') > -1;
        return isAndroidResult;
    },

    // 是否是 PC .
    isPC : function() {
        var userAgentInfo = navigator.userAgent;
        var Agents = ["Android", "iPhone",
	    "SymbianOS", "Windows Phone",
	    "iPad", "iPod"];
	
        var flag = true;
	
        for (var v = 0; v < Agents.length; v++) {
            if (userAgentInfo.indexOf(Agents[v]) > 0) {
                flag = false;
                break;
            }
        }
        return flag;
    },








    // 是否是 百度浏览器 App.
    // IOS下 百度浏览器 App 的 userAgent 为 Mozilla/5.0 (iPhone; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Mobile/12F70 baiduboxapp/0_21.0.6.7_enohpi_6311_046/......
    isBaiduApp : function() {
        var u = navigator.userAgent;
        var isBaiduAppResult = u.indexOf('baiduboxapp') > -1;
        return isBaiduAppResult;
    },

    // 是否是 UC浏览器 App.
    // IOS下Safari的 userAgent 为  Mozilla/5.0 (iPhone; CPU iPhone OS 8_3 like Mac OS X; zh-CN) AppleWebKit/537.51.1 (KHTML, like Gecko) Mobile/12F70 UCBrowser/11.0.6.831 Mobile
    isUCApp : function() {
        var u = navigator.userAgent;
        var isUCAppResult = u.indexOf('UCBrowse') > -1;
        return isUCAppResult;
    },


    // 是否是 Safari浏览器 App.
    // 这个函数，Windows 10下， Microsoft Edge 浏览器也会返回 true.
    // IOS下Safari的 userAgent 为  Mozilla/5.0 (iPhone; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12F70 Safari/600.1.4
    // Win10下 Microsoft Edge 的 userAgent 为 Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.10586
    isSafariApp : function() {
        var u = navigator.userAgent;
        var isSafariAppResult = u.indexOf('Safari') > -1;
        return isSafariAppResult;
    },


    // 是否是 QQ App.
    // IOS下QQ的 userAgent 为 Mozilla/5.0 (iPhone; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Mobile/12F70 QQ/6.5.6.427 V1_IPH_SQ_6.5.6_1_APP_A Pixel/640 Core/UIWebView NetType/WIFI Mem/16
    isQQApp : function() {
        var u = navigator.userAgent;
        var isQQAppResult = u.indexOf('QQ') > -1;
        return isQQAppResult;
    },

    // 是否是 Weibo App.
    // IOS下Weibo的 userAgent 为 Mozilla/5.0 (iPhone; CPU iPhone OS 8_3 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Mobile/12F70 Weibo (iPhone5,3__weibo__6.10.0__iphone__os8.3) AliApp(BC/2.1) tae_sdk_ios_2.1 havana
    isWeiboApp: function () {
        var u = navigator.userAgent;
        var isWeiboAppResult = u.indexOf('Weibo') > -1;
        return isWeiboAppResult;
    }



};