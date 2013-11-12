using System;
using System.Collections.Generic;
using System.Text;

using Velocity = NVelocity.App.Velocity;
using VelocityContext = NVelocity.VelocityContext;
using Template = NVelocity.Template;
using ParseErrorException = NVelocity.Exception.ParseErrorException;
using ResourceNotFoundException = NVelocity.Exception.ResourceNotFoundException;

namespace B0010_NVelocity.Sample
{
    public class NVelocitySample
    {

        /// <summary>
        /// 属性列表
        /// 用于测试在 输出文件中
        /// 数据是否正确输出.
        /// </summary>
        public virtual List<String> Names
        {
            get
            {
                List<String> list = new List<String>();

                list.Add("北京");
                list.Add("上海");
                list.Add("深圳");
                list.Add("重庆");

                return list;
            }
        }



        public void Process(String templateFile)
        {

            // Velocity 初始化.
            // 从配置文件读取配置信息.
            Velocity.Init("nvelocity.properties");


            // 创建 Velocity Context
            VelocityContext context = new VelocityContext();
            // 将列表的数据， 以 list 作为名称，放入 context.
            context.Put("list", Names);

            // 模版.
            Template template = null;


            // 尝试加载模版文件.
            try
            {
                template = Velocity.GetTemplate(templateFile);
            }
            catch (ResourceNotFoundException)
            {
                System.Console.Out.WriteLine("Example1 : error : cannot find template " + templateFile);
            }
            catch (ParseErrorException pee)
            {
                System.Console.Out.WriteLine("Example1 : Syntax error in template " + templateFile + ":" + pee);
            }

            // 处理模版信息.
            if (template != null)
            {
                template.Merge(context, System.Console.Out);
            }

        }


    }
}
