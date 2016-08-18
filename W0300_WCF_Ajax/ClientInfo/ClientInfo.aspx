<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientInfo.aspx.cs" Inherits="W0300_WCF_Ajax.ClientInfo.ClientInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

<ul>
  <li>
    Request.UserHostName = <%=Request.UserHostName %>
  </li>

  <li>
    Request.UserHostAddress = <%=Request.UserHostAddress %>
  </li>

  <li>
    Request.UserAgent = <%=Request.UserAgent %>
  </li>

  <li>
    
  </li>

  <li>
    Request.Browser.Browser = <%=Request.Browser.Browser %>
  </li>

  <li>
    Request.Browser.ClrVersion = <%=Request.Browser.ClrVersion %>
  </li>

  <li>
    Request.Browser.Cookies = <%=Request.Browser.Cookies %>
  </li>

  <li>
    Request.Browser.EcmaScriptVersion = <%=Request.Browser.EcmaScriptVersion %>
  </li>

  <li>
    Request.Browser.IsMobileDevice = <%=Request.Browser.IsMobileDevice %>
  </li>

  <li>
    Request.Browser.JavaApplets = <%=Request.Browser.JavaApplets %>
  </li>

    
  <li>
    Request.Browser.JScriptVersion = <%=Request.Browser.JScriptVersion %>
  </li>


  <li>
    Request.Browser.MajorVersion = <%=Request.Browser.MajorVersion %>
  </li>
  
  <li>
    Request.Browser.MinorVersion = <%=Request.Browser.MinorVersion %>
  </li>
    


  <li>
    Request.Browser.MobileDeviceManufacturer = <%=Request.Browser.MobileDeviceManufacturer %>
  </li>
  <li>
    Request.Browser.MobileDeviceModel = <%=Request.Browser.MobileDeviceModel %>
  </li>

  <li>
    Request.Browser.Platform = <%=Request.Browser.Platform %>
  </li>

  
  <li>
    Request.Browser.SupportsCallback = <%=Request.Browser.SupportsCallback %>
  </li>

  <li>
    Request.Browser.SupportsRedirectWithCookie = <%=Request.Browser.SupportsRedirectWithCookie %>
  </li>


  <li>
    Request.Browser.VBScript = <%=Request.Browser.VBScript %>
  </li>


  <li>
        Request.Browser.Win16 = <%=Request.Browser.Win16 %>
  </li>
  <li>
        Request.Browser.Win32 = <%=Request.Browser.Win32 %>
  </li>



</ul>



    </div>
    </form>
</body>
</html>
