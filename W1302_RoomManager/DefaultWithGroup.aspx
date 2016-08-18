<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultWithGroup.aspx.cs" Inherits="W1302_RoomManager.DefaultWithGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>  在 服务端 判断， 是不是我这个聊天室的消息  </title>


    <style type="text/css">
        .container {
            background-color: #99CCFF;
            border: thick solid #808080;
            padding: 20px;
            margin: 20px;
        }
    </style>


    <script src="Scripts/jquery-1.6.4.js"></script>
    <script src="Scripts/jquery.signalR-2.2.0.js"></script>


    <script src="signalr/hubs"></script>



    <script type="text/javascript">
        $(function () {


            // Declare a proxy to reference the hub. 
            var chat = $.connection.groupRoomHub;




            // 下面定义了， 服务端 调用 客户端 的方法.
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (name, message) {

                // Html encode display name and message. 
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();

                // Add the message to the page. 
                $('#discussion').append('<li><strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };



            // 提示用户, 输入一个用户名.
            $('#displayname').val(prompt('Enter your name:', ''));
            // 消息输入框获得输入焦点.
            $('#message').focus();





            // 下面定义的是   客户端 调用 服务端的 方法.
            // Start the connection.
            $.connection.hub.start().done(function () {

                // 初始化.
                chat.server.initGroup($('#<%=roomId.ClientID%>').val());


                $('#sendmessage').click(function () {

                    // 调用 hub 里面的 send 方法.
                    chat.server.send( $('#<%=roomId.ClientID%>').val(),  $('#displayname').val(), $('#message').val());


                    // Clear text box and reset focus for next comment. 
                    $('#message').val('').focus();
                });
            });


        });
    </script>



</head>
<body>
    <form id="form1" runat="server">
    
        <asp:HiddenField ID="roomId" runat="server" />

        <div class="container">
            <input type="text" id="message" />
            
            <select id="userList">
                <option value="">全部</option>
            </select>
            
            <input type="button" id="sendmessage" value="Send" />
            <input type="hidden" id="displayname" />

            <ul id="discussion"></ul>
        </div>

    </form>
</body>
</html>
