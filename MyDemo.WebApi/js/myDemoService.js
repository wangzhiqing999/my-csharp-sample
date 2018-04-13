"use strict";

var myDemoService = {

    // Access Token.
    _accessToken: "",

    // 保存  Access Token 到 Cookie 中.
    saveAccessTokenToCookie: function () {
        document.cookie = "AccessToken=" + this._accessToken;
    },
    // 从 Cookie 中， 加载 Access Token .
    loadAccessTokenFromCookie: function () {
        if (document.cookie.length > 0) {
            var c_start = document.cookie.indexOf("AccessToken=");
            if (c_start != -1) {
                c_start = c_start + 12;
                var c_end = document.cookie.indexOf(";", c_start)
                if (c_end == -1) {
                    c_end = document.cookie.length;
                }
                this._accessToken = document.cookie.substring(c_start, c_end);
            }
        }
    },


    // 登录.
    login: function (username, password) {
        var _this = this;
        var loginResult = false;
        $.ajax({
            url: '/oauth2/token',
            type: 'POST',
            async: false,
            contentType: 'application/x-www-form-urlencoded',
            data: {
                username: username,
                password: password,
                grant_type: "password"
            },
            success: function (data) {                
                _this._accessToken = data["access_token"];
                _this.saveAccessTokenToCookie();
                loginResult = true;
            }
            }).fail(function (xhr, textStatus, err) {                
            });
        return loginResult;
    },

    // 登出.
    logoff: function() {
        this._accessToken = "";
        this.saveAccessTokenToCookie();
    },

    // 获取  Access Token.
    getAccessToken: function () {
        if (this._accessToken == "") {
            // 如果 Access Token 为空.
            // 尝试从 Cookie 中加载.
            this.loadAccessTokenFromCookie();
        }
        return this._accessToken;
    },

    // 是否已登录.
    isLogin: function() {
        return this.getAccessToken() != "";
    }

};
