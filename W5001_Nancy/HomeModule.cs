using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Nancy;


namespace W5001_Nancy
{

    public class HomeModule : NancyModule
    {

        public HomeModule()
        {


            // 测试 根节点,  简单 Hello World.
            Get["/"] = _ =>
            {
                var os = System.Environment.OSVersion;
                return "Hello World <br/>  System:" + os.VersionString + @" <br/> 

<ul>
  <li>
    <a href='/blog/Test123'> /blog/Test123 </a>
  </li>
  <li>
    <a href='/mvc/blog/linezero/123'> /mvc/blog/linezero/123 </a>
  </li>

  <li>
    <a href='/products/list'> /products/list </a>
  </li>



  <li>
    <a href='/SSVE/model'> /SSVE/model </a>
  </li>
  <li>
    <a href='/SSVE/modelplus'> /SSVE/modelplus </a>
  </li>


  <li>
    <a href='/SSVE/each'> /SSVE/each </a>
  </li>

  <li>
    <a href='/SSVE/MasterDetail'> /SSVE/MasterDetail </a>
  </li>


</ul>
";
            };


            // 测试 /blog/* 的路径.
            Get["/blog/{name}"] = r =>
            {
                return "blog name " + r.name;
            };


            // 模仿 mvc 处理.
            Get["/mvc/{controller}/{action}/{id}"] = r =>
            {
                StringBuilder mvc = new StringBuilder();
                mvc.AppendLine("controller :" + r.controller + "<br/>");
                mvc.AppendLine("action :" + r.action + "<br/>");
                mvc.AppendLine("id :" + r.id + "<br/>");
                return mvc.ToString();
            };

        }

    }
}
