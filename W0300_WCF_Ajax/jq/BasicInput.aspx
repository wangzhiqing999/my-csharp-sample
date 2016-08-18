<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicInput.aspx.cs" Inherits="W0300_WCF_Ajax.jq.BasicInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> jQuery  基本 输入控件的 处理机制  </title>
    

    <!--  这个是 基本的 jQuery 的 js.  -->
    <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>



    <!--  这个是 用于提供 placeholder 功能的 js.  -->
    <script src="../Scripts/jquery.placeholder.1.3.min.js" type="text/javascript"></script>



    <script type="text/javascript">


        $(document).ready(function () {


            // placeholder 功能的， 只需要初始化一次即可.
            $.Placeholder.init();


            // -------------------- Text --------------------

            // 测试读取 Text  点击处理事件.
            $("#btnTestReadText").click(function () {

                // 取得用户输入.
                // $("#txtTest")  为获取画面上的 id = txtTest 的对象.
                // val() 为 获取对象上的数据.
                var vText = $("#<%= txtTest.ClientID %>").val();

                var vPlaceholder = $("#<%= txtTest.ClientID %>").attr("placeholder");

                if (vText != vPlaceholder) {
                    alert("Input Text 上输入的信息为：" + vText);
                } else {
                    alert("Input Text 上，用户还没有输入信息！");
                }
            });



            // 测试写入 Text  点击处理事件.
            $("#btnTestWriteText").click(function () {

                // $("#txtTest")  为获取画面上的 id = txtTest 的对象.
                // val( "测试写入数据" ) 为 修改对象上的数据.
                $("#<%= txtTest.ClientID %>").val("测试写入数据");

            });

            // -------------------- Text --------------------







            // -------------------- Checkbox --------------------

            // 注意： 由于 asp:CheckBox 控件无法设置  name 与 value 属性.
            // 因此这里需要使用 CssClass 属性的 find 来进行设置.

            $(".OneCheckbox").find("input").change(function () {

                // 取得用户输入.
                // 注意： 这里是取得 asp:CheckBox 控件 的 Text 属性.
                var vUserSelectVal = $(this).prev().html();

                if ($(this).attr("checked") == "checked") {
                    $("#checkResult").html("用户选择了：" + vUserSelectVal);
                } else {
                    $("#checkResult").html("用户取消了：" + vUserSelectVal);
                }


                // 新追加：
                // 设置 已选择 chkResult 数据部分.
                if ($(this).attr("checked") == "checked") {
                    // 用户选择了.
                    $("#chkResultUl").append("<li code='" + vUserSelectVal + "'>" + vUserSelectVal + "</li>");
                } else {
                    // 用户取消了
                    $("#chkResultUl").children().each(function () {
                        if ($(this).attr("code") == vUserSelectVal) {
                            $(this).remove();
                        }
                    });
                }

            });



            // 强制全部选择.
            $("#chkAll").change(function () {
                if ($(this).attr("checked") == "checked") {
                    $(".OneCheckbox").find("input").each(function (index) {
                        // 设置 checkbox 的选择.
                        $(this).attr("checked", "checked");
                        // 锁定，不允许修改
                        $(this).attr("disabled", "disabled");
                    });
                } else {
                    $(".OneCheckbox").find("input").each(function (index) {
                        // 取消锁定，允许修改
                        $(this).removeAttr("disabled");
                    });
                }
            });



            // 全选  点击处理事件.
            $("#btnTestSelectAllCheckbox").click(function () {
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckbox").find("input").each(function (index) {
                    // 设置 checkbox 的选择.
                    $(this).attr("checked", "checked");
                });
            });


            // 全取消  点击处理事件.
            $("#btnTestSelectNoneCheckbox").click(function () {
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckbox").find("input").each(function (index) {
                    // 取消 checkbox 的选择.
                    $(this).removeAttr("checked");
                });
            });


            // 测试读取 CheckBox 点击处理事件
            $("#btnTestReadCheckBox").click(function () {
                // 用字符串存储选择的项目.
                var vCheckBoxVal = "";
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckbox").find("input").each(function (index) {
                    if ($(this).attr("checked") == "checked") {
                        vCheckBoxVal = vCheckBoxVal + $(this).prev().html() + " ";
                    }
                });
                alert("asp:CheckBox 上输入的信息为：" + vCheckBoxVal);
            });


            // 测试写入 CheckBox 点击处理事件
            $("#btnTestWriteCheckBox").click(function () {
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckbox").find("input").each(function (index) {

                    var vText = $(this).prev().html();

                    if (vText == "A" || vText == "C") {
                        // 设置 checkbox 的选择.
                        $(this).attr("checked", "checked");
                    } else {
                        // 取消 checkbox 的选择.
                        $(this).removeAttr("checked");
                    }

                });

            });



            // -------------------- Checkbox --------------------









            // -------------------- CheckBoxList --------------------

            // 注意： 由于 asp:CheckBoxList 控件无法设置  name 与 value 属性.
            // 因此这里需要使用 CssClass 属性的 find 来进行设置.

            $(".OneCheckBoxList").find("input").change(function () {

                // 取得用户输入.
                // 注意： 这里是取得 asp:CheckBox 控件 的 Text 属性.
                var vUserSelectVal = $(this).val();

                if ($(this).attr("checked") == "checked") {
                    $("#checkBoxListResult").html("用户选择了：" + vUserSelectVal);
                } else {
                    $("#checkBoxListResult").html("用户取消了：" + vUserSelectVal);
                }


                // 新追加：
                // 设置 已选择 chkResult 数据部分.
                if ($(this).attr("checked") == "checked") {
                    // 用户选择了.
                    $("#checkboxListResultUl").append("<li code='" + vUserSelectVal + "'>" + vUserSelectVal + "</li>");
                } else {
                    // 用户取消了
                    $("#checkboxListResultUl").children().each(function () {
                        if ($(this).attr("code") == vUserSelectVal) {
                            $(this).remove();
                        }
                    });
                }

            });




            // 强制全部选择.
            $("#chkAllCheckboxList").change(function () {
                if ($(this).attr("checked") == "checked") {
                    $(".OneCheckBoxList").find("input").each(function (index) {
                        // 设置 checkbox 的选择.
                        $(this).attr("checked", "checked");
                        // 锁定，不允许修改
                        $(this).attr("disabled", "disabled");
                    });
                } else {
                    $(".OneCheckBoxList").find("input").each(function (index) {
                        // 取消锁定，允许修改
                        $(this).removeAttr("disabled");
                    });
                }
            });





            // 全选  点击处理事件.
            $("#btnTestSelectAllCheckboxList").click(function () {
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckBoxList").find("input").each(function (index) {
                    // 设置 checkbox 的选择.
                    $(this).attr("checked", "checked");
                });
            });


            // 全取消  点击处理事件.
            $("#btnTestSelectNoneCheckboxList").click(function () {
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckBoxList").find("input").each(function (index) {
                    // 取消 checkbox 的选择.
                    $(this).removeAttr("checked");
                });
            });





            // 测试读取 CheckBox 点击处理事件
            $("#btnTestReadCheckBoxList").click(function () {
                // 用字符串存储选择的项目.
                var vCheckBoxVal = "";
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckBoxList").find("input").each(function (index) {
                    if ($(this).attr("checked") == "checked") {
                        vCheckBoxVal = vCheckBoxVal + $(this).val() + " ";
                    }
                });
                alert("asp:CheckBoxList 上输入的信息为：" + vCheckBoxVal);
            });


            // 测试写入 CheckBox 点击处理事件
            $("#btnTestWriteCheckBoxList").click(function () {
                // 遍历画面中的 每一个 class  为 OneCheckbox 的元素 的下属的 input 控件.
                $(".OneCheckBoxList").find("input").each(function (index) {

                    var vText = $(this).val();

                    if (vText == "A" || vText == "C") {
                        // 设置 checkbox 的选择.
                        $(this).attr("checked", "checked");
                    } else {
                        // 取消 checkbox 的选择.
                        $(this).removeAttr("checked");
                    }

                });

            });

            // -------------------- CheckBoxList --------------------







            // -------------------- asp:RadioButton --------------------


            $(":radio[name='rdoABCD']").change(function () {
                // 取得用户输入.
                var vUserSelectVal = $(this).val();
                $("#radioResult").html("用户选择了：" + vUserSelectVal);
            });


            // 测试读取 Radio  点击处理事件.
            $("#btnTestReadRadio").click(function () {

                // 取得用户输入.
                var vUserSelectVal = "";

                // 遍历画面中的 每一个 名称为 rdoABCD 的元素.
                $("input[name='rdoABCD']").each(function (index) {
                    if ($(this).attr("checked") == "checked") {
                        // 本 Radio 被选择了.
                        vUserSelectVal = $(this).val();
                    }
                });

                if (vUserSelectVal == "") {
                    alert("Input Radio 上还没有输入信息！");
                } else {
                    alert("Input Radio 上输入的信息为：" + vUserSelectVal);
                }
            });



            // 测试写入 Radio  点击处理事件.
            $("#btnTestWriteRadio").click(function () {

                // 遍历画面中的 每一个 名称为 rdoABCD 的元素.
                $("input[name='rdoABCD']").each(function (index) {

                    var vText = $(this).prev().html();

                    if (vText == "C") {
                        // 如果是 C ， 那么选择.
                        $(this).attr("checked", "checked");
                    } else {
                        // 其他的，取消选择.
                        $(this).removeAttr("checked");
                    }
                });

            });



            // -------------------- asp:RadioButton --------------------






            // -------------------- asp:RadioButtonList --------------------



            $(".OneRadioButtonList").find("input").change(function () {
                // 取得用户输入.
                var vUserSelectVal = $(this).val();
                $("#radioListResult").html("用户选择了：" + vUserSelectVal);
            });


            // 测试读取 Radio  点击处理事件.
            $("#btnTestReadRadioList").click(function () {

                // 取得用户输入.
                var vUserSelectVal = "";

                // 遍历画面中的 每一个 名称为 rdoABCD 的元素.
                $(".OneRadioButtonList").find("input").each(function (index) {
                    if ($(this).attr("checked") == "checked") {
                        // 本 Radio 被选择了.
                        vUserSelectVal = $(this).val();
                    }
                });

                if (vUserSelectVal == "") {
                    alert("Input Radio 上还没有输入信息！");
                } else {
                    alert("Input Radio 上输入的信息为：" + vUserSelectVal);
                }
            });



            // 测试写入 Radio  点击处理事件.
            $("#btnTestWriteRadioList").click(function () {

                // 遍历画面中的 每一个 名称为 rdoABCD 的元素.
                $(".OneRadioButtonList").find("input").each(function (index) {

                    var vText = $(this).val();

                    if (vText == "C") {
                        // 如果是 C ， 那么选择.
                        $(this).attr("checked", "checked");
                    } else {
                        // 其他的，取消选择.
                        $(this).removeAttr("checked");
                    }
                });

            });


            // -------------------- asp:RadioButtonList --------------------









            // -------------------- asp:DropDownList --------------------


            // 测试 Select 选择发生变化处理事件.
            $("#<%=cboABCD.ClientID %>").change(function () {
                // 选择的文本.
                var vSelectText = $(this).find('option:selected').text();

                // 选择的 Value.
                var vSelectValue = $(this).val();

                $("#selectResult").html("Select 选择的文本为：" + vSelectText + " Value为:" + vSelectValue);
            });



            // 测试读取 Select  点击处理事件.
            $("#btnTestReadSelect").click(function () {

                // 选择的文本.
                var vSelectText = $("#<%=cboABCD.ClientID %>").find('option:selected').text();

                // 选择的 Value.
                var vSelectValue = $("#<%=cboABCD.ClientID %>").val();


                alert("Select 选择的文本为：" + vSelectText + " Value为:" + vSelectValue);
            });



            // 测试写入 Select  点击处理事件.
            $("#btnTestWriteSelect").click(function () {

                $("#<%=cboABCD.ClientID %> option").each(function (index) {
                    if ($(this).val() == "C") {
                        // 如果是 C ， 那么选择.
                        $(this).attr("selected", "selected");
                    } else {
                        // 其他的，取消选择.
                        $(this).removeAttr("selected");
                    }
                });

            });


            // 测试清除 Select
            $("#btnTestClearSelect").click(function () {
                $("#<%=cboABCD.ClientID %> option").each(function (index) {
                    $(this).remove();
                });
            });

            // 测试初始化 Select
            $("#btnTestInitSelect").click(function () {
                $("#<%=cboABCD.ClientID %>").append('<option value="W" selected="selected">W1</option>');
                $("#<%=cboABCD.ClientID %>").append('<option value="X">X2</option>');
                $("#<%=cboABCD.ClientID %>").append('<option value="Y">Y3</option>');
                $("#<%=cboABCD.ClientID %>").append('<option value="Z">Z4</option>');
            });


            // -------------------- asp:DropDownList --------------------








            // -------------------- asp:ListBox --------------------


            // 测试读取 Select  点击处理事件.
            $("#btnTestReadSelectMul").click(function () {

                // 选择的文本.
                var vSelectText = $("#<%=lstABCD.ClientID %>").find('option:selected').text();

                // 选择的 Value.
                var vSelectValue = $("#<%=lstABCD.ClientID %>").val();


                alert("Select 选择的文本为：" + vSelectText + " Value为:" + vSelectValue);
            });



            // 测试写入 Select  点击处理事件.
            $("#btnTestWriteSelectMul").click(function () {

                $("#<%=lstABCD.ClientID %> option").each(function (index) {
                    if ($(this).val() == "A" || $(this).val() == "C") {
                        // 如果是 A 或 C ， 那么选择.
                        $(this).attr("selected", "selected");
                    } else {
                        // 其他的，取消选择.
                        $(this).removeAttr("selected");
                    }
                });

            });


            // -------------------- asp:ListBox --------------------
            

        })

    </script>

</head>
<body>

    <form id="form1" runat="server">
    <div>
    

  <h4> asp:TextBox </h4>
  
  <table>
    <tr>
      <td> 
          <asp:TextBox ID="txtTest" runat="server" title="这里输入一个文本信息!" placeholder="这里输入姓名或者昵称！"></asp:TextBox>
      </td>

      <td>
          <input id="btnTestReadText" type="button" value="测试读取 Text " />
      </td>

      <td>
          <input id="btnTestWriteText" type="button" value="测试写入 Text " />
      </td>
    </tr>
  </table>







  <hr />
  <h4> asp:CheckBox </h4>


  <ul id="chkResultUl">

  </ul>


  <table>

    <tr>
      <td> 
          <asp:CheckBox ID="chkA" runat="server"  Text="A" TextAlign="Left" title="选择A" CssClass="OneCheckbox" />
      </td>
      <td> 
          <asp:CheckBox ID="chkB" runat="server"  Text="B" TextAlign="Left" title="选择B" CssClass="OneCheckbox" />
      </td>
      <td> 
          <asp:CheckBox ID="chkC" runat="server"  Text="C" TextAlign="Left" title="选择C" CssClass="OneCheckbox" />
      </td>
      <td> 
          <asp:CheckBox ID="chkD" runat="server"  Text="D" TextAlign="Left" title="选择D" CssClass="OneCheckbox" />
      </td>
    </tr>

	<tr>
	  <td id="checkResult"  colspan="4">	    
	  </td>
	</tr>	
	
    <tr>
      <td colspan="2">
          <input id="btnTestSelectAllCheckbox" type="button" value="全选" />
      </td>

      <td colspan="2">
          <input id="btnTestSelectNoneCheckbox" type="button" value="全取消" />
      </td>
    </tr>

    <tr>
      <td colspan="4">
          强制全部选择 <input id="chkAll" type="checkbox"  title="强制全部选择" />
      </td>
    </tr>

    <tr>
	  <td colspan="2">
	    <input id="btnTestReadCheckBox" type="button" value="测试读取" />
	  </td>


      <td colspan="2">
          <input id="btnTestWriteCheckBox" type="button" value="测试写入 = A,C" />
      </td>
    </tr>


    <tr>
      <td colspan="2">  
          <asp:Button ID="btnReadCheckBox" runat="server" Text="后台获取读取数据" 
              onclick="btnReadCheckBox_Click" />
      </td>
      
      <td colspan="2">
          <asp:Label ID="lblReadCheckBoxResult" runat="server" Text="Label"></asp:Label>
      </td>
    </tr>


  </table>







  <hr />
  <h4> asp:CheckBoxList </h4>


  <ul id="checkboxListResultUl">

  </ul>


  <table>
    
    <tr>
      <td colspan="4"> 
          <asp:CheckBoxList ID="cblTest" runat="server" CssClass="OneCheckBoxList">
              <asp:ListItem Value="A">A1</asp:ListItem>
              <asp:ListItem Value="B">B2</asp:ListItem>
              <asp:ListItem Value="C">C3</asp:ListItem>
              <asp:ListItem Value="D">D4</asp:ListItem>
          </asp:CheckBoxList>
      </td>
    </tr>

	<tr>
	  <td id="checkBoxListResult"  colspan="4">	    
	  </td>
	</tr>	
	
    <tr>
      <td colspan="2">
          <input id="btnTestSelectAllCheckboxList" type="button" value="全选" />
      </td>

      <td colspan="2">
          <input id="btnTestSelectNoneCheckboxList" type="button" value="全取消" />
      </td>
    </tr>

    <tr>
      <td colspan="4">
          强制全部选择 <input id="chkAllCheckboxList" type="checkbox"  title="强制全部选择" />
      </td>
    </tr>

    <tr>
	  <td colspan="2">
	    <input id="btnTestReadCheckBoxList" type="button" value="测试读取" />
	  </td>


      <td colspan="2">
          <input id="btnTestWriteCheckBoxList" type="button" value="测试写入 = A,C" />
      </td>
    </tr>


    <tr>
      <td colspan="2">  
          <asp:Button ID="btnReadCheckBoxList" runat="server" Text="后台获取读取数据" 
              onclick="btnReadCheckBoxList_Click"  />
      </td>
      
      <td colspan="2">
          <asp:Label ID="lblReadCheckBoxListResult" runat="server" Text="Label"></asp:Label>
      </td>
    </tr>


  </table>





  <hr />

  <h4> asp:RadioButton </h4>

  <table>

    <tr>
      <td> <asp:RadioButton ID="rdoA" runat="server" Text="A" TextAlign="Left" ToolTip="选择A" GroupName="rdoABCD"  /> </td>
      <td> <asp:RadioButton ID="rdoB" runat="server" Text="B" TextAlign="Left" ToolTip="选择B" GroupName="rdoABCD"  /> </td>
      <td> <asp:RadioButton ID="rdoC" runat="server" Text="C" TextAlign="Left" ToolTip="选择C" GroupName="rdoABCD"  /> </td>
      <td> <asp:RadioButton ID="rdoD" runat="server" Text="D" TextAlign="Left" ToolTip="选择D" GroupName="rdoABCD"  /> </td>
    </tr>
    
	<tr>
	  <td id="radioResult"  colspan="4">
	    
	  </td>
	</tr>
	
    <tr>
      <td colspan="2">
          <input id="btnTestReadRadio" type="button" value="测试读取 Radio" />
      </td>

      <td colspan="2">
          <input id="btnTestWriteRadio" type="button" value="测试写入 Radio = C" />
      </td>

    </tr>

  </table>









  <hr />

  <h4> asp:RadioButtonList </h4>


    <table>

    <tr>
      <td colspan="4">
        <asp:RadioButtonList ID="rblTestABCD" runat="server" CssClass="OneRadioButtonList">
            <asp:ListItem Value="A">A1</asp:ListItem>
            <asp:ListItem Value="B">B1</asp:ListItem>
            <asp:ListItem Value="C">C1</asp:ListItem>
            <asp:ListItem Value="D">D1</asp:ListItem>
        </asp:RadioButtonList>      
      </td>
    </tr>
    
	<tr>
	  <td id="radioListResult"  colspan="4">
	    
	  </td>
	</tr>
	
    <tr>
      <td colspan="2">
          <input id="btnTestReadRadioList" type="button" value="测试读取 Radio" />
      </td>

      <td colspan="2">
          <input id="btnTestWriteRadioList" type="button" value="测试写入 Radio = C" />
      </td>

    </tr>

  </table>









  <hr />

  <h4> asp:DropDownList </h4>

  
  <table>
    <tr>
      <td>
          <asp:DropDownList ID="cboABCD" runat="server">
              <asp:ListItem Value="A">A1</asp:ListItem>
              <asp:ListItem Value="B">B2</asp:ListItem>
              <asp:ListItem Value="C">C3</asp:ListItem>
              <asp:ListItem Value="D">D4</asp:ListItem>
          </asp:DropDownList>
      </td>

	  <td id="selectResult">
	    
	  </td>
	  
    </tr>
	
	
  
    <tr>
      <td>
        <input id="btnTestReadSelect" type="button" value="测试读取 Select" />
      </td>

      <td>
        <input id="btnTestWriteSelect" type="button" value="测试写入 Select = C" />
      </td>
    </tr>

    <tr>
      <td>
        <input id="btnTestClearSelect" type="button" value="测试清除 Select" />
      </td>

      <td>
        <input id="btnTestInitSelect" type="button" value="测试初始化 Select" />
      </td>
    </tr>

    <tr>
      <td>
          <asp:Button ID="btnTestDropDownListSelectedValue" runat="server" 
              Text="后台获取 SelectValue" onclick="btnTestDropDownListSelectedValue_Click" />
      </td>
      <td>
          <asp:Label ID="lblDropDownListSelectedValue" runat="server" Text="Label"></asp:Label>
      </td>
    </tr>

  </table>








  <hr />

  <h4> asp:ListBox </h4>

  <table>
    <tr>
      <td colspan="2">
          <asp:ListBox ID="lstABCD" runat="server" SelectionMode="Multiple">
              <asp:ListItem Value="A">A1</asp:ListItem>
              <asp:ListItem Value="B">B2</asp:ListItem>
              <asp:ListItem Value="C">C3</asp:ListItem>
              <asp:ListItem Value="D">D4</asp:ListItem>
          </asp:ListBox>
      </td>
    </tr>
  
    <tr>
      <td>
        <input id="btnTestReadSelectMul" type="button" value="测试读取 Select" />
      </td>

      <td>
        <input id="btnTestWriteSelectMul" type="button" value="测试写入 Select = A,C" />
      </td>
    </tr>
  </table>



    </div>
    </form>

</body>
</html>
