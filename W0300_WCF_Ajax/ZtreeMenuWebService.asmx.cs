using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Runtime.Serialization;


namespace W0300_WCF_Ajax
{
    /// <summary>
    /// ZtreeMenuWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ZtreeMenuWebService : System.Web.Services.WebService
    {


        private const string SESSION_MENU_KEYWORD = "SESSION_MENU_KEYWORD";

        /// <summary>
        /// 获取菜单列表.
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<MenuData> GetMrModuleList()
        {

            // 如果 Session 中已经存在有数据了， 那么直接返回 Session 中的数据.
            if (Session[SESSION_MENU_KEYWORD] != null)
            {
                List<MenuData> oldResultList = Session[SESSION_MENU_KEYWORD] as List<MenuData>;
                return oldResultList;
            }


            // 如果 Session 中没有数据，那么从 加载.
            List<MenuData> resultList = new List<MenuData>()
            {
                new MenuData()
                {
                    MODULE_CODE = "010000",
                    MODULE_NAME = "文件"
                },
                new MenuData()
                {
                    MODULE_CODE = "010100",
                    PARENT_CODE = "010000",
                    MODULE_NAME = "新建"
                },
                new MenuData()
                {
                    MODULE_CODE = "010101",
                    PARENT_CODE = "010100",                    
                    MODULE_NAME = "项目",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010102",
                    PARENT_CODE = "010100",                    
                    MODULE_NAME = "网站",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010103",
                    PARENT_CODE = "010100",                    
                    MODULE_NAME = "团队项目",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010104",
                    PARENT_CODE = "010100",                    
                    MODULE_NAME = "文件",
                    MODULE_EXPAND = "#"
                },
                 new MenuData()
                {
                    MODULE_CODE = "010105",
                    PARENT_CODE = "010100",                    
                    MODULE_NAME = "从现有代码创建项目",
                    MODULE_EXPAND = "#"
                },



                new MenuData()
                {
                    MODULE_CODE = "010200",
                    PARENT_CODE = "010000",
                    MODULE_NAME = "打开"
                },
                new MenuData()
                {
                    MODULE_CODE = "010201",
                    PARENT_CODE = "010200",                    
                    MODULE_NAME = "项目/解决方案",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010202",
                    PARENT_CODE = "010200",                    
                    MODULE_NAME = "网站",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010203",
                    PARENT_CODE = "010200",                    
                    MODULE_NAME = "团队项目",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010204",
                    PARENT_CODE = "010200",                    
                    MODULE_NAME = "文件",
                    MODULE_EXPAND = "#"
                },
                 new MenuData()
                {
                    MODULE_CODE = "010205",
                    PARENT_CODE = "010200",                    
                    MODULE_NAME = "转换",
                    MODULE_EXPAND = "#"
                },



                new MenuData()
                {
                    MODULE_CODE = "010300",
                    PARENT_CODE = "010000",
                    MODULE_NAME = "添加"
                },
                new MenuData()
                {
                    MODULE_CODE = "010301",
                    PARENT_CODE = "010300",                    
                    MODULE_NAME = "新建项目",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010302",
                    PARENT_CODE = "010300",                    
                    MODULE_NAME = "新建网站",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010303",
                    PARENT_CODE = "010300",                    
                    MODULE_NAME = "现有项目",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "010304",
                    PARENT_CODE = "010300",                    
                    MODULE_NAME = "现有网站",
                    MODULE_EXPAND = "#"
                },




                new MenuData()
                {
                    MODULE_CODE = "020000",
                    MODULE_NAME = "编辑"
                },
                new MenuData()
                {
                    MODULE_CODE = "020100",
                    PARENT_CODE = "020000",                    
                    MODULE_NAME = "撤销",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020200",
                    PARENT_CODE = "020000",                    
                    MODULE_NAME = "重做",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020300",
                    PARENT_CODE = "020000",                    
                    MODULE_NAME = "剪切",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020400",
                    PARENT_CODE = "020000",                    
                    MODULE_NAME = "复制",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020500",
                    PARENT_CODE = "020000",                    
                    MODULE_NAME = "粘贴",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020600",
                    PARENT_CODE = "020000",                    
                    MODULE_NAME = "查找和替换",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020601",
                    PARENT_CODE = "020600",                    
                    MODULE_NAME = "快速查找",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020602",
                    PARENT_CODE = "020600",                    
                    MODULE_NAME = "快速替换",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020603",
                    PARENT_CODE = "020600",                    
                    MODULE_NAME = "在文件中查找",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020604",
                    PARENT_CODE = "020600",                    
                    MODULE_NAME = "在文件中替换",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "020605",
                    PARENT_CODE = "020600",                    
                    MODULE_NAME = "查找符号",
                    MODULE_EXPAND = "#"
                },


                new MenuData()
                {
                    MODULE_CODE = "030000",
                    MODULE_NAME = "视图",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "030100",
                    PARENT_CODE = "030000",                    
                    MODULE_NAME = "设计器",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "030200",
                    PARENT_CODE = "030000",                    
                    MODULE_NAME = "标记",
                    MODULE_EXPAND = "#"
                },


            new MenuData()
                {
                    MODULE_CODE = "040000",
                    MODULE_NAME = "项目",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "040100",
                    PARENT_CODE = "040000",                    
                    MODULE_NAME = "添加类",
                    MODULE_EXPAND = "#"
                },
                new MenuData()
                {
                    MODULE_CODE = "040200",
                    PARENT_CODE = "040000",                    
                    MODULE_NAME = "添加引用",
                    MODULE_EXPAND = "#"
                },
            };



            return resultList;

        }



    }






    /// <summary>
    /// 用于存储菜单数据的类.
    /// </summary>
    [DataContract]
    public class MenuData
    {
        /// <summary>
        /// 模块代码.
        /// </summary>
        [DataMember]
        public global::System.String MODULE_CODE { set; get; }


        /// <summary>
        /// 模块父代码.
        /// </summary>
        [DataMember]
        public global::System.String PARENT_CODE { set; get; }



        /// <summary>
        /// 模块名.
        /// </summary>        
        [DataMember]
        public global::System.String MODULE_NAME { set; get; }


        /// <summary>
        /// 模块地址.
        /// </summary>
        [DataMember]
        public global::System.String MODULE_EXPAND { set; get; }





        /// <summary>
        /// 此属性用于 zTree 组件.
        /// </summary>
        [DataMember]
        public string name
        {
            get
            {
                return this.MODULE_NAME;
            }
        }


        /// <summary>
        /// 此属性用于 zTree 组件.
        /// </summary>
        [DataMember]
        public string open
        {
            get
            {
                return "true";
            }
        }

    }


}
