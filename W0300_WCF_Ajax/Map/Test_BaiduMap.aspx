<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test_BaiduMap.aspx.cs" Inherits="W0300_WCF_Ajax.Map.Test_BaiduMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="content-type" content="text/html; charset=uft-8"/>
    <title> 百度地图测试 </title>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtAddress" runat="server" Text="上海市九江路333号"></asp:TextBox>
        <asp:Button ID="btnQuery" runat="server" Text="Button" 
            onclick="btnQuery_Click" />



<!-- 团购地图的容器 -->
<div id="container" style="position:absolute;border:solid 1px #ccc;"></div>
<!-- 引用团品插件js文件 -->
<script type='text/javascript' src='http://api.map.baidu.com/tuan/v1.0/groupPurchase.js'></script>
<script type='text/javascript'>
    //json对象，存储point信息
    var poiData = [{ lng: <%=lon %>, lat: <%=lat %>, title: "<%= txtAddress.Text %>", tel: "(010)66161527", address: "<%= txtAddress.Text %>" },
];
    //初始化团购控件
    var gp = new BMapGP.GroupPurchase("container", {
        //启用附近公交/地铁路线功能 
        enableRouteInfo: true,
        //启用从这里来/到这里去 公交路线搜索功能 
        enableRouteSearchBox: true,
        //是否启用展开第一个结果 
        selectFirstResult: true,
        //地图类型 JS_MAP为js类型地图，STATIC_MAP为静态图, IFRAME_MAP为嵌入IFRAME类型
        type: JS_MAP,
        //地图缩放级别，如果多点情况，插件会自动缩放级别，将所有点显示在视野内
        zoom: 11,
        //地图大小 
        mapSize: { width: 230, height: 250 },
        pois: poiData
    });
    //设置商家详情的高度，如果不调用此方法，则为自动延伸状态 
    // gp.setRouteInfoHeight(600);
</script>


    </div>
    </form>
</body>
</html>
