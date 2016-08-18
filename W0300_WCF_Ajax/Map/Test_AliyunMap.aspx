<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test_AliyunMap.aspx.cs" Inherits="W0300_WCF_Ajax.Map.Test_AliyunMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 阿里云地图测试 </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtAddress" runat="server" Text="上海市九江路333号"></asp:TextBox>
        <asp:Button ID="btnQuery" runat="server" Text="Button" 
            onclick="btnQuery_Click" />



<script src='http://api.ditu.aliyun.com/map.js' charset='utf-8'></script> 
<script charset='utf-8'>
    var data = {
        "children": [

            {
                "nodeName": "Placemark",
                "Point": { "coordinates": "<%=lon %>,<%=lat %>" },
                "type": "Point",
                "name": "<%= txtAddress.Text %>",
                "description": "<%= txtAddress.Text %>"
            }
        ]
    };

    Jla.require(
        'Ali.Map.Utils.Groupon', 3, null,
        [data,
            {
                div: AliUtils.writeElement('div'),
                mapSize: { x: 200, y: 200 },
                defaultIcon: new AliIcon('|Icon4:blue.png', { x: 31, y: 31 }, { x: 12, y: 31 }),
                labelOffset: { x: -3, y: -26 },
                fieldList: 'Map,ViewLarge,Overview,Basic,BusGuide,QuickRoute'
            }
        ]); 

</script>



    </div>
    </form>
</body>
</html>
