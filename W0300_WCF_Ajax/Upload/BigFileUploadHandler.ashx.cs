using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


using Newtonsoft.Json;


using log4net;



namespace W0300_WCF_Ajax.Upload
{

    /// <summary>
    /// 大文件上传.
    /// </summary>
    public class BigFileUploadHandler : IHttpHandler
    {

        /// <summary>
        /// 上传结果.
        /// </summary>
        class UploadResult
        {
            /// <summary>
            /// 文件名.
            /// </summary>
            public string Name { set; get; }

            /// <summary>
            /// 文件总数.
            /// </summary>
            public int Total { set; get; }

            /// <summary>
            /// 文件索引.
            /// </summary>
            public int Index { set; get; }

            /// <summary>
            /// 上传结果.
            /// </summary>
            public int Result { set; get; }
        }


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public void ProcessRequest(HttpContext context)
        {


            // 注意： 这里是为了模拟 上传的时候， 速度慢的效果.
            // 实际使用的时候，请移除下面这一行.
            System.Threading.Thread.Sleep(1000);


            context.Response.ContentType = "application/json";  



            //从Request中取参数，注意上传的文件在Requst.Files中
            string name = context.Request["name"];
            int total = 0;
            int index = 0;
            var data = context.Request.Files["data"];


            if (String.IsNullOrEmpty(name))
            {
                // 无效的 name. 忽略请求.
                return;
            }
            if(!Int32.TryParse(context.Request["total"], out total)){
                // 无效的 total. 忽略请求.
                return;
            }
            if (!Int32.TryParse(context.Request["index"], out index))
            {
                // 无效的 index. 忽略请求.
                return;
            }
            if (data == null)
            {
                // 无效的 data. 忽略请求.
                return;
            }


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("ProcessRequest name = {0}; total={1}; index={2}; data={3}", name, total, index, data);
            }

            
            UploadResult uploadResult = new UploadResult()
            {
                Name = name,
                Total = total,
                Index = index,
                
            };


            try
            {
                //保存一个分片到磁盘上
                string dir = context.Request.MapPath("~/temp");

                // 目录不存在的情况下，先创建.
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                // 存储分片的文件.
                string file = Path.Combine(dir, name + "_" + index);
                data.SaveAs(file);


                //如果已经是最后一个分片，组合
                //当然你也可以用其它方法比如接收每个分片时直接写到最终文件的相应位置上，但要控制好并发防止文件锁冲突
                if (index == total)
                {
                    // 取得结果文件名.
                    file = Path.Combine(dir, name);

                    // 单个文件的字节数组.
                    byte[] bytes = null;

                    // 创建结果文件.
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        // 遍历每一个组成部分.
                        for (int i = 1; i <= total; ++i)
                        {
                            // 组成部分的文件名.
                            string part = Path.Combine(dir, name + "_" + i);

                            // 读取.
                            bytes = System.IO.File.ReadAllBytes(part);
                            // 写入到目标文件.
                            fs.Write(bytes, 0, bytes.Length);

                            // 释放资源.
                            bytes = null;


                            // 视情况需要， 进行删除 分片文件的处理.
                            // System.IO.File.Delete(part);
                            
                        }

                        // 关闭目标文件.
                        fs.Close();
                    }
                }

                // 能执行到这里，认为当前索引成功了.
                uploadResult.Result = 1;    

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                // 当前索引失败了.
                uploadResult.Result = -1;                
            }


            // 返回 Json 结果.
            string jsonResult = JsonConvert.SerializeObject(uploadResult);
            context.Response.Write(jsonResult);
            context.Response.End();

        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


}